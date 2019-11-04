using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ServiceClasses;

namespace Threads
{
    public class Matrix
    {
        private IPrinter Printer;
        private static Random rand;
        private int[,] Array;
        private int M, N, K, Sum;

        public Matrix(IPrinter printer,int m, int n, int k)
        {
            Array = new int[M, N];
            InitializeArrayWithRandomNumbers();
            Printer = printer;
            M = m;
            N = n;
            rand = new Random();
            Sum = 0;
        }

        public void CountSumWithThreads()
        {
            for (int i = 0; i < M; i += K)
            {
                Thread thread = new Thread(new ParameterizedThreadStart(CountSumOfSection));
                thread.Start(new ThreadParameters(i));
            }
            Printer.Print("Sum= " + Sum);
        }

        public void CountSumOfSection(object threadParameters)
        {
            int left = ((ThreadParameters)threadParameters).Left;
            int right = (left + K) > M ? M : (left + K);
            for (int i = left; i < right + K; ++i)
            {
                for (int j = 0; j < K; ++j)
                {
                    Sum += Array[i, j];
                }
            }
        }
        public void InitializeArrayWithRandomNumbers()
        {
            for (int i = 0; i < K; ++i)
            {
                for (int j = 0; j < N; ++j)
                {
                    Array[i, j] = rand.Next(1000);
                }
            }
        }

        public void DisplayArray()
        {
            for (int i = 0; i < M; ++i)
            {
                Printer.Print(" ");
                for (int j = 0; j < N; ++j)
                {
                    Printer.Print(Array[i, j].ToString());
                }
            }
        }
    }
}

