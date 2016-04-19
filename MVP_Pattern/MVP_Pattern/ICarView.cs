using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Pattern
{
    interface ICarView
    {
        int OwnerID { get; set; }
        string Model { get; set; }
        string Make { get; set; }
        int YOP { get; set; }
        System.Drawing.Color ColorCode { get; set; }

        event EventHandler Add;
        event EventHandler Open;
        event EventHandler Modify;
    }

    
}
