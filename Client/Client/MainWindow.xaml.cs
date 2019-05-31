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
using System.Threading;
using Client.SinglePlayer;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Client.SinglePlayer.SinglePlayerGameMode singlePlayerWindow = new Client.SinglePlayer.SinglePlayerGameMode();
        public MainWindow()
        {
            Application.Current.ShutdownMode = ShutdownMode.OnLastWindowClose;
            InitializeComponent();
        }

        private void Single_Player_Menu(object sender, RoutedEventArgs e)
        {
           singlePlayerWindow.Show();
            MainMenu.Close();
        }
        private void Multi_Player_Menu(object sender, RoutedEventArgs e)
        {
            MainMenu.Close();
        }

    }
    
}

