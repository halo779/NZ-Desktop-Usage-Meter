using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;
using MeterBase;
using NZ_Desktop_Usage_Meter.UI;

namespace NZ_Desktop_Usage_Meter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MeterObject Meter = new MeterObject();
        private Timer Timer = new Timer();
        public MainWindow()
        {
            InitializeComponent();
            Timer.Elapsed += new ElapsedEventHandler(Timer_Elapsed);
            Timer.Interval = (int)TimeSpan.FromMinutes(Meter.UpdateInterval).TotalMilliseconds;
            Timer.Start();

            Timer DelayCheck = new Timer(TimeSpan.FromSeconds(0.5).TotalMilliseconds);
            DelayCheck.Elapsed += new ElapsedEventHandler(DelayCheck_Elapsed);
            DelayCheck.Start();
        }

        /// <summary>
        /// Handles the Elapsed event of the DelayCheck control, delaying the start-up Usage check.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Timers.ElapsedEventArgs"/> instance containing the event data.</param>
        void DelayCheck_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Meter.Configured)
            {
                RunChecks.CheckUsage(Meter);
            }
        }
        /// <summary>
        /// Gets or sets the Meter Object.
        /// </summary>
        /// <value>
        /// The meter Meter Object.
        /// </value>
        /// <returns>The Meter Object.</returns>
        public static MeterObject MeterObje
        {
            get { return Meter; }
            set { value = Meter; }
        }

        /// <summary>
        /// Handles the Elapsed event of the Timer control for the Interval between Data Usage checks.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Timers.ElapsedEventArgs"/> instance containing the event data.</param>
        void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                Timer.Stop();
                RunChecks.CheckUsage(Meter);
            }
            finally
            {
                Timer.Start();
            }
        }
    }
}
