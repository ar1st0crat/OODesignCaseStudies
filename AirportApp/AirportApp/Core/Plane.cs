using System.Drawing;

namespace AirportApp.Core
{
    class Plane : IDrawable
    {
        public string Name { get; set; }
        public short ProductionYear { get; set; }

        // схему самолета можно нарисовать

        public void Draw(Graphics g)
        {
            //;
        }
    }
}
