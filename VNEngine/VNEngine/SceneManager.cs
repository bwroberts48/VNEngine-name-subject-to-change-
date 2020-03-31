/**********************************************************************************************************************************************************************************************************************
* Author:		Brett Roberts
* Filename:		SceneManager.cs
* Date Created: 3/28/2020
*
* Class: SceneManager (Singleton)
*
* Purpose: Directed unweighted graph wrapper for all branches of scenes in the game. Branches are vertices and text the player chooses to cause a branch are the edges
*
* Manager functions:
*	private SceneManager()
*
* Methods:
*  void AddScene(string fgImageName, string bgImageName, string displayText)
*  void AddBranchConnection(int startId, int endId)
*       Creates a directed edge from the Branch with the given startId to the Branch with the given endId
*  void SerializeScenes()
*       Serializes the underlaying data structure and puts it in a file
***********************************************************************************************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace VNEngine
{
    public sealed class SceneManager
    {
        private SceneManager()
        {
            _graph = new BranchesGraph();
        }

        public void AddBranch(string fgImageName, string bgImageName, string displayText)
        {
            //Construct and add the new scene to the graph
            _graph.InsertVertex(new Branch(_currSceneID, fgImageName, bgImageName, displayText));
            ++_currSceneID;
        }

        //Creates a connection from the startId to the endId with the choiceText as the data for the edge
        public void AddBranchConnection(int startId, int endId, string choiceText)
        {
            _graph.InsertEdge(startId, endId, choiceText, 0, true);
        }

        //Throws a SerializationException if _graph was not successfully serialized
        public void SerializeScenes()
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(SAVE_FILE_PATH + "text.nstc", FileMode.Create, FileAccess.Write);
                formatter.Serialize(stream, _graph);
                stream.Close();
            }
            catch
            {
                throw new SerializationException("Could not serialize SceneManager to \"" + SAVE_FILE_PATH + "\" successfully");
            }
        }

        public static SceneManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SceneManager();
                return _instance;
            }
        }

        private static SceneManager _instance = null;
        private int _currSceneID = 0;
        private BranchesGraph _graph;

        private const string SAVE_FILE_PATH = "..\\NSTC_Files\\";
    }
}
