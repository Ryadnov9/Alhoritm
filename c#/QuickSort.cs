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

            Console.Write("Початковий масив: ");
            PrintArray(A);
            //Доповнити код засобом підрахування часу сортування//
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Hoare(A, 0, n - 1);

            stopwatch.Stop();
            TimeSpan elapsed = stopwatch.Elapsed;

            Console.Write("Відсортований масив: ");
            PrintArray(A);

            Console.WriteLine($"Время сортування: {elapsed.TotalMilliseconds} міллісекунд");
        }
        else
        {
            Console.WriteLine("Введть коректне число.");
        }
    }

    static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    static void Hoare(int[] array, int L, int R)
    {
        if (L < R)
        {
            int x = array[(L + R) / 2];
            int left = L;
            int right = R;

            while (true)
            {
                while (array[left] < x)
                {
                    left++;
                }

                while (array[right] > x)
                {
                    right--;
                }

                if (left <= right)
                {
                    Swap(array, left, right);
                    left++;
                    right--;
                }

                if (left > right)
                {
                    break;
                }
            }

            Hoare(array, L, right);
            Hoare(array, left, R);
        }
    }
    //Доповнити програму сторенням випадкового масиву//
    static int[] GenerateRandomArray(int length)
    {
        Random random = new Random();
        int[] array = new int[length];
        for (int i = 0; i < length; i++)
        {
            array[i] = random.Next(1, 102); // 
        }
        return array;
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
