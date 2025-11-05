using System;
using System.Diagnostics;
class Program
{
    static void Main(string[] args)
    {
        bool needExit = false;
        while (!needExit)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Отгадай ответ");
            Console.WriteLine("2. Об авторе");
            Console.WriteLine("3. Сортировка массивов");
            Console.WriteLine("4. Выход");
            Console.Write("Ваш выбор: ");
            int choice = InputNumberInt();
            switch (choice)
            {
                case 1:
                    GuessGame();
                    break;
                case 2:
                    Credits();
                    break;
                case 3:
                    SortArrays()
                    break;
                case 4:
                    needExit = ConfirmExit();
                    break;
                default:
                    Console.WriteLine("Ошибка. Введите цифру от 1 до 3.");
                    break;
            }
        }
    }
    static void GuessGame()
    {
        Console.Write("Введите a: ");
        bool validnumberA = false;
        double numberA;
        while (Math.Cos(numberA = InputNumberDouble()) - 1 == 0)
        {
            Console.WriteLine("Некорректный ввод. Деление на ноль недопустимо.");
        }
        Console.Write("Введите число b: ");
        bool validnumberB = false;
        double numberB = InputNumberDouble();
        double result = FunctionResult(numberA, numberB);
        Console.WriteLine("Попробуйте угадать результат вычисления: ");
        bool isRight = LifeGuess(result);
        if (isRight == false)
        {
            Console.WriteLine(string.Format("У вас не осталось попыток, ответом было {0}", result));
        }
        else
        {
            Console.WriteLine("Поздравляю, вы угадали!");
        }
    }
    static void Credits()
    {
        Console.WriteLine("Аверьянов Роман Олегович, 6106-090301D");
    }
    static bool ConfirmExit()
    {
        Console.WriteLine("Вы действительно хотите выйти? 'д' - да, 'н' - нет.");
        bool isChoiceConfirmed = false;
        bool shouldExit = false;
        while (!isChoiceConfirmed)
        {
            string confirmChoice = Console.ReadLine();
            switch (confirmChoice)
            {
                case "д":
                    Console.WriteLine("Выходим из программы.");
                    isChoiceConfirmed = true;
                    shouldExit = true;
                    break;
                case "н":
                    Console.WriteLine("Хорошо, мы не выходим.");
                    isChoiceConfirmed = true;
                    break;
                default:
                    Console.WriteLine("Некорректный ввод. Введите д/н");
                    break;
            }
        }
        return shouldExit;
    }
    static double InputNumberDouble()
    {
        double number;
        while (!double.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("Некорректный ввод.");
        }
        return number;
    }
    static int InputNumberInt()
    {
        int number;
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("Некорректный ввод.");
        }
        return number;
    }
    static double FunctionResult(double numberA, double numberB)
    {
        return Math.Round(Math.Pow(Math.Log(numberB), 2) / Math.Cos(numberA) - 1, 2);
    }
    static bool LifeGuess(double result)
    {
        bool isRight = false;
        int lifeCounter = 3;
        while (lifeCounter != 0 && isRight == false)
        {
            double guessTry = InputNumberDouble();
            if (guessTry == result)
            {
                isRight = true;
            }
            else
            {
                Console.WriteLine("Вы не угадали...");
                --lifeCounter;
                Console.WriteLine(string.Format("У вас осталось {0} попыток", lifeCounter));
            }
        }
        return isRight;
    }
    static int ArraySizeInput()
    {
        int size;
        Console.Write("Введите размер массива: ");
        while (!((size = InputNumberInt()) > 0))
        {
            Console.WriteLine("Длина массива должна быть больше нуля.");
        }
        return size;
    }
    static int[] FillArray(int size)
    {
        int[] array = new int[size];
        Random random = new Random();
        for (int i = 0; i < size; ++i)
        {
            array[i] = random.Next(100);
        }
        return array;
    }
    static void ShowMassive(int[] array)
    {
        if (array.Length > 10)
        {
            Console.WriteLine("Массивы не могут быть выведены на экран, так как длина массива больше 10");
            return;
        }
        for (int i = 0; i < array.Length; ++i)
        {
            Console.Write(string.Format("[{0}], ", array[i]));
        }
        Console.WriteLine("");
        return;
    }
    static int[] CopyMassive(int[] array)
    {
        int[] copy = new int[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            copy[i] = array[i];
        }
        return copy;
    }
    static int[] SortBubble(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
        return array;
    }
    static int[] SortShaker(int[] array)
    {
        {
            int left = 0;
            int right = array.Length - 1;
            bool swapped;
            do
            {
                swapped = false;
                for (int i = left; i < right; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    break;
                }
                right--;
                for (int i = right; i > left; i--)
                {
                    if (array[i] < array[i - 1])
                    {
                        int temp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = temp;
                        swapped = true;
                    }
                }
                left++;
            } while (swapped && left <= right);
        }
        return array;
    }
    static void SortArrays()
    {
        int[] array1 = FillArray(ArraySizeInput());
        int[] array2 = CopyMassive(array1);
        Console.WriteLine("Пробуем вывести массив до сортировки...");
        ShowMassive(array1);
        Stopwatch stopwatchBubble = new Stopwatch();
        Stopwatch stopwatchShaker = new Stopwatch();
        stopwatchBubble.Start();
        Console.WriteLine("Пробуем вывести массив после сортировки пузырьком...");
        ShowMassive(SortBubble(array1));
        stopwatchBubble.Stop();
        TimeSpan BubbleSortTime = stopwatchBubble.Elapsed;
        stopwatchShaker.Start();
        Console.WriteLine("Пробуем вывести массив после сортировки перемешиванием...");
        ShowMassive(SortShaker(array2));
        stopwatchShaker.Stop();
        TimeSpan ShakerSortTime = stopwatchShaker.Elapsed;
        Console.WriteLine("Результаты сравнения сортировок:");
        Console.WriteLine($"Пузырьковая: {BubbleSortTime.TotalMilliseconds:F2} мс");
        Console.WriteLine($"Перемешиванием: {ShakerSortTime.TotalMilliseconds:F2} мс");
        Console.WriteLine($"Перемешиванием быстрее пузырьковой в {BubbleSortTime.TotalMilliseconds / ShakerSortTime.TotalMilliseconds:F2} раз");
    }
}