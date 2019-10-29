using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    [Serializable]
    public class Car
    {
        public Int32 Carld;
        public decimal Price;
        public Int32 Quantity;
        public decimal Total;
        public Car() { }
        public Car(int carId, decimal price, int quantity, decimal total)
        {
            Carld = carId;
            Price = price;
            Quantity = quantity;
            Total = total;
        }
    }
}
