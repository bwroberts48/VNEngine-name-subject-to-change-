/**********************************************************************************************************************************************************************************************************************
* Author:		Brett Sprague
* Filename:		SceneManager.cs
* Date Created: 3/28/2020
*
* Class: SceneManager
*
* Purpose: Directed unweighted graph wrapper for all scenes in the game where scenes are vertices.
*
* Manager functions:
*	SceneManager()
*
* Methods:
*  void AddScene(string fgImageName, string bgImageName, string displayText)
*  void AddBranchConnection(int startId, int endId)
*       Creates a directed edge from the Branch with the given startId to the Branch with the given endId
***********************************************************************************************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph;
namespace VNEngine
{
    public class SceneManager
    {
        public SceneManager()
        {
            _currSceneID = 0;
           // m_graph = new Graph<Branch, string>();
        }

        void AddBranch(string fgImageName, string bgImageName, string displayText)
        {
            //Construct and add the new scene to the graph
            m_graph.InsertVertex(new Branch(_currSceneID, fgImageName, bgImageName, displayText));
            ++_currSceneID;
        }

        void AddBranchConnection(int startId, int endId)
        {
 
        }

        private Graph<Branch, string> m_graph;
        private int _currSceneID;
    }
}
