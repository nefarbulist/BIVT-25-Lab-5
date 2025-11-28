using System.Collections.Generic;
using System.Linq;

namespace Lab5
{
    public class White
    {
        public double Task1(int[,] matrix)
        {
            double average = 0;

            // code here
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
            {
                return average;
            }

            double sum = 0;
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }
            }

            if (count > 0)
            {
                average = sum / count;
            }

            // end

            return average;
        }
        public (int row, int col) Task2(int[,] matrix)
        {
            int row = 0, col = 0;

            // code here
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
            {
                return (row, col);
            }

            int min = matrix[0, 0];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }

            // end

            return (row, col);
        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            if (matrix == null || k < 0 || k >= matrix.GetLength(1))
            {
                return;
            }

            int maxRow = 0;
            int maxValue = matrix[0, k];
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, k] > maxValue)
                {
                    maxValue = matrix[i, k];
                    maxRow = i;
                }
            }

            if (maxRow != 0)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int temp = matrix[0, j];
                    matrix[0, j] = matrix[maxRow, j];
                    matrix[maxRow, j] = temp;
                }
            }

            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
            {
                return answer;
            }

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
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
                answer = new int[0, cols];
            }
            else
            {
                answer = new int[rows - 1, cols];
                for (int i = 0, a = 0; i < rows; i++)
                {
                    if (i == minRow)
                    {
                        continue;
                    }
                    for (int j = 0; j < cols; j++)
                    {
                        answer[a, j] = matrix[i, j];
                    }
                    a++;
                }
            }

            // end

            return answer;
        }
        public int Task5(int[,] matrix)
        {
            int sum = 0;

            // code here
            if (matrix == null)
            {
                return sum;
            }

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows != cols)
            {
                return sum;
            }

            for (int i = 0; i < rows; i++)
            {
                sum += matrix[i, i];
            }

            // end

            return sum;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            if (matrix == null)
            {
                return;
            }

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                int firstNegative = -1;
                int lastNegative = -1;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        if (firstNegative == -1)
                        {
                            firstNegative = j;
                        }
                        lastNegative = j;
                    }
                }

                if (firstNegative <= 0 || lastNegative == -1)
                {
                    continue;
                }

                int maxIndex = 0;
                int maxValue = matrix[i, 0];
                for (int j = 1; j < firstNegative; j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        maxIndex = j;
                    }
                }

                int temp = matrix[i, maxIndex];
                matrix[i, maxIndex] = matrix[i, lastNegative];
                matrix[i, lastNegative] = temp;
            }

            // end

        }
        public int[] Task7(int[,] matrix)
        {
            int[] negatives = null;

            // code here
            if (matrix == null)
            {
                return negatives;
            }

            var list = new List<int>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        list.Add(matrix[i, j]);
                    }
                }
            }

            negatives = list.ToArray();

            // end

            return negatives;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            if (matrix == null)
            {
                return;
            }

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                if (cols <= 1)
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

                if (maxIndex == 0)
                {
                    matrix[i, 1] *= 2;
                }
                else if (maxIndex == cols - 1)
                {
                    matrix[i, cols - 2] *= 2;
                }
                else
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
            }

            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            if (matrix == null)
            {
                return;
            }

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                int left = 0;
                int right = cols - 1;
                while (left < right)
                {
                    int temp = matrix[i, left];
                    matrix[i, left] = matrix[i, right];
                    matrix[i, right] = temp;
                    left++;
                    right--;
                }
            }

            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            if (matrix == null)
            {
                return;
            }

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows != cols)
            {
                return;
            }

            int startRow = rows / 2;
            for (int i = startRow; i < rows; i++)
            {
                for (int j = 0; j <= i && j < cols; j++)
                {
                    matrix[i, j] = 1;
                }
            }

            // end

        }
        public int[,] Task11(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
            {
                return answer;
            }

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            var keepRows = new List<int>();

            for (int i = 0; i < rows; i++)
            {
                bool hasZero = false;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        hasZero = true;
                        break;
                    }
                }
                if (!hasZero)
                {
                    keepRows.Add(i);
                }
            }

            if (keepRows.Count == 0)
            {
                answer = new int[0, cols];
            }
            else
            {
                answer = new int[keepRows.Count, cols];
                for (int i = 0; i < keepRows.Count; i++)
                {
                    int sourceRow = keepRows[i];
                    for (int j = 0; j < cols; j++)
                    {
                        answer[i, j] = matrix[sourceRow, j];
                    }
                }
            }

            // end

            return answer;
        }
        public void Task12(int[][] array)
        {

            // code here
            if (array == null || array.Length == 0)
            {
                return;
            }

            var sorted = array
                .Select((row, index) => new
                {
                    Row = row,
                    Index = index,
                    Sum = row?.Sum() ?? 0
                })
                .OrderBy(x => x.Sum)
                .ThenBy(x => x.Index)
                .ToArray();

            for (int i = 0; i < sorted.Length; i++)
            {
                array[i] = sorted[i].Row;
            }

            // end

        }
    }
}