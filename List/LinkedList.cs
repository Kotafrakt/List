using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class LinkedList: IList
    {
        public int Length { get; private set; }
        public int this[int index]
        {
            get
            {
                Node current = FindNodeByIndex(index);
                return current.Value;
            }
            set
            {
                Node current = FindNodeByIndex(index);
                current.Value = value;
            }
        }
        private Node _root;
        private Node _tail;
        public LinkedList()
        {
            CreateSpaceList();
        }
        public LinkedList(int value)
        {
            CreateOneValueList(value);
        }
        public LinkedList(int[] values)
        {
            if (values.Length != 0)
            {
                _root = new Node(values[0]);
                _tail = _root;
                for (int i = 1; i < values.Length; i++)
                {
                    _tail.Next = new Node(values[i]);
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
                _tail.Next = new Node(value);
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
                Node tmp = new Node(value);
                tmp.Next = _root;
                _root = tmp;
                Length++;
            }
        }

        public void AddByIndex(int value, int index)
        {
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
                Node current = FindNodeByIndex(index - 1);
                Node tmp = new Node(value);
                tmp.Next = current.Next;
                current.Next = tmp;
                Length++;
            }
        }

        public void RemoveLast()
        {
            if (Length == 1)
            {
                _root = null;
            }
            if (Length == 2)
            {
                _root.Next = null;
                _tail = _root;
            }
            if (Length > 2)
            {
                Node current = FindNodeByIndex(Length - 2);
                current.Next = null;
                _tail = current;
            }
            Length--;
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
                Length--;
            }
        }

        public void RemoveByIndex(int index)
        {
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
                        Node current = FindNodeByIndex(index - 1);
                        current.Next = current.Next.Next;
                        Length--;
                    }
                }
            }
        }

        public void RemoveLastElements(int amount)
        {
            Node current = FindNodeByIndex(Length - amount - 1);
            current.Next = null;
            _tail = current;
            Length -= amount;
        }

        public void RemoveFirstElements(int amount)
        {
            Node current = FindNodeByIndex(amount);
            _root = current;
            Length -= amount;
        }

        public void RemoveByIndexElements(int index, int amount)
        {
            Node current = FindNodeByIndex(index - 1);
            Node next = FindNodeByIndex(index + amount);
            current.Next = next;
            if (Length == index + amount)
            {
                _tail = current;
            }
            Length -= amount;
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
                Node current = _root;
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
            //Node current = _root;
            //_tail = _root;
            //Node tmp = _root;
            //current = current.Next;
            //while (!(current.Next is null))
            //{
            //    tmp = current;
            //    current = current.Next;
            //    tmp.Next = _tail;
            //    _tail = tmp;
            //}
            //_root.Next = null;
            //_tail = _root;
            //_root = current;
            //_root.Next = tmp;

            if (!(Length<2))
            {
                Node current = _root;
                _tail = _root;
                Node tmp = _root;
                current = current.Next;
                while (!(current.Next is null))
                {
                    tmp = current;
                    current = current.Next;
                    tmp.Next = _root;
                    _root = tmp;
                }
                _tail.Next = null;
                _root = current;
                _root.Next = tmp;
            }
        }

        public int GetMax()
        {
            Node current = _root;
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
            Node current = _root;
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
            Node current = _root;
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
            Node current = _root;
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
            Node current = _root;
            int tmp;
            while (!(current.Next is null))
            {
                if (current.Value > current.Next.Value)
                {
                    tmp = current.Value;
                    current.Value = current.Next.Value;
                    current.Next.Value = tmp;
                }
                current = current.Next;
            }
        }
        public void DownSort()
        {
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
            throw new NotImplementedException();
        }

        public void CopyArrayAtTheStart(int[] newArray)
        {
            throw new NotImplementedException();
        }

        public void CopyArrayAtTheIndex(int index, int[] newArray)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            if (Length != 0)
            {
                Node current = _root;
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

        //public override bool Equals(object obj)
        //{
        //    LinkedList list = (LinkedList)obj;

        //    if (this.Length != list.Length)
        //    {
        //        return false;
        //    }

        //    Node currentThis = this._root;
        //    Node currentList = list._root;

        //    do
        //    {
        //        if (currentThis.Value != currentList.Value)
        //        {
        //            return false;
        //        }
        //        currentList = currentList.Next;
        //        currentThis = currentThis.Next;
        //    }
        //    while (!(currentThis.Next is null));

        //    return true;
        //}
        public override bool Equals(object obj)
        {
            LinkedList list = (LinkedList)obj;
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
            Node currentThis = this._root;
            Node currentList = list._root;

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
            _root = new Node(value);
            _tail = _root;
        }

        private Node FindNodeByIndex(int index)
        {
            Node current = _root;
            for (int i = 1; i <= index; i++)
            {
                current = current.Next;
            }
            return current;
        }
    }
}
