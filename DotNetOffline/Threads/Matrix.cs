using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    public class Matrix
    {
        private static Random rand;
        private int m, n,k, Sum;
        private int[,] Array;
        public int[] temp = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        public int sum1, sum2;

        public Matrix(int m, int n)
        {
            Array = new int[m, n];
            InitializeArrayWithRandomNumbers();
            sum1 = 0;
        }

        public void CountSumWithThreads()
        {
            Thread thread1 = new Thread(new ParameterizedThreadStart(Temp));
            thread1.Start(5);
            Console.WriteLine(sum1);

            Thread thread2 = new Thread(new ParameterizedThreadStart(Temp));
            thread2.Start(9);

        }

        public void Temp(object right)
        {
            sum1 = 0;
            int r = (int)right;
            for(int i=0;i<r;++i)
            {
                sum1 += temp[i];
            }

            Console.WriteLine("sum from 0 to " + r + " element= " + sum1);
        }

        public void InitializeArrayWithRandomNumbers()
        {
            for(int i=0;i<n;++i)
            {
                for (int j = 0; j< m;++j)
                {
                    Array[i, j] = rand.Next(1000);
                }
            }
        }
    }
}
