using NUnit.Framework;
using List;

namespace ListTests
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
        [TestCase(new int[] { }, new int[] { })]

        public void RemoveLast_WhenAllCondition_ShouldRemoveLast(int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.RemoveLast();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 2 }, new int[] { 1, 2 })]
        [TestCase(new int[] { }, new int[] { })]

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
    }
}