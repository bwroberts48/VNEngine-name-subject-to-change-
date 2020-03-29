/**********************************************************************************************************************************************************************************************************************
* Author:		Brett Sprague
* Filename:		SceneManager.cs
* Date Created: 3/28/2020
*
* Class: SceneManager
*
* Purpose: Directed unweighted graph wrapper for all branches of scenes in the game. Branches are vertices and text the player chooses to cause a branch are the edges
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
            m_graph = new Graph<Branch, string>();
        }

        void AddBranch(string fgImageName, string bgImageName, string displayText)
        {
            //Construct and add the new scene to the graph
            m_graph.InsertVertex(new Branch(_currSceneID, fgImageName, bgImageName, displayText));
            ++_currSceneID;
        }

        //Creates a connection from the startId to the endId with the choiceText as the data for the edge
        void AddBranchConnection(int startId, int endId, string choiceText)
        {
            m_graph.InsertEdge(new Branch(startId), new Branch(endId), choiceText, 0, true);
        }

        private Graph<Branch, string> m_graph;
        private int _currSceneID;
    }
}
