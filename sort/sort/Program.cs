using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workout
{
    internal class Program
    {
        static void Main(string[] args)
        {
            task2 myArray = new task2(10);
            myArray.fillRandom();
            Console.WriteLine("Исходный массив:");
            myArray.PrintArray();

            myArray.sort();
            Console.WriteLine("Отсортированный массив:");
            myArray.PrintArray();

            Console.ReadLine();
        }
    }

    public class task2
    {
        public int[] array;
        public int count;

        public task2(int count1)
        {
            this.count = count1;
            this.array = new int[count1];
        }

        public void fillRandom()
        {
            Random rnd = new Random();
            for (int i = 0; i < count; i++)
            {
                array[i] = rnd.Next(1, 50);
            }
        }

        public void sort()
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] < array[j])
                    {
                        int v = array[i];
                        array[i] = array[j];
                        array[j] = v;
                    }
                }
            }
        }

        public void PrintArray()
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }
}