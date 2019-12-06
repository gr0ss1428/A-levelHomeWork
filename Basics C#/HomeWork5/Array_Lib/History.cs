using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_Lib
{
    public static class History
    {
        static int[][,] historyArray;
        static int currentPos;
        static public int Count
        {
            get
            {
                if (historyArray != null) return historyArray.Length;
                else return 0;
            }
        }
        static public int[,] GetCurentMatrix
        {
            get
            {
                if (currentPos == -1) return null;
                else return CopyArr(historyArray[currentPos]);
            }
        }
        static public int GetCurrentMatrixPosInHistory
        {
            get { return currentPos; }
        }
        static public int GetMatrixSizeByPos(int pos)
        {
            if (pos < historyArray.Length) return historyArray[pos].GetLength(0);
            else return 0;
        }
        static public int[,] GetMatrixByPos(int pos)
        {
            if (pos < historyArray.Length) return CopyArr(historyArray[pos]);
            else return null;
        }
        static public void SetCurrentMatrix(int pos)
        {
            if (pos < historyArray.Length) currentPos = pos;
        }
        static History()
        {
            currentPos = -1;
            History.NewGenArray(5);
            History.NewGenArray(6);
            History.NewGenArray(7);
            History.NewGenArray(8);
            History.NewGenArray(9);
            History.NewGenArray(10);
        }
        static public void NewGenArray(int size)
        {
            int[,] matrix = new int[size, size];
            Random random = new Random();
            for (int i = 0; i < size; i++)
                for (int y = 0; y < size; y++)
                    matrix[i, y] = random.Next(1, 99);
            AddArray(matrix);
        }
        static public void AddArray(int[,] arrayAdd)
        {
            if (historyArray == null)
            {
                historyArray = new int[1][,];
                historyArray[0] = arrayAdd;
            }
            else
            {
                int[][,] tempArray = new int[historyArray.Length + 1][,];
                for (int i = 0; i < historyArray.Length; i++)
                    tempArray[i] = historyArray[i];
                historyArray = tempArray;
                historyArray[historyArray.Length - 1] = arrayAdd;
            }
            currentPos = historyArray.Length - 1;
        }
        static public int[,] UpperTriangular(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int y = 0; y < matrix.GetLength(0); y++)
                {
                    if (y < i) matrix[i, y] = 0;
                    else break;
                }
            return matrix;
        }
        static public int[,] LowerTriangular(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int y = matrix.GetLength(0) - 1; y >= 0; y--)
                {
                    if (y > i) matrix[i, y] = 0;
                    else break;
                }
            return matrix;
        }
        static int[,] CopyArr(int[,] matrix)
        {
            int[,] copyMatrix = new int[matrix.GetLength(0), matrix.GetLength(0)];
            for (int i = 0; i < copyMatrix.GetLength(0); i++)
                for (int y = 0; y < copyMatrix.GetLength(0); y++)
                {
                    copyMatrix[i, y] = matrix[i, y];
                }
            return copyMatrix;
        }
        static public int[,] Transpose(int[,] matrix)
        {
            int[,] tempMatrix = new int[matrix.GetLength(0), matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int y = 0; y < matrix.GetLength(0); y++)
                    tempMatrix[y, i] = matrix[i, y];
            return tempMatrix;
        }
        static public int GetCurrentMatrixSize()
        {
            if (historyArray == null) return 0;
            else return historyArray[currentPos].GetLength(0);
        }
    }
}
