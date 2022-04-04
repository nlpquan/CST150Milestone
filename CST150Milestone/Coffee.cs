/**
 * Quan Nguyen
 * CST-150
 * Milestone
 * 4/3/2022
 * This is my own work (with some ideas from StackOverflow)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST150Milestone
{
    internal class Coffee
    {
        // Define the properties
        public bool IsAvailable { get; set; }
        public string Name { get; set; }
        public string FirstLayer { get; set; }
        public string SecondLayer { get; set; }
        public string ThirdLayer { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        /// <summary>
        /// Parameterized Cosntructor
        /// </summary>
        /// <param name="isAvailable"></param>
        /// <param name="name"></param>
        /// <param name="firstLayer"></param>
        /// <param name="secondLayer"></param>
        /// <param name="thirdLayer"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        public Coffee(bool isAvailable, string name, string firstLayer, string secondLayer, string thirdLayer, double price, int quantity)
        {
            IsAvailable = isAvailable;
            Name = name;
            FirstLayer = firstLayer;
            SecondLayer = secondLayer;
            ThirdLayer = thirdLayer;
            Price = price;
            Quantity = quantity;
        }
    }
}
