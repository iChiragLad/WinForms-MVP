using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Pattern
{
    class CarModel
    {
        public int OwnerID { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public int YOP { get; set; }
        public System.Drawing.Color ColorCode { get; set; }
        public List<CarModel> cars;

        public CarModel()
        {
            cars = new List<CarModel>();
        }
    }
}
