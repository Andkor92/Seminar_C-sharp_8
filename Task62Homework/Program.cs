// Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

int[,] NewSperalMatrix(int rows, int columns)
{
    int[,] matrix = new int[rows, columns];
    int count = 0;
    int round = 0;
    int i;
    int value = 1;
    while (count < rows * columns)
    {
        round++;
        for (i = round - 1; i < columns - round + 1; i++) { matrix[round - 1, i] = value++; count++; }
        for (i = round; i < rows - round + 1; i++) { matrix[i, columns - round] = value++; count++; }
        for (i = columns - round - 1; i >= round - 1; i--) { matrix[rows - round, i] = value++; count++; }
        for (i = rows  - round - 1; i >= round; i--) { matrix[i, round - 1] = value++; count++; }
    }
    return matrix;
}
void PrintMatrix(int[,] matrix)
{
    int count = matrix.GetLength(0) * matrix.GetLength(1);
    for (int i = 0; i < matrix.GetLength(0); i++) {
        for (int j = 0; j < matrix.GetLength(1); j++) {
            //Для красивого вывода матрицы со значениями до 1000
            if(count < 100 && matrix[i, j] > 0 && matrix[i, j] < 10) {Console.Write("0" + matrix[i, j] + " ");}
            else if(count >= 100 && count < 1000 && matrix[i, j] > 0 && matrix[i, j] < 10) {Console.Write("00" + matrix[i, j] + " ");}
            else if(count >= 100 && count < 1000 && matrix[i, j] >= 10 && matrix[i, j] < 100) {Console.Write("0" + matrix[i, j] + " ");}
            else Console.Write(matrix[i, j] + " ");
        }
        Console.WriteLine();
    }
}

Console.WriteLine("Введите количество строк: ");
int rows = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите количество столбцов: ");
int columns = Convert.ToInt32(Console.ReadLine());
Console.WriteLine();
int[,] matrix = NewSperalMatrix(rows, columns);

PrintMatrix(matrix);
