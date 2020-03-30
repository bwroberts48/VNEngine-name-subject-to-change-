/**********************************************************************************************************************************************************************************************************************
* Author:		Brett Roberts
* Filename:		Vertex.cs
* Date Created: 3/29/2020
*
* Class: Vertex
*
* Purpose: Holds V data as well a list of Edges. Used as an element in a Graph List
*
* Manager functions:
*	Vertex()
*		At default, the edgelist is empty, and processed is set to false
*   Vertex(Branch data);
*		Creates a vertex with the specified data
* Methods:
*   int FindDataIndex(string data)
*       Finds if the passed through edge data exists in _edges and returns true if it does
*	void InsertEdge(Edge edge)
*	    Appends an edge to this vertex's edge list
*	void DeleteEdge(string data)
*	    Deletes the edge at the specified index of _edges
***********************************************************************************************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNEngine
{
    [Serializable]
    class Vertex
    {
        public Vertex()
        {
            _edges = new List<Edge>();
        }

        public Vertex(Branch data)
        {
            _data = data;
            _edges = new List<Edge>();
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
        private int FindDataIndex(string data)
        {
            int index = -1;

            for (int i = 0; i < _edges.Count && index == -1; ++i)
            {
                if (_edges[i].EdgeData == data)
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
        public void InsertEdge(Edge edge)
        {
            _edges.Add(edge);
        }

        /********************************************************************************************************************************************************************
        * Purpose: Removes the specified edge from the graph
        *
        * Precondition:
        *	Called through the Graph DeleteEdge function
        *
        * Postcondition:
        *   If the passed through data is not found in the edge list a GraphException is thrown
        *	Otherwise, edge from _edges at the specified index is deleted
        *********************************************************************************************************************************************************************/
        public void DeleteEdge(string data)
        {
            int index = FindDataIndex(data);
            if (index == -1)
                throw new GraphException("Index was out of bounds for edge deletion");

            _edges.Remove(_edges[index]);
        }

        /********************************************************************************************************************************************************************
        * Purpose: Overloaded subscript operator (accessor only)
        *
        * Precondition:
        *	None
        *
        * Postcondition:
        *	Returns the Edge at the given index of _edges
        *********************************************************************************************************************************************************************/
        public Edge this[int i]
        {
            get { return _edges[i]; }
        }

        public List<Edge> Edges
        {
            get { return _edges; }
        }

        public Branch Data
        {
            get { return _data; }
        }

        private List<Edge> _edges { get; }
        private Branch _data { get; }
    }
}
