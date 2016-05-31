using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestModelConsole.Test
{
    [TestClass]
    public class MyLinkedListTest
    {
        [TestMethod]
        public void AddToFirst_should_prepend_data_to_the_list()
        {
            var myLinkedList = new MyLinkedList();
            myLinkedList.AddToFirst("pujan");
            myLinkedList.AddToFirst("haha");
            myLinkedList.AddToFirst(123);
            //get the data
            var firstNode = myLinkedList.GetFirstNode();
            //verify
            //verify the added data
            //Assert.AreEqual(firstNode.Data, "pujan");
            //Assert.AreEqual(firstNode.Data, "haha");
            Assert.AreEqual(firstNode.Data, 123);            
        }

        [TestMethod]
        public void AddToLast_should_append_data_to_the_list()
        {
            var myLinkedList = new MyLinkedList();
            myLinkedList.AddToLast("firstElement");
            myLinkedList.AddToLast("secondElement");

            //get the head of the list
            var firstNode = myLinkedList.GetFirstNode();
            Assert.AreEqual(firstNode.Data, "firstElement");

            //verify if the secondElement is in the Next Pointer of the first Node
            Assert.AreEqual(firstNode.Next.Data, "secondElement");
        }

        [TestMethod]
        public void GetNode_should_return_particular_node_with_specified_data() {
            var myLinkedList = new MyLinkedList();
            myLinkedList.AddToFirst("firstElement");
            myLinkedList.AddToLast("secondElement");
            myLinkedList.AddToLast("thirdElement");

            var secondElement = myLinkedList.GetNode("secondElement");
            Assert.AreEqual(secondElement.Data, "secondElement");
            Assert.AreEqual(secondElement.Next.Data, "thirdElement");
                       

        }

        [TestMethod]
        public void GetLastNode_should_return_the_last_node() {
            var myLinkedList = new MyLinkedList();
            myLinkedList.AddToFirst("firstElement");
            myLinkedList.AddToLast("secondElement");
            myLinkedList.AddToLast("thirdElement");

            var lastElement = myLinkedList.GetLastNode();
            Assert.AreEqual(lastElement.Data, "thirdElement");
            Assert.IsNull(lastElement.Next);
        }

        [TestMethod]
        public void InsertAfter_should_add_node_after_specefied_node()
        {
            var myLinkedList = new MyLinkedList();
            myLinkedList.AddToFirst("firstElement");            
            myLinkedList.AddToLast("thirdElement");

            myLinkedList.InsertAfter("firstElement", "secondElement");

            //get node
            var secondElement = myLinkedList.GetNode("secondElement");
            //verify that the secondElement is before the thirdElement
            Assert.AreEqual(secondElement.Next.Data, "thirdElement");
            
        }

        [TestMethod]
        public void InsertBefore_should_add_node_before_specified_node() {
            var myLinkedList = new MyLinkedList();
            myLinkedList.AddToFirst("firstElement");
            myLinkedList.AddToLast("thirdElement");

            myLinkedList.InsertBefore("thirdElement", "secondElement");
            //get node
            var secondElement = myLinkedList.GetNode("secondElement");
            //verify that the secondElement is added before third
            Assert.AreEqual(secondElement.Next.Data,"thirdElement");

        }

        [TestMethod]
        public void InsertBefore_should_throw_keyNotFound_exception_for_unknown_data() {
            var myLinkedList = new MyLinkedList();
            myLinkedList.AddToFirst("firstElement");
            myLinkedList.AddToLast("thirdElement");
            
            try
            {
                myLinkedList.InsertBefore("secondElement", "secondElement");
                Assert.Fail("Exception not thrown");
            }
            catch (KeyNotFoundException ex)
            {
                Assert.IsNotNull(ex);
                Assert.AreEqual(ex.Message, "Node not Found");
            }
            


        }

        [TestMethod]
        public void RemoveNode_should_remove_Node_from_the_list() {

            var myLinkedList = new MyLinkedList();
            myLinkedList.AddToLast("firstElement");
            myLinkedList.AddToLast("secondElement");
            myLinkedList.AddToLast("thirdElement");

            myLinkedList.RemoveNode("secondElement");

            var firstNode = myLinkedList.GetFirstNode();

            Assert.AreEqual(firstNode.Next.Data, "thirdElement");
            
        }

    }
}
