/**********************************************************************************************************************************************************************************************************************
* Author:		Brett Roberts
* Filename:		BranchesGraph.cs
* Date Created: 3/29/2020
*
* Class: BranchesGraph
*
* Purpose: Graph data structure using Lists for vertices and edges for Branches
*
* Manager functions:
*	BranchesGraph()
*
* Methods:
*   int FindDataIndex(int id)
*       Finds if the passed through id exists in the graph and returns the index if it does otherwise it returns -1
*   void InsertVertex(Branch data)
*       Appends a vertex to the graph and returns the index of its place in m_vertices
*   void DeleteVertex(int id)
*       Removes a vertex with the specified data and all associated edges from the graph
*   public void InsertEdge(int startId, int endId, string edgeData, int weight = 0, bool insertDirectedEdge = false)
*       Inserts an edge (or arc) between the two vertices that hold the passed in data
*   void DeleteEdge(int startId, int endId, string data, bool deleteDirectedEdge = false)
*       Deletes the undirected edge connecting the passed in start and end indicies of m_vertices, if deleteDirectedEdge is set then only the directed edge going from the start to the end is deleted
*   public Vertex this[int i]
*       Overload of the subscript operator
***********************************************************************************************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNEngine
{
    [Serializable]
    class BranchesGraph
    {
        public BranchesGraph()
        {
            m_vertices = new List<Vertex>();
        }

        /********************************************************************************************************************************************************************
        * Purpose: Signals whether the passed through branch id exists in the graph
        *
        * Precondition:
        *
        * Postcondition:
        *	Returns true if the passed in Vertex data was found in the graph
        *	Otherwise, it returns false
        *********************************************************************************************************************************************************************/
        private int FindDataIndex(int id)
        {
            int index = -1;

            for (int i = 0; i < m_vertices.Count && index == -1; ++i)
            {
                if (m_vertices[i].Data.ID == id)
                    index = i;
            }

            return index;
        }

        /********************************************************************************************************************************************************************
        * Purpose: Adds a new vertex to the graph
        *
        * Precondition:
        *	None
        *
        * Postcondition:
        *	If the data to add is already present in the graph a GraphException is thrown
        *	Otherwise, a new Vertex with the given data is appended to m_vertices
        *********************************************************************************************************************************************************************/
        public void InsertVertex(Branch data)
        {
            //If the data is already in the graph
            if (FindDataIndex(data.ID) != -1)
                throw new GraphException("Cannot have duplicate vertex data");

            m_vertices.Add(new Vertex(data));
        }

        /********************************************************************************************************************************************************************
        * Purpose: Removes the vertex with the passed in data from the graph and all associated edges
        *
        * Precondition:
        *	None
        *
        * Postcondition:
        *	If the data given for the vertex does not exist within the graph an exception is thrown
        *	Otherwise, the vertex with the given data (and all edges holding that vertexData) are deleted
        *********************************************************************************************************************************************************************/
        public void DeleteVertex(int id)
        {
            int index = FindDataIndex(id);

            //If the vertex wasn't found throw an exception
            if (index == -1)
                throw new GraphException("Could not vertex for deletion");

            //Remove the vertex
            m_vertices.RemoveAt(index);

            //For all vertices
            for (int i = 0; i < m_vertices.Count; ++i)
            {
                //Check each edge and delete those associated with the deleted vertex data
                for (int j = 0; j < m_vertices[i].Edges.Count; ++j)
                {
                    //If the current edge is a match remove it
                    if (m_vertices[i][j].VertexId == id)
                        m_vertices[i].Edges.RemoveAt(j);
                }
            }
        }

        /********************************************************************************************************************************************************************
        * Purpose: Inserts an edge between the vertices that hold the passed in V data
        *   This edge is by default undirected but if insertDirectedEdge is set then only a directed edge from the start and end is created
        *
        * Precondition:
        *	None
        *
        * Postcondition:
        *   If NEGATIVE_WEIGHTS_ALLOWED is not set and the weight is less than 0 a GraphException is thrown
        *   If the start or end vertex indices are out of bounds of the graph a GraphException is thrown
        *	Otherwise, an undirected edge (or directed edge if insertDirectedEdge is set) is inserted between the vertices located at the passed in 
        *	    start and end vertex indices of the graph's m_vertices
        *********************************************************************************************************************************************************************/
        public void InsertEdge(int startId, int endId, string edgeData, int weight = 0, bool insertDirectedEdge = false)
        {
            int startIndex = FindDataIndex(startId);
            int endIndex = FindDataIndex(endId);

            if (!GraphGlobals.NEGATIVE_WEIGHTS_ALLOWED && weight < 0)
                throw new GraphException("Weight cannot be negative");

            if (startIndex == -1)
                throw new GraphException("Could not find start vertex for edge insertion");

            if (endIndex == -1)
                throw new GraphException("Could not find end vertex for edge insertion");

            //Create a new directed edge that connects the start vertex to the end vertex and add it to the edgelist of the start vertex
            Edge directedEdge = new Edge(edgeData, endId, weight);
            m_vertices[startIndex].InsertEdge(directedEdge);

            //If the user wants to insert the directed edge and if the first edge wasn't cyclical also insert a directed edge from the end vertex to the start vertex
            if (!insertDirectedEdge && startId != endId)
            {
                directedEdge = new Edge(edgeData, startId, weight);
                m_vertices[endIndex].InsertEdge(directedEdge);
            }
        }

        /********************************************************************************************************************************************************************
        * Purpose: Deletes the undirected edge between vertices at the start and end indices passed through. 
        *   This edge is by default undirected but if deleteDirectedEdge is set then only the directed edge from start to end is deleted
        *
        * Precondition:
        *	None
        *
        * Postcondition:
        *   If the start or end vertex indices are out of bounds of the graph a GraphException is thrown
        *	Otherwise, the undirected edge (or directed edge if deleteDirectedEdge is set) is deleted between the vertices located at the passed in 
        *	    start and end vertex indices of the graph's m_vertices
        *********************************************************************************************************************************************************************/
        public void DeleteEdge(int startId, int endId, string data, bool deleteDirectedEdge = false)
        {
            int startIndex = FindDataIndex(startId);
            int endIndex = FindDataIndex(endId);

            if (startIndex == -1)
                throw new GraphException("Could not find start vertex for edge deletion");

            if (endIndex == -1)
                throw new GraphException("Could not find start vertex for edge deletion");

            m_vertices[startIndex].DeleteEdge(data);

            //Remove an edge located from the end vertex to the start if deleteDirectedEdge was not flagged
            if (!deleteDirectedEdge)
                m_vertices[endIndex].DeleteEdge(data);
        }

        /********************************************************************************************************************************************************************
        * Purpose: Overloaded subscript operator (accessor only)
        * Intended for use with Vertex subscript overload to return an edge (Ex. graph[2][0] returns the second vertex's 0th edge)
        *
        * Precondition:
        *	None
        *
        * Postcondition:
        *	Returns the Vertex at the given index of m_vertices
        *********************************************************************************************************************************************************************/
        public Vertex this[int i]
        {
            get { return m_vertices[i]; }
        }

        public List<Vertex> m_vertices { get; }
    }

    //Holds globals to be used within the Graph data structure
    public static class GraphGlobals
    {
        public const bool NEGATIVE_WEIGHTS_ALLOWED = false;
    }
}