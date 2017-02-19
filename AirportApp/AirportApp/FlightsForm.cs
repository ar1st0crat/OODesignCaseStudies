using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AirportApp.Core;
using AirportApp.Utils;

namespace AirportApp
{
    public partial class FlightsForm : Form
    {
        // здесь можем легко подменять создаваемый объект, и вся логика приложения будет меняться
        private readonly IRepository<Flight> _repository = new MockFlightRepository();

        public FlightsForm()
        {
            InitializeComponent();
        }

        // делегат - аналог указателя на функцию (точнее - функтора)
        delegate void ShowFunc(string message);

        // эта функция подходит для присоединения делегату ShowFunc по сигнатуре
        public void ShowBrief(string message)
        {
            MessageBox.Show(message);
        }

        // и эта функция подходит для присоединения делегату ShowFunc по сигнатуре
        public void ShowDetails(string message)
        {
            MessageBox.Show(message + "\n\n(c) DonNU");
        }
        

        private void buttonLoadFlights_Click(object sender, EventArgs e)
        {
            var flights = _repository.Load();

            dataGridFlights.Rows.Clear();
            dataGridFlights.ColumnCount = 2;
            dataGridFlights.RowCount = flights.Count;

            for (int i = 0; i < flights.Count; i++)
            {
                dataGridFlights.Rows[i].Cells[0].Value = flights[i].Code;
                dataGridFlights.Rows[i].Cells[1].Value = flights[i].DepartureCity;
            }
        }

        private void buttonDelegatesDemo_Click(object sender, EventArgs e)
        {
            var funcs = new List<ShowFunc> {ShowBrief, ShowDetails};
            
            // ShowFunc func = ShowBrief;
            // это аналог указателя на функцию в С++:
            // void (*fn)(string) = ShowBrief;

            ShowFunc coolFunc = (param => MessageBox.Show("COOOOOOL! " + param));
            funcs.Add(coolFunc);

            foreach (var f in funcs)
            {
                f("Hey!");
            }
        }

        private void buttonLINQDemo_Click(object sender, EventArgs e)
        {
            var flights = _repository.LoadByDepartureCity("Donetsk");

            dataGridFlights.Rows.Clear();
            dataGridFlights.ColumnCount = 2;
            dataGridFlights.RowCount = flights.Count;

            for (int i = 0; i < flights.Count; i++)
            {
                dataGridFlights.Rows[i].Cells[0].Value = flights[i].Code;
                dataGridFlights.Rows[i].Cells[1].Value = flights[i].DepartureCity;
            }
        }

        // здесь на лекции демонстрировали некоторые фишки C#
        private void FlightsForm_Load(object sender, EventArgs e)
        {
            // удобная инициализация
            var flight = new Flight {Code = "Y43N", DepartureCity = "Donetsk", DepartureTime = DateTime.Now};

            // демонстрация полиморфизма
            Employee steward = new Steward();
            var salary = steward.CalculateSalary();

            // демонстрация динамических кастов
            Pilot p = steward as Pilot;
            if (p != null)
            {
                // в данном случае сюда не попадем, т.к. p - не Pilot
            }

            if (steward is Steward)
            {
                // сюда попадем
            }

            // пример Nullable
            int? number = null;
            //number = 35;

            if (number.HasValue)        // если не null
            {
                // сюда попадем
            }

            // синтаксический сахар для: 
            // Nullable<int> number = null;


            // демонстрация упаковки-распаковки (boxing-unboxing)
            object o = new object();
            int x = 40;

            o = x;  //boxing

            int y = (int)o;     // unboxing

            // value-type           struct, int, double,
            // reference-type  
            
            // демо перехвата исключения
            try
            {
                var name = "".Cleanse();
                MessageBox.Show(name);
            }
            catch (ArgumentException aex)
            {
                // ... close and clean resources
                //throw;
            }
            finally
            {
                // ...
            }

            //
            // конструкция using
            //

            //using (FileStream fs = new FileStream("a.txt", FileMode.Open))
            //{
            //}

            // => аналогично:

            //FileStream fs;
            //try
            //{
            //    fs = new FileStream();
            //    // ...
            //}
            //finally
            //{
            //    if (fs != null)
            //        fs.Close();
            //}

            // пример кортежа (Tuple)
            var tuple = new Tuple<int, string>(1, "OK");

            // например, если хотим вернуть из функции два результата
            // (аналог кортежа в Python)

            var info = tuple.Item1 + tuple.Item2;
        }
    }
}
