
using Assignment.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace AssignmentTests
{
    [TestClass]
    public class ItemTests
    {
            [TestMethod]

            public void TestNewItemHasCorrectId_NoMocking()
            {
                Item item = new Item(1, "a", 1, DateTime.Now);

                ItemDictionary dictionary = new ItemDictionary();

                dictionary.AddItem(item);
                Assert.AreEqual(item.ID, dictionary.FindItem(1).ID);

            }
        [TestMethod]
        public void TestNewItemHasCorrectId_WithMocking()
        {

            Mock<Item> itemMock = new Mock<Item>(1, "a", 1, DateTime.Now);

            ItemDictionary dictionary = new ItemDictionary();

            dictionary.AddItem(itemMock.Object);

            Assert.AreEqual(itemMock.Object.ID, dictionary.FindItem(1).ID);
        }





            [TestMethod]
            public void TestNewItemHasCorrectName_NoMocking()
            {
                Item item = new Item(1, "a", 1, DateTime.Now);

                ItemDictionary dictionary = new ItemDictionary();
            
                dictionary.AddItem(item);
                Assert.AreEqual(item.Name, dictionary.FindItem(1).Name);

            }
        [TestMethod]
        public void TestNewItemHasCorrectName_WithMocking()
        {
            Mock<Item> itemMock = new Mock<Item>(1, "a", 1, DateTime.Now);

            ItemDictionary dictionary = new ItemDictionary();

            dictionary.AddItem(itemMock.Object);

            Assert.AreEqual(itemMock.Object.Name, dictionary.FindItem(1).Name);
        }



            [TestMethod]
            public void TestNewItemHasCorrectQuantity_NoMocking()
            {
                Item item = new Item(1, "a", 1, DateTime.Now);

                ItemDictionary dictionary = new ItemDictionary();

                dictionary.AddItem(item);
                Assert.AreEqual(item.Quantity, dictionary.FindItem(1).Quantity);

            }

            [TestMethod]
            public void TestNewItemHasCorrectCreationDate_NoMocking()
            {
                DateTime now = DateTime.Now;

                Item item = new Item(2, "a", 1, now);

                ItemDictionary dictionary = new ItemDictionary();

                dictionary.AddItem(item);
                Assert.AreEqual(now, item.DateCreated);

            }

            [TestMethod]
            public void TestInvalidValuesForNewItemProducesException_NoMocking()
            {
                Item item;
                Assert.ThrowsException<Exception>(
                    () => item = new Item(0, "", 0, DateTime.Now));

            }

            [TestMethod]
            public void TestInvalidValuesForNewItemProducesCorrectErrorMessage_WithMocking()
            {
                try
                {
                // Item item = new Item(0, "", 0, DateTime.Now);
                Mock<Item> itemMock = new Mock<Item>(0, "", 0, DateTime.Now);
                }
                catch (Exception e)
                {
                    string expectedErrorMsg =
                        "ERROR: ID below 1; Quantity below 1; Item name is empty; ";
                    Assert.AreEqual(expectedErrorMsg, e.Message);
                }
            }

        [TestMethod]
        public void TestAddQuantityItemUpdatesItemInDictionary_NoMocking()
        {
            Item item1 = new Item(1, "Pen", 10, DateTime.Now );
            Item item2 = new Item(1, "Pen", 10, DateTime.Now );

            ItemDictionary dictionary = new ItemDictionary();
            dictionary.AddItem(item1);

            dictionary.AddItem(item2);

            Assert.AreEqual(20, dictionary.FindItem(1).Quantity);
        }
        [TestMethod]
        public void TestRemoveItemUpdatesItemInDictionary_WithMocking()
        {
            int quantity = 0;

            Mock<Item> itemMock1 = new Mock<Item>(1, "Pen", 10, DateTime.Now);
            Mock<Item> itemMock2 = new Mock<Item>(1, "Pen", 10, DateTime.Now);

            ItemDictionary dictionary = new ItemDictionary();



            dictionary.Remove(itemMock1.Object);
            dictionary.Remove(itemMock2.Object);

            Assert.AreEqual(0, quantity);
        }




    }
}

    

