// Задайте двумерный массив. Напишите программу, которая заменяет строки на столбцы.
// В случае, если это невозможно, программа должна вывести сообщение для пользователя.

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
int[,] ReplaceRowsToColumnsMatrix(int[,] matrix)
{
    int[,] newMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
    for (int i = 0; i < matrix.GetLength(0); i++) {
        for (int j = 0; j < matrix.GetLength(1); j++) { newMatrix[j, i] = matrix[i, j]; }
    }
    return newMatrix;
}

Console.WriteLine("Введите количество строк: ");
int rows = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите количество столбцов: ");
int columns = Convert.ToInt32(Console.ReadLine());
Console.WriteLine();

if (rows != columns) { Console.WriteLine($"Ошибка! Матрица имеет не равное количество строк и столбцов."); ; }
else {
    int[,] matrix = NewMatrix(rows, columns);
    PrintMatrix(matrix);
    Console.WriteLine();
    int[,] newM = ReplaceRowsToColumnsMatrix(matrix);
    PrintMatrix(newM);
}
