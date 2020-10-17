﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text;
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
    }
}
