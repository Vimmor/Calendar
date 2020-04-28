using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalendarUI.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void currentDateTimeInformationButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(DateTime.Now.ToString(), "Current DateTime");
        }

        private void addNewEventButton_Click(object sender, RoutedEventArgs e)
        {
            AddNewEventWindow eventWindow = new AddNewEventWindow();
            eventWindow.Show();
            this.Close();
        }

        private void displayWeatherForecastButton_Click(object sender, RoutedEventArgs e)
        {
            var weatherwindow = new WeatherForecastWindow();
            weatherwindow.Show();
            this.Close();
        }

        private void showDayBookButton_Click(object sender, RoutedEventArgs e)
        {
            var dayBookWindow = new DayBookWindow();
            dayBookWindow.Show();
            this.Close();
        }
    }
}
