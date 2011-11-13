using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MeterBase;
using Isps;

namespace NZ_Desktop_Usage_Meter
{
    /// <summary>
    /// Class Containing all Checks to be used by the Desktop Meter
    /// </summary>
    class RunChecks
    {
        /// <summary>
        /// Checks the data usage using the function defined for that ISP in Isps.dll.
        /// </summary>
        /// <param name="Meter">The meter Object to be passed on.</param>
        public static void CheckUsage(MeterObject Meter)
        {
            switch (Meter.ISP)
            {
                case ISP.Vodafone:
                    {
                        bool status = Isps.Vodafone.Meter.ProcessSite(Meter);
                        Meter.Remaining = Meter.Total - Meter.Used;
                        Meter.Percentage = Math.Round((Meter.Used / Meter.Total) * 100, 2);
                        Meter.PerDay = Math.Round(Meter.Remaining / Meter.DaysLeft, 2);
                        break;
                    }
                case ISP.Xnet:
                    {
                        bool status = Isps.Xnet.Meter.ProccessUsageMeter(Meter);
                        if (!Meter.PPM)
                        {
                            Meter.Remaining = Meter.Total - Meter.Used;
                            Meter.Percentage = Math.Round((Meter.Used / Meter.Total) * 100, 2);
                            Meter.PerDay = Math.Round(Meter.Remaining / Meter.DaysLeft, 2);
                        }
                        if (Meter.UnmeteredData > 0)
                        {
                            Meter.ShowUnmetered = true;
                        }
                        break;
                    }
            }
        }
    }
}
