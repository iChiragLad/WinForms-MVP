using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MVP_Pattern
{
    class CarPresenter
    {
        ICarView view;
        CarModel car;
        public CarPresenter(ICarView view)
        {
            this.view = view;
            car = new CarModel();
            InitializePresenter();
        }

        private void InitializePresenter()
        {
            view.Add += View_Add;
            view.Open += View_Open;
            view.Modify += View_Modify;
        }

        private void View_Modify(object sender, EventArgs e)
        {
            car.cars.Remove(SearchCar(view.OwnerID));

            CarModel dum = new CarModel();
            this.FillCarDataFromView(ref dum);
            car.cars.Add(dum);
        }

        private void View_Open(object sender, EventArgs e)
        {
            int SearchableItem = view.OwnerID;
            CarModel result = this.SearchCar(SearchableItem);
            view.OwnerID = result.OwnerID;
            view.Model = result.Model;
            view.Make = result.Make;
            view.YOP = result.YOP;
            view.ColorCode = result.ColorCode;
        }

        private void View_Add(object sender, EventArgs e)
        {
            CarModel dum = new CarModel();
            this.FillCarDataFromView(ref dum);
            car.cars.Add(dum);
        }

        private CarModel SearchCar(int id)
        {
            return (car.cars.Find(delegate (CarModel c) { return (c.OwnerID == id); }));
        }

        private void FillCarDataFromView(ref CarModel dum)
        {
            dum.OwnerID = view.OwnerID;
            dum.Model = view.Model;
            dum.Make = view.Make;
            dum.YOP = view.YOP;
            dum.ColorCode = view.ColorCode;
        }
    }
}
