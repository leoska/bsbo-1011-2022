using System;
namespace bsbo_1011_2022
{
    public class Stack : ListElem
    {
        // Перегрузка оператора индексации [] (как у массива)
        public override int this[int index] {
            get => Get(index, Application.tmp);
            set => Set(index, value, Application.tmp);
        }

        // Получение доступа к i-тому элементу на чтение value
        public int Get(int index, Stack tmp)
        {
            if (isEmpty())
            {
                throw new Exception("Stack is empty!");
            }

            for (int i = 0; i < index; i++)
            {
                tmp.Push(Pop());

                if (isEmpty())
                {
                    while (!tmp.isEmpty())
                        Push(tmp.Pop());

                    throw new Exception("Out of Range in Stack!");
                }
            }

            int result = top.value;

            while (!tmp.isEmpty())
                Push(tmp.Pop());

            return result;
        }

        // Получение доступа к i-тому элементу на запись value
        public void Set(int index, int newValue, Stack tmp)
        {
            if (isEmpty())
            {
                throw new Exception("Stack is empty!");
            }

            for (int i = 0; i < index; i++)
            {
                tmp.Push(Pop());

                if (isEmpty())
                {
                    while (!tmp.isEmpty())
                        Push(tmp.Pop());

                    throw new Exception("Out of Range in Stack!");
                }
            }

            top.value = newValue;

            while (!tmp.isEmpty())
                Push(tmp.Pop());
        }
    }
}

