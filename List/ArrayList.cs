using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class ArrayList: IList
    {
        public int Length { get; private set; }
        private int[] _array;
        public ArrayList()
        {
            Length = 0;
            _array = new int[10];
        }
        public ArrayList(int value)
        {
            Length = 1;
            _array = new int[10];
            _array[0] = value;
        }
        public ArrayList(int[] array)
        {
            _array = array;
            Length = _array.Length;
        }
        public int this[int index]
        {
            get
            {
                CheckIndexException(index);
                return _array[index];
            }
            set
            {
                _array[index] = value;
            }
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
            CheckIndexException(index);
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
            if (Length != 0)
            {
                Length--;
                if (Length < (_array.Length / 2))
                {
                    DownSize();
                }
            }
            else
            {
                CheckLengthZeroException();
            }
        }
        public void RemoveFirst()
        {
            RemoveByIndex(0);
        }
        public void RemoveByIndex(int index)
        {
            if (Length != 0)
            {
                CheckIndexException(index);
                for (int i = index; i < Length - 1; i++)
                {
                    _array[i] = _array[i + 1];
                }
                Length--;
                if (Length < (_array.Length / 2))
                {
                    DownSize();
                }
            }
            else
            {
                CheckLengthZeroException();
            }
        }
        public void RemoveLastElements(int n)
        {
            if (n > Length)
            {
                throw new ArgumentOutOfRangeException("массив меньше количества удаляемых элементов");
            }
            CheckElements(n);
            Length -= n;
            if (Length < (_array.Length / 2))
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
            CheckIndexException(index);
            if (Length - index < n)
            {
                throw new IndexOutOfRangeException("длина массива после индекса меньше количества удаляемых элементов");
            }
            CheckElements(n);
            for (int i = index; i < Length - n; i++)
            {
                _array[i] = _array[i + n];
            }
            Length -= n;
            if (Length < (_array.Length / 2))
            {
                DownSize();
            }
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
            CheckLengthZeroException();
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
            CheckLengthZeroException();
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
            CheckLengthZeroException();
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
            return index;
        }
        public int GetMinIndex()
        {
            CheckLengthZeroException();
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
            return index;
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
        public int RemoveFirstByValue(int x)
        {
            int index = GetIndexByValue(x);
            if (index >= 0)
            {
                RemoveByIndex(index);
            }
            return index;
        }
        public int RemoveAllByValue(int x)
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
            if (sum >= 0)
            {
                sum++;
            }
            return sum;
        }
        public void CopyArrayAtTheEnd(int[] newArray)
        {
            CopyArrayAtTheIndex(Length, newArray);
        }
        public void CopyArrayAtTheStart(int[] newArray)
        {
            CopyArrayAtTheIndex(0, newArray);
        }
        public void CopyArrayAtTheIndex(int index,int[] newArray)
        {
            CheckIndexException(index);
            //int[] tmpArray = new int[_array.Length * 2];
            //for (int i = 0; i < _array.Length; i++)
            //{
            //    tmpArray[i] = _array[i];
            //}
            //_array = tmpArray;
            //int j = 0;
            //for (int i = Length + index; i < Length * 2; i++)
            //{
            //    _array[i] = _array[j + index];
            //    j++;
            //}
            //j = 0;
            //for (int i = Length + index - 1; i > index - 1; i--)
            //{
            //    _array[i] = _array[Length - j - 1];
            //    j++;
            //}
            //Length = Length * 2;

            int[] tmpArray = new int[_array.Length + newArray.Length];
            for (int i = 0; i < index; i++)
            {
                tmpArray[i] = _array[i];
            }

            for (int i = index; i < index+newArray.Length; i++)
            {
                tmpArray[i] = newArray[i- index];
            }

            for (int i = index+newArray.Length; i < Length+ newArray.Length; i++)
            {
                tmpArray[i] = _array[i - newArray.Length];
            }

            Length = Length + newArray.Length;
            _array = tmpArray;
        }

        public override bool Equals(object obj)
        {
            ArrayList arrayList = (ArrayList)obj;
            if (this.Length != arrayList.Length)
            {
                return false;
            }
            for (int i = 0; i < Length; i++)
            {
                if (this._array[i] != arrayList._array[i])
                {
                    return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < Length; i++)
            {
                s += _array[i] + " ";
            }
            return s;
        } 
        public override int GetHashCode()
        {
            return base.GetHashCode();
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

        private void CheckElements(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("нельзя удалить отрицательное количество элементов");
            }
        }
    }
}
