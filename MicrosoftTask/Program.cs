using System;
using System.Diagnostics;

class Program{
    static void Main()
    {
        int[,] arr = 
        {
            { 1, 0, 1, 1, 0 },
            { 1, 0, 0, 0, 1 },
            { 0, 1, 1, 1, 0 },
            { 1, 1, 1, 1, 1 },
            { 0, 1, 1, 1, 1 },
            { 1, 1, 0, 1, 1 }
        };
        var sw = Stopwatch.StartNew();

        int rows = arr.GetLength(0);
        int cols = arr.GetLength(1);
        int maxSide = 0;
        
        for (int i = 0; i < rows; i++)
        {
            if(rows-i <= maxSide) break;

            for (int j = 0; j < cols; j++)
            {
                if (cols - j <= maxSide) break;

                if (arr[i,j] == 1)
                {
                    int currSide = 1;
                    bool canExpand = true;

                    while (i + currSide < rows && j + currSide < cols && canExpand)
                    {
                        for (int r = i; r <= i + currSide; r++)
                        {
                            if (arr[r, j + currSide] == 0)
                            {
                                canExpand = false;
                                break;
                            }
                        }

                        if (canExpand)
                        {
                            for (int c = j; c < j + currSide; c++)
                            {
                                if (arr[i + currSide, c] == 0)
                                {
                                    canExpand = false;
                                    break;
                                }
                            }
                        }

                        if (canExpand)
                            currSide++;
                    }
                    
                    if(currSide > maxSide)
                        maxSide = currSide;
                }
            }
        }

        sw.Stop();

        Console.WriteLine(maxSide * maxSide);
        Console.WriteLine("Время выполнения: " + sw.Elapsed.TotalMilliseconds);
    }
}