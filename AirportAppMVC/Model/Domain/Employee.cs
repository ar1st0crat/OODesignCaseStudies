namespace AirportAppMVC.Model.Domain
{
    class Employee
    {
        public string Lastname { get; set; }

        public Employee()
        {
        }

        public Employee(string lastname)
        {
            Lastname = lastname;
        }

        // хотя, скорее всего, этому методу место не здесь, а в специальном классе
        // SalaryCalculator (паттерн "Стратегия")

        public virtual double CalculateSalary()
        {
            return 0.0;
        }

        // финализатор - вызывается при уничтожении объекта сборщиком мусора
        // public ~Employee() 
        // { 
        // }
    }
}
