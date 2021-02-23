using MaterialSkin.Controls;
using System;
using Webinar1App.Entities;

namespace Webinar1App.Views
{
    partial class DriverForm : MaterialForm
    {
        public Driver Driver { get; set; }

        public DriverForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            var randomizer = new Random();

            Driver = new Driver
            {
                Id = randomizer.Next(),
                FirstName = firstnameText.Text,
                LastName = lastnameText.Text,
                ExperienceYears = int.Parse(experienceText.Text),
                Car = new Car
                {
                    Id = randomizer.Next(),
                    Make = "Make",
                    Model = "Model",
                    No = "xdddxx"
                }
            };

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
