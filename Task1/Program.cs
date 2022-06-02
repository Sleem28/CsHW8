// Найти произведение двух матриц
//------------------------------------------------------------------------------------------------------------------------------+
int[,] GetFilledMatrix(int rows,int columnes)
{
    int[,] matrix = new int[rows,columnes];
    Random rnd    = new Random();

    for(int i=0;i<matrix.GetLength(0);i++)
        for (int j=0; j<matrix.GetLength(1);j++)
            matrix[i,j] = rnd.Next(-100,100);
            
    return(matrix);    
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
int[,] ProductOfTwoMatrixes(int[,] firstMatrix,int[,] secondMatrix)
{
    for (int i=0;i<firstMatrix.GetLength(0);i++)
        for (int j=0;j<firstMatrix.GetLength(1);j++)
            firstMatrix[i,j] *= secondMatrix[i,j];
        
    return(firstMatrix);
}
//------------------------------------------------------------------------------------------------------------------------------+
int    matrixRows     = 10;
int    matrixColumnes = 10;

Console.WriteLine("\nПолучим 2 матрицы с заполненными значениями.");
int[,] firstMatrix    = GetFilledMatrix(matrixRows,matrixColumnes);
int[,] secondMatrix   = GetFilledMatrix(matrixRows,matrixColumnes);

Console.WriteLine("\nПервая матрица:");
PrintIntMatrix(firstMatrix);

Console.WriteLine("\nВторая матрица матрица:");
PrintIntMatrix(secondMatrix);
Console.WriteLine("\nРасчитаем произведение матриц.\n\nПроизведение матриц равно:");
firstMatrix = ProductOfTwoMatrixes(firstMatrix,secondMatrix);
PrintIntMatrix(firstMatrix);



