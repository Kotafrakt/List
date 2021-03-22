using NUnit.Framework;
using System;

namespace List.Tests
{
    public class ArrayListsTests
    {
        [TestCase(14, new int[] { 1, 2, 3, 14 }, new int[] { 1, 2, 3 })]
        [TestCase(111, new int[] { 1, 2, 3, 111 }, new int[] { 1, 2, 3 })]
        [TestCase(22, new int[] { 22 }, new int[] { })]

        public void Add_WhenValueIsAny_ShouldValueAddToLast(int value, int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.Add(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(14, new int[] { 14, 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(111, new int[] { 111, 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(22, new int[] { 22 }, new int[] { })]

        public void AddFirst_WhenValueIsAny_ShouldValueAddToFirst(int value, int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.AddFirst(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(14, 2, new int[] { 1, 2, 14, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(111, 3, new int[] { 1, 2, 3, 111 }, new int[] { 1, 2, 3 })]
        [TestCase(22, 0, new int[] { 22 }, new int[] { })]

        public void AddByIndex_WhenValueIsAny_ShouldValueAddInIndex(int value, int index, int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.AddByIndex(value, index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1 }, new int[] { 1, 2 })]
        [TestCase(new int[] { }, new int[] { 1})]

        public void RemoveLast_WhenAllCondition_ShouldRemoveLast(int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.RemoveLast();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 2 }, new int[] { 1, 2 })]
        [TestCase(new int[] { }, new int[] { 21})]

        public void RemoveFirst_WhenAllCondition_ShouldRemoveFirst(int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.RemoveFirst();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, new int[] { 1, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(0, new int[] { 2 }, new int[] { 1, 2 })]
        [TestCase(1, new int[] { 12, 33, 55, 743 }, new int[] { 12, 22, 33, 55, 743 })]
        [TestCase(0, new int[] {}, new int[] {1})]


        public void RemoveByIndex_WhenAllCondition_ShouldRemoveByIndex(int index, int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.RemoveByIndex(index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, new int[] { 1, 2 }, new int[] { 1, 2, 3 })]
        [TestCase(0, new int[] { 1, 2 }, new int[] { 1, 2 })]
        [TestCase(5, new int[] { }, new int[] { 12, 22, 33, 55, 743 })]

        public void RemoveLastElements_WhenLengthMoreValue_ShouldRemoveLastElements(int value, int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.RemoveLastElements(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, new int[] { 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(0, new int[] { 1, 2 }, new int[] { 1, 2 })]
        [TestCase(4, new int[] { 743 }, new int[] { 12, 22, 33, 55, 743 })]

        public void RemoveFirstElements_WhenLengthMoreValue_ShouldRemoveFirstElements(int value, int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.RemoveFirstElements(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 2, new int[] { 1 }, new int[] { 1, 2, 3 })]
        [TestCase(0, 0, new int[] { 1, 2 }, new int[] { 1, 2 })]
        [TestCase(3, 2, new int[] { 12, 22, 33 }, new int[] { 12, 22, 33, 55, 743 })]

        public void RemoveByIndexElements_WhenLengthMinusIndexMoreValue_ShouldRemoveByIndexElements(int index, int value, int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.RemoveByIndexElements(index, value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 0, new int[] { 1, 2, 3 })]
        [TestCase(0, -1, new int[] { 1, 2 })]
        [TestCase(743, 4, new int[] { 12, 22, 33, 55, 743 })]

        public void GetIndexByValue_WhenValueInArray_ShouldGetIndexByValue(int value, int expected, int[] actualArray)
        {
            ArrayList array = new ArrayList(actualArray);
            int actual = array.GetIndexByValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 3, 2, 1 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] {  }, new int[] {  })]
        [TestCase(new int[] { 12 }, new int[] { 12 })]

        public void Reverse_WhenAllCondition_ShouldReverse(int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.Reverse();
            Assert.AreEqual(expected, actual);
        }

        [TestCase( 3, new int[] { 1, 2, 3 })]
        [TestCase(5, new int[] { 1, 2, 5, 4, 0 })]
        [TestCase( 743, new int[] { 12, 22, 33, 55, 743 })]

        public void GetMax_WhenThereAreValues_ShouldGetMax(int expected, int[] actualArray)
        {
            ArrayList array = new ArrayList(actualArray);
            int actual = array.GetMax();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, new int[] { 1, 2, 3 })]
        [TestCase(0, new int[] { 1, 2, 5, 4, 0 })]
        [TestCase(-1, new int[] { 12, 22, 33, -1, 55, 743 })]

        public void GetMin_WhenThereAreValues_ShouldGetMin(int expected, int[] actualArray)
        {
            ArrayList array = new ArrayList(actualArray);
            int actual = array.GetMin();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, new int[] { 1, 2, 3 })]
        [TestCase(3, new int[] { 1, 2, 5, 6, 0 })]
        [TestCase(0, new int[] { 1222, 22, 33, -1, 55, 743 })]

        public void GetMaxIndex_WhenThereAreValues_ShouldGetMaxIndex(int expected, int[] actualArray)
        {
            ArrayList array = new ArrayList(actualArray);
            int actual = array.GetMaxIndex();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, new int[] { 1, 2, 3 })]
        [TestCase(4, new int[] { 1, 2, 5, 7, 0 })]
        [TestCase(3, new int[] { 1222, 22, 33, -1, 55, 743 })]

        public void GetMinIndex_WhenThereAreValues_ShouldGetMinIndex(int expected, int[] actualArray)
        {
            ArrayList array = new ArrayList(actualArray);
            int actual = array.GetMinIndex();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { -1, 12, 22, 33, 55, 743 }, new int[] { 12, 22, 33, -1, 55, 743 })]

        public void UpSort_WhenThereAreValues_ShouldUpSort(int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.UpSort();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 3, 2, 1 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] {}, new int[] {})]
        [TestCase(new int[] { 743, 55, 33, 22, 12, -1 }, new int[] { 12, 22, 33, -1, 55, 743 })]

