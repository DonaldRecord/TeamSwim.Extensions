using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Classes.Tests
{
    [TestClass]
    public class MustacheTests
    {
        public void AssertGetResult(string value, params string[] expectedGroups)
        {
            var results = Mustache.GetContents(value).ToList();

            Assert.AreEqual(expectedGroups.Length, results.Count);

            for (int i = 0; i < expectedGroups.Length; i++)
            {
                var expected = expectedGroups[i];
                var actual = results[i];
                Assert.AreEqual(expected, actual, $"\"{actual}\" did not match \"{expected}\" at index {i}");
            }
        }

        public void AssertReplaceResult(string value, string expected, params string[] replacements)
        {
            var actual = Mustache.ReplaceContents(value, replacements);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Get_Contents_Returns_Expected_Groups()
        {
            AssertGetResult("Hello {{world}}", "world");
            AssertGetResult("Hello {{ world }}", "world");
            AssertGetResult("Hello {{ wo rld }}", "wo rld");
            AssertGetResult("Hello {{      world     }}", "world");
            AssertGetResult("Hello {{ }}", "");
            AssertGetResult("Hello {{}}", "");
            AssertGetResult("Hello {world}");
            AssertGetResult("{{Hello}} {{world}}", "Hello", "world");
            AssertGetResult("{{ Dude }}", "Dude");
            AssertGetResult("{{Dude}}", "Dude");
            AssertGetResult("{Dude}" /*nothing found*/);
            AssertGetResult("{{Helloworld}}", "Helloworld");
            AssertGetResult("{{ Hello }} {{ world }}", "Hello", "world");

            // not sure
            AssertGetResult("Hello {{ {{ world }} }}", "{{ world");
        }

        [TestMethod]
        public void Replace_Contents_Returns_Expected_Results()
        {
            AssertReplaceResult("a{{ b }}c{{ d }}", "aBcD", "B", "D");
            AssertReplaceResult("a{{b}}c{{d     }}", "aBcD", "B", "D");
        }

        [TestMethod]
        public void Replace_Contents_By_Name_Returns_Expected_Results()
        {
            void AssertValue(string value, string expected, params string[] kvps)
            {
                var dict = new Dictionary<string, string>();
                string idx = null;
                var zag = false;
                foreach (var kvp in kvps)
                {
                    if (!zag)
                    {
                        dict[kvp] = null;
                        idx = kvp;
                    }
                    else
                    {
                        dict[idx] = kvp;
                    }

                    zag = !zag;
                }

                var actual = Mustache.ReplaceContents(value, dict);
                Assert.AreEqual(expected, actual);
            }

            AssertValue("A {{z}} C {{f}} E {{l}} G", "A B C D E F G",
                "z", "B",
                "f", "D",
                "l", "F");

            AssertValue("A {{z}} C {{f}} E {{l}} G", "A {{z}} C D E F G",
                // "z", "B",
                "f", "D",
                "l", "F");

            AssertValue("{{ B }}", "{{ B }}");
        }
    }
}
