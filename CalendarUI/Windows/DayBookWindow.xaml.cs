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
    /// Logika interakcji dla klasy DayBookWindow.xaml
    /// </summary>
    public partial class DayBookWindow : Window
    {
        public DayBookWindow()
        {
            InitializeComponent();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            //if (preferenceComboBox.SelectedIndex > -1)
            //{
            //    if (preferenceComboBox.SelectedItem.ToString() == "From Date")
            //    {
            //        try
            // {
            //DateTime.Parse(dayBookContextTextBox.Text);
            //var result = DataConverter.DayBookConverter.getDayBooks(Communication.CommunicateWithApi.getDataFromApi(dayBookContextTextBox.Text));
            //resultTextBox.Text = result;
            //        }
            //        catch (FormatException badParsing)
            //        {
            //            throw badParsing;
            //            MessageBoxResult message = MessageBox.Show(badParsing.ToString(), "Try another one");
            //        }
            //    }
            //    else
            //    {
            var response = DataConverter.DayBookConverter.getAllEvents(Communication.CommunicateWithApi.getAllEvents());
            resultTextBox.Text = response;
            //    }
            //}
            //else
            //{
            //    MessageBoxResult message = MessageBox.Show("Choice an option in combo box!", "Nothing has been chosen");
            //}
            //}
        }
    }
}
