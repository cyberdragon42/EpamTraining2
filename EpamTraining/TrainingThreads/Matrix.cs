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
        private static Random rand;
        private int Step;

        #region Constructor
        public Matrix(int n, int k)
        {
            if (!ValidateParameters(n, k))
                throw new ArgumentException("Invalid parameters for matrix");
            N = n;
            K = k;
            Step = N / K;
            Sum = 0;
            Array = new int[N, N];
            rand = new Random();
            InitializeArrayWithRandomNumbers();
        }
        #endregion

        #region Properties
        public int[,] Array { get; private set; }
        public int N { get; private set; }
        public int K { get; private set; }
        public int Sum { get; private set; }
        #endregion

        #region MainMethods
        public void CountSumWithThreads()
        {
            List<Task> tasks = new List<Task>();

            for (int i = 0; i < K - 1; ++i)
            {
                tasks.Add(new Task(() => CountSum(Step * i, Step * i + Step)));
            }
            tasks.Add(new Task(() => CountSum(Step * (K - 1), N)));

            foreach (var t in tasks)
            {
                t.Start();
                t.Wait();
            }
        }

        public void CountSum(int start, int end)
        {
            for (int i = start; i < end; ++i)
            {
                for (int j = 0; j < N; ++j)
                {
                    Sum += Array[i, j];
                }
            }
        }
        #endregion

        #region HelpingMethods
        public bool ValidateParameters(int n, int k)
        {
            if (n <= 0 || k > n || k == 0)
                return false;
            return true;
        }

        public void InitializeArrayWithRandomNumbers()
        {
            try
            {
                for (int i = 0; i < N; ++i)
                {
                    for (int j = 0; j < N; ++j)
                    {
                        Array[i, j] = rand.Next(100);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
