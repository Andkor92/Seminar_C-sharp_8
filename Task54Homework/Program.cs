// Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

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
void SortArrayStringDescending(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++) {
        for (int j = 1; j < matrix.GetLength(1); j++) {
            for (int k = 1; k < matrix.GetLength(1); k++) {
                    if (matrix[i, k] > matrix[i, k - 1]) {
                        int temp = matrix[i, k - 1];
                        matrix[i, k - 1] = matrix[i, k];
                        matrix[i, k] = temp;
                    }
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

SortArrayStringDescending(matrix);
PrintMatrix(matrix);
