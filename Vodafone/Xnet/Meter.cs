using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebClient;
using MeterBase;
using System.Xml;

namespace Isps.Xnet
{
    /// <summary>
    /// Meter processor to retrieve all the data from the Meter
    /// </summary>
    public class Meter
    {
        /// <summary>
        /// Processes the usage meter XML feed for Xnet.
        /// </summary>
        /// <param name="MeterObj">The meter Object currently in use.</param>
        /// <returns>true if Meter Object has been successfully altered; Otherwise false if there is an error</returns>
        public static bool ProccessUsageMeter(MeterObject MeterObj)
        {
            CookieAwareWebClient Client = new CookieAwareWebClient();
            string Xml = Encoding.ASCII.GetString(Client.DownloadData(Constants.APIURL + "?username=" + MeterObj.Username + ";token=" + Functions.ApiToken(MeterBase.MeterBase.DecodeFrom64(MeterObj.Password))));
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(Xml);
            MeterObj.LastError = Functions.ReadXmlValue(xdoc, "errstr");
            if (MeterObj.LastError == "")
            {
                MeterObj.Used = Math.Round(Convert.ToDecimal(Functions.ReadXmlValue(xdoc, "total")) / 1024, 2);
                MeterObj.PPM = Convert.ToBoolean(Functions.ReadXmlValue(xdoc, "ppm"));
                if (!MeterObj.PPM)
                {
                    MeterObj.Total = Math.Round(Convert.ToDecimal(Functions.ReadXmlValue(xdoc, "cap")) / 1024, 2);
                }
                else
                {
                    MeterObj.Total = 0.00M;
                }
                MeterObj.UnmeteredData = Math.Round((Convert.ToDecimal(Functions.ReadXmlValue(xdoc, "rxlocal")) + (Convert.ToDecimal(Functions.ReadXmlValue(xdoc, "txlocal")))) / 1024, 2);
                MeterObj.Cost = Math.Round(Convert.ToDecimal(Functions.ReadXmlValue(xdoc, "bpc")), 2);
                DateTime today = DateTime.Today;
                DateTime lastday = new DateTime(today.Year, today.Month, 1).AddMonths(1).AddDays(-1);
                TimeSpan ts = lastday - DateTime.Today;
                MeterObj.RenewDate = (byte)lastday.Day;
                MeterObj.DaysLeft = (byte)ts.TotalDays;
                return true;
            }
            else
            {
                return false;
            }
            //TODO: Correct bool Statements
        }
        
    }
}
