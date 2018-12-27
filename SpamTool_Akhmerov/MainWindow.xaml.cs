using MahApps.Metro.Controls;
using System.Windows;

namespace SpamTool_Akhmerov
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnExitClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
