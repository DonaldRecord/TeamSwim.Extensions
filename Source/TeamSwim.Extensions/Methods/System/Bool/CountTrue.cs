using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    partial class BooleanExt
    {
        /// <summary>
        ///     
        /// </summary>
        /// <param name="numberTrue"></param>
        /// <param name="evaluations"></param>
        /// <returns></returns>
        public static bool CountTrue(int numberTrue, params bool[] evaluations)
        {
            if (numberTrue <= 0) throw new ArgumentException($"{nameof(numberTrue)} must be 1 or greater.");
            var i = evaluations.Count(result => result);
            return numberTrue == i;
        }
    }
}
