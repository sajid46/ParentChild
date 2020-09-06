using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantity
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Quantity
            Quantity q1 = new Quantity();
            q1.Value = 6;
            AddOne(q1.Value);

            Console.WriteLine(q1.Value);

            Quantity q2 = q1;
            q2.Value = 5;

            AddOneToQuantity(q1);
            AddOneToQuantity(q2);

            Console.WriteLine(q2.Value);
            Console.WriteLine(q1.Value);

            Console.ReadLine();
            #endregion

            void AddOne(int value)
            {
                value = value + 1;
            }
            void AddOneToQuantity(Quantity quantity)
            {
                quantity.Value = quantity.Value + 1;
            }
        }
    }

    internal class Quantity
    {
        public int Value;
    }
}
