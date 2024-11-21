using System;

class Program
{
    static void Main(string[] args)
    {
        Task1();
        Task2();
    }
    /*Задание 1.Вывести на экран массив из 20 случайных чисел.Ввести два числа из этого массива,
        которые нужно поменять местами. Вывести на экран получившийся массив.*/
        static void PrintArray(int[] array)
    {
        foreach (int number in array)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }
    static void Task1()
    {
        Console.WriteLine("1");
        Random random = new Random();
        int[] array = new int[20];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(1, 101);
        }
        Console.WriteLine("Исходный массив:");
        PrintArray(array);

        Console.WriteLine("Введите первое число для замены:");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите второе число для замены:");
        int b = Convert.ToInt32(Console.ReadLine());

        int firstIndex = Array.IndexOf(array, a);
        int secondIndex = Array.IndexOf(array, b);
        if (firstIndex != -1 && secondIndex != -1)
        {
            int temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;
            Console.WriteLine("Массив после замены:");
            PrintArray(array);
        }
        else
        {
            Console.WriteLine("Ошибка про вводе чисел массива!");
        }
    }
    /* Задание 2. Написать метод, где в качества аргумента будет передан массив (ключевое слово params).
    Вывести сумму элементов массива (вернуть). Вывести (ref) произведение массива.
    Вывести (out) среднее арифметическое в массиве.*/
    static double CalculateStats(out double average, ref double product, params double[] numbers)
    {
        double sum = 0;
        product = 1;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
            product *= numbers[i];
        }
        average = numbers.Length > 0 ? sum / numbers.Length : 0;

        return sum;
    }
    static void Task2()
    {
        {
            Console.WriteLine("2");
            double product = 1;
            double sum = CalculateStats(out double average, ref product, 3, 4, 5, 6, 7);
            Console.WriteLine($"Сумма элементов массива: {sum}");
            Console.WriteLine($"Произведение элементов массива: {product}");
            Console.WriteLine($"Среднее арифметическое: {average}");
        }
    }
}