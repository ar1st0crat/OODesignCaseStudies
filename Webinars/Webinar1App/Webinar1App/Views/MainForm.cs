using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Linq;
using System.Windows.Forms;
using Webinar1App.Services;

namespace Webinar1App.Views
{
    public partial class MainForm : MaterialForm
    {
        private readonly IDriverService _driverService = new DriverService();

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Этого не было в видео:
        /// кусок кода взят из README по MaterialSkin - настройка цветовой схемы (зеленая)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Green900, Primary.Green900, Accent.DeepPurple200, TextShade.WHITE);

            FillDriverList();
        }

        private void FillDriverList()
        {
            driversListView.Items.Clear();

            var drivers = _driverService.GetDrivers();

            foreach (var driver in drivers)
            {
                var lvi = new ListViewItem(new[]
                {
                    $"{driver.FirstName} {driver.LastName}",
                    driver.Car.Make,
                    driver.Car.No
                });

                driversListView.Items.Add(lvi);
            }
        }


        private void addDriverButton_Click(object sender, EventArgs e)
        {
            var driverForm = new DriverForm();
            
            if (driverForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var newDriver = driverForm.Driver;

            _driverService.AddDriver(newDriver);

            FillDriverList();
        }

        /// <summary>
        /// Этого не было в видео:
        /// код удаления выделенного в списке элемента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeDriverButton_Click(object sender, EventArgs e)
        {
            if (driversListView.SelectedIndices.Count == 0)
            {
                return;
            }

            var idx = driversListView.SelectedIndices[0];

            var driverId = _driverService.GetDrivers()
                                         .ElementAt(idx)
                                         .Id;

            _driverService.RemoveDriver(driverId);

            FillDriverList();
        }
    }
}
