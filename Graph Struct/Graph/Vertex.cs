/**********************************************************************************************************************************************************************************************************************
* Author:		Brett Sprague
* Filename:		Vertex.cs
* Date Created: 5/17/2019
*
* Class: Vertex
*
* Purpose: Holds V data as well a list of Edges. Used as an element in a Graph List
*
* Manager functions:
*	Vertex()
*		At default, the edgelist is empty, and processed is set to false
*   Vertex(V data);
*		Creates a vertex with the specified data
* Methods:
*   int FindDataIndex(E data)
*       Finds if the passed through edge data exists in m_edges and returns true if it does
*	void InsertEdge(Edge<V, E> edge)
*	    Appends an edge to this vertex's edge list
*	void DeleteEdge(E data)
*	    Deletes the edge at the specified index of m_edges
***********************************************************************************************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Vertex<V, E> where V : class where E : class
    {
        public Vertex()
        {
            m_processed = false;
            m_edges = new List<Edge<V, E>>();
        }

        public Vertex(V data)
        {
            m_data = data;
            m_processed = false;
            m_edges = new List<Edge<V, E>>();
        }
        /********************************************************************************************************************************************************************
        * Purpose: Signals whether the passed through edge data exists in the edge list
        *
        * Precondition:
        *   None
        *   
        * Postcondition:
        *	Returns the index of the passed in data if it exists
        *	Otherwise, it returns false
        *********************************************************************************************************************************************************************/
        private int FindDataIndex(E data)
        {
            int index = -1;

            for (int i = 0; i < m_edges.Count && index == -1; ++i)
            {
                if (m_edges[i].m_edgeData == data)
                    index = i;
            }

            return index;
        }

        /********************************************************************************************************************************************************************
        * Purpose: Appends an edge to the edge list with the specified data
        *
        * Precondition:
        *	None
        *
        * Postcondition:
        *	The edge list of the current vertex is given an additional edge
        *********************************************************************************************************************************************************************/
        public void InsertEdge(Edge<V, E> edge)
        {
            m_edges.Add(edge);
        }

        /********************************************************************************************************************************************************************
        * Purpose: Removes the specified edge from the graph
        *
        * Precondition:
        *	Called through the Graph DeleteEdge function
        *
        * Postcondition:
        *   If the passed through data is not found in the edge list a GraphException is thrown
        *	Otherwise, edge from m_edges at the specified index is deleted
        *********************************************************************************************************************************************************************/
        public void DeleteEdge(E data)
        {
            int index = FindDataIndex(data);
            if (index == -1)
                throw new GraphException("Index was out of bounds for edge deletion");

            m_edges.Remove(m_edges[index]);
        }

        /********************************************************************************************************************************************************************
        * Purpose: Overloaded subscript operator (accessor only)
        *
        * Precondition:
        *	None
        *
        * Postcondition:
        *	Returns the Edge at the given index of m_edges
        *********************************************************************************************************************************************************************/
        public Edge<V, E> this[int i]
        {
            get { return m_edges[i]; }
        }

        public bool Processed
        {
            get { return m_processed; }
            set { m_processed = value; }
        }

        public List<Edge<V, E>> m_edges { get; }
        public V m_data { get; }
        private bool m_processed;
    }
}
