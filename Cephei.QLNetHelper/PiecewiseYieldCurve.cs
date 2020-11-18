using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNet;

namespace Cephei.QLNetHelper
{
    /// <summary>
    /// Helper for non-generic construction of yield curves
    /// </summary>
    public class PiecewiseYieldCurve : QLNet.PiecewiseYieldCurve
    {
        /// <summary>
        /// copied from PeicewiseYieldCurve<_,_,_> with addtion of trait
        /// </summary>
        /// <param name="trait">additional parameter to avoid generics</param>
        /// <param name="referenceDate"></param>
        /// <param name="instruments"></param>
        /// <param name="dayCounter"></param>
        /// <param name="jumps"></param>
        /// <param name="jumpDates"></param>
        /// <param name="accuracy"></param>
        /// <param name="i"></param>
        public PiecewiseYieldCurve
            ( ITraits<YieldTermStructure> trait
            , Date referenceDate, List<RateHelper> instruments,
                                   DayCounter dayCounter, List<Handle<Quote>> jumps, List<Date> jumpDates,
                                   double accuracy, IInterpolationFactory i)
           : base(referenceDate, new Calendar(), dayCounter, jumps, jumpDates)
        {

            _instruments_ = instruments;

            accuracy_ = accuracy;
            interpolator_ = i;
            bootstrap_ = new IterativeBootstrapForYield();
            _traits_ = trait;

            bootstrap_ .setup(this);
        }

    }
}
