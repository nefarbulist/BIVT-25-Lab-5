
using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
@@ -10,7 +10,24 @@ public double Task1(int[,] matrix)
            double average = 0;

            // code here

            int count = 0; 
            double sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0;  j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }
            }
            if (count == 0)
            {
                return 0;
            }
            average = sum / count;
            // end

            return average;
@@ -20,7 +37,19 @@ public double Task1(int[,] matrix)
            int row = 0, col = 0;

            // code here

            int min = matrix[0,0];
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
@@ -29,7 +58,24 @@ public void Task3(int[,] matrix, int k)
        {

            // code here

            if ((k < 0) || (k >= matrix.GetLength(1)))
            {
                return;
            }
            int maxi = 0;
            int max = matrix[0, k];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, k] > max)
                {
                    max = matrix[i, k];
                    maxi = i;
                }
            }
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                (matrix[maxi, j], matrix[0, j]) = (matrix[0, j], matrix[maxi, j]);
            }
            // end

        }
@@ -38,7 +84,30 @@ public void Task3(int[,] matrix, int k)
            int[,] answer = null;

            // code here

            if (matrix.GetLength(0) == 1) 
            { 
                return new int[0, matrix.GetLength(1)]; 
            }
            int mini = 0;
            int min = matrix[0, 0];
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, 0] < min)
                {
                    min = matrix[i, 0];
                    mini = i;
                }
            }
            answer = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
            for (int i = 0, new_row = 0; i < matrix.GetLength(0); i++)
            {
                if (i != mini)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                        answer[new_row, j] = matrix[i, j];
                    new_row++;
                }
            }
            // end

            return answer;
@@ -48,7 +117,12 @@ public int Task5(int[,] matrix)
            int sum = 0;

            // code here

            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return 0;
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
                sum += matrix[i, i];
            // end

            return sum;
@@ -57,7 +131,28 @@ public void Task6(int[,] matrix)
        {

            // code here

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int maxi = -1, negative = -1;
                int max = int.MinValue;
                bool n = false;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (n == false && matrix[i, j] < 0)
                        n = true;
                    if (n == false && matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxi = j;
                    }
                    if (matrix[i, j] < 0)
                        negative = j;
                }
                if (maxi != -1 && negative != -1)
                {
                    (matrix[i, maxi], matrix[i, negative]) = (matrix[i, negative], matrix[i, maxi]);
                }
            }
            // end

        }
@@ -66,7 +161,34 @@ public int[] Task7(int[,] matrix)
            int[] negatives = null;

            // code here

            int k = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        k++;
                    }
                }
            }
            if (k == 0) 
            {
                return null; 
            }
            negatives = new int[k];
            int c = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        negatives[c] = matrix[i, j];
                        c++;
                    }
                }
            }
            // end

            return negatives;
@@ -75,23 +197,72 @@ public void Task8(int[,] matrix)
        {

            // code here

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix.GetLength(1) == 1)
                {
                    continue;
                }
                int maxi = 0;
                for (int j = 1; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] > matrix[i, maxi])
                    {
                        maxi = j;
                    }
                if (maxi > 0 && maxi < matrix.GetLength(1) - 1)
                {
                    if (matrix[i, maxi - 1] <= matrix[i, maxi + 1])
                    {
                        matrix[i, maxi - 1] *= 2;
                    }
                    else
                    {
                        matrix[i, maxi + 1] *= 2;
                    }
                }
                else if (maxi == 0)
                {
                    matrix[i, 1] *= 2;
                }
                else
                {
                    matrix[i, maxi - 1] *= 2;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1) / 2; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[i, matrix.GetLength(1) - 1 - j];
                    matrix[i, matrix.GetLength(1) - 1 - j] = temp;
                }
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here

            if ((matrix.GetLength(0) != matrix.GetLength(1)) || (matrix.GetLength(0) == 0))
            {
                return;
            }
            for (int i = matrix.GetLength(0) / 2; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    matrix[i, j] = 1;
                }
            }
            // end

        }
@@ -100,7 +271,50 @@ public void Task10(int[,] matrix)
            int[,] answer = null;

            // code here

            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                bool n = false;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        n = true;
                        break;
                    }
                }
                if (n == false) 
                { 
                    count++; 
                }
            }
            if (count == 0)
            {
                answer = new int[0, matrix.GetLength(1)];
            }
            else
            {
                answer = new int[count, matrix.GetLength(1)];
                int r = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    bool N = false;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] == 0)
                        {
                            N = true;
                            break;
                        }
                    }
                    if (N == false)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                            answer[r, j] = matrix[i, j];
                        r++;
                    }
                }
            }
            // end

            return answer;
@@ -109,9 +323,29 @@ public void Task12(int[][] array)
        {

            // code here

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    int sum1 = 0;
                    int sum2 = 0;
                    for (int k = 0; k < array[j].Length; k++)
                    {
                        sum1 += array[j][k];
                    }
                    for (int k = 0; k < array[j + 1].Length; k++)
                    {
                        sum2 += array[j + 1][k];
                    }
                    if (sum1 > sum2)
                    {
                        (array[j],array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }
            // end

        }
    }
} 
}
