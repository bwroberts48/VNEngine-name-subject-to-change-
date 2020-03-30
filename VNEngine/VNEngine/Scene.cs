/**********************************************************************************************************************************************************************************************************************
* Author:		Brett Roberts
* Filename:		Scene.cs
* Date Created: 3/28/2020
*
* Class: Scene
*
* Purpose: Holds text
*
* Manager functions:
*	Scene(string bgImageName, string fgImageName, string displayText)
*
* Methods:
*   AddLine
*   
***********************************************************************************************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace VNEngine
{
    [Serializable]
    class Scene
    {
        public Scene(int id, string fgImageName, string bgImageName, string displayText)
        {
            _fgImageName = fgImageName;
            _bgImageName = bgImageName;
            _displayText = displayText;
            _id = id;
        }

        private string _fgImageName;
        private string _bgImageName;
        private string _displayText;
        private int _id;
    }
}
