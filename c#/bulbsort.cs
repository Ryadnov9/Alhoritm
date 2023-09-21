using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Console.Write("Введіть дліну масива: ");
        if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
        {
            int[] arr = GenerateRandomArray(n);

            Console.WriteLine("Початковий  масив:");
            PrintArray(arr);
            //Доповнити код засобом підрахування часу сортування
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            BubbleSort(arr);

            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;

            Console.WriteLine("\nВідсортований масив:");
            PrintArray(arr);

            Console.WriteLine($"\nВремя сортування: {elapsedTime.TotalMilliseconds} міллісекунд");
        }
        else
        {
            Console.WriteLine("Введіть коректне число.");
        }
    }
    //Доповнити програму сторенням випадкового масиву
    static int[] GenerateRandomArray(int size)
    {
        int[] arr = new int[size];
        Random rand = new Random();

        for (int i = 0; i < size; i++)
        {
            arr[i] = rand.Next(1, 101); 
        }

        return arr;
    }

    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        bool swapped;

        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;

            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    // Обмін елементів
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;

                    swapped = true;
                }
            }

            // Если внутренний цикл не произвел обмена, то массив уже отсортирован
            // якщо внутрі цико не зробив обмін то масив вже відсортований
            if (!swapped)
                break;
        }
    }

    static void PrintArray(int[] arr)
    {
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}