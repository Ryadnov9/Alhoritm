using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Console.Write("Введіть дліну масива: ");
        if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
        {
            int[] A = GenerateRandomArray(n);

            Console.WriteLine("Початковий  масив:");
            PrintArray(A);
            //Доповнити код засобом підрахування часу сортуванняв   
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            InsertionSort(A);

            stopwatch.Stop();

            Console.WriteLine("Відсортований масив:");
            PrintArray(A);

            Console.WriteLine($"Время сортування: {stopwatch.ElapsedMilliseconds} міллісекунд");
        }
        else
        {
            Console.WriteLine("Введіть коректне число.");
        }
    }
    //Доповнити програму сторенням випадкового масиву
    static int[] GenerateRandomArray(int length)
    {
        Random rand = new Random();
        int[] array = new int[length];

        for (int i = 0; i < length; i++)
        {
            array[i] = rand.Next(100); 
        }

        return array;
    }

    static void InsertionSort(int[] array)
    {
        Stopwatch sortStopwatch = new Stopwatch();
        sortStopwatch.Start();

        for (int k = 1; k < array.Length; k++)
        {
            int b = array[k];
            int j = k - 1;

            while (j >= 0 && array[j] > b)
            {
                array[j + 1] = array[j];
                j--;
            }

            array[j + 1] = b;
        }

        sortStopwatch.Stop();
        Console.WriteLine($"Время сортировки: {sortStopwatch.ElapsedMilliseconds} миллисекунд");
    }

    static void PrintArray(int[] array)
    {
        foreach (int element in array)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }
}
