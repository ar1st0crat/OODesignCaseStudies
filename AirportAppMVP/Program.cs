using AirportAppMVP.Presenter;
using AirportAppMVP.View;
using System;
using System.Windows.Forms;

namespace AirportAppMVP
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

            var view = new FlightsForm();
            var presenter = new FlightsPresenter(view);

            Application.Run(view);
        }
    }
}
