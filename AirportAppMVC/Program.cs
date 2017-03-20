using AirportAppMVC.View;
using AirportAppMVC.Controller;
using System;
using System.Windows.Forms;

namespace AirportAppMVC
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FlightsForm(new FlightsController()));
        }
    }
}
