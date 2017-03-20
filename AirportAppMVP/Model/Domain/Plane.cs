using System.Drawing;

namespace AirportAppMVP.Model.Domain
{
    class Plane
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
