using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TeamSwim.Features.RelativeOrdering
{
    [DebuggerDisplay("{CurrentType}")]
    internal class RelativeOrderInstruction
    {
        public Type CurrentType { get; }
        public Type SequenceType { get; }
        public int Ordinal { get; set; } = 0;
        public List<Type> BeforeInstructions { get; set; } = new List<Type>();
        public List<Type> AfterInstructions { get; set; } = new List<Type>();
        public bool FirstFlag { get; set; }
        public bool FirstFlagForce { get; set; }
        public bool LastFlag { get; set; }
        public bool LastFlagForce { get; set; }

        internal RelativeOrderInstruction(Type currentType, Type sequenceType)
        {
            CurrentType = currentType;
            SequenceType = sequenceType;
        } 
    }
}
