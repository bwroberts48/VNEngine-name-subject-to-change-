/**********************************************************************************************************************************************************************************************************************
* Author:		Brett Sprague
* Filename:		Edge.cs
* Date Created: 5/17/2019
*
* Class: Edge
*
* Purpose: Holds E data as well as the index of a vertex within the graph indicating how vertices are connected
*
* Manager functions:
*	Edge()
*		By default, m_weight is 0
*	Edge(E edgeData, V vertexData, int weight)
*		Creates an edge with the passed in edgeData and weight. It is connected to the vertex that shares the passed in vertexData.
***********************************************************************************************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Edge<V, E>
    {
        public Edge()
        {
            m_weight = 0;
        }

        /********************************************************************************************************************************************************************
        * Purpose: Creates an edge with passed in attributes
        *
        * Precondition:
        *	None
        *
        * Postcondition:
        *	If NEGATIVE_WEIGHTS_ALLOWED dictates there cannot be negative weights and a negative weight is passed in a GraphException is thrown
        *	Otherwise, an Edge is created
        *********************************************************************************************************************************************************************/
        public Edge(E edgeData, V vertexData, int weight)
        {
            if (weight < 0 && !GraphGlobals.NEGATIVE_WEIGHTS_ALLOWED)
                throw new GraphException("Weight cannot be negative");

            m_edgeData = edgeData;
            m_vertexData = vertexData;
            m_weight = weight;
        }


        public E m_edgeData { get; }
        public V m_vertexData { get; }
        private int m_weight;
    }
}
