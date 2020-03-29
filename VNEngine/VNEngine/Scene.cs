using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**********************************************************************************************************************************************************************************************************************
* Author:		Brett Sprague
* Filename:		Scene.cs
* Date Created: 3/28/2019
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
namespace VNEngine
{
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
