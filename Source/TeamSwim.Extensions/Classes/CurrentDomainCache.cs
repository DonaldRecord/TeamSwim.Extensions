using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace System.Reflection
{
    /// <summary>
    ///     Provides a read-only cache for <see cref="Type"/> and <see cref="Assembly"/>
    ///     information from <see cref="AppDomain.CurrentDomain"/>.
    /// </summary>
    public static class CurrentDomainCache
    {
        // TODO: Use a WeakReference?

        private static readonly object _lock = new object();
        private static HashSet<Type> _types;
        private static HashSet<Assembly> _assemblies;

        /// <summary>
        ///     All types in <see cref="AppDomain.CurrentDomain"/>, curated from the assemblies.
        /// </summary>
        [PublicAPI]
        [NotNull]
        public static IReadOnlyCollection<Type> Types
        {
            [PublicAPI] get => GetTypesImpl();
        }

        /// <summary>
        ///     All assemblies in <see cref="AppDomain.CurrentDomain"/>.
        /// </summary>
        [PublicAPI]
        [NotNull]
        public static IReadOnlyCollection<Assembly> Assemblies
        {
            [PublicAPI]
            get => GetAssembliesImpl();
        }

        private static HashSet<Type> GetTypesImpl()
        {
            Initialize();
            return _types;

        }

        private static HashSet<Assembly> GetAssembliesImpl()
        {
            Initialize();
            return _assemblies;
        }

        private static void Initialize()
        {
            if (_types == null)
            {
                lock (_lock)
                {
                    if (_types == null)
                    {
                        var tmp = new HashSet<Assembly>();
                        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                        foreach (var assembly in assemblies)
                            tmp.Add(assembly);
                        _assemblies = tmp;

                        _types = new HashSet<Type>();
                        var types = assemblies
                            .SelectMany(a => a.GetLoadableTypes())
                            .Prioritize(t => typeof(Attribute).IsAssignableFrom(t));

                        foreach (var type in types)
                        {
                            if (!_types.Add(type))
                                throw new NotImplementedException();


                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Clear the cache.
        ///     This will force a reload on the next invocation of <see cref="Types"/> or <see cref="Assemblies"/>.
        /// </summary>
        [PublicAPI]
        public static void ClearCache()
        {
            lock (_lock)
            {
                _types = null;
            }
        }
    }
}
