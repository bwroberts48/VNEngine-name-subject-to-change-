/**********************************************************************************************************************************************************************************************************************
* Author:		Brett Roberts
* Filename:		Edge.cs
* Date Created: 3/29/2020
*
* Class: Edge
*
* Purpose: Holds E data as well as the index of a vertex within the graph indicating how vertices are connected
*
* Manager functions:
*	Edge()
*		By default, m_weight is 0
*	Edge(E edgeData, int vertexId, int weight)
*		Creates an edge with the passed in edgeData and weight. It is connected to the vertex that shares the passed in vertexData.
***********************************************************************************************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNEngine
{
    class Edge
    {
        public Edge()
        {
            _weight = 0;
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
        public Edge(string edgeData, int vertexId, int weight)
        {
            if (weight < 0 && !GraphGlobals.NEGATIVE_WEIGHTS_ALLOWED)
                throw new GraphException("Weight cannot be negative");

            _edgeData = edgeData;
            _vertexId = vertexId;
            _weight = weight;
        }

        public string EdgeData
        {
            get { return _edgeData; }
        }

        public int VertexId
        {
            get { return _vertexId; }
        }

        private string _edgeData;
        private int _vertexId;
        private int _weight;
    }
}
