using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Isps.Vodafone
{
    /// <summary>
    /// Constants used in processing the Meter data for Vodafone.
    /// </summary>
    public static class Constants
    {
        public const string
            LoginPage = "https://the.vodafone.co.nz/acnts/myaccounts.pl/login",
            AccountOverviewPage = "https://the.vodafone.co.nz/acnts/myaccount-acc.pl/overview",
            MatchUsed = @"<span class=""usedValue"">\s*(.+?)\s*</span>",
            MatchTotal = @"<span class=""quotaValue"">\s*(.+?)\s*</span>",
            MatchLastDay = @"<p class=""dataDates"">.+?(-.+?((0[1-9]|[12][0-9]|3[01])[- /.](Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)[- /.](19|20)\d\d)).+?</p>";
    }
}
