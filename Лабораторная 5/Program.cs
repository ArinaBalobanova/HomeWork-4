using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Task1();
        Task2();
        Task3();
        Task4();
        Task5();
    }
    /* Упражнение 5.1. Написать метод, возвращающий наибольшее из двух чисел. Входные
       параметры метода – два целых числа. Протестировать метод. */
    static int FindMax(int a, int b)
    {
        return (a > b) ? a : b; // Возвращаем большее из двух чисел
    }

    static void Task1()
    {
        Console.WriteLine("Упражнение 5.1");
        Console.WriteLine("Введите первое целое число:");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите второе целое число:");
        int b = int.Parse(Console.ReadLine());

        int maxNumber = FindMax(a, b);
        if (a == b)
        {
            Console.WriteLine("Числа равны.");
        }
        Console.WriteLine($"Наибольшее из двух чисел: {maxNumber}");
    }

    /*Написать метод, который меняет местами значения двух передаваемых параметров.
    Параметры передавать по ссылке.Протестировать метод. */
    static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    static void Task2()
    {
        Console.WriteLine("Упражнение 5.2");
        Console.WriteLine("Введите первое целое число:");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите второе целое число:");
        int b = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"До обмена: первое число = {a}, второе число = {b}");
        Swap(ref a, ref b); // метод Swap для того, чтобы менять местами параметры 
        Console.WriteLine($"После обмена: первое число = {a}, второе число = {b}");
    }

    /* Упражнение 5.3. Написать метод вычисления факториала числа, результат вычислений
    передавать в выходном параметре. Если метод отработал успешно, то вернуть значение true;
    если в процессе вычисления возникло переполнение, то вернуть значение false. Для 
    отслеживания переполнения значения использовать блок checked. */

    static bool CalculateFactorial(int number, out ulong result)
    {
        result = 1;
        if (number < 0)
        {
            return false;
        }
        for (int a = 2; a <= number; a++)
        {
            try
            {
                result = checked(result * (ulong)a);
            }
            catch (OverflowException)
            {
                return false;
            }
        }
        return true;
    }

    static void Task3()
    {
        Console.WriteLine("Упражнение 5.3");
        Console.WriteLine("Введите число для вычисления факториала:");
        int number = Convert.ToInt32(Console.ReadLine());
        if (CalculateFactorial(number, out ulong factorialResult))
        {
            Console.WriteLine($"Факториал числа {number} равен: {factorialResult}");
        }
        else
        {
            Console.WriteLine("Переполнение значения или неверный ввод числа(нужно неотрицательное число).");
        }
    }

    /* Упражнение 5.4. Написать рекурсивный метод вычисления факториала числа.*/
    static bool Factorial(int number, out ulong result)
    {
        result = 1;
        if (number < 0)
        {
            return false;
        }
        else if (number == 0 || number == 1)
        {
            result = 1;
            return true;
        }
        else
        {
            try
            {
                if (Factorial(number - 1, out ulong tempResult))
                {
                    result = checked((ulong)number * tempResult);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (OverflowException)
            {
                return false;
            }
        }
    }
    static void Task4()
    {
        Console.WriteLine("Упражнение 5.4");
        Console.WriteLine("Введите целое число для вычисления факториала:");
        int number = Convert.ToInt32(Console.ReadLine());
        if (CalculateFactorial(number, out ulong factorialResult))
        {
            Console.WriteLine($"Факториал числа {number} равен: {factorialResult}");
        }
        else
        {
            Console.WriteLine("Переполнение значения или неверный ввод(Число должно быть неотрицательным..).");
        }
    }

    /* Домашнее задание 5.1. Написать метод, который вычисляет НОД двух натуральных чисел (алгоритм Евклида).
    Написать метод с тем же именем, который вычисляет НОД трех натуральных чисел.*/
    static int NOD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
    static int NOD(int a, int b, int c)
    {
        return NOD(NOD(a, b), c);
    }
    static void Task5()
    {
        Console.WriteLine("Домашнее задание 5.1");
        Console.WriteLine("Введите два натуральных числа для вычисления НОД:");
        int a = Convert.ToInt32(Console.ReadLine());
        int b = Convert.ToInt32(Console.ReadLine());

        int ForTwo = NOD(a, b);
        Console.WriteLine($"НОД чисел {a} и {a} равен: {ForTwo}");

        Console.WriteLine("Введите три натуральных числа для вычисления НОД:");
        int x = Convert.ToInt32(Console.ReadLine());
        int y = Convert.ToInt32(Console.ReadLine());
        int z = Convert.ToInt32(Console.ReadLine());

        int ForThree = NOD(x, y, z);
        Console.WriteLine($"НОД чисел {x}, {y} и {z} равен: {ForThree}");
    }
}
