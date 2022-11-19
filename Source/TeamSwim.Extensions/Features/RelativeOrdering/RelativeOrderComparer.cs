using System.Collections.Generic;
using System.Linq;

namespace TeamSwim.Features.RelativeOrdering
{
    internal class RelativeOrderComparer : IComparer<RelativeOrderInstruction>
    {
        internal const int Before = -1;
        internal const int After = 1;
        internal const int Inconclusive = 0;
        internal const int DoesntMatter = -1;
        
        /// <inheritdoc />
        public int Compare(RelativeOrderInstruction x, RelativeOrderInstruction y)
        {
            if (ReferenceEquals(x, y)) return Inconclusive;
            if (ReferenceEquals(null, y)) return After;
            if (ReferenceEquals(null, x)) return Before;

            // forced first flag
            if (x.FirstFlagForce && y.FirstFlagForce)
                throw RelativeOrderException.ForceFirstError(x, y).WithSource();

            if (x.FirstFlagForce ^ y.FirstFlagForce)
                return x.FirstFlagForce ? Before : After;

            // forced last flag
            if (x.LastFlagForce && y.LastFlagForce)
                throw RelativeOrderException.ForceLastError(x, y).WithSource();

            if (x.LastFlagForce ^ y.LastFlagForce)
                return x.LastFlagForce ? After : Before;

            // first flag
            if (x.FirstFlag && y.FirstFlag)
                return DoesntMatter;

            if (x.FirstFlag ^ y.FirstFlag)
                return x.FirstFlag ? Before : After;

            // last flag
            if (x.LastFlag && y.LastFlag)
                return DoesntMatter;

            if (x.LastFlag ^ y.LastFlag)
                return x.LastFlag ? After : Before;

            // before instructions
            var xBefore = x.BeforeInstructions.Any(i => i == y.CurrentType);
            var yBefore = y.BeforeInstructions.Any(i => i == x.CurrentType);

            if (xBefore && yBefore)
                throw RelativeOrderException.CircularBefore(x, y).WithSource();

            if (xBefore ^ yBefore)
                return xBefore ? Before : After;

            // after instructions
            var xAfter = x.AfterInstructions.Any(i => i == y.CurrentType);
            var yAfter = y.AfterInstructions.Any(i => i == x.CurrentType);

            if (xAfter && yAfter)
                throw RelativeOrderException.CircularAfter(x, y).WithSource();

            if (xAfter ^ yAfter)
                return xAfter ? After : Before;

            // ordinal
            if (x.Ordinal > y.Ordinal)
                return After;

            if (x.Ordinal < y.Ordinal)
                return Before;

            return DoesntMatter;
        }
    }
}
