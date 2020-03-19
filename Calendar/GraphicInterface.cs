using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar
{
    class GraphicInterface {
        private EventCalendar calendar = new EventCalendar();
        public void menu() {
            int choice;
            do {
                Console.WriteLine("1.Add event\n2.Remove event\n3.Display events\n4.Clear console\n0.Exit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice) {
                    case 1:
                        calendar.addNewEvent();
                        break;

                    case 2:
                        Console.WriteLine("Write id of event that you want to remove:");
                        calendar.removeEvent(Convert.ToInt32(Console.ReadLine()));
                        break;

                    case 3:
                        Console.WriteLine(calendar.getAllEvents());
                        break;

                    case 4:
                        Console.Clear();
                        break;
                    case 0: break;
                    default:
                        Console.WriteLine("You choose option out of range.");
                        break;
                }
            } while (choice != 0);
        }
    }
}
