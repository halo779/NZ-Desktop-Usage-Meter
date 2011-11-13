using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MeterBase
{

    /// <summary>
    /// Object for interacting with Meter variables 
    /// </summary>
    public class MeterObject
    {
        #region Varibles
        private static readonly MeterObject MO = new MeterObject();
        private MeterBase Meter = new MeterBase();
        private ISP _ISP;
        #endregion

        #region Getters And Setters
        /// <summary>
        /// Gets or sets the ISP.
        /// </summary>
        /// <value>
        /// The ISP.
        /// </value>
        public ISP ISP
        {
            get { return _ISP; }
            set { _ISP = value; }
        }
        /// <summary>
        /// Gets or sets the used data.
        /// </summary>
        /// <value>
        /// The used data.
        /// </value>
        public decimal Used
        {
            get { return Meter.Used; }
            set { Meter.Used = value; }

        }
        /// <summary>
        /// Gets or sets the total data.
        /// </summary>
        /// <value>
        /// The total data.
        /// </value>
        public decimal Total
        {
            get { return Meter.Total; }
            set { Meter.Total = value; }
        }
        /// <summary>
        /// Gets or sets the remaining data.
        /// </summary>
        /// <value>
        /// The remaining data.
        /// </value>
        public decimal Remaining
        {
            get { return Meter.Remaining; }
            set { Meter.Remaining = value; }
        }
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// Isp username.
        /// </value>
        public string Username
        {
            get { return MeterBase.DecodeFrom64(Meter.Username); }
            set { Meter.Username = MeterBase.EncodeTo64(value); }
        }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// Isp password.
        /// </value>
        public string Password
        {
            get { return MeterBase.DecodeFrom64(Meter.Password); }
            set { Meter.Password = MeterBase.EncodeTo64(value); }
        }
        /// <summary>
        /// Gets or sets the last error.
        /// </summary>
        /// <value>
        /// The last error.
        /// </value>
        public string LastError
        {
            get { return Meter.LastError; }
            set { Meter.LastError = value; }
        }
        /// <summary>
        /// Gets or sets the renew date.
        /// </summary>
        /// <value>
        /// The renew date.
        /// </value>
        public byte RenewDate
        {
            get { return Meter.RenewDate; }
            set { Meter.RenewDate = value; }
        }
        /// <summary>
        /// Gets or sets the days left on the cap.
        /// </summary>
        /// <value>
        /// The days left on the cap.
        /// </value>
        public byte DaysLeft
        {
            get { return Meter.DaysLeft; }
            set { Meter.DaysLeft = value; }
        }
        /// <summary>
        /// Gets or sets the Recommended usage per day.
        /// </summary>
        /// <value>
        /// The recommended usage per day.
        /// </value>
        public decimal PerDay
        {
            get { return Meter.PerDay; }
            set { Meter.PerDay = value; }
        }
        /// <summary>
        /// Gets or sets the percentage of used data.
        /// </summary>
        /// <value>
        /// The percentage of used data.
        /// </value>
        public decimal Percentage
        {
            get { return Meter.Percentage; }
            set { Meter.Percentage = value; }
        }
        /// <summary>
        /// Gets or sets the used unmetered data.
        /// </summary>
        /// <value>
        /// The used unmetered data.
        /// </value>
        public decimal UnmeteredData
        {
            get { return Meter.UnmeteredData; }
            set { Meter.UnmeteredData = value; }
        }
        /// <summary>
        /// Gets or sets the cost of the plan.
        /// </summary>
        /// <value>
        /// The cost of the plan.
        /// </value>
        public decimal Cost
        {
            get { return Meter.Cost; }
            set { Meter.Cost = value; }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="MeterObject"/> is configured.
        /// </summary>
        /// <value>
        ///   <c>true</c> if configured; otherwise, <c>false</c>.
        /// </value>
        public bool Configured
        {
            get { return Meter.Configured; }
            set { Meter.Configured = value; }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="MeterObject"/> is Pay Per Megabyte.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the account is Pay Per Megabyte; otherwise, <c>false</c>.
        /// </value>
        public bool PPM
        {
            get { return Meter.PPM; }
            set { Meter.PPM = value; }
        }
        /// <summary>
        /// Gets or sets a value indicating whether used unmetered data is shown.
        /// </summary>
        /// <value>
        ///   <c>true</c> if unmetered data is set to visible; otherwise, <c>false</c>.
        /// </value>
        public bool ShowUnmetered
        {
            get { return Meter.ShowUnmetered; }
            set { Meter.ShowUnmetered = value; }
        }

        /// <summary>
        /// Gets or sets the Usage Meter update interval.
        /// </summary>
        /// <value>
        /// The usage meter update interval.
        /// </value>
        public int UpdateInterval
        {
            get { return Meter.UpdateInterval; }
            set { Meter.UpdateInterval = value; }
        }
        #endregion
    }
}
