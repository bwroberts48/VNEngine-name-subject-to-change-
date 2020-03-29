using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Graph;

namespace GraphTests
{
    [TestClass]
    public class GraphInsertionTests
    {
        [TestMethod]
        public void InsertionOfVerticesGivesExpectedGraph()
        {
            Graph<String, String> graph = new Graph<String, String>();
            String s0 = "firstData";
            String s1 = "secondData";
            String s2 = "thirdData";

            graph.InsertVertex(s0);
            graph.InsertVertex(s1);
            graph.InsertVertex(s2);
            int expectedSize = 3;

            Assert.AreEqual(s0, graph.m_vertices[0].m_data);
            Assert.AreEqual(s1, graph.m_vertices[1].m_data);
            Assert.AreEqual(s2, graph.m_vertices[2].m_data);
            Assert.AreEqual(expectedSize, graph.m_vertices.Count);
        }

        [TestMethod]
        public void InsertionOfUndirectedEdgeGivesExpectedVertexReferences()
        {
            Graph<String, String> graph = new Graph<String, String>();
            String s0 = "firstData";
            String s1 = "secondData";
            String edgeData = "testData";

            graph.InsertVertex(s0);
            graph.InsertVertex(s1);
            graph.InsertEdge(s0, s1, edgeData);

            //Get the vertex index each edge has stored
            String expectedFirstEdgeVert = graph[0][0].m_vertexData;
            String expectedSecondEdgeVert = graph[1][0].m_vertexData;
            

            //Make sure the vertices pointed to are correct
            Assert.AreEqual(expectedFirstEdgeVert, s1);
            Assert.AreEqual(expectedSecondEdgeVert, s0);
        }

        [TestMethod]
        public void InsertionOfUndirectedEdgeProperlyStoresEdgeData()
        {
            Graph<String, String> graph = new Graph<String, String>();
            String s0 = "firstData";
            String s1 = "secondData";
            String edgeData = "testData";

            graph.InsertVertex(s0);
            graph.InsertVertex(s1);
            graph.InsertEdge(s0, s1, "testData");

            String expectedEdgeData = edgeData;

            Assert.AreEqual(expectedEdgeData, graph[0][0].m_edgeData);
            Assert.AreEqual(expectedEdgeData, graph[1][0].m_edgeData);
        }

        [TestMethod]
        public void InsertionOfDirectedEdgeGivesSingleEdge()
        {
            Graph<String, String> graph = new Graph<String, String>();
            String s0 = "firstData";
            String s1 = "secondData";
            String edgeData = "testData";

            graph.InsertVertex(s0);
            graph.InsertVertex(s1);
            graph.InsertEdge(s0, s1, edgeData, 0, true);

            String expectedEdgeVert = graph[0][0].m_vertexData;

            //Check that the expected edge from start to end exists
            Assert.AreEqual(s1, expectedEdgeVert);
            //Start to end edge should exist but end to start edge should not; therefore, the graph at index 1 should have no edges
            Assert.AreEqual(0, graph[1].m_edges.Count);
        }

        [TestMethod]
        public void InsertionOfCircularEdgeDoesntCreateTwoUndirectedEdges()
        {
            Graph<String, String> graph = new Graph<String, String>();
            String s0 = "firstData";
            graph.InsertVertex(s0);

            graph.InsertEdge(s0, s0, "testData");

            Assert.AreEqual(1, graph[0].m_edges.Count);
        }
    }
}
