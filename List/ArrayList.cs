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
        public void AddFirst(int value)
        {
            if (Length == _array.Length)
            {
                UpSize();
            }
            int[] tmpArray = new int[_array.Length];
            tmpArray[0] = value;
            //for (int i = index; i < Length + 1; i++)
            for (int i = 0; i < _array.Length; i++)
            {
                tmpArray[i + 1] = _array[i];
            }
            _array = tmpArray;
            Length++;
        }
        public void AddIndex(int value, int index)
        {
            if (Length == _array.Length)
            {
                UpSize();
            }
            int[] tmpArray = new int[_array.Length];
            tmpArray[index] = value;
            for (int i = index; i < _array.Length; i++)
            {
                tmpArray[i + 1] = _array[i];
            }
            _array = tmpArray;
            Length++;
        }
        public void DeleteLast()
        {
            int[] tmpArray = new int[_array.Length];
            for (int i = 0; i < _array.Length - 1; i++)
            {
                tmpArray[i] = _array[i];
            }
            _array = tmpArray;
            Length--;
            if (Length <= (_array.Length / 2))
            {
                DownSize();
            }
        }
        public void DeleteFirst()
        {
            int[] tmpArray = new int[_array.Length];
            for (int i = _array.Length; i > 0; i--)
            {
                tmpArray[i - 1] = _array[i];
            }
            _array = tmpArray;
            Length--;
            if (Length <= (_array.Length / 2))
            {
                DownSize();
            }
        }
        public void DeleteIndex(int index)
        {
            int[] tmpArray = new int[_array.Length];
            for (int i = 0; i < index; i++)
            {
                tmpArray[i] = _array[i];
            }
            for (int i = index - 1; i < _array.Length - 1; i++)
            {
                tmpArray[i] = _array[i + 1];
            }
            _array = tmpArray;
            Length--;
            if (Length <= (_array.Length / 2))
            {
                DownSize();
            }
        }
        public void DeleteLastN(int N)
        {
            int[] tmpArray = new int[_array.Length];
            for (int i = 0; i < _array.Length - N; i++)
            {
                tmpArray[i] = _array[i];
            }
            _array = tmpArray;
            Length -= N;
            if (Length <= (_array.Length / 2))
            {
                DownSize();
            }
        }
        public void DeleteFirstN(int N)
        {
            int[] tmpArray = new int[_array.Length];
            for (int i = Length; i >= N; i--)
            {
                tmpArray[i - N] = _array[i];
            }
            _array = tmpArray;
            Length -= N;
            if (Length <= (_array.Length / 2))
            {
                DownSize();
            }
        }
        public void DeleteIndexN(int index, int N)
        {
            int[] tmpArray = new int[_array.Length];
            for (int i = 0; i < index - 1; i++)
            {
                tmpArray[i] = _array[i];
            }
            for (int i = index - 1; i < _array.Length - N; i++)
            {
                tmpArray[i] = _array[i + N];
            }
            _array = tmpArray;
            Length -= N;
            if (Length <= (_array.Length / 2))
            {
                DownSize();
            }
        }
        public int GetLength()
        {
            return Length;
        }
        public int GetIndex(int index)
        {
            return _array[index - 1];
        }
        public int GetIndexX(int X)
        {
            int index = -1;
            for (int i = 0; i <= Length; i++)
            {
                if (_array[i] == X)
                {
                    index = i + 1;
                    break;
                }
            }
            return index;
        }
        public void ChangeIndexN(int N, int X)
        {
            _array[N - 1] = X;
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
        public int SearchMax()
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
        public int SearchMin()
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
        public int SearchMaxIndex()
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
        public int SearchMinIndex()
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
        public void SortingOfIncrease()
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
        public void SortingOfDecrease()
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
        public int DeleteFirstX(int X)
        {
            int index = GetIndexX(X);
            if (index>0)
            {
                DeleteIndex(index);
            }
            return index;
        }
        public int DeleteAllX(int X)
        {
            int index = 0;
            int sum = -1;
            while (index >= 0)
            {
                index = GetIndexX(X);
                if (index > 0)
                {
                    DeleteIndex(index);
                }
                sum++;
            }
            return sum;
        }
    }
}
