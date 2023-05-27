using System;
namespace bsbo_1011_2022
{
	public class ListElem
	{
		protected Element? top = null;

		// Проверка на пустой ли список
		public bool isEmpty()
		{
			Application.N_OP += 1;
            return top == null;
        }

		// Добавление нового элемента в начало списка
		public void Push(Element elem)
		{
			Application.N_OP += 2;
            if (!isEmpty()) // 2
			{
				elem.next = top; // 2
				Application.N_OP += 2;
            }

			top = elem; // 1
			Application.N_OP += 1;

        }

		// Извлечение элемента из начала списка
		public Element Pop()
		{
			Application.N_OP += 1;

            if (isEmpty()) // 1
			{
				throw new Exception("ListElem is empty!");
			}


			Element result = top; // 1
			top = top.next; // 2

			result.next = null; // 2

			Application.N_OP += 5;


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
			Application.N_OP += 1;
            Element current = top; // 1
			Application.N_OP += 2;
            for (int i = 1; i < index; i++) // 2
			{
				current = current.next; // 2

				if (current == null) // 1
				{
					throw new Exception("Out of range in ListElem!");
				}

				Application.N_OP += 5;
				// 2
            }


			return current.value; // 1
        }

        // Получение доступа к i-тому элементу на запись value
        public void Set(int index, int newValue)
		{
            Element current = top; // 1
			Application.N_OP += 3;
			// 2
            for (int i = 1; i < index; i++)
            {
                current = current.next; // 2

                if (current == null) // 1
                {
                    throw new Exception("Out of range in ListElem!");
                }

				Application.N_OP += 5;
				// 2
            }

			current.value = newValue; // 2
									  // 2
			Application.N_OP += 4;
        }

		// Перегрузка оператора индексации [] (как у массива)
		public virtual int this[int index]
		{
			get
			{
				Application.N_OP += 2;
                return Get(index);
			}
			set
			{
				Application.N_OP += 3;
                Set(index, value);
			}
		}
	}
}

