using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class White
    {
        public double Task1(int[,] matrix)
        {
            double average = 0;
            int count = 0;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        average += matrix[i, j];
                        count++;
                    }
                }
            }

            if (count > 0)
            {
                average /= count;
            }

            return average;
        }
        public (int row, int col) Task2(int[,] matrix)
        {
            int row = 0, col = 0;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int min = matrix[0, 0];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }

            return (row, col);
        }
        public void Task3(int[,] matrix, int k)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (k < 0 || k >= cols || rows == 0)
            {
                return;
            }

            int maxRow = 0;
            int maxValue = matrix[0, k];
            for (int i = 1; i < rows; i++)
            {
                if (matrix[i, k] > maxValue)
                {
                    maxValue = matrix[i, k];
                    maxRow = i;
                }
            }

            if (maxRow == 0)
            {
                return;
            }

            for (int j = 0; j < cols; j++)
            {
                (matrix[0, j], matrix[maxRow, j]) = (matrix[maxRow, j], matrix[0, j]);
            }
        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows == 0)
            {
                return new int[0, cols];
            }

            int minRow = 0;
            int minValue = matrix[0, 0];
            for (int i = 1; i < rows; i++)
            {
                if (matrix[i, 0] < minValue)
                {
                    minValue = matrix[i, 0];
                    minRow = i;
                }
            }

            if (rows == 1)
            {
                return new int[0, cols];
            }

            answer = new int[rows - 1, cols];
            int targetRow = 0;
            for (int i = 0; i < rows; i++)
            {
                if (i == minRow)
                {
                    continue;
                }

                for (int j = 0; j < cols; j++)
                {
                    answer[targetRow, j] = matrix[i, j];
                }
                targetRow++;
            }

            return answer;
        }
        public int Task5(int[,] matrix)
        {
            int sum = 0;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows != cols)
            {
                return 0;
            }

            for (int i = 0; i < rows; i++)
            {
                sum += matrix[i, i];
            }

            return sum;
        }
        public void Task6(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                int firstNegativeIndex = -1;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        firstNegativeIndex = j;
                        break;
                    }
                }

                if (firstNegativeIndex <= 0)
                {
                    continue;
                }

                int maxIndex = 0;
                int maxValue = matrix[i, 0];
                for (int j = 1; j < firstNegativeIndex; j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        maxIndex = j;
                    }
                }

                int lastNegativeIndex = -1;
                for (int j = cols - 1; j >= 0; j--)
                {
                    if (matrix[i, j] < 0)
                    {
                        lastNegativeIndex = j;
                        break;
                    }
                }

                if (lastNegativeIndex == -1)
                {
                    continue;
                }

                (matrix[i, maxIndex], matrix[i, lastNegativeIndex]) = (matrix[i, lastNegativeIndex], matrix[i, maxIndex]);
            }
        }
        public int[] Task7(int[,] matrix)
        {
            int[] negatives = null;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int count = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        count++;
                    }
                }
            }

            if (count == 0)
            {
                return null;
            }

            negatives = new int[count];
            int index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        negatives[index++] = matrix[i, j];
                    }
                }
            }

            return negatives;
        }
        public void Task8(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                if (cols == 0)
                {
                    continue;
                }

                int maxIndex = 0;
                int maxValue = matrix[i, 0];
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        maxIndex = j;
                    }
                }

                if (cols == 1)
                {
                    continue;
                }

                bool hasLeft = maxIndex - 1 >= 0;
                bool hasRight = maxIndex + 1 < cols;
                if (!hasLeft && !hasRight)
                {
                    continue;
                }

                if (hasLeft && hasRight)
                {
                    int left = matrix[i, maxIndex - 1];
                    int right = matrix[i, maxIndex + 1];
                    if (left <= right)
                    {
                        matrix[i, maxIndex - 1] = left * 2;
                    }
                    else
                    {
                        matrix[i, maxIndex + 1] = right * 2;
                    }
                }
                else if (hasLeft)
                {
                    matrix[i, maxIndex - 1] *= 2;
                }
                else if (hasRight)
                {
                    matrix[i, maxIndex + 1] *= 2;
                }
            }
        }
        public void Task9(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols / 2; j++)
                {
                    int opposite = cols - 1 - j;
                    (matrix[i, j], matrix[i, opposite]) = (matrix[i, opposite], matrix[i, j]);
                }
            }
        }
        public void Task10(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n != m)
            {
                return;
            }

            int startRow = n / 2;
            for (int i = startRow; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    matrix[i, j] = 1;
                }
            }
        }
        public int[,] Task11(int[,] matrix)
        {
            int[,] answer = null;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            bool[] hasZero = new bool[rows];
            int remaining = rows;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        hasZero[i] = true;
                        remaining--;
                        break;
                    }
                }
            }

            answer = new int[remaining, cols];
            int target = 0;
            for (int i = 0; i < rows; i++)
            {
                if (hasZero[i])
                {
                    continue;
                }

                for (int j = 0; j < cols; j++)
                {
                    answer[target, j] = matrix[i, j];
                }
                target++;
            }

            return answer;
        }
        public void Task12(int[][] array)
{
    if (array == null)
        return;

    Array.Sort(array, CompareByRowSum);
}

private static int CompareByRowSum(int[] a, int[] b)
{
    int sumA = 0;
    int sumB = 0;

    if (a != null)
    {
        for (int i = 0; i < a.Length; i++)
            sumA += a[i];
    }

    if (b != null)
    {
        for (int i = 0; i < b.Length; i++)
            sumB += b[i];
    }

    return sumA.CompareTo(sumB);
}
    }
}

