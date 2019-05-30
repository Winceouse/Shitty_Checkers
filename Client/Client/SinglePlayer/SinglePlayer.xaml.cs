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
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Interaction logic for SinglePlayer.xaml
    /// </summary>
    public partial class SinglePlayer : Window
    {
        public SinglePlayer()
        {
            Application.Current.ShutdownMode = ShutdownMode.OnLastWindowClose;
            InitializeComponent();
            FillBoard();
        }
        private void FillBoard()
        {
            for (int a = 1; a < 9; a++)
            {
                for (int b = 0; b < 8; b++)
                {
                    StackPanel stackPanel = new StackPanel();
                    if (a % 2 == 1)
                    {
                        if (b % 2 == 0)
                            stackPanel.Background = Brushes.White;
                        else
                            stackPanel.Background = Brushes.Black;
                    }
                    else
                    {
                        if (b % 2 == 0)
                            stackPanel.Background = Brushes.Black;
                        else
                            stackPanel.Background = Brushes.White;
                    }
                    Grid.SetRow(stackPanel, a);
                    Grid.SetColumn(stackPanel, b);
                    Board.Children.Add(stackPanel);
                }
            }
            CreateFigures();
        }
        UIElement GetGridElement(Grid temp, int a, int b)
        {
            for (int i = 0; i < temp.Children.Count; i++)
            {
                UIElement uIElement = temp.Children[i];
                if (Grid.GetRow(uIElement) == a && Grid.GetColumn(uIElement) == b)
                    return uIElement;
            }
            return null;
        }
        private void CreateFigures()
        {
            var WhiteBrush = new ImageBrush();
            var BlackBrush = new ImageBrush();
            WhiteBrush.ImageSource = new BitmapImage(new Uri(@"C:\Users\Deasmond\source\repos\Winceouse\Shitty_Checkers\Client\Client\SinglePlayer\Images\White.png", UriKind.Relative));
            BlackBrush.ImageSource = new BitmapImage(new Uri(@"C:\Users\Deasmond\source\repos\Winceouse\Shitty_Checkers\Client\Client\SinglePlayer\Images\Black.png", UriKind.Relative));

            for (int a = 1; a < 9; a++)
            {
                for (int b = 0; b < 8; b++)
                {
                    StackPanel stackPanel = (StackPanel)GetGridElement(Board, a, b);
                    Button temp = new Button();
                    temp.HorizontalAlignment = HorizontalAlignment.Center;
                    temp.VerticalAlignment = VerticalAlignment.Center;
                    temp.Height = 75;
                    temp.Width = 75;
                    

                    switch (a)
                    {
                        case 1:
                            if (b % 2 == 1)
                            {
                                temp.Name = "WhiteButton" + a + b;
                                temp.Background = WhiteBrush;
                                stackPanel.Children.Add(temp);
                            }
                            break;
                        case 2:
                            if (b % 2 == 0)
                            {
                                temp.Name = "WhiteButton" + a + b;
                                temp.Background = WhiteBrush;
                                stackPanel.Children.Add(temp);
                            }
                            break;
                        case 3:
                            if (b % 2 == 1)
                            {
                                temp.Name = "WhiteButton" + a + b;
                                temp.Background = WhiteBrush;
                                stackPanel.Children.Add(temp);
                            }
                            break;
                        case 4:
                            if (b % 2 == 0)
                            {
                                temp.Name = "Button" + a + b;
                                temp.Background = Brushes.Black;
                                stackPanel.Children.Add(temp);
                            }
                            break;
                        case 5:
                            if (b % 2 == 1)
                            {
                                temp.Name = "Button" + a + b;
                                temp.Background = Brushes.Black;
                                stackPanel.Children.Add(temp);
                            }
                            break;
                        case 6:
                            if (b % 2 == 0)
                            {
                                temp.Name = "BlackButton" + a + b;
                                temp.Background = BlackBrush;
                                stackPanel.Children.Add(temp);
                            }
                            break;
                        case 7:
                            if (b % 2 == 1)
                            {
                                temp.Name = "BlackButton" + a + b;
                                temp.Background = BlackBrush;
                                stackPanel.Children.Add(temp);
                            }
                            break;
                        case 8:
                            if (b % 2 == 0)
                            {
                                temp.Name = "BlackButton" + a + b;
                                temp.Background = BlackBrush;
                                stackPanel.Children.Add(temp);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        //////////////////////////
    }
}
