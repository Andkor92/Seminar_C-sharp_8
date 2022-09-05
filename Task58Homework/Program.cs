// Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

int[,] NewMatrix(int rows, int columns, int min = 0, int max = 10)
{
    int[,] matrix = new int[rows, columns];
    Random rand = new Random();
    for (int i = 0; i < matrix.GetLength(0); i++) {
        for (int j = 0; j < matrix.GetLength(1); j++) {
            matrix[i, j] = rand.Next(min, max);
        }
    }
    return matrix;
}
void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++) {
        for (int j = 0; j < matrix.GetLength(1); j++) {
            Console.Write(matrix[i, j] + " ");
        }
        Console.WriteLine();
    }
}
int[,] MultiplicationOfTwoMatrices(int[,] firstMatrix, int[,] secondMatrix)
{
    int[,] newMatrix = new int[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];
    for (int i = 0; i < firstMatrix.GetLength(0); i++) {
        for (int l = 0; l < secondMatrix.GetLength(1); l++) {
            int j = 0;
            int k = 0;
            while (j < firstMatrix.GetLength(1) && k < secondMatrix.GetLength(0)) {
                int multiplication = firstMatrix[i, j] * secondMatrix[k, l];
                newMatrix[i, l] += multiplication;
                j++;
                k++;
            }
        }
    }
    return newMatrix;
}

Console.WriteLine("Введите количество строк для первой матрицы: ");
int rowsFirstMatrix = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите количество столбцов для первой матрицы: ");
int columnsFirstMatrix = Convert.ToInt32(Console.ReadLine());
Console.WriteLine();
int[,] firstMatrix = NewMatrix(rowsFirstMatrix, columnsFirstMatrix);
Console.WriteLine("Введите количество строк для второй матрицы: ");
int rowsSecondMatrix = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите количество столбцов для второй матрицы: ");
int columnsSecondMatrix = Convert.ToInt32(Console.ReadLine());
Console.WriteLine();
int[,] secondMatrix = NewMatrix(rowsSecondMatrix, columnsSecondMatrix);

if (firstMatrix.GetLength(1) != secondMatrix.GetLength(0)) {
        Console.WriteLine("Умножение невозмножно! Число столбцов первой матрицы должно быть равно числу строк второй!");
    }
else {
    Console.WriteLine("Первая матрица: ");
    PrintMatrix(firstMatrix);
    Console.WriteLine();
    Console.WriteLine("Вторая матрица: ");
    PrintMatrix(secondMatrix);
    Console.WriteLine();
    int[,] multiplication = MultiplicationOfTwoMatrices(firstMatrix, secondMatrix);
    Console.WriteLine("Результат: ");
    PrintMatrix(multiplication);
}