using bsbo_1011_2022;
using System;

internal class Application
{
    public static int N_OP = 0;

    // Вывод в консоль содержимого массива
    static void PrintArr(int[] arr)
    {
        foreach(int i in arr)
        {
            Console.Write($"{i} ");
        }
        Console.WriteLine();
    }

    // Сортировка пузырьком массива
    static void SortArr()
    {
        int N = 5;
        int[] arr = new int[] { 14, 28, 7, -2, 0 };
        // 14, 7, -2, 0 | 28
        // 7, -2, 0 | 14, 28
        // -2, 0 | 7, 14, 28
        // -2 | 0, 7, 14, 28

        PrintArr(arr);

        bool flagSwap = false;

        for (int i = 0; i < N; i++)
        {
            flagSwap = false;
            for (int j = 0; j < N - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    // 1) С доп. памятью
                    // O(2 + 4 + 3 = 9), M(1)
                    //int tmp = arr[j];
                    //arr[j] = arr[j + 1];
                    //arr[j + 1] = tmp;

                    // 2) Без доп. памяти
                    // [28, 7] 
                    // 1) [28, 35] ([2] = [1] + [2])
                    // 2) [7, 35] ([1] = [2] - [1])
                    // 3) [7, 28] ([2] = [2] - [1])
                    // O(7 + 6 + 7 = 20), M(0)
                    //arr[j + 1] = arr[j + 1] + arr[j];
                    //arr[j] = arr[j + 1] - arr[j];
                    //arr[j + 1] = arr[j + 1] - arr[j];

                    // 3) TupleValue Swap
                    // O(6 + k), M(2k)
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    flagSwap = true;
                }
            }

            if (!flagSwap)
                break;
        }

        PrintArr(arr);
    }

    // Демонстрация хранения структуры и класса в памяти
    static void RefvsValType()
    {
        // RefTypes
        // Тут создаются классы
        Element a = new Element(15);
        Element b = a;

        // a = 15, b = 15;
        Console.WriteLine($"a: {a.value}, b: {b.value}");
        b.value = 27;
        // a = 27, b = 27;
        Console.WriteLine($"a: {a.value}, b: {b.value}");

        // Value Types
        // Тут создаются структуры
        ElemValue p = new ElemValue(15);
        ElemValue l = p;

        // a = 15, b = 15;
        Console.WriteLine($"p: {p.value}, l: {l.value}");
        l.value = 27;
        // a = 15, b = 27;
        Console.WriteLine($"p: {p.value}, l: {l.value}");
    }

    // Создание ссылок на следующий элемент
    static void RefNext()
    {
        Element a = new Element(15);
        Element b = new Element(12);
        a.next = b;

        Console.WriteLine($"a: {a.value}, a->next: {a.next.value}");
    }

    // Пользовательские исключения и ошибки
    static void UserExceptions()
    {
        int a = 2;
        int b = 0;

        try
        {
            Console.WriteLine(a / b);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            Console.WriteLine("Success");
        }


        try
        {
            throw new Exception("Test exception");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            Console.WriteLine("Success 2");
        }
    }

    // Сортировка линейного списка алгоримтом пузырька
    static void SortListElem()
    {
        ListElem list = new ListElem();
        Random rnd = new Random();
        int N = 500;

        for (int i = 0; i < N; i++)
        {
            list.Push(new Element(rnd.Next(0, 100)));
        }

        list.Print();

        // START N_OP CALCULATE


        bool flagSwap = false; // 1
        Application.N_OP += 3;
        for (int i = 0; i < N; i++) // 2
        {
            flagSwap = false; // 1

            Application.N_OP += 5;
            for (int j = 0; j < N - i - 1; j++) // 4
            {
                Application.N_OP += 4;
                if (list[j] > list[j + 1]) // 4
                {
                    Application.N_OP += 13;
                    (list[j], list[j + 1]) = (list[j + 1], list[j]); // 6 + 4 + 2
                    flagSwap = true; // 1
                }

                Application.N_OP += 4;
                // 4
            }


            if (!flagSwap) // 1
            {
                Application.N_OP += 1;
                break;
            }
                
            Application.N_OP += 3;
            // 2
        }

        // END N_OP CALCULATE

        list.Print();
        Console.WriteLine($"N_OP: {Application.N_OP}");
    }

    // Объявляем временный стэк для перестановок элементов
    public static Stack tmp = new Stack();

    // Сортировка стэка алгоримтом пузырька
    static void StackSort()
    {
        Stack stack = new Stack();
        Random rnd = new Random();
        int N = 5;

        for (int i = 0; i < N; i++)
        {
            stack.Push(new Element(rnd.Next(0, 100)));
        }

        stack.Print();

        bool flagSwap = false;
        for (int i = 0; i < N; i++)
        {
            flagSwap = false;

            for (int j = 0; j < N - i - 1; j++)
            {
                if (stack[j] > stack[j + 1])
                {
                    (stack[j], stack[j + 1]) = (stack[j + 1], stack[j]);
                    flagSwap = true;
                }
            }

            if (!flagSwap)
                break;
        }

        stack.Print();
    }

    static void Main(string[] args)
    {
        //SortArr();
        //RefvsValType();
        //RefNext();
        //UserExceptions();
        SortListElem();
        //StackSort();
    }
}