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
using VNEngine;

namespace CreationGUI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            _gameManager = GameManager.Instance;
        }

        private void CreateBranch_Click(object sender, RoutedEventArgs e)
        {
            _gameManager.Scene_Manager.AddBranch(fgPathTB.Text, bgPathTB.Text, displayTextTB.Text);
        }

        private void ConnectBranch_Click(object sender, RoutedEventArgs e)
        {
            _gameManager.Scene_Manager.AddBranchConnection
                (Int32.Parse(branchFromTB.Text), Int32.Parse(branchToTB.Text), branchDialogueTB.Text);
        }

        private void SaveProject_Click(object sender, RoutedEventArgs e)
        {
            _gameManager.Scene_Manager.SerializeScenes();
        }

        GameManager _gameManager;
    }
}
