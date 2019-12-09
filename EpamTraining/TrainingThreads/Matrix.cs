using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ServiceClasses;

namespace TrainingThreads
{
    public class Matrix
    {
        private IPrinter Printer;
        private static Random rand;
        private int[,] Array;
        private int M, N, K, Sum, Step;

        public Matrix(IPrinter printer, int m, int n, int k)
        {
            if (!ValidateParameters(m, n, k))
                throw new ArgumentException("Invalid parameters for matrix");
            else
            {
                Printer = printer;
                M = m;
                N = n;
                K = k;
                rand = new Random();
                Array = new int[M, N];
                InitializeArrayWithRandomNumbers();
                Sum = 0;
                Step = M / K;
            }
        }

        public bool ValidateParameters(int m, int n, int k)
        {
            if (m <= 0 || n <= 0 || k > m || k==0)
                return false;
            return true;

        }

        public void CountSumWithThreads()
        {
            try
            {
                for (int i = 0; i < M; i += Step)
                {
                    Thread thread = new Thread(new ParameterizedThreadStart(CountSumOfSection));
                    thread.Start(new ThreadParameters(i));
                }
                Printer.Print("Sum= " + Sum);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void CountSumOfSection(object threadParameters)
        {
            try
            {
                int left = ((ThreadParameters)threadParameters).Left;
                int right = (left + Step) > M ? M : (left + Step);
                for (int i = left; i < right + Step; ++i)
                {
                    for (int j = 0; j < M; ++j)
                    {
                        Sum += Array[i, j];
                    }
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void InitializeArrayWithRandomNumbers()
        {
            try
            {
                for (int i = 0; i < N; ++i)
                {
                    for (int j = 0; j < M; ++j)
                    {
                        Array[i, j] = rand.Next(1000);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
