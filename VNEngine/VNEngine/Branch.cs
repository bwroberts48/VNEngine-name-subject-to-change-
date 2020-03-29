/**********************************************************************************************************************************************************************************************************************
* Author:		Brett Roberts
* Filename:		Branch.cs
* Date Created: 3/28/2020
*
* Class: Scene
*   Inherits from IComparable
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
*   public int CompareTo(Object obj)
*   
***********************************************************************************************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace VNEngine
{

    class Branch : IComparable<Branch>
    {
        public Branch(int id, string fgImageName = null, string bgImageName = null, string displayText = null)
        {
            m_scenes = new List<Scene>();
            _id = id;
            _currLineId = 0;

            AddScene(fgImageName, bgImageName, displayText);
        }

        //Will not change last known values for any fields that are null
        public void AddScene(string fgImageName, string bgImageName, string displayText)
        {
            m_scenes.Add(new Scene(_currLineId, fgImageName, bgImageName, displayText));
            ++_currLineId;
        }

        //Compares the IDs of branches
        public int CompareTo(Branch other)
        {
            if (other == null)
                return 1;

            return _id.CompareTo(other._id);
        }

        private List<Scene> m_scenes;
        private int _id;
        private int _currLineId;
    }
}
