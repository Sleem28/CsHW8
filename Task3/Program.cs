// Сформировать трехмерный массив не повторяющимися двузначными числами показать его построчно на экран выводя индексы соответствующего элемента
//-------------------------------------Заполним массив разными вдузначными числами----------------------------------------------+
int[,,] GetFilled3DArray(int length,int height, int deep)
{
    int[,,] threeDArray = new int[length,height,deep];

    for(int i=0;i<threeDArray.GetLength(0);i++)
        for (int j=0; j<threeDArray.GetLength(1);j++)
            for (int k=0; k<threeDArray.GetLength(2);k++)
                    threeDArray[i,j,k] = GetDifferentValue(
                                                          threeDArray:            threeDArray,
                                                          finishIndexFirstLevel:  i,
                                                          finishIndexSecondLevel: j,
                                                          finishIndexThirdLevel:  k
                                                          );  
    return(threeDArray);    
}
//-------------------------------------Получим целочисленное значение с проверкой на уникальность числа-------------------------+
int GetDifferentValue(int[,,] threeDArray,
                      int     finishIndexFirstLevel, 
                      int     finishIndexSecondLevel,
                      int     finishIndexThirdLevel
                      )
{
    if(threeDArray.Length > 90) return(-1);

    Random rnd          = new Random();
    int    value        = 0;
    bool   foundTheSame =  true;
    while(foundTheSame)
    {
        value = rnd.Next(10,100);
        foundTheSame = false;

        for(int i=0;i<=finishIndexFirstLevel;i++)
        {
            for (int j=0; j<=finishIndexSecondLevel;j++)
            {
                for (int k=0;k<finishIndexThirdLevel;k++)
                {
                    if(threeDArray[i,j,k]==value) 
                        {
                            foundTheSame = true;
                            break;
                        }
                }
                if(foundTheSame) break;
            }
            if(foundTheSame) break;
        }          
    }
    return(value);
}
//------------------------------------------------------------------------------------------------------------------------------+
void SpecialPrintThreeDArray(int[,,] threeDArray)
{
    for(int i=0;i<threeDArray.GetLength(0);i++)
        for (int j=0; j<threeDArray.GetLength(1);j++)
            for (int k=0; k<threeDArray.GetLength(2);k++)
                Console.WriteLine($"Индекс первого уровня {i+1}, второго уровня {j+1}, третьего уровня {k+1}. Число по индексам {threeDArray[i,j,k]}.");
}
//-----------------------------------------------------Main-------------------------------------------------------------------------+
int length = 3; //Двузначные числа находятся в диапазоне от 10 до 99. Соответственно это 90 элементов. 
int height = 5; //Значит нужно сделать 3Д массив на 90 элементов. Подходит размерность 3 х 5 х 6.
int deep   = 6;

Console.Clear();
Console.WriteLine("\nСоздадим трехмерный массив и напечатаем его построчно с выводом индексов.\n");
int[,,] threeDArray = GetFilled3DArray(
                                      length: length,
                                      height: height,
                                      deep:   deep
                                      );
SpecialPrintThreeDArray(threeDArray);
