using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CalendarUI.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy WeatherForecastWindow.xaml
    /// </summary>
    public partial class WeatherForecastWindow : Window
    {
        public WeatherForecastWindow()
        {
            InitializeComponent();
        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void acceptWeatherButton_Click(object sender, RoutedEventArgs e)
        {
            if (ConfirmWeatherCheckBox.IsChecked == true)
            {
                if (choiceComboBox.SelectedItem == city)
                {
                    if (dataTextBox.Text.Contains("/"))
                    {
                        MessageBoxResult message = MessageBox.Show("You choose City, then give a city name!", "Nothing has been chosen");
                    }
                    else
                    {
                        resultTextBox.Text = Communication.CommunicateWithApi.getWeatherForecast(dataTextBox.Text);
                    }
                }
                if (choiceComboBox.SelectedItem == cityId) {
                    try
                    {
                        var id = int.Parse(dataTextBox.Text);
                        resultTextBox.Text = Communication.CommunicateWithApi.getWeatherByCityId(dataTextBox.Text);
                    }
                    catch (Exception except)
                    {
                        MessageBoxResult message = MessageBox.Show("You choose by City ID, then give a city id!", "Nothing has been chosen");
                    }
                }
               if (choiceComboBox.SelectedItem == zipcode) {
                   if (dataTextBox.Text.Contains("/")) {
                        resultTextBox.Text = Communication.CommunicateWithApi.getWeatherForecast(dataTextBox.Text);
                   }
                   else {
                        MessageBoxResult message = MessageBox.Show("You choose by Zip Code and country code, then give zip code and country code!", "Nothing has been chosen");
                    }
               }
            }
        }
    }
}
