using System;
namespace bsbo_1011_2022
{
	public class ListElem
	{
		protected Element? top = null;

		// Проверка на пустой ли список
		public bool isEmpty()
		{
			return top == null;
        }

		// Добавление нового элемента в начало списка
		public void Push(Element elem)
		{
			if (!isEmpty())
			{
				elem.next = top;
            }

			top = elem;
		}

		// Извлечение элемента из начала списка
		public Element Pop()
		{
			if (isEmpty())
			{
				throw new Exception("ListElem is empty!");
			}

			Element result = top;
			top = top.next;

			result.next = null;

			return result;
        }

		// Вывод в консоль нашего списка
		public void Print()
		{
			Element current = top;
			while(current != null)
			{
				Console.Write($"{current.value} ");
				current = current.next;
            }
			Console.WriteLine();
        }

		// Получение доступа к i-тому элементу на чтение value
		public int Get(int index)
		{
            Element current = top;
			for (int i = 1; i < index; i++)
			{
				current = current.next;

				if (current == null)
				{
					throw new Exception("Out of range in ListElem!");
				}
            }

			return current.value;
        }

        // Получение доступа к i-тому элементу на запись value
        public void Set(int index, int newValue)
		{
            Element current = top;
            for (int i = 1; i < index; i++)
            {
                current = current.next;

                if (current == null)
                {
                    throw new Exception("Out of range in ListElem!");
                }
            }

			current.value = newValue;
        }

		// Перегрузка оператора индексации [] (как у массива)
		public virtual int this[int index]
		{
			get => Get(index);
			set => Set(index, value);
		}
	}
}

