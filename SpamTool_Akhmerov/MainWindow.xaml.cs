using MahApps.Metro.Controls;
using System.Windows;

namespace SpamTool_Akhmerov
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            BtnPreviousTab.IsEnabled = false;
        }
    }
}