        public void DownSort_WhenThereAreValues_DownSort(int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.DownSort();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 0, new int[] { 1, 2, 3 })]
        [TestCase(6, -1, new int[] { 1, 2, 5, 4, 0 })]
        [TestCase(12, 1, new int[] { 22, 12, 12, -1, 12, 743 })]

        public void RemoveFirstByValue_WhenThereAreValues_ShouldRemoveFirstByValue(int value, int expected, int[] actualArray)
        {
            ArrayList array = new ArrayList(actualArray);
            int actual = array.RemoveFirstByValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 1, new int[] { 1, 2, 3 })]
        [TestCase(7, -1, new int[] { 1, 2, 5, 4, 0 })]
        [TestCase(12, 4, new int[] { 12, 22, 12, 12, 55, 12 })]

        public void RemoveAllByValue_WhenThereAreValues_ShouldRemoveAllByValue(int value, int expected, int[] actualArray)
        {
            ArrayList array = new ArrayList(actualArray);
            int actual = array.RemoveAllByValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 2, new int[] { 1, 2, 3 })]
        [TestCase(0, 1, new int[] { 1, 2, 5, 4, 0 })]
        [TestCase(4, 55, new int[] { 12, 22, 12, 12, 55, 12 })]

        public void GetIndex_WhenIndexInArray_GetIndex(int index, int expected, int[] actualArray)
        {
            ArrayList array = new ArrayList(actualArray);
            int actual = array[index];
            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, 3, 3, new int[] { 1, 2, 3 })]
        [TestCase(1, 777, 777, new int[] { 1, 2, 5, 4, 0 })]
        [TestCase(0, 4, 4, new int[] { 12, 22, 12, 12, 55, 12 })]

        public void SetIndex_WhenIndexInArray_SetIndex(int index, int value, int expected, int[] actualArray)
        {
            ArrayList array = new ArrayList(actualArray);
            array[index]=value;
            int actual = array[index];
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 1, 2 }, new int[] { 1, 2 })]
        [TestCase(new int[] { }, new int[] { })]

        public void CopyArrayAtTheEnd_WhenAllCondition_CopyArrayAtTheEnd( int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.CopyArrayAtTheEnd();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 1, 2 }, new int[] { 1, 2 })]
        [TestCase(new int[] { }, new int[] { })]

        public void CopyArrayAtTheStart_WhenAllCondition_CopyArrayAtTheStart( int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.CopyArrayAtTheStart();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, new int[] { 1, 2, 3, 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(2, new int[] { 1, 2, 1, 2, 3, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(0, new int[] { }, new int[] { })]

        public void CopyArrayAtTheIndex_WhenAllCondition_CopyArrayAtTheIndex(int index, int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.CopyArrayAtTheIndex(index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, -5, new int[] { 1, 2, 3 })]
        public void AddByIndexException(int value, int index, int[] actualArray)
        {
            ArrayList array = new ArrayList(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() => array.AddByIndex(value, index));
        }

        [TestCase( new int[] { })]

        public void RemoveLastException( int[] actualArray)
        {
            ArrayList array = new ArrayList(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() => array.RemoveLast());
        }

        [TestCase(-5, new int[] { 1, 2, 3 })]
        [TestCase(4, new int[] { 1, 2, 3 })]
        [TestCase(0, new int[] { })]

        public void RemoveByIndexException( int index, int[] actualArray)
        {
            ArrayList array = new ArrayList(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() => array.RemoveByIndex( index ));
        }

        [TestCase(4, new int[] { 1, 2, 3 })]
        [TestCase(5, new int[] { })]

        public void RemoveLastElementsException(int index, int[] actualArray)
        {
            ArrayList array = new ArrayList(actualArray);
            Assert.Throws<ArgumentOutOfRangeException>(() => array.RemoveLastElements(index));
        }

        [TestCase(-5, new int[] { 1, 2, 3 })]

        public void RemoveLastElements_WhenElementsMinus_Exception(int index, int[] actualArray)
        {
            ArrayList array = new ArrayList(actualArray);
            Assert.Throws<ArgumentException>(() => array.RemoveLastElements(index));
        }

        [TestCase(4,1, new int[] { 1, 2, 3 })]
        [TestCase(-2,1, new int[] { })]

        public void RemoveByIndexElementsException(int index, int value, int[] actualArray)
        {
            ArrayList array = new ArrayList(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() => array.RemoveByIndexElements(index, value));
        }

        [TestCase(1, -5, new int[] { 1, 2, 3 })]
        public void RemoveByIndexElements_WhenElementsMinus_Exception(int index, int value, int[] actualArray)
        {
            ArrayList array = new ArrayList(actualArray);
            Assert.Throws<ArgumentException>(() => array.RemoveByIndexElements(index, value));
        }

        [TestCase(new int[] {})]
        public void GetMaxException(int[] actualArray)
        {
            ArrayList array = new ArrayList(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() => array.GetMax());
        }

        [TestCase(new int[] { })]
        public void GetMinException(int[] actualArray)
        {
            ArrayList array = new ArrayList(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() => array.GetMin());
        }

        [TestCase(new int[] { })]
        public void GetMaxIndexException(int[] actualArray)
        {
            ArrayList array = new ArrayList(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() => array.GetMaxIndex());
        }

        [TestCase(new int[] { })]
        public void GetMinIndexException(int[] actualArray)
        {
            ArrayList array = new ArrayList(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() => array.GetMinIndex());
        }
        [TestCase(1, -5, new int[] { 1, 2, 3 })]
        public void AddByIndexException3(int value, int index, int[] actualArray)
        {
            ArrayList array = new ArrayList(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() => { int t = array[index]; });
        }

        [TestCase(-1, new int[] { 1, 2, 3 })]
        [TestCase(4, new int[] { 1, 2, 3 })]

        public void CopyArrayAtTheIndexException(int index, int[] actualArray)
        {
            ArrayList array = new ArrayList(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() => array.CopyArrayAtTheIndex(index));
        }
    }
}