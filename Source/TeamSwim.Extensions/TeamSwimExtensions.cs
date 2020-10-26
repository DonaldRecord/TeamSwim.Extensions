using System.Reflection;
using JetBrains.Annotations;

namespace TeamSwim
{
    /// <summary>
    ///     Provides metadata for the TeamSwim Extensions project.
    /// </summary>
    public static class TeamSwimExtensions
    {
        /// <summary>
        ///     Tag for the TeamSwim Extensions Assembly
        /// </summary>
        public static Assembly Assembly { [PublicAPI] get; } = typeof(TeamSwimExtensions).Assembly;

        /// <summary>
        ///     Source of exceptions thrown from the TeamSwim.Extensions library.
        /// </summary>
        public const string ExceptionSource = "TeamSwim.Extensions";
    }
}
