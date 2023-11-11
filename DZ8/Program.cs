using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ8
{
    using System;

    class SquaringArray
    {
        private int[] array;

        public SquaringArray(int length)
        {
            array = new int[length];
        }

        public int this[int index]
        {
            get => array[index];
            set => array[index] = value * value;
        }
    }

    class Program
    {
        static void Main()
        {
            var myArray = new SquaringArray(5);
            myArray[0] = 2; // Значение будет установлено как 2 * 2 = 4
            Console.WriteLine(myArray[0]); // Выведет 4
        }
    }

}
