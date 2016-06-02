using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModelConsole.CodingExercise
{
    public class MyLinkedList
    {
        private Node _head;

        public void PrintAllNodes()
        {
            Node current = _head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

        /// <summary>
        /// adds data to the beginning of the list
        /// i.e, prepends data to the list
        /// </summary>
        /// <param name="data"></param>
        public void AddToFirst(Object data)
        {
            Node nodeToAdd = new Node();
            nodeToAdd.Data = data;
            nodeToAdd.Next = _head;

            _head = nodeToAdd;

        }

        /// <summary>
        /// adds data to the last of the list, 
        /// i.e appends data to the list
        /// </summary>
        /// <param name="data"></param>
        public void AddToLast(Object data)
        {
            //add the data to the Head/First node, if the list is null
            if (_head == null)
            {
                _head = new Node()
                {
                    Data = data,
                    Next = null
                };
            }
            else
            {
                Node nodeToAdd = new Node()
                {
                    Data = data
                };

                Node current = _head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = nodeToAdd;
            }
        }

        /// <summary>
        /// retrieves the first element of the node
        /// </summary>
        /// <returns></returns>
        public Node GetFirstNode()
        {
            return _head;
        }



        /// <summary>
        /// retrieves node with specified data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Node GetNode(Object data)
        {
            Node current = _head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }

        /// <summary>
        /// retrieves the last node
        /// </summary>
        /// <returns></returns>
        public Node GetLastNode()
        {
            Node current = _head;
            while (current != null)
            {
                if (current.Next == null)
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }


        /// <summary>
        /// inserts data to a node after specified node
        /// </summary>
        /// <param name="referenceData">referenceData</param>
        /// <param name="dataToInsert">data to add</param>
        public void InsertAfter(Object referenceData, Object dataToInsert)
        {
            bool dataFound = false;
            Node current = _head;
            while (current != null)
            {
                if (current.Data.Equals(referenceData))
                {
                    Node nodeToInsert = new Node() { Data = dataToInsert };
                    nodeToInsert.Next = current.Next;
                    current.Next = nodeToInsert;
                    dataFound = true;
                    return;
                }
                current = current.Next;

                if (!dataFound)
                {
                    throw new KeyNotFoundException("Data Not Found");
                }
            }
        }

        /// <summary>
        /// inserts data before specified node
        /// </summary>
        /// <param name="referenceData">reference data</param>
        /// <param name="dataToInsert">data to insert</param>
        public void InsertBefore(Object referenceData, Object dataToInsert)
        {

            bool dataFound = false;
            Node current = _head;
            Node previous = _head;
            while (current != null)
            {
                if (current.Data.Equals(referenceData))
                {
                    Node nodeToInsert = new Node() { Data = dataToInsert };
                    nodeToInsert.Next = current;

                    previous.Next = nodeToInsert;
                    dataFound = true;
                    return;
                }

                previous = current;
                current = current.Next;
            }

            if (!dataFound)
            {
                throw new KeyNotFoundException("Node not Found");
            }
        }

        /// <summary>
        /// removes node from the list
        /// </summary>
        /// <param name="dataToDelete"></param>
        public void RemoveNode(Object dataToDelete)
        {
            Node current = _head;
            Node previous = _head;
            bool dataFound = false;

            while (current != null)
            {
                if (current.Data.Equals(dataToDelete))
                {
                    previous.Next = current.Next;
                    dataFound = true;
                    return;
                }

                previous = current;
                current = current.Next;
            }

            if (!dataFound)
            {
                throw new KeyNotFoundException("Node not Found");
            }

        }

        /// <summary>
        /// reverses the linked list
        /// </summary>
        public void ReverseNode() {

            Node currentNode = _head;
            Node previousNode = null;
            Node nextNode = null;

            while (currentNode != null)
            {
                //set
                nextNode = currentNode.Next;
                currentNode.Next = previousNode;
                //move
                previousNode = currentNode;
                currentNode = nextNode;
            }

            _head = previousNode;

        }

    }

    public class Node
    {
        public Node Next;
        public Object Data;
    }
}
