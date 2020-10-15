using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text;

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
        [ExcludeFromCodeCoverage]
        public static Assembly Assembly { get; } = typeof(TeamSwimExtensions).Assembly;
    }
}
