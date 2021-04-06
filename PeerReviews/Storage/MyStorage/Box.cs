using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace MyStorage {
    /// <summary>
    /// This class describes vagetables.
    /// Box has 3 features:(.)
    /// 1) Name of vagetables.
    /// 2) Weight.
    /// 3) Price for per kilogram.
    /// </summary>
    class Box {

        /// <summary>
        /// This 4 properties describes all features.
        /// Total price counts price for all weight.
        /// </summary>
        public string NameOfProduct { get; private set; }
        public double Weight { get; private set; }
        public double PricePerKilogram { get; private set; }
        public double TotalPrice { get; set; }
        /// <summary>
        /// Constructor for Box class.
        /// Constructor can takes only 3 parameters.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="weight"></param>
        /// <param name="price"></param>

        public Box(string name, double weight, double price) {
            NameOfProduct = name;
            Weight = weight;
            PricePerKilogram = price;
            TotalPrice = PricePerKilogram * Weight;
        }

    }
}
