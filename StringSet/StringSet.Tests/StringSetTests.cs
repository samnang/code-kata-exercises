using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace StringSet.Tests {
    public class StringSetTests {

        public StringSet Make_StringSet_Items(params string[] items) {
            var stringSet = new StringSet();
            foreach (var item in items) {
                stringSet.Add(item);
            }

            return stringSet;
        }

        [Test]
        public void Add_OneItem_ReturnTheItem() {
            var addedItem = Make_StringSet_Items().Add("One");

            addedItem.ShouldBeEqual("One");
        }

        [Test]
        public void Count_AddedOneItem_ReturnOne() {
            var numberOfItems = Make_StringSet_Items("One").Count;

            numberOfItems.ShouldBeEqual(1);
        }

        [Test]
        public void Count_AddedTwoItem_ReturnTwo() {
            var numberOfItems = Make_StringSet_Items("One", "Two").Count;

            numberOfItems.ShouldBeEqual(2);
        }

        [Test]
        public void Count_AddedTwoDuplicatedItems_ReturnOne() {
            var stringSet = Make_StringSet_Items("One", "One");

            var numberOfItems = stringSet.Count;

            numberOfItems.ShouldBeEqual(1);
        }

        [Test]
        public void Remove_ExistingItem_ReturnTrue() {
            var item = "One";
            var stringSet = Make_StringSet_Items(item);

            var succeed = stringSet.Remove(item);

            succeed.ShouldBeEqual(true);
        }


        [Test]
        public void Remove_NonExistingItem_ReturnFalse() {
            var stringSet = Make_StringSet_Items("One");

            var succeed = stringSet.Remove("NonExist");

            succeed.ShouldBeEqual(false);
        }

        [Test]
        public void Clear_Items_CountReturnsZero() {
            var stringSet = Make_StringSet_Items("One", "Two");

            stringSet.Clear();

            stringSet.Count.ShouldBeEqual(0);
        }

        [Test]
        public void Union_TwoStringSets_CountReturnsSumOfItems() {
            var stringSet1 = Make_StringSet_Items("One");
            var stringSet2 = Make_StringSet_Items("Two");

            var unionedResult = stringSet1.Union(stringSet2);

            unionedResult.Count.ShouldBeEqual(2);
        }

        [Test]
        public void Union_TwoStringSets_CountReturnsSumOfItemsWithoutDuplicate() {
            var stringSet1 = Make_StringSet_Items("One");
            var stringSet2 = Make_StringSet_Items("Two", "One");

            var unionedResult = stringSet1.Union(stringSet2);

            unionedResult.Count.ShouldBeEqual(2);
        }

        [Test]
        public void UnionByOperator_TwoStrings_CountReturnsSumOfItems() {
            var stringSet1 = Make_StringSet_Items("One");
            var stringSet2 = Make_StringSet_Items("Two");

            var unionedResult = stringSet1 + stringSet2;

            unionedResult.Count.ShouldBeEqual(2);
        }

        [Test]
        public void Intersect_TwoStringSets_CountReturnsIntersectedItems() {
            var stringSet1 = Make_StringSet_Items("One", "Two");
            var stringSet2 = Make_StringSet_Items("One", "Three");

            var intersectedResult = stringSet1.Intersect(stringSet2);

            intersectedResult.Count.ShouldBeEqual(1);
        }

        [Test]
        public void IntersectByOperator_TwoStringSets_CountReturnsIntersectedItems() {
            var stringSet1 = Make_StringSet_Items("One", "Two");
            var stringSet2 = Make_StringSet_Items("One", "Three");

            var intersectedResult = stringSet1 - stringSet2;

            intersectedResult.Count.ShouldBeEqual(1);
        }
    }
}
