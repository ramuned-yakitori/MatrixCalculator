using System;
class MatrixCalculate
{
    public static void Main()
    {
        Console.WriteLine("m×n行列");
        Console.WriteLine("-------");
        Console.WriteLine("m n");
        Console.WriteLine("↓ ↓");
        string[] sizeStringArray = Console.ReadLine().Split(' ');
        int m = int.Parse(sizeStringArray[0]);
        int n = int.Parse(sizeStringArray[1]);

        Console.WriteLine(new string('-', n * 2));

        decimal[][] matrix = new decimal[m][];
        for (int i = 0; i < m; i++)
        {
            matrix[i] = new decimal[n];
        }

        for (int i = 0; i < m; i++)
        {
            string[] matrixStringArray = Console.ReadLine().Split(' ');
            matrix[i] = Array.ConvertAll(matrixStringArray, decimal.Parse);
        }

        Console.WriteLine(new string('-', n * 2));
        Console.WriteLine("指定のコードを入力");
        Console.WriteLine("・簡約階段行列化: REEF");
        if (Console.ReadLine() == "REEF")
        {
            decimal[][] afterMatrix = MatrixCalc(matrix, m, n);
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(afterMatrix[i][j].ToString("G"));
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
        
    }
    public static decimal[][] MatrixCalc(decimal[][] matrix, int m, int n)
    {
        
        int pivotRow = 0;

        for (int i = 0; i < n; i++)
        {
            if (pivotRow >= m)
            {
                break;
            }

            for (int j = pivotRow; j < m; j++)
            {
                if (matrix[j][i] != 0)
                {
                    decimal[] tempLine = matrix[j];
                    matrix[j] = matrix[pivotRow];
                    matrix[pivotRow] = tempLine;
                    decimal x = matrix[pivotRow][i];
                    for (int k = i; k < n; k++)
                    {
                        matrix[pivotRow][k] /= x;
                    }
                    for (int k = 0; k < m; k++)
                    {
                        if (k == pivotRow)
                        {
                            continue;
                        }
                        if (matrix[k][i] != 0)
                        {
                            decimal factor = matrix[k][i];
                            for (int l = i; l < n; l++)
                            {
                                matrix[k][l] -= factor * matrix[pivotRow][l];
                            }
                        } 
                        else
                        {
                            continue;
                        }
                        
                    }
                    pivotRow++;
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        return matrix;
    }
}