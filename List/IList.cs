using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public interface IList
    {
        virtual int this[int index]
        {
            get { return 0;}
            set
            {
                this[index] = value;
            }
        }
        void Add(int value);
        void AddFirst(int value);
        void AddByIndex(int value, int index);
        void RemoveLast();
        void RemoveFirst();
        void RemoveByIndex(int index);
        void RemoveLastElements(int n);
        void RemoveFirstElements(int n);
        void RemoveByIndexElements(int index, int n);
        int GetIndexByValue(int value);
        void Reverse();
        int GetMax();
        int GetMin();
        int GetMaxIndex();
        int GetMinIndex();
        void UpSort();
        void DownSort();
        int RemoveFirstByValue(int x);
        int RemoveAllByValue(int x);
        void CopyArrayAtTheEnd(int[] newArray);
        void CopyArrayAtTheStart(int[] newArray);
        void CopyArrayAtTheIndex(int index, int[] newArray);
    }
}
