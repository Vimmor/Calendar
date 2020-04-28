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
                else
                {
                    resultTextBox.Text = Communication.CommunicateWithApi.getWeatherForecast(dataTextBox.Text);
                }
            }
        }
    }
}
