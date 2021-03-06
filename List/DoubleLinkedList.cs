using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class DoubleLinkedList : IList
    {
        public int Length { get; private set; }
        public int this[int index]
        {
            get
            {
                CheckIndexException(index);
                DoubleNode current = FindNodeByIndex(index);
                return current.Value;
            }
            set
            {
                DoubleNode current = FindNodeByIndex(index);
                current.Value = value;
            }
        }
        private DoubleNode _root;
        private DoubleNode _tail;
        public DoubleLinkedList()
        {
            CreateSpaceList();
        }
        public DoubleLinkedList(int value)
        {
            CreateOneValueList(value);
        }
        public DoubleLinkedList(int[] values)
        {
            if (values.Length != 0)
            {
                _root = new DoubleNode(values[0]);
                _tail = _root;
                for (int i = 1; i < values.Length; i++)
                {
                    _tail.Next = new DoubleNode(values[i]);
                    _tail.Next.Previous = _tail;
                    _tail = _tail.Next;
                }
                Length = values.Length;
            }
            else
            {
                CreateSpaceList();
            }
        }
        public void Add(int value)
        {
            if (Length == 0)
            {
                CreateOneValueList(value);
            }
            else
            {
                _tail.Next = new DoubleNode(value);
                _tail.Next.Previous = _tail;
                _tail = _tail.Next;
                Length++;
            }
        }
        public void AddFirst(int value)
        {
            if (Length == 0)
            {
                CreateOneValueList(value);
            }
            else
            {
                DoubleNode tmp = new DoubleNode(value);
                tmp.Next = _root;
                _root = tmp;
                Length++;
            }
        }

        public void AddByIndex(int value, int index)
        {
            CheckIndexException(index);
            if (Length == 0)
            {
                CreateOneValueList(value);
            }
            else if (index == 0)
            {
                AddFirst(value);
            }
            else if (index == Length)
            {
                Add(value);
            }
            else
            {
                DoubleNode current = FindNodeByIndex(index);
                DoubleNode tmp = new DoubleNode(value);
                tmp.Next = current;
                tmp.Previous = current.Previous;
                current.Previous.Next = tmp;
                current.Previous = tmp;
                Length++;
            }
        }

        public void RemoveLast()
        {
            if (Length <= 0)
            {
                CheckLengthZeroException();
            }
            else
            {
                if (Length == 1)
                {
                    CreateSpaceList();
                }
                else
                {
                    _tail = _tail.Previous;
                    _tail.Next = null;
                    Length--;
                }
            }
            
            
        }

        public void RemoveFirst()
        {
            if (Length == 1)
            {
                CreateSpaceList();
            }
            else
            {
                _root = _root.Next;
                _root.Previous = null;
                Length--;
            }
        }

        public void RemoveByIndex(int index)
        {
            if (Length != 0)
            {
                CheckIndexException(index);
            }
            else
            {
                CheckLengthZeroException();
            }

            if (Length == 1)
            {
                CreateSpaceList();
            }
            else
            {
                if (index == 0)
                {
                    RemoveFirst();
                }
                else
                {
                    if (index == Length - 1)
                    {
                        RemoveLast();
                    }
                    else
                    {
                        DoubleNode current = FindNodeByIndex(index);
                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;
                        Length--;
                    }
                }
            }
        }

        public void RemoveLastElements(int amount)
        {
            if (amount > Length)
            {
                throw new ArgumentOutOfRangeException("массив меньше количества удаляемых элементов");
            }
            CheckElements(amount);
            DoubleNode current = FindNodeByIndex(Length - amount - 1);
            current.Next = null;
            _tail = current;
            Length -= amount;
        }

        public void RemoveFirstElements(int amount)
        {
            DoubleNode current = FindNodeByIndex(amount);
            _root = current;
            _root.Previous = null;
            Length -= amount;
        }

        public void RemoveByIndexElements(int index, int amount)
        {
            CheckIndexException(index);
            if (Length - index < amount)
            {
                throw new IndexOutOfRangeException("длина массива после индекса меньше количества удаляемых элементов");
            }
            CheckElements(amount);
            if (index == 0)
            {
                RemoveFirstElements(amount);
            }
            else
            {
                if (index + amount == Length)
                {
                    RemoveLastElements(amount);
                }
                else
                {
                    DoubleNode current = FindNodeByIndex(index - 1);
                    DoubleNode next = FindNodeByIndex(index + amount);
                    current.Next = next;
                    next.Previous = current;
                    Length -= amount;
                }
            }
        }

        public int GetIndexByValue(int value)
        {
            int index = -1;
            if (Length == 0)
            {
                return index;
            }
            else
            {
                int count = 0;
                DoubleNode current = _root;
                while (!(current is null))
                {
                    if (current.Value == value)
                    {
                        index = count;
                        break;
                    }
                    current = current.Next;
                    count++;
                }
            }
            return index;
        }

        public void Reverse()
        {
            if (!(Length < 2))
            {
                DoubleNode current = _root;
                _tail = _root;
                _tail.Previous = _root.Next;
                DoubleNode tmp = _root;
                current = current.Next;
                while (!(current.Next is null))
                {
                    tmp = current;
                    current = current.Next;
                    tmp.Next = _root;
                    tmp.Previous = current;
                    _root = tmp;
                }

                _tail.Next = null;
                _root = current;
                _root.Next = tmp;
                _root.Previous = null;
            }

            //DoubleNode current = _root;
            //DoubleNode tmp = _root;
            //current = current.Next;
            //while (!(current is null))
            //{
            //    tmp = current;
            //    current = current.Next;
            //    tmp.Next = current.Previous.Previous;

            //    tmp.Previous = current;
            //}
            //_root = tmp;
            //_tail = _root;
            //_tail.Next = null;
            //_root.Previous = null;
        }

        public int GetMax()
        {
            CheckLengthZeroException();
            DoubleNode current = _root;
            int max = current.Value;
            while (!(current is null))
            {
                if (current.Value > max)
                {
                    max = current.Value;
                }
                current = current.Next;
            }
            return max;
        }
        public int GetMin()
        {
            CheckLengthZeroException();
            DoubleNode current = _root;
            int min = current.Value;
            while (!(current is null))
            {
                if (current.Value < min)
                {
                    min = current.Value;
                }
                current = current.Next;
            }
            return min;
        }
        public int GetMaxIndex()
        {
            CheckLengthZeroException();
            DoubleNode current = _root;
            int max = current.Value;
            int index = 0;
            int count = 0;
            while (!(current is null))
            {
                if (current.Value > max)
                {
                    max = current.Value;
                    index = count;
                }
                current = current.Next;
                count++;
            }
            return index;
        }
        public int GetMinIndex()
        {
            CheckLengthZeroException();
            DoubleNode current = _root;
            int min = current.Value;
            int index = 0;
            int count = 0;
            while (!(current is null))
            {
                if (current.Value < min)
                {
                    min = current.Value;
                    index = count;
                }
                current = current.Next;
                count++;
            }
            return index;
        }
        public void UpSort()
        {
            int tmp;
            int tmp2;

            for (int i = 0; i < Length; i++)
            {
                DoubleNode current = _root;
                for (int j = 0; j < Length; j++)
                {
                    if (current.Next != null)
                    {
                        tmp = current.Value;
                        tmp2 = current.Next.Value;
                        if (current.Value > current.Next.Value)
                        {
                            current.Value = tmp2;
                            current.Next.Value = tmp;
                        }
                    }
                    current = current.Next;
                }
            }
            //DoubleNode current = _root;
            //int tmp;
            //while (!(current.Next is null))
            //{
            //    if (current.Value > current.Next.Value)
            //    {
            //        tmp = current.Value;
            //        current.Value = current.Next.Value;
            //        current.Next.Value = tmp;
            //    }
            //    current = current.Next;
            //}
        }
        public void DownSort()
        {
            int tmp;
            int tmp2;

            for (int i = 0; i < Length; i++)
            {
                DoubleNode current = _root;
                for (int j = 0; j < Length; j++)
                {
                    if (current.Next != null)
                    {
                        tmp = current.Value;
                        tmp2 = current.Next.Value;
                        if (current.Value < current.Next.Value)
                        {
                            current.Value = tmp2;
                            current.Next.Value = tmp;
                        }
                    }
                    current = current.Next;
                }
            }
        }
        public int RemoveFirstByValue(int value)
        {
            int index = GetIndexByValue(value);
            if (index >= 0)
            {
                RemoveByIndex(index);
            }
            return index;
        }
        public int RemoveAllByValue(int value)
        {
            int index = 0;
            int sum = -1;
            while (index != -1)
            {
                index = GetIndexByValue(value);
                if (index >= 0)
                {
                    RemoveByIndex(index);
                    sum++;
                }
            }
            if (sum >= 0)
            {
                sum++;
            }
            return sum;
        }

        public void CopyArrayAtTheEnd(int[] newArray)
        {
            DoubleLinkedList tmp = new DoubleLinkedList(newArray);
            if (Length == 0)
            {
                _root = tmp._root;
                _tail = tmp._tail;
                Length = tmp.Length;
            }
            else
            {
                DoubleNode current = _tail;
                current.Next = tmp._root;
                Length = tmp.Length + Length;
                _tail = tmp._tail;
            }
        }

        public void CopyArrayAtTheStart(int[] newArray)
        {
            DoubleLinkedList tmp = new DoubleLinkedList(newArray);
            if (Length == 0)
            {
                _root = tmp._root;
                _tail = tmp._tail;
                Length = tmp.Length;
            }
            else
            {
                tmp._tail.Next = _root;
                _root = tmp._root;
                Length += tmp.Length;
            }
        }

        public void CopyArrayAtTheIndex(int index, int[] newArray)
        {
            CheckIndexException(index);
            if (index == 0)
            {
                CopyArrayAtTheStart(newArray);
            }
            else
            if (index == Length)
            {
                CopyArrayAtTheEnd(newArray);
            }
            else
            {
                DoubleLinkedList tmp = new DoubleLinkedList(newArray);
                DoubleNode current = FindNodeByIndex(index - 1);
                tmp._tail.Next = current.Next;
                current.Next = tmp._root;
                Length += tmp.Length;
            }
        }

        public override string ToString()
        {
            if (Length != 0)
            {
                DoubleNode current = _root;
                string s = current.Value + " ";

                while (!(current.Next is null))
                {
                    current = current.Next;
                    s += current.Value + " ";
                }

                return s;
            }
            else
            {
                return String.Empty;
            }
        }

        public override bool Equals(object obj)
        {
            DoubleLinkedList list = (DoubleLinkedList)obj;
            if (this.Length != list.Length)
            {
                return false;
            }
            if (this.Length == 0)
            {
                return true;
            }
            if (this._tail.Value != list._tail.Value)
            {
                return false;
            }
            if (!(this._tail.Next is null) || !(list._tail.Next is null))
            {
                return false;
            }
            if (!(this._root.Previous is null) || !(list._root.Previous is null))
            {
                return false;
            }
            DoubleNode currentThis = this._root;
            DoubleNode currentList = list._root;

            while (!(currentThis.Next is null))
            {
                if (currentThis.Value != currentList.Value)
                {
                    return false;
                }
                currentList = currentList.Next;
                currentThis = currentThis.Next;
            }
            if (currentThis.Value != currentList.Value)
            {
                return false;
            }
            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        private void CreateSpaceList()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }

        private void CreateOneValueList(int value)
        {
            Length = 1;
            _root = new DoubleNode(value);
            _tail = _root;
        }

        private DoubleNode FindNodeByIndex(int index)
        {
            DoubleNode current;
            if (index + 1 > Length / 2)
            {
                current = _tail;
                for (int i = 1; i <= Length - index - 1; i++)
                {
                    current = current.Previous;
                }
            }
            else
            {
                current = _root;
                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;
                }
            }
            return current;
        }
        private void CheckElements(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("нельзя удалить отрицательное количество элементов");
            }
        }
        private void CheckIndexException(int index)
        {
            if (index > Length || index < 0)
            {
                throw new IndexOutOfRangeException("индекс не входит в массив");
            }
        }
        private void CheckLengthZeroException()
        {
            if (Length <= 0)
            {
                throw new IndexOutOfRangeException("массив пустой");
            }
        }
    }
}
