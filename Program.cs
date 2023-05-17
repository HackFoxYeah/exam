using System;
namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 11,
                k = 0;
            int[] arr = new int[n];
            Random random = new Random();
            (int, int, int)[] resArr = new (int, int, int)[5]; //здесь хранятся результаты\
            (int, int, int)[] resCopy;
            for (int i = 0; i < n; i++)
            {
                arr[i] = random.Next(-10, 11);
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                if (arr[i] > 0)
                {
                    if (resArr[k].Item3 == 0)
                        resArr[k].Item1 = i; //индекс первого элемента последовательности
                    resArr[k].Item2++; //длина последовательности
                    if (arr[i] < resArr[k].Item3 || resArr[k].Item3 == 0)
                        resArr[k].Item3 = arr[i]; //минимальный элемент текущей последовательности
                }
                else if (resArr[k].Item3 != 0)
                {
                    if (k + 1 == resArr.Length)
                    {
                        resCopy = new (int, int, int)[resArr.Length];
                        Array.Copy(resArr, resCopy, resArr.Length);
                        resArr = new (int, int, int)[resArr.Length + 1];
                        Array.Copy(resCopy, resArr, resCopy.Length);
                    }
                    k++;
                }
                else
                    continue;
            }
            int maxLength = 0,
                minValue = 0,
                indx = 0;
            for (int i = 0; i < resArr.Length; i++)
            {
                if (resArr[i].Item2 > maxLength)
                {
                    indx = resArr[i].Item1;
                    maxLength = resArr[i].Item2;
                    minValue = resArr[i].Item3;
                }
            }
            for (int i = indx; i < indx + maxLength; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine("\nМинимальное значение максимaльно длинной " +
                              "последовательности положительных чисел = " + minValue);
            Console.ReadKey();
        }
    }
}