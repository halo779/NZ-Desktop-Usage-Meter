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
using System.Windows.Shapes;
using MeterBase;

namespace NZ_Desktop_Usage_Meter.UI
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        private MeterObject MO = MainWindow.MeterObje;
        public Settings()
        {
            InitializeComponent();
            IspSelection.ItemsSource = Enum.GetValues(typeof(ISP));
        }

        private void UsernameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            MO.Username = UsernameBox.Text;
        }

        private void passwordBox1_PasswordChanged(object sender, RoutedEventArgs e)
        {
            MO.Password = passwordBox1.Password;
        }

        private void UpdateInterval_ValueChanged(object sender, RoutedEventArgs e)
        {
            MO.UpdateInterval = (int)UpdateInterval.Value;
        }

        private void IspSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MO.ISP = (ISP)Enum.Parse(typeof(ISP), IspSelection.SelectedItem.ToString());
        }

        private void ShowUnmetered_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            MO.ShowUnmetered = ShowUnmetered.IsEnabled;
        }
    }
}
