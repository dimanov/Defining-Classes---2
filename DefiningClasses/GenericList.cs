/*Problem 5. Generic class
Write a generic class GenericList<T> that keeps a list of elements of some parametric type T.
Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor.
Implement methods for adding element, accessing element by index, removing element by index, inserting element at given position, clearing the list, finding element by its value and ToString().
Check all input parameters to avoid accessing elements at invalid positions.
 * 
 * Problem 6. Auto-grow
Implement auto-grow functionality: when the internal array is full, create a new array of double size and move all elements to it.
 * 
 * Problem 7. Min and Max
Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal element in the GenericList<T>.
You may need to add a generic constraints for the type T.
 */
namespace DefiningClasses
{
    using System;
    using System.Text;
    class GenericList<T> where T : IComparable, new()
    {
        const int DefaultCapacity = 16;

        private T[] elements;
        private int count = 0;
        private int capacity;

        public int Capacity
        {
            get { return this.capacity; }
            private set { this.capacity = value; }
        }

        public GenericList(int capacity)
        {
            this.elements = new T[capacity];
            this.Capacity = capacity;
        }

        public GenericList()
            : this(DefaultCapacity)
        {
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Add(T element)
        {
            if (count >= elements.Length)
            {
                this.DoubleSize();
            }
            this.elements[count] = element;
            count++;
        }

        public T RemoveAt(int index)
        {
            if (index >= count || index < 0)
            {
                throw new IndexOutOfRangeException(String.Format(
                    "Invalid index: {0}.", index));
            }
            T result = elements[index];

            for (int i = index; i < count - 1; i++)
            {
                this.elements[i] = this.elements[i + 1];
            }

            this.elements[count - 1] = new T();
            count--;
            return result;
        }

        public void InsertAt(int index, T element)
        {
            if (index > count || index < 0)
            {
                throw new IndexOutOfRangeException(String.Format(
                    "Invalid index: {0}.", index));
            }

            if (index == count)
            {
                this.Add(element);
                return;
            }

            if (count >= this.elements.Length - 1)
            {
                this.DoubleSize();
            }

            count++;

            for (int i = count; i > index; i--)
            {
                this.elements[i] = this.elements[i - 1];
            }

            this.elements[index] = element;
        }

        public T this[int index]
        {
            get
            {
                if (index >= count || index < 0)
                {
                    throw new IndexOutOfRangeException(String.Format(
                        "Invalid index: {0}.", index));
                }
                T result = elements[index];
                return result;
            }
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < count; i++)
            {
                if (this.elements[i].Equals(element))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Clear()
        {
            this.elements = new T[DefaultCapacity];
            this.count = 0;
            this.Capacity = DefaultCapacity;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                result.Append(elements[i]);
                if (i < count - 1)
                {
                    result.Append(", ");
                }
            }

            return result.ToString();
        }

        private void DoubleSize() 
        {
            int newSize = this.elements.Length * 2;
            T[] newData = new T[newSize];

            for (int i = 0; i < count; i++)
            {
                newData[i] = this.elements[i];
            }

            this.elements = newData;
            this.Capacity *= 2;
        }

        public T Min() 
        {
            T min = this.elements[0];

            for (int i = 0; i < count; i++)
            {
                if (this.elements[i].CompareTo(min) < 0)
                {
                    min = this.elements[i];
                }
            }
            return min;
        }

        public T Max()
        {
            T max = this.elements[0];

            for (int i = 0; i < count; i++)
            {
                if (this.elements[i].CompareTo(max) > 0)
                {
                    max = this.elements[i];
                }
            }
            return max;
        }
    }
}
