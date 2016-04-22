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

        DBHelper db;

        public CarModel()
        {
            db = new DBHelper();
        }

        public void Add(CarModel car)
        {
            db.OpenConnection();
            db.Insert(car);
            db.CloseConnection();
        }

        public void Modify(CarModel car)
        {
            db.OpenConnection();
            db.Modify(car);
            db.CloseConnection();
        }

        public CarModel Search(Int32 id)
        {
            db.OpenConnection();
            CarModel dummy = db.Search(id);
            db.CloseConnection();

            return dummy;
        }
    }
}
