using System;
using System.Text;
using System.Text.RegularExpressions;
using WebClient;
using MeterBase;

namespace Isps.Vodafone
{
    /// <summary>
    /// Meter processor to retrieve all the data from the Meter
    /// </summary>
    public class Meter
    {
        /// <summary>
        /// Searches through the Vodafone data meter for the Meter Objet values.
        /// </summary>
        /// <param name="MeterObj">The meter Object currently in use.</param>
        /// <returns>true if Meter Object has been successfully altered; Otherwise false if there is an error</returns>
        public static bool ProcessSite(MeterObject MeterObj)
        {
            try
            {
                CookieAwareWebClient Client = new CookieAwareWebClient();
                string Response = Encoding.ASCII.GetString(Client.UploadData(Constants.LoginPage, "POST", Encoding.ASCII.GetBytes("login=" + MeterObj.Username + "&password=" + MeterBase.MeterBase.DecodeFrom64(MeterObj.Password) + "&cmd=login")));
                if (Response.IndexOf("incorrect") == -1)
                {
                    Response = Client.DownloadString(Constants.AccountOverviewPage);
                    Match m = Regex.Match(Response, Constants.MatchTotal);
                    MeterObj.Total = Math.Round(Convert.ToDecimal(m.Groups[1].Value), 2);

                    m = Regex.Match(Response, Constants.MatchUsed);
                    MeterObj.Used = Math.Round(Convert.ToDecimal(m.Groups[1].Value), 2);

                    m = Regex.Match(Response, Constants.MatchLastDay);

                    try
                    {
                        DateTime Date = DateTime.Parse(m.Groups[2].Value);
                        TimeSpan ts = Date - DateTime.Today;

                        MeterObj.RenewDate = (byte)Date.Day;
                        MeterObj.DaysLeft = (byte)ts.TotalDays;
                        return true;
                    }
                    catch (ArgumentException are)
                    {

                        MeterObj.LastError = "Error occurred while collecting data: " + are.Message;
                        return false;
                    }
                }
                else
                {
                    MeterObj.LastError = "The Username or Password supplied is incorrect or site is currently down!";
                    return false;
                }
            }
            catch (System.Net.WebException e)
            {
                MeterObj.LastError = "Error occurred while collecting data: " + e.Status.ToString();
                return false;
            }

        }

    }
}
