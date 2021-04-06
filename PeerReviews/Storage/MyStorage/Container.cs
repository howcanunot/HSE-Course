using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyStorage {
    /// <summary>
    /// Class Container stores boxes of vegetables.
    /// Container has 3 features:(.)
    /// 1) Capacity.
    /// 2) List of boxes.
    /// 3) Percent of damage.
    /// 4) Current weight.
    /// 5) Total Price.
    /// 6) Container id.
    /// </summary>
    class Container {

        // Random example.
        static Random rand = new Random();
        /// <summary>
        /// Describe all properties for class.
        /// CurrentWeight shows fullness of Container.
        /// It's can't be more than Capacity.
        /// </summary>
        public List<Box> ListOfBoxes { get; private set; }
        public double Capacity { get; private set; }
        public double PercentOfDamage { get; private set; }
        public double CurrentWeight { get; private set; }
        public double TotalPrice { get; private set; }
        public int Id { get; private set; }
        /// <summary>
        /// Constructor init all properties.
        /// This constructor is not required, because all properties can init without constructor.
        /// </summary>
        public Container(int id) {
            ListOfBoxes = new List<Box>();
            PercentOfDamage = rand.NextDouble() * 0.5;
            Capacity = rand.Next(50, 1001);
            CurrentWeight = 0;
            TotalPrice = 0;
            Id = id;
        }

        /// <summary>
        /// Method adds new box in container.
        /// If CurrentWeight + weight of box less than capacity.
        /// New box adds in container.
        /// Else Method returns false.
        /// </summary>
        /// <param name="boxOfVagetable"></param>
        /// <returns>True - if CurrentWeight less than Capacity. Else false.</returns>
        public bool AddBox(Box boxOfVagetable) {
            if (CurrentWeight + boxOfVagetable.Weight <= Capacity) {
                CurrentWeight += boxOfVagetable.Weight;
                ListOfBoxes.Add(boxOfVagetable);
                TotalPrice += boxOfVagetable.TotalPrice * (1 - PercentOfDamage);
                return true;
            }
            return false;
        }
    }
}
