using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Graph;

namespace GraphTests
{
    [TestClass]
    public class GraphExceptionTests
    {

        //Insertion Exceptions

        [TestMethod]
        [ExpectedException(typeof(GraphException))]
        public void InsertionOfDuplicateVertexDataThrowsException()
        {
            Graph<String, String> graph = new Graph<String, String>();
            String str = "testData";

            graph.InsertVertex(str);
            graph.InsertVertex(str);
        }

        [TestMethod]
        [ExpectedException(typeof(GraphException))]
        public void EdgeInsertionWithInvalidStartDataThrowsException()
        {
            Graph<String, String> graph = new Graph<String, String>();
            String s0 = "firstData";
            String s1 = "secondData";
            String edgeData = "testData";

            graph.InsertVertex(s0);

            graph.InsertEdge(s1, s0, edgeData);
        }

        [TestMethod]
        [ExpectedException(typeof(GraphException))]
        public void EdgeInsertionWithInvalidEndDataThrowsException()
        {
            Graph<String, String> graph = new Graph<String, String>();
            String s0 = "firstData";
            String s1 = "secondData";
            String edgeData = "testData";

            graph.InsertVertex(s0);

            graph.InsertEdge(s0, s1, edgeData);
        }

        //Deletion Exceptions

        [TestMethod]
        [ExpectedException(typeof(GraphException))]
        public void VertexDeletionWithInvalidDataThrowsException()
        {
            Graph<String, String> graph = new Graph<String, String>();
            String s0 = "firstData";
            String s1 = "secondData";

            graph.InsertVertex(s0);

            graph.DeleteVertex(s1);
        }

        [TestMethod]
        [ExpectedException(typeof(GraphException))]
        public void DeletionOfDirectedEdgeWithoutFlagRaisedThrowsException()
        {
            Graph<String, String> graph = new Graph<String, String>();
            String s0 = "firstData";
            String s1 = "secondData";
            String edgeData = "testData";

            graph.InsertVertex(s0);
            graph.InsertVertex(s1);
            graph.InsertEdge(s0, s1, edgeData, 0, true);

            //Should attempt to delete non-existant second edge from 1 to 0 and throw exception
            graph.DeleteEdge(s0, s1, edgeData);
        }

        [TestMethod]
        [ExpectedException(typeof(GraphException))]
        public void EdgeDeletionWithInvalidStartDataThrowsException()
        {
            Graph<String, String> graph = new Graph<String, String>();
            String s0 = "firstData";
            String s1 = "secondData";
            String s2 = "thirdData";
            String edgeData = "testData";

            graph.InsertVertex(s0);
            graph.InsertVertex(s1);
            graph.InsertVertex(s2);
            graph.InsertEdge(s0, s1, edgeData);

            graph.DeleteEdge(s2, s0, edgeData);
        }

        [TestMethod]
        [ExpectedException(typeof(GraphException))]
        public void EdgeDeletionWithInvalidEndDataThrowsException()
        {
            Graph<String, String> graph = new Graph<String, String>();
            String s0 = "firstData";
            String s1 = "secondData";
            String s2 = "thirdData";
            String edgeData = "testData";

            graph.InsertVertex(s0);
            graph.InsertVertex(s1);
            graph.InsertVertex(s2);
            graph.InsertEdge(s0, s1, edgeData);

            graph.DeleteEdge(s0, s2, edgeData);
        }

        [TestMethod]
        [ExpectedException(typeof(GraphException))]
        public void EdgeDeletionWithInvalidEdgeDataThrowsException()
        {
            Graph<String, String> graph = new Graph<String, String>();
            String s0 = "firstData";
            String s1 = "secondData";
            String edgeData = "testData";
            String unusedEdgeData = "unusedData";

            graph.InsertVertex(s0);
            graph.InsertVertex(s1);
            graph.InsertEdge(s0, s1, edgeData);

            graph.DeleteEdge(s0, s1, unusedEdgeData);
        }
    }
}
