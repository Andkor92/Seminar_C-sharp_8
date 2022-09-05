// Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив,
// добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

int[,,] NewMatrixOfNonRepeatingRandomNumbers(int x, int y, int z, int minValue, int maxValue)
{
    int[,,] matrix = new int[x, y, z];
    Random rand = new Random();
    int[] temporary = new int[matrix.GetLength(0) * matrix.GetLength(1) * matrix.GetLength(2)];
    int indexTemporary = 0;
    for (int i = 0; i < matrix.GetLength(0); i++) {
        for (int j = 0; j < matrix.GetLength(1); j++) {
            for (int k = 0; k < matrix.GetLength(2); k++) {
                int temp = rand.Next(minValue, maxValue + 1);
                if (indexTemporary == 0) { temporary[indexTemporary] = temp; matrix[i, j, k] = temp; indexTemporary++; }
                else {
                    for (int l = 0; l < indexTemporary; l++) {
                        if (temp == temporary[l]) {
                            temp = rand.Next(minValue, maxValue + 1);
                            l = 0;
                        }
                    }
                    temporary[indexTemporary] = temp;
                    matrix[i, j, k] = temp;
                    indexTemporary++;
                }
            }
        }
    }
    return matrix;
}
void PrintMatrix(int[,,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++) {
        for (int j = 0; j < matrix.GetLength(1); j++) {
            for (int k = 0; k < matrix.GetLength(2); k++) {
                Console.Write($"{matrix[i, j, k]}({i},{j},{k}) ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

Console.WriteLine("Введите размер массива по X: ");
int x = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите размер массива по Y: ");
int y = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите размер массива по Z: ");
int z = Convert.ToInt32(Console.ReadLine());
Console.WriteLine();

//По условию задачи
int lowRandomValue = 10;
int highRandomValue = 99;

if(x * y * z > highRandomValue - lowRandomValue + 1) {
    Console.WriteLine($"Уникальных чисел от {lowRandomValue} до {highRandomValue} = {highRandomValue - lowRandomValue + 1}.");
    Console.WriteLine($"Размер трехмерного массива превышает это значение ({x} * {y} * {z} = {x*y*z}).");
}
else { int[,,] matrix = NewMatrixOfNonRepeatingRandomNumbers(x, y, z, lowRandomValue, highRandomValue);
                        PrintMatrix(matrix); }
