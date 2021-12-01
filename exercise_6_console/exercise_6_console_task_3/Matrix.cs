using System;
using System.Collections.Generic;
using System.Text;

namespace exercise_6_console_task_3
{
    class Matrix
    {
        private int[,] matr;
        private Random rand;
        public int GetLength { get { return matr.GetLength(0); } }
        public int this[int n,int m]
            {
            get
            {
                if (n >= 0 && n < matr.GetLength(0) &&
                    m >=0 && m < matr.GetLength(0))
                {
                    return matr[n, m];
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            set
            {
                if (n >= 0 && n < matr.GetLength(0) &&
                    m >= 0 && m < matr.GetLength(0))
                {
                    matr[n, m] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            }
        public Matrix(int n)
        {
            matr=new int[n,n];
            rand = new Random();
            SetValues();
        }
        private void SetValues()
        {
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    matr[i, j] = rand.Next(-50, 50);
                }
            }
        }
        public static Matrix operator *(Matrix matr1,Matrix matr2)
        {
            Matrix returnableMatrix=new Matrix(matr1.GetLength);
            int tmpValue;

            for (int i = 0; i <returnableMatrix.GetLength; i++)
            {
                for (int j = 0; j <returnableMatrix.GetLength; j++)
                {
                    tmpValue = 0;

                    for (int c = 0; c < returnableMatrix.GetLength; c++)
                    {
                        tmpValue += matr1[i, c] * matr2[c, j];
                    }
                    returnableMatrix[i, j] = tmpValue;
                }
            }
            return returnableMatrix;

        }
    }
}
