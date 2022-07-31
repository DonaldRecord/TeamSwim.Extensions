using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using TeamSwim;

namespace System.Text
{
    /// <summary>
    ///     Facade for dealing with mustache formatted substrings (E.G. "{{ content }}").
    /// </summary>
    public abstract class Mustache
    {
        /// <summary>
        ///     Get all substrings that are decorated with mustache formatters.
        /// </summary>
        /// <param name="value">String value to seek.</param>
        /// <returns></returns>
        [PublicAPI]
        [Pure, NotNull, ItemNotNull, LinqTunnel]
        public static IEnumerable<string> GetContents(string value) => GetTokens(value).Select(t => t.Content);

        /// <summary>
        ///     Replace all substrings that are decorated with mustache formatters.
        /// </summary>
        /// <param name="value">String value to seek</param>
        /// <param name="replacements">Replacements for mustache-formatted substrings (order specific).</param>
        /// <returns></returns>
        [PublicAPI]
        [Pure, NotNull]
        public static string ReplaceContents(string value, params string[] replacements) => ReplaceContentsByIndex(value, true, replacements);

        /// <summary>
        ///     Replace all substrings by name.
        /// </summary>
        /// <param name="value">String value to seek</param>
        /// <param name="replacements">Names/values to substitute for mustache-formatted substrings (not order specific).</param>
        /// <returns></returns>
        [PublicAPI]
        [Pure, NotNull]
        public static string ReplaceContents(string value, IDictionary<string, string> replacements) => ReplaceContentsByName(value, replacements);

        readonly struct MustacheStringToken
        {
            public int Index { get; }
            public int StartBraceIndex { get; }
            private int StartContextIndex { get; }
            public int EndBraceIndex { get; }
            private int EndContextIndex { get; }
            public string Content { get; }
            public string Body { get; }

            public MustacheStringToken(
                string body,
                int index,
                string content,
                int startBraceIndex,
                int startContextIndex,
                int endBraceIndex,
                int endContextIndex)
            {
                Body = body;
                Index = index;
                Content = content;
                StartBraceIndex = startBraceIndex;
                StartContextIndex = startContextIndex;
                EndBraceIndex = endBraceIndex;
                EndContextIndex = endContextIndex;
            }
        }

        private static IEnumerable<MustacheStringToken> GetTokens(string value)
        {
            var inBraces = false;
            var sb = new StringBuilder();
            var startIndex = 0;
            var tokenIndex = 0;

            for (var i = 0; i < value.Length; i++)
            {
                var c = value[i];

                // skip the first
                if (i == 0)
                    continue;

                var target = String.Concat(value[i - 1], c);

                // starting a new token
                if (!inBraces && target == "{{")
                {
                    inBraces = true;
                    startIndex = i;
                    continue;
                }

                if (inBraces)
                {
                    // append content to result
                    if (target != "}}")
                    {
                        sb.Append(c);
                    }
                    // end current token
                    else
                    {
                        inBraces = false;
                        var content = sb.ToString();
                        content = content.Substring(0, content.Length - 1);
                        var body = value.Substring(startIndex - 1, content.Length + 4); // 4 is for "{{" and "}}"
                        var trimmedContent = content.TrimStart();
                        var startWhiteSpaceCount = content.Length - trimmedContent.Length;
                        trimmedContent = content.TrimEnd();
                        var endWhiteSpaceCount = content.Length - trimmedContent.Length;
                        var startBraceIndex = startIndex - 1;
                        var startContentIndex = startIndex + 1 + startWhiteSpaceCount;
                        var endContentIndex = i - endWhiteSpaceCount - 1;
                        var token = new MustacheStringToken(body, tokenIndex++, content.Trim(), startBraceIndex, startContentIndex, i, endContentIndex);
                        yield return token;
                        sb.Clear();
                    }
                }
            }
        }

        private static string ReplaceContentsByIndex(
            string value,
            bool ignoreExtraReplacements,
            params string[] replacements)
        {
            var tokens = GetTokens(value).ToList();

            if (tokens.Count > replacements.Length)
                throw Exceptions.InvalidOperation("Not enough replacements were passed to account for all tokens.");

            if (tokens.Count != replacements.Length && !ignoreExtraReplacements)
                throw Exceptions.InvalidOperation(
                    "Too many replacement tokens were received. Pass the correct amount or choose to ignore.");

            var sb = new StringBuilder();
            var i = 0;
            var consumedTokens = new List<MustacheStringToken>();

            while (i < value.Length)
            {
                var tokenIdx = tokens.FindIndex(t => t.StartBraceIndex <= i && t.EndBraceIndex >= i);
                if (tokenIdx == -1)
                {
                    sb.Append(value[i]);
                    i++;
                    continue;
                }

                var token = tokens[tokenIdx];
                if (consumedTokens.Contains(token))
                {
                    i++;
                    continue;
                }

                var replacement = replacements[token.Index];
                consumedTokens.Add(token);
                sb.Append(replacement);
                i++;
            }

            var result = sb.ToString();
            return result;
        }

        private static string ReplaceContentsByName(
            string value,
            IDictionary<string, string> replacements)
        {
            var tokens = GetTokens(value).ToList();
            var indexes = new List<string>(tokens.Count);
            var i = 0;

            foreach (var token in tokens)
            {
                //var replacement = replacements[token.Content];
                if (replacements.TryGetValue(token.Content, out var replacement))
                {
                    indexes.Add(replacement);
                }
                else
                {
                    indexes.Add(token.Body);
                }

                i++;
            }

            var result = ReplaceContentsByIndex(value, false, indexes.ToArray());
            return result;
        }
    }
}
