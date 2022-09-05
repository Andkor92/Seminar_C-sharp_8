// Задайте двумерный массив из целых чисел. Напишите программу, которая удалит строку и столбец,
// на пересечении которых расположен наименьший элемент массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Наименьший элемент - 1, на выходе получим
// следующий массив:
// 9 4 2
// 2 2 6
// 3 4 7

int[,] NewMatrix(int rows, int columns, int min = 0, int max = 10)
{
    int[,] matrix = new int[rows, columns];
    Random rand = new Random();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rand.Next(min, max);
        }
    }
    return matrix;
}
void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write(matrix[i, j] + " ");
        }
        Console.WriteLine();
    }
}
int[,] DeleteRowsAndColumnsMinimumValueMatrix(int[,] matrix)
{
    int i = 0;
    int j = 0;
    int minValue = matrix[i, j];
    int[] positionMinValue = new int[2];
    positionMinValue[0] = i;
    positionMinValue[1] = j;
    for (i = 0; i < matrix.GetLength(0); i++)
    {
        for (j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] < minValue)
            {
                minValue = matrix[i, j];
                positionMinValue[0] = i;
                positionMinValue[1] = j;
            }
        }
    }
    int[,] newMatrix = new int[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
    int rowOffset = 0;
    int columnOffset = 0;
    for (i = 0; i < newMatrix.GetLength(0); i++)
    {
        if(i == positionMinValue[0]) rowOffset++;
        for (j = 0; j < newMatrix.GetLength(1); j++)
        {
            if(j == positionMinValue[1]) columnOffset++;
            newMatrix[i, j] = matrix[i + rowOffset, j + columnOffset];
        }
        columnOffset = 0;
    }
    return newMatrix;
}

Console.WriteLine("Введите количество строк: ");
int rows = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Введите количество столбцов: ");
int columns = Convert.ToInt32(Console.ReadLine());
Console.WriteLine();
int[,] matrix = NewMatrix(rows, columns);
PrintMatrix(matrix);
Console.WriteLine();

int[,] newM = DeleteRowsAndColumnsMinimumValueMatrix(matrix);
PrintMatrix(newM);
