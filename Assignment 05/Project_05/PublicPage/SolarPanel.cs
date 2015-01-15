using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PublicPage
{
    class SolarPanel
    {
        public string name;
        public string number;
        public double price;
        public bool inCart;

        public SolarPanel()
        {
            // TODO: Complete member initialization
            this.name = "blank";
            this.number = "blank";
            this.price = 0.0D;
            this.inCart = true;
        }

        public SolarPanel(string name, string number, double price, bool inCart)
        {
            // TODO: Complete member initialization
            this.name = name;
            this.number = number;
            this.price = price;
            this.inCart = true;
        }
    }
}
