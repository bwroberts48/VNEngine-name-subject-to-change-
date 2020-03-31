using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using VNEngine;

namespace GameGUI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DeserializeScenes();
        }

        //Deserialize the file from the CreationGUI and store it into a graph for this project
        void DeserializeScenes()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(LOAD_FILE_PATH + "text.nstc", FileMode.Open, FileAccess.Read);
            _graph = (BranchesGraph)formatter.Deserialize(stream);
        }


        private BranchesGraph _graph;

        private const string LOAD_FILE_PATH = "..\\..\\..\\CreationGUI\\bin\\NSTC_Files\\";
    }
}
