using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class ArrayList
    {
        public int Length { get; private set; }
        private int[] _array;
        public ArrayList()
        {
            Length = 0;
            _array = new int[10];
        }
        public void Add(int value)
        {
            if (Length == _array.Length)
            {
                UpSize();
            }
            _array[Length] = value;
            Length++;
        }
        public void AddFirst(int value)
        {
            AddByIndex(value, 0);
        }
        public void AddByIndex(int value, int index)
        {
            if (Length == _array.Length)
            {
                UpSize();
            }
            for (int i = Length; i > index; i--)
            {
                _array[i] = _array[i - 1];
            }
            _array[index] = value;
            Length++;
        }
        public void RemoveLast()
        {
            Length--;
            if (Length <= (_array.Length / 2))
            {
                DownSize();
            }
        }
        public void RemoveFirst()
        {
            RemoveByIndex(0);
        }
        public void RemoveByIndex(int index)
        {
            for (int i = index; i < Length - 1; i++)
            {
                _array[i] = _array[i + 1];
            }
            Length--;
            if (Length <= (_array.Length / 2))
            {
                DownSize();
            }
        }
        public void RemoveLastElements(int n)
        {
            Length -= n;
            if (Length <= (_array.Length / 2))
            {
                DownSize();
            }
        }
        public void RemoveFirstElements(int n)
        {
            RemoveByIndexElements(0, n);
        }
        public void RemoveByIndexElements(int index, int n)
        {
            for (int i = index; i < Length - n; i++)
            {
                _array[i] = _array[i + n];
            }
            Length -= n;
            if (Length <= (_array.Length / 2))
            {
                DownSize();
            }
        }
        public int GetByIndex(int index)
        {
            return _array[index];
        }
        public int GetIndexByValue(int value)
        {
            int index = -1;
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        public void ChangeValueByIndex(int index, int value)
        {
            _array[index] = value;
        }

        public void Reverse()
        {
            int tmpArrayX;
            for (int i = 0; i < (Length / 2); i++)
            {
                tmpArrayX = _array[i];
                int x = Length - i - 1;
                _array[i] = _array[x];
                _array[x] = tmpArrayX;
            }
        }
        public int GetMax()
        {
            int max = _array[0];
            for (int i = 1; i < Length; i++)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                }
            }
            return max;
        }
        public int GetMin()
        {
            int min = _array[0];
            for (int i = 1; i < Length; i++)
            {
                if (min > _array[i])
                {
                    min = _array[i];
                }
            }
            return min;
        }
        public int GetMaxIndex()
        {
            int max = _array[0];
            int index = 0;
            for (int i = 1; i < Length; i++)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                    index = i;
                }
            }
            return index + 1;
        }
        public int GetMinIndex()
        {
            int min = _array[0];
            int index = 0;

            for (int i = 1; i < Length; i++)
            {
                if (min > _array[i])
                {
                    min = _array[i];
                    index = i;
                }
            }
            return index + 1;
        }
        public void UpSort()
        {
            int tmp;
            for (int i = 0; i < Length; i++)
            {
                for (int j = i + 1; j < Length; j++)
                {
                    if (_array[i] > _array[j])
                    {
                        tmp = _array[i];
                        _array[i] = _array[j];
                        _array[j] = tmp;
                    }
                }
            }
        }
        public void DownSort()
        {
            int tmp;
            for (int i = 0; i < Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)

                {
                    if (_array[j - 1] < _array[j])
                    {
                        tmp = _array[j - 1];
                        _array[j - 1] = _array[j];
                        _array[j] = tmp;
                    }
                }
            }
        }
        public int DeleteFirstByValue(int x)
        {
            int index = GetIndexByValue(x);
            if (index > 0)
            {
                RemoveByIndex(index);
            }
            return index;
        }
        public int DeleteAllByValue(int x)
        {
            int index = 0;
            int sum = -1;
            while (index != -1)
            {
                index = GetIndexByValue(x);
                if (index >= 0)
                {
                    RemoveByIndex(index);
                    sum++;
                }
            }
            if (sum > 0)
            {
                sum++;
            }
            return sum;
        }
        private void UpSize()
        {
            int newLength = (int)(_array.Length * 1.33d + 1);
            int[] tmpArray = new int[newLength];
            for (int i = 0; i < _array.Length; i++)
            {
                tmpArray[i] = _array[i];
            }
            _array = tmpArray;
        }
        private void DownSize()
        {
            int newLength = (int)(_array.Length * 0.67d + 1);
            int[] tmpArray = new int[newLength];
            for (int i = 0; i < tmpArray.Length; i++)
            {
                tmpArray[i] = _array[i];
            }
            _array = tmpArray;
        }
    }
}
