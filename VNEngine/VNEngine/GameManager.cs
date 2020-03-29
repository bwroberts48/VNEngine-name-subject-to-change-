/**********************************************************************************************************************************************************************************************************************
* Author:		Brett Roberts
* Filename:		SceneManager.cs
* Date Created: 3/28/2020
*
* Class: GameManager (Singleton)
*
* Purpose: Holds instances for all Manager classes and other global settings
*
* Manager functions:
*	private GameManager()
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

namespace VNEngine
{
    public sealed class GameManager
    {
        private GameManager()
        {
            _sceneManager = SceneManager.Instance;
        }

        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameManager();
                return _instance;
            }
        }

        public SceneManager Scene_Manager
        {
            get { return _sceneManager; }
        }

        private static GameManager _instance = null;
        private SceneManager _sceneManager;
    }
}
