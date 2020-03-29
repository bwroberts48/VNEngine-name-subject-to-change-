using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Graph;

namespace GraphTests
{
    [TestClass]
    public class GraphDeletionTests
    {
        [TestMethod]
        public void DeletionOfVertexRemovesExpectedVertexFromList()
        {
            Graph<String, String> graph = new Graph<String, String>();
            String s0 = "firstData";
            String s1 = "secondData";
            String s2 = "thirdData";
            graph.InsertVertex(s0);
            graph.InsertVertex(s1);
            graph.InsertVertex(s2);

            graph.DeleteVertex(s0);
            int expectedSize = 2;
            String expectedDataIndex0 = s1;
            String expectedDataIndex1 = s2;

            Assert.AreEqual(expectedSize, graph.m_vertices.Count);
            Assert.AreEqual(expectedDataIndex0, graph.m_vertices[0].m_data);
            Assert.AreEqual(expectedDataIndex1, graph.m_vertices[1].m_data);
        }


        [TestMethod]
        public void DeletionOfVertexRemovesAssociatedEdges()
        {
            Graph<String, String> graph = new Graph<String, String>();
            String s0 = "firstData";
            String s1 = "secondData";
            String s2 = "thirdData";
            String s3 = "fourthData";
            graph.InsertVertex(s0);
            graph.InsertVertex(s1);
            graph.InsertVertex(s2);
            graph.InsertVertex(s3);

            graph.InsertEdge(s0, s2, "0 and 2");
            graph.InsertEdge(s2, s3, "2 to 3", 0, true);
            graph.InsertEdge(s0, s1, "0 and 1");
            graph.InsertEdge(s2, s1, "2 to 1", 0, true);
            graph.DeleteVertex(s1);

            bool noAssociatedEdges = true;
            //For each vertex
            for (int i = 0; i < graph.m_vertices.Count && true; ++i)
            {
                //Check each edge to see if it contains the data that should be wiped from the graph
                for (int j = 0; j < graph[i].m_edges.Count && true; ++j)
                    if (graph.m_vertices[i][j].m_vertexData == s1)
                        noAssociatedEdges = false;           
            }

            Assert.IsTrue(noAssociatedEdges);
        }

        [TestMethod]
        public void DeletionOfUndirectedEdgeRemovesBothEdges()
        {
            Graph<String, String> graph = new Graph<String, String>();
            String s0 = "firstData";
            String s1 = "secondData";
            String edgeData = "testData";
            graph.InsertVertex(s0);
            graph.InsertVertex(s1);
            graph.InsertEdge(s0, s1, edgeData);

            graph.DeleteEdge(s0, s1, edgeData);

            Assert.AreEqual(0, graph[0].m_edges.Count);
            Assert.AreEqual(0, graph[1].m_edges.Count);
        }

        [TestMethod]
        public void DeletionOfDirectedEdgeRemovesEdge()
        {
            Graph<String, String> graph = new Graph<String, String>();
            String s0 = "firstData";
            String s1 = "secondData";
            graph.InsertVertex(s0);
            graph.InsertVertex(s1);
            graph.InsertEdge(s0, s1, "testData", 0, true);

            graph.DeleteEdge(s0, s1, "testData", true);

            Assert.AreEqual(0, graph[0].m_edges.Count);

        }

        [TestMethod]
        public void DeletionOfSingleDirectionOnUndirectedEdgeDoesNotDeleteFullUndirectedEdge()
        {
            Graph<String, String> graph = new Graph<String, String>();
            String s0 = "firstData";
            String s1 = "secondData";
            graph.InsertVertex(s0);
            graph.InsertVertex(s1);
            //Insert undirected edge
            graph.InsertEdge(s0, s1, "testData");

            //Delete edge pointing from the start to the end vertex
            graph.DeleteEdge(s0, s1, "testData", true);

            //Check that only start to end directed edge was deleted
            Assert.AreEqual(0, graph[0].m_edges.Count);
            Assert.AreEqual(1, graph[1].m_edges.Count);
        }
    }
}
