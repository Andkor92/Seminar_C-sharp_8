// Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

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
void FindLineNumberWithMinimumAmount(int[,] matrix)
{
    int[] rowSum = new int[matrix.GetLength(0)];
    for (int i = 0; i < matrix.GetLength(0); i++) {
        for (int j = 0; j < matrix.GetLength(1); j++) { rowSum[i] += matrix[i, j]; }
        Console.WriteLine($"Сумма строки под индексом {i} равна {rowSum[i]}");
    }
    Console.WriteLine();
    int minSum = rowSum[0];
    int indexRowMinSum = 0;
    for (int i = 1; i < matrix.GetLength(0); i++) { if (rowSum[i] < minSum) { minSum = rowSum[i]; indexRowMinSum = i; } }
    Console.WriteLine($"Номер строки с наименьшей суммой элементов: {indexRowMinSum + 1} строка.");
    Console.WriteLine($"Ее сумма составляет {minSum}.");
}

Console.WriteLine("Введите количество строк: ");
int rows = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите количество столбцов: ");
int columns = Convert.ToInt32(Console.ReadLine());
Console.WriteLine();
int[,] matrix = NewMatrix(rows, columns);
PrintMatrix(matrix);
Console.WriteLine();

FindLineNumberWithMinimumAmount(matrix);
