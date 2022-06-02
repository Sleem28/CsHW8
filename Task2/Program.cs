// В двумерном массиве целых чисел. Удалить строку и столбец, на пересечении которых расположен наименьший элемент.
//------------------------------------------------------------------------------------------------------------------------------+
int[,] GetFilledMatrix(int rows,int columnes)
{
    int[,] matrix = new int[rows,columnes];
    Random rnd    = new Random();

    for(int i=0;i<matrix.GetLength(0);i++)
        for (int j=0; j<matrix.GetLength(1);j++)
            matrix[i,j] = rnd.Next(0,1000);
            
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
int[,] GetCoordinatesMinValue(int[,] matrix)
{
    int[,] coordinatesMinValue = new int[1,2];
    int    minValue            = 2000;

    for(int i=0;i<matrix.GetLength(0);i++)
        for (int j=0; j<matrix.GetLength(1);j++)
            {
                if(matrix[i,j] < minValue)
                {
                  minValue =  matrix[i,j];
                  coordinatesMinValue[0,0] = i;
                  coordinatesMinValue[0,1] = j;
                }  
            }
    return(coordinatesMinValue);
}
//------------------------------------------------------------------------------------------------------------------------------+
int[,] DeleteRowAndColumn(int[,] matrix, int row,int column)
{
    for(int i=0;i<matrix.GetLength(0);i++)
        for (int j=0; j<matrix.GetLength(1);j++)
            {
                if(i==row || j==column)
                  matrix[i,j] = 0;
            }
    return(matrix);
}
//------------------------------------------------------------------------------------------------------------------------------+
int    matrixRows     = 10;
int    matrixColumnes = 10;
int[,] coordinatesMinValue = new int[1,2];

Console.WriteLine("\nПолучим матрицу с заполненными значениями.");
int[,] matrix    = GetFilledMatrix(matrixRows,matrixColumnes);
PrintIntMatrix(matrix);

Console.WriteLine("\nНайдем координаты элемента с минимальным значением.");
coordinatesMinValue = GetCoordinatesMinValue(matrix);

int minValueInMatrix = matrix[coordinatesMinValue[0,0],coordinatesMinValue[0,1]];
Console.WriteLine($"Минимальный элемент в матрице равен {minValueInMatrix}. Координаты в массиве: ряд {coordinatesMinValue[0,0]+1}, колонка {coordinatesMinValue[0,1]+1}.");

Console.WriteLine("\nУдалим строку и столбец на пересечении с наименьшим элементом.");
matrix = DeleteRowAndColumn(
                            matrix: matrix,
                            row:    coordinatesMinValue[0,0],
                            column: coordinatesMinValue[0,1]
                            );
PrintIntMatrix(matrix);