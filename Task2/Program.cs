// В двумерном массиве целых чисел. Удалить строку и столбец, на пересечении которых расположен наименьший элемент.
//------------------------------------------------------------------------------------------------------------------------------+
int[,] GetFilledMatrix(int rows,int columnes)
{
    int[,] matrix = new int[rows,columnes];
    Random rnd    = new Random();

    for(int i=0;i<matrix.GetLength(0);i++)
        for (int j=0; j<matrix.GetLength(1);j++)
            matrix[i,j] = rnd.Next(0,100);
            
    return(matrix);    
}
//------------------------------------------------------------------------------------------------------------------------------+
void PrintIntMatrix(int[,] matrix)
{
    string backSpaces = string.Empty;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            backSpaces = matrix[i,j]/10 == 0? "  ": " ";
            Console.Write(matrix[i,j] + backSpaces);
        }   
        Console.WriteLine();
    }
}
//------------------------------------------------------------------------------------------------------------------------------+
int[] GetCoordinatesMinValue(int[,] matrix)
{
    int[] coordinatesMinValue = new int[2];
    int    minValue            = 2000;

    for(int i=0;i<matrix.GetLength(0);i++)
        for (int j=0; j<matrix.GetLength(1);j++)
            {
                if(matrix[i,j] < minValue)
                {
                  minValue =  matrix[i,j];
                  coordinatesMinValue[0] = i;
                  coordinatesMinValue[1] = j;
                }  
            }
    return(coordinatesMinValue);
}
//------------------------------------------------------------------------------------------------------------------------------+
int[,] DeleteRowAndColumn(int[,] matrix,int row,int column)
{
    int[,] matrixResized = new int[matrix.GetLength(0)-1,matrix.GetLength(1)-1];
    int rowCounter = 0;
    for(int i=0;i<matrix.GetLength(0);i++)
        {
             int colCounter = 0;
           for (int j=0; j<matrix.GetLength(1);j++)
            {
                if(j==column)
                    continue;
    
                matrixResized[rowCounter,colCounter] = matrix[i,j];
                colCounter++;
            } 
            if(i==row)
                continue;
            rowCounter++;
        }
    return(matrixResized);
}
//------------------------------------------------------------------------------------------------------------------------------+
int    matrixRows     = 10;
int    matrixColumnes = 10;
int[] coordinatesMinValue = new int[2];

Console.WriteLine("\nПолучим матрицу с заполненными значениями.");
int[,] matrix        = GetFilledMatrix(matrixRows,matrixColumnes);
int[,] matrixResized = new int[matrixRows-1,matrixColumnes-1];
PrintIntMatrix(matrix);

Console.WriteLine("\nНайдем координаты элемента с минимальным значением.");
coordinatesMinValue = GetCoordinatesMinValue(matrix);

int minValueInMatrix = matrix[coordinatesMinValue[0],coordinatesMinValue[1]];
Console.WriteLine($"Минимальный элемент в матрице равен {minValueInMatrix}. Координаты в массиве: ряд {coordinatesMinValue[0]+1}, колонка {coordinatesMinValue[1]+1}.");

Console.WriteLine("\nУдалим строку и столбец на пересечении с наименьшим элементом.");
matrixResized = DeleteRowAndColumn(
                            matrix:        matrix,
                            row:           coordinatesMinValue[0],
                            column:        coordinatesMinValue[1]
                            );

Console.WriteLine("/nМатрица после удаления строки и столбца.");
PrintIntMatrix(matrixResized);