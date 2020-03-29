using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**********************************************************************************************************************************************************************************************************************
* Author:		Brett Sprague
* Filename:		Branch.cs
* Date Created: 3/28/2019
*
* Class: Scene
*
* Purpose: Creates and adds to a list of SceneLines with an ID for future reference
*
* Manager functions:
*	Branch(int id, string fgImageName, string bgImageName, string displayText)
*
* Methods:
*   void AddScene(string fgImageName, string bgImageName, string displayText)
*       Appends a scene to the current
*       
*   
***********************************************************************************************************************************************************************************************************************/
namespace VNEngine
{

    class Branch
    {
        public Branch(int id, string fgImageName, string bgImageName, string displayText)
        {
            AddScene(fgImageName, bgImageName, displayText);

            _id = id;
            _currLineId = 0;
        }

        //Will not change last known values for any fields that are null
        public void AddScene(string fgImageName, string bgImageName, string displayText)
        {
            m_scenes.Add(new Scene(_currLineId, fgImageName, bgImageName, displayText));
            ++_currLineId;
        }

        private List<Scene> m_scenes;
        private int _id;
        private int _currLineId;
    }
}
