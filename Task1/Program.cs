// Найти произведение двух матриц
//------------------------------------------------------------------------------------------------------------------------------+
int[,] GetFilledMatrix(int rows, int columnes)
{
    int[,] matrix = new int[rows, columnes];
    Random rnd = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++)
        for (int j = 0; j < matrix.GetLength(1); j++)
            matrix[i, j] = rnd.Next(0, 10);

    return (matrix);
}
//------------------------------------------------------------------------------------------------------------------------------+
void PrintIntMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
            Console.Write($"{matrix[i, j]} ");
        Console.WriteLine();
    }
}
//------------------------------------------------------------------------------------------------------------------------------+
int[,] ProductOfTwoMatrixes(int[,] firstMatrix, int[,] secondMatrix, int[,] thirdMatrix)
{
    for (int i = 0; i < thirdMatrix.GetLength(0); i++)
        for (int j = 0; j < thirdMatrix.GetLength(1); j++)
            thirdMatrix[i, j] = GetSumMult(i,j,firstMatrix,secondMatrix);

    return (thirdMatrix);
}
//------------------------------------------------------------------------------------------------------------------------------+
int GetSumMult(int row, int column, int[,]firstMatrix,int[,] secondMatrix)
{
    int result = 0;
    for (int i = 0; i < firstMatrix.GetLength(1); i++)
    {
        result += firstMatrix[row,i]*secondMatrix[i,column];
    }
    return(result);
}
//------------------------------------------------------------------------------------------------------------------------------+
Console.Clear();
bool matrixesTheSame     = false;
int firstMatrixRows      = 0,
    firstMatrixColumnes  = 0,
    secondMatrixRows     = 0,
    secondMatrixColumnes = 0;
while (!matrixesTheSame)
{
    Console.Write("Введите количество рядов первой матрицы: ");
     firstMatrixRows = int.Parse(Console.ReadLine() ?? "");
    Console.Write("Введите количество колонок первой матрицы: ");
     firstMatrixColumnes = int.Parse(Console.ReadLine() ?? "");
    Console.Write("Введите количество рядов второй матрицы: ");
     secondMatrixRows = int.Parse(Console.ReadLine() ?? "");
    Console.Write("Введите количество колонок второй матрицы: ");
     secondMatrixColumnes = int.Parse(Console.ReadLine() ?? "");

    if (firstMatrixColumnes != secondMatrixRows)
        Console.WriteLine("Произведение двух матриц имеет смысл только в том случае, " +
        "когда число колонок первой матрицы  совпадает с числом рядов второй матрицы." + "\n Введите размеры матриц еще раз.");
    else 
        matrixesTheSame = true;
}

int[,] firstMatrix  = GetFilledMatrix(firstMatrixRows, firstMatrixColumnes);
int[,] secondMatrix = GetFilledMatrix(secondMatrixRows, secondMatrixColumnes);
int[,] thirdMatrix  = new int[firstMatrixRows,secondMatrixColumnes];

Console.WriteLine("\nПервая матрица:");
PrintIntMatrix(firstMatrix);

Console.WriteLine("\nВторая матрица матрица:");
PrintIntMatrix(secondMatrix);
Console.WriteLine("\nРасчитаем произведение матриц.\n\nПроизведение матриц равно:");
thirdMatrix = ProductOfTwoMatrixes(firstMatrix, secondMatrix,thirdMatrix);
PrintIntMatrix(thirdMatrix);



