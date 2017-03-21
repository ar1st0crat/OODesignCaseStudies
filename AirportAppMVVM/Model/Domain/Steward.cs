namespace AirportAppMVVM.Model.Domain
{
    class Steward : Employee
    {
        // пример делегирования конструктора
        public Steward() : this("Unknown")
        {
        }

        // пример вызова родительского конструктора
        public Steward(string name) : base(name)
        {
        }

        // переопределение виртуального метода - через override
        public override double CalculateSalary()
        {
            return 2000.0;
        }
    }
}