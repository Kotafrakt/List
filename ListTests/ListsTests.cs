using NUnit.Framework;
using System;

namespace List.Tests
{
    [TestFixture("LinkedList")]
    [TestFixture("ArrayList")]
    [TestFixture("DoubleLinkedList")]
    public class ListsTests
    {
        IList actual;
        IList expected;

        string s = "";

        public ListsTests(string type)
        {
            s = type;
        }

        public void SetupTwo(int[] array, int[] expectedArray)
        {
            switch (s)
            {
                case "LinkedList":
                    actual = new LinkedList(array);
                    expected = new LinkedList(expectedArray);
                    break;

                case "ArrayList":
                    actual = new ArrayList(array);
                    expected = new ArrayList(expectedArray);
                    break;

                case "DoubleLinkedList":
                    actual = new DoubleLinkedList(array);
                    expected = new DoubleLinkedList(expectedArray);
                    break;
            }
        }

        public void SetupOne(int[] array)
        {
            switch (s)
            {
                case "LinkedList":
                    actual = new LinkedList(array);
                    
                    break;

                case "ArrayList":
                    actual = new ArrayList(array);

                    break;

                case "DoubleLinkedList":
                    actual = new DoubleLinkedList(array);

                    break;
            }
        }


        [TestCase(14, new int[] { 1, 2, 3, 14 }, new int[] { 1, 2, 3 })]
        [TestCase(111, new int[] { 1, 2, 3, 111 }, new int[] { 1, 2, 3 })]
        [TestCase(22, new int[] { 22 }, new int[] { })]

        public void Add_WhenValueIsAny_ShouldValueAddToLast(int value, int[] expectedArray, int[] actualArray)
        {
            SetupTwo(actualArray,expectedArray);
            actual.Add(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(14, new int[] { 14, 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(111, new int[] { 111, 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(22, new int[] { 22 }, new int[] { })]

        public void AddFirst_WhenValueIsAny_ShouldValueAddToFirst(int value, int[] expectedArray, int[] actualArray)
        {
            SetupTwo(actualArray, expectedArray);
            actual.AddFirst(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(14, 2, new int[] { 1, 2, 14, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(111, 3, new int[] { 1, 2, 3, 111 }, new int[] { 1, 2, 3 })]
        [TestCase(22, 0, new int[] { 22 }, new int[] { })]

        public void AddByIndex_WhenValueIsAny_ShouldValueAddInIndex(int value, int index, int[] expectedArray, int[] actualArray)
        {
            SetupTwo(actualArray, expectedArray);
            actual.AddByIndex(value, index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1 }, new int[] { 1, 2 })]
        [TestCase(new int[] { }, new int[] { 1})]

        public void RemoveLast_WhenAllCondition_ShouldRemoveLast(int[] expectedArray, int[] actualArray)
        {
            SetupTwo(actualArray, expectedArray);
            actual.RemoveLast();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 2 }, new int[] { 1, 2 })]
        [TestCase(new int[] { }, new int[] { 21})]

        public void RemoveFirst_WhenAllCondition_ShouldRemoveFirst(int[] expectedArray, int[] actualArray)
        {
            SetupTwo(actualArray, expectedArray);
            actual.RemoveFirst();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, new int[] { 1, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(0, new int[] { 2 }, new int[] { 1, 2 })]
        [TestCase(1, new int[] { 12, 33, 55, 743 }, new int[] { 12, 22, 33, 55, 743 })]
        [TestCase(0, new int[] {}, new int[] {1})]


        public void RemoveByIndex_WhenAllCondition_ShouldRemoveByIndex(int index, int[] expectedArray, int[] actualArray)
        {
            SetupTwo(actualArray, expectedArray);
            actual.RemoveByIndex(index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, new int[] { 1, 2 }, new int[] { 1, 2, 3 })]
        [TestCase(0, new int[] { 1, 2 }, new int[] { 1, 2 })]
        [TestCase(5, new int[] { }, new int[] { 12, 22, 33, 55, 743 })]

        public void RemoveLastElements_WhenLengthMoreValue_ShouldRemoveLastElements(int value, int[] expectedArray, int[] actualArray)
        {
            SetupTwo(actualArray, expectedArray);
            actual.RemoveLastElements(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, new int[] { 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(0, new int[] { 1, 2 }, new int[] { 1, 2 })]
        [TestCase(4, new int[] { 743 }, new int[] { 12, 22, 33, 55, 743 })]

        public void RemoveFirstElements_WhenLengthMoreValue_ShouldRemoveFirstElements(int value, int[] expectedArray, int[] actualArray)
        {
            SetupTwo(actualArray, expectedArray);
            actual.RemoveFirstElements(value);
            Assert.AreEqual(expected, actual);
        }

        //[TestCase(1, 2, new int[] { 1 }, new int[] { 1, 2, 3 })]
        //[TestCase(0, 0, new int[] { 1, 2 }, new int[] { 1, 2 })]
        //[TestCase(3, 2, new int[] { 12, 22, 33 }, new int[] { 12, 22, 33, 55, 743 })]

        //public void RemoveByIndexElements_WhenLengthMinusIndexMoreValue_ShouldRemoveByIndexElements(int index, int value, int[] expectedArray, int[] actualArray)
        //{
        //    SetupTwo(actualArray, expectedArray);
        //    actual.RemoveByIndexElements(index, value);
        //    Assert.AreEqual(expected, actual);
        //}

        [TestCase(1, 0, new int[] { 1, 2, 3 })]
        [TestCase(0, -1, new int[] { 1, 2 })]
        [TestCase(743, 4, new int[] { 12, 22, 33, 55, 743 })]

        public void GetIndexByValue_WhenValueInArray_ShouldGetIndexByValue(int value, int expected, int[] actualArray)
        {
            SetupOne(actualArray);
            int tmp = actual.GetIndexByValue(value);
            Assert.AreEqual(expected, tmp);
        }

        [TestCase(new int[] { 3, 2, 1 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] {  }, new int[] {  })]
        [TestCase(new int[] { 12 }, new int[] { 12 })]

        public void Reverse_WhenAllCondition_ShouldReverse(int[] expectedArray, int[] actualArray)
        {
            SetupTwo(actualArray, expectedArray);
            actual.Reverse();
            Assert.AreEqual(expected, actual);
        }

        [TestCase( 3, new int[] { 1, 2, 3 })]
        [TestCase(5, new int[] { 1, 2, 5, 4, 0 })]
        [TestCase( 743, new int[] { 12, 22, 33, 55, 743 })]

        public void GetMax_WhenThereAreValues_ShouldGetMax(int expected, int[] actualArray)
        {
            SetupOne(actualArray);
            int tmp = actual.GetMax();
            Assert.AreEqual(expected, tmp);
        }

        [TestCase(1, new int[] { 1, 2, 3 })]
        [TestCase(0, new int[] { 1, 2, 5, 4, 0 })]
        [TestCase(-1, new int[] { 12, 22, 33, -1, 55, 743 })]

        public void GetMin_WhenThereAreValues_ShouldGetMin(int expected, int[] actualArray)
        {
            SetupOne(actualArray);
            int tmp = actual.GetMin();
            Assert.AreEqual(expected, tmp);
        }

        [TestCase(2, new int[] { 1, 2, 3 })]
        [TestCase(3, new int[] { 1, 2, 5, 6, 0 })]
        [TestCase(0, new int[] { 1222, 22, 33, -1, 55, 743 })]

        public void GetMaxIndex_WhenThereAreValues_ShouldGetMaxIndex(int expected, int[] actualArray)
        {
            SetupOne(actualArray);
            int tmp = actual.GetMaxIndex();
            Assert.AreEqual(expected, tmp);
        }

        [TestCase(0, new int[] { 1, 2, 3 })]
        [TestCase(4, new int[] { 1, 2, 5, 7, 0 })]
        [TestCase(3, new int[] { 1222, 22, 33, -1, 55, 743 })]

        public void GetMinIndex_WhenThereAreValues_ShouldGetMinIndex(int expected, int[] actualArray)
        {
            SetupOne(actualArray);
            int tmp = actual.GetMinIndex();
            Assert.AreEqual(expected, tmp);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { -1, 12, 22, 33, 55, 743 }, new int[] { 12, 22, 33, -1, 55, 743 })]

        public void UpSort_WhenThereAreValues_ShouldUpSort(int[] expectedArray, int[] actualArray)
        {
            SetupTwo(actualArray, expectedArray);
            actual.UpSort();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 3, 2, 1 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] {}, new int[] {})]
        [TestCase(new int[] { 743, 55, 33, 22, 12, -1 }, new int[] { 12, 22, 33, -1, 55, 743 })]

        public void DownSort_WhenThereAreValues_DownSort(int[] expectedArray, int[] actualArray)
        {
            SetupTwo(actualArray, expectedArray);
            actual.DownSort();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 0, new int[] { 1, 2, 3 })]
        [TestCase(6, -1, new int[] { 1, 2, 5, 4, 0 })]
        [TestCase(12, 1, new int[] { 22, 12, 12, -1, 12, 743 })]

        public void RemoveFirstByValue_WhenThereAreValues_ShouldRemoveFirstByValue(int value, int expected, int[] actualArray)
        {
            SetupOne(actualArray);
            int tmp = actual.RemoveFirstByValue(value);
            Assert.AreEqual(expected, tmp);
        }

        [TestCase(1, 1, new int[] { 1, 2, 3 })]
        [TestCase(7, -1, new int[] { 1, 2, 5, 4, 0 })]
        [TestCase(12, 4, new int[] { 12, 22, 12, 12, 55, 12 })]

        public void RemoveAllByValue_WhenThereAreValues_ShouldRemoveAllByValue(int value, int expected, int[] actualArray)
        {
            SetupOne(actualArray);
            int tmp = actual.RemoveAllByValue(value);
            Assert.AreEqual(expected, tmp);
        }

        [TestCase(1, 2, new int[] { 1, 2, 3 })]
        [TestCase(0, 1, new int[] { 1, 2, 5, 4, 0 })]
        [TestCase(4, 55, new int[] { 12, 22, 12, 12, 55, 12 })]

        public void GetIndex_WhenIndexInArray_GetIndex(int index, int expected, int[] actualArray)
        {
            SetupOne(actualArray);
            int tmp = actual[index];
            Assert.AreEqual(expected, tmp);
        }

        [TestCase(2, 3, 3, new int[] { 1, 2, 3 })]
        [TestCase(1, 777, 777, new int[] { 1, 2, 5, 4, 0 })]
        [TestCase(0, 4, 4, new int[] { 12, 22, 12, 12, 55, 12 })]

        public void SetIndex_WhenIndexInArray_SetIndex(int index, int value, int expected, int[] actualArray)
        {
            SetupOne(actualArray);
            actual[index] = value;
            int tmp = actual[index];
            Assert.AreEqual(expected, tmp);
        }

        [TestCase(new int[] { 1, 2, 3, 22, 33, 44  }, new int[] { 1, 2, 3 }, new int[] { 22, 33, 44 })]
        [TestCase(new int[] { 1, 2, 22, 33, 44 }, new int[] { 1, 2 }, new int[] { 22, 33, 44 })]
        [TestCase(new int[] { 22, 33, 44 }, new int[] { }, new int[] { 22, 33, 44 })]

        public void CopyArrayAtTheEnd_WhenAllCondition_CopyArrayAtTheEnd( int[] expectedArray, int[] actualArray, int[] newArray)
        {
            SetupTwo(actualArray, expectedArray);
            actual.CopyArrayAtTheEnd(newArray);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 22, 33, 44, 1, 2, 3 }, new int[] { 1, 2, 3 }, new int[] { 22, 33, 44 })]
        [TestCase(new int[] { 22, 33, 44, 1, 2 }, new int[] { 1, 2 }, new int[] { 22, 33, 44 })]
        [TestCase(new int[] { 22, 33, 44 }, new int[] { }, new int[] { 22, 33, 44 })]

        public void CopyArrayAtTheStart_WhenAllCondition_CopyArrayAtTheStart( int[] expectedArray, int[] actualArray, int[] newArray)
        {
            SetupTwo(actualArray, expectedArray);
            actual.CopyArrayAtTheStart(newArray);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, new int[] { 22, 33, 44, 1, 2, 3 }, new int[] { 1, 2, 3 }, new int[] { 22, 33, 44 })]
        [TestCase(2, new int[] { 1, 2, 22, 33, 44, 3 }, new int[] { 1, 2, 3 }, new int[] { 22, 33, 44 })]
        [TestCase(0, new int[] { }, new int[] { }, new int[] { })]
        [TestCase(3, new int[] { 1, 2, 22, 22, 33, 44 }, new int[] { 1, 2, 22 }, new int[] { 22, 33, 44 })]

        public void CopyArrayAtTheIndex_WhenAllCondition_CopyArrayAtTheIndex(int index, int[] expectedArray, int[] actualArray, int[] newArray)
        {
            SetupTwo(actualArray, expectedArray);
            actual.CopyArrayAtTheIndex(index, newArray);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, -5, new int[] { 1, 2, 3 })]
        public void AddByIndexException(int value, int index, int[] actualArray)
        {
            SetupOne(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() => actual.AddByIndex(value, index));
        }

        [TestCase( new int[] { })]

        public void RemoveLastException( int[] actualArray)
        {
            SetupOne(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveLast());
        }

        [TestCase(-5, new int[] { 1, 2, 3 })]
        [TestCase(4, new int[] { 1, 2, 3 })]
        [TestCase(0, new int[] { })]

        public void RemoveByIndexException( int index, int[] actualArray)
        {
            SetupOne(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveByIndex( index ));
        }

        [TestCase(4, new int[] { 1, 2, 3 })]
        [TestCase(5, new int[] { })]

        public void RemoveLastElementsException(int index, int[] actualArray)
        {
            SetupOne(actualArray);
            Assert.Throws<ArgumentOutOfRangeException>(() => actual.RemoveLastElements(index));
        }

        [TestCase(-5, new int[] { 1, 2, 3 })]

        public void RemoveLastElements_WhenElementsMinus_Exception(int index, int[] actualArray)
        {
            SetupOne(actualArray);
            Assert.Throws<ArgumentException>(() => actual.RemoveLastElements(index));
        }

        [TestCase(4,1, new int[] { 1, 2, 3 })]
        [TestCase(-2,1, new int[] { })]

        public void RemoveByIndexElementsException(int index, int value, int[] actualArray)
        {
            SetupOne(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveByIndexElements(index, value));
        }

        [TestCase(1, -5, new int[] { 1, 2, 3 })]
        public void RemoveByIndexElements_WhenElementsMinus_Exception(int index, int value, int[] actualArray)
        {
            SetupOne(actualArray);
            Assert.Throws<ArgumentException>(() => actual.RemoveByIndexElements(index, value));
        }

        [TestCase(new int[] {})]
        public void GetMaxException(int[] actualArray)
        {
            SetupOne(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() => actual.GetMax());
        }

        [TestCase(new int[] { })]
        public void GetMinException(int[] actualArray)
        {
            SetupOne(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() => actual.GetMin());
        }

        [TestCase(new int[] { })]
        public void GetMaxIndexException(int[] actualArray)
        {
            SetupOne(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() => actual.GetMaxIndex());
        }

        [TestCase(new int[] { })]
        public void GetMinIndexException(int[] actualArray)
        {
            SetupOne(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() => actual.GetMinIndex());
        }

        [TestCase(1, -5, new int[] { 1, 2, 3 })]
        public void AddByIndexException3(int value, int index, int[] actualArray)
        {
            SetupOne(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() => { int t = actual[5]; });
        }

        [TestCase(-1, new int[] { 1, 2, 3 }, new int[] { 22, 33, 44 })]
        [TestCase(4, new int[] { 1, 2, 3 }, new int[] { 22, 33, 44 })]

        public void CopyArrayAtTheIndexException(int index, int[] actualArray, int[] newArray)
        {
            SetupOne(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() => actual.CopyArrayAtTheIndex(index, newArray));
        }
    }
}