// Задайте двумерный массив. Напишите программу, которая поменяет местами первую и последнюю строку массива.

int[,] NewMatrix(int rows, int columns, int min = 10, int max = 100)
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
void ReplaseFirstAndLastRowsMatrix(int[,] matrix, int rows, int columns)
{
    for (int i = 0; i < matrix.GetLength(0); i++) {
        int[] temp = new int[columns];
        if (i == 0) {
            for (int j = 0; j < matrix.GetLength(1); j++) {
                temp[j] = matrix[i, j];
                matrix[i, j] = matrix[matrix.GetLength(0) - 1, j];
                matrix[matrix.GetLength(0) - 1, j] = temp[j];
            }
        }
    }
}

Console.WriteLine("Введите количество строк: ");
int rows = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Введите количество столбцов: ");
int columns = Convert.ToInt32(Console.ReadLine());
Console.WriteLine();
int[,] matrix = NewMatrix(rows, columns);
PrintMatrix(matrix);
Console.WriteLine();

ReplaseFirstAndLastRowsMatrix(matrix, rows, columns);
PrintMatrix(matrix);
