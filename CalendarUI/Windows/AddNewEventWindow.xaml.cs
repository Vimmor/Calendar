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
    public partial class AddNewEventWindow : Window
    {
        public AddNewEventWindow()
        {
            InitializeComponent();
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (confirmCheckBox.IsChecked == true)
            {
                try
                {
                    var date = DateTime.Parse(timeTextBox.Text);
                    var newEvent = new Models.Event() { location = locationTextBox.Text, title = titleTextBox.Text };
                    Communication.CommunicateWithApi.addNewRecord(newEvent, timeTextBox.Text);
                }
                catch (FormatException exept)
                {
                    MessageBoxResult message = MessageBox.Show(exept.ToString(), "Empty field");
                }
            }
        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}

