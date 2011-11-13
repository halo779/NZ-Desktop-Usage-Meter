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
using NZ_Desktop_Usage_Meter;
using MeterBase;

namespace NZ_Desktop_Usage_Meter.UI
{
    /// <summary>
    /// Interaction logic for ToolTip.xaml
    /// </summary>
    public partial class ToolTip : UserControl
    {
        private MeterObject MO = MainWindow.MeterObje;
        public ToolTip()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Loaded event of the UserControl control changing the view as per the settings provided.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (MO.LastError == "")
            {
                switch (MO.ISP)
                {
                    case ISP.Vodafone:
                        {
                            image1.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Icons/vf512x512trans.png", UriKind.Absolute));
                            defaultgrid.Visibility = System.Windows.Visibility.Collapsed;
                            OffPeak.Visibility = System.Windows.Visibility.Collapsed;
                            NoOffPeak.Visibility = System.Windows.Visibility.Visible;
                            
                            UsedAmmount.Content = MO.Used.ToString() + " GB";
                            RemainingAmmount.Content = MO.Remaining.ToString() + " GB";
                            TotalAmmount.Content = MO.Total.ToString() + " GB";
                            RecomendedAmmount.Content = MO.PerDay.ToString() + " GB";
                            DaysLeftAmmount.Content = MO.DaysLeft.ToString() + " Days";
                            ProgressBar.Value = (double)MO.Percentage;
                            ProgressLabel.Content = MO.Percentage.ToString() + "%";

                            break;
                        }
                    case ISP.Xnet:
                        {
                            if (MO.PPM && MO.ShowUnmetered)
                            {
                                image1PPMWLD.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Icons/xnet-logo.png", UriKind.Absolute));
                                defaultgrid.Visibility = System.Windows.Visibility.Collapsed;
                                OffPeak.Visibility = System.Windows.Visibility.Collapsed;
                                NoOffPeak.Visibility = System.Windows.Visibility.Collapsed;
                                PPM.Visibility = System.Windows.Visibility.Collapsed;
                                PPMWithLocalData.Visibility = System.Windows.Visibility.Visible;

                                UsedAmmountPPMWLD.Content = MO.Used.ToString() + " GB";
                                CostPPMWLD.Content = "$" + MO.Cost.ToString();
                                DaysLeftAmmountPPMWLD.Content = MO.DaysLeft + " Days";
                                UnmeteredDataPPMWLD.Content = MO.UnmeteredData + " GB";
                            }
                            break;
                        }
                    case ISP.Telecom:
                        {
                            image1.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Icons/telecom-logo.png", UriKind.Absolute));
                            defaultgrid.Visibility = System.Windows.Visibility.Collapsed;
                            OffPeak.Visibility = System.Windows.Visibility.Collapsed;
                            NoOffPeak.Visibility = System.Windows.Visibility.Visible;
                            break;
                        }
                    case ISP.None:
                        {
                            defaultgrid.Visibility = System.Windows.Visibility.Visible;
                            OffPeak.Visibility = System.Windows.Visibility.Collapsed;
                            NoOffPeak.Visibility = System.Windows.Visibility.Collapsed;
                            break;
                        }
                }
            }
            else
            {
                defaultgrid.Visibility = System.Windows.Visibility.Visible;
                OffPeak.Visibility = System.Windows.Visibility.Collapsed;
                NoOffPeak.Visibility = System.Windows.Visibility.Collapsed;
                ErrorLabel.Content = MO.LastError;
                MO.LastError = "";
            }
        }
    }
}
