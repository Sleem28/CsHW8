//Показать треугольник Паскаля *Сделать вывод в виде равнобедренного треугольника
//--------------------------Расчитаем треугольник Паскаля----------------------------------------------------+
int[,] GetPascalTriangle(int triangleHeight)
{
    int triangleWidth = triangleHeight*2 % 2 == 0? triangleHeight*2 + 1: triangleHeight*2;
    int[,] pascalTriangle = new int[triangleHeight,triangleWidth];

    pascalTriangle[0,triangleWidth/2] = 1;
   // pascalTriangle[triangleHeight-1,0]  = 1;
   // pascalTriangle[triangleHeight-1,triangleWidth-1]  = 1;


    for(int i=1;i<pascalTriangle.GetLength(0);i++)
        {
            for(int j=1;j<pascalTriangle.GetLength(1)-1;j++)
                pascalTriangle[i,j] = pascalTriangle[i-1,j-1] + pascalTriangle[i-1,j+1];
        } 

    return(pascalTriangle);
}
//-----------------------------------------------------------------------------------------------------------+
string GetBackSpaces(int num)
{
    string backspaces   = string.Empty;
    int    backspacesLength = 3;
    int    step         = 10;
    bool   isCalculated = false;
    while(!isCalculated)
    {
        if(num/step > 0 || backspacesLength == 0) 
        {
            backspacesLength--;
            num /= step;
        }
        else isCalculated = true;
    }

    for (int i = 0; i <= backspacesLength; i++)
    {
        backspaces += " ";
    }
    return(backspaces);
}
//-----------------------------------------------------------------------------------------------------------+
void PrintTriangle(int[,] pascalTriangle)
{
    for(int i=0;i<pascalTriangle.GetLength(0);i++)
        {
            for(int j=0;j<pascalTriangle.GetLength(1);j++)
                Console.Write(pascalTriangle[i,j] == 0? "    " : pascalTriangle[i,j] + GetBackSpaces(pascalTriangle[i,j]));
            Console.WriteLine();
        }       
}
//-----------------------------------Main--------------------------------------------------------------------+
Console.Write("Введите высоту треугольника Паскаля: ");
int triangleHeight = int.Parse(Console.ReadLine()?? "");

int[,] pascalTriangle = GetPascalTriangle(triangleHeight);
Console.WriteLine();
PrintTriangle(pascalTriangle); 
