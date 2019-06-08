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

namespace Client.SinglePlayer
{
    public partial class SinglePlayerGameMode : Window
    {
        private string _turn;
        private FigureMove moveCheck;
        private string winner;
        public SinglePlayerGameMode()
        {
            InitializeComponent();
            _turn = "black";
            winner = null;
            moveCheck = null;
            FillBoard();
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
                    temp.Click += new RoutedEventHandler(Figure_Move_Click);
                    switch (a)
                    {
                        case 1:
                            if (b % 2 == 1)
                            {
                                temp.Name = "Button" +"White" + a + b;
                                temp.Background = WhiteBrush;
                                stackPanel.Children.Add(temp);
                            }
                            break;
                        case 2:
                            if (b % 2 == 0)
                            {
                                temp.Name = "Button" + "White" + a + b;
                                temp.Background = WhiteBrush;
                                stackPanel.Children.Add(temp);
                            }
                            break;
                        case 3:
                            if (b % 2 == 1)
                            {
                                temp.Name = "Button" + "White" + a + b;
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
                                temp.Name = "Button" + "Black" + a + b;
                                temp.Background = BlackBrush;
                                stackPanel.Children.Add(temp);
                            }
                            break;
                        case 7:
                            if (b % 2 == 1)
                            {
                                temp.Name = "Button" + "Black" + a + b;
                                temp.Background = BlackBrush;
                                stackPanel.Children.Add(temp);
                            }
                            break;
                        case 8:
                            if (b % 2 == 0)
                            {
                                temp.Name = "Button" + "Black" + a + b;
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
        private void KingCheck(Figure figure)
        {
            StackPanel stackPanel = GetGridElement(Board, figure.row, figure.column) as StackPanel;
            var WhiteBrush = new ImageBrush();
            var BlackBrush = new ImageBrush();
            WhiteBrush.ImageSource = new BitmapImage(new Uri(@"C:\Users\Deasmond\source\repos\Winceouse\Shitty_Checkers\Client\Client\SinglePlayer\Images\WhiteKing.png", UriKind.Relative));
            BlackBrush.ImageSource = new BitmapImage(new Uri(@"C:\Users\Deasmond\source\repos\Winceouse\Shitty_Checkers\Client\Client\SinglePlayer\Images\BlackKing.png", UriKind.Relative));
            if (stackPanel.Children.Count > 0)
            {
                Button button = stackPanel.Children[0] as Button;
                if ((button.Name.Contains("Black")) && (!button.Name.Contains("King")))
                {
                    if (figure.row == 1)
                    {
                        button.Name = "BlackButtonKing" + figure.row + figure.column;
                        button.Background = BlackBrush;
                    }
                }
                else if ((button.Name.Contains("White")) && (!button.Name.Contains("King")))
                {
                    if (figure.row == 8)
                    {
                        button.Name = "WhiteButtonKing" + figure.row + figure.column;
                        button.Background = WhiteBrush;
                    }
                }
            }
        }
        private void WinnerCheck()
        {
            int White = 0, Black = 0;
            for (int a = 1; a < 9; a++)
            {
                for (int b = 0; b < 8; b++)
                {
                    StackPanel stackPanel = GetGridElement(Board, a, b) as StackPanel;
                    if (stackPanel.Children.Count > 0)
                    {
                        Button button = stackPanel.Children[0] as Button;
                        if (button.Name.Contains("White"))
                            White++;
                        if (button.Name.Contains("Black"))
                            Black++;
                    }
                }
            }
            if (White == 0)
                winner = "Black";
            if (Black == 0)
                winner = "White";
            if (winner != null)
            {
                for (int a = 1; a < 9; a++)
                {
                    for (int b = 0; b < 8; b++)
                    {
                        StackPanel stackPanel = GetGridElement(Board, a, b) as StackPanel;
                        if (stackPanel.Children.Count > 0)
                        {
                            Button button = stackPanel.Children[0] as Button;
                            button.Click -= new RoutedEventHandler(Figure_Move_Click);
                        }
                    }
                }
                MessageBox.Show(winner + " WIN THIS GAME!!!", "Winner");
            }
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
        private void AddFigure(Figure temp)
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Background = Brushes.Black;
            Button button = new Button();
            button.VerticalAlignment = VerticalAlignment.Center;
            button.HorizontalAlignment = HorizontalAlignment.Center;
            button.Background = Brushes.Black;
            button.Name = "Button" + temp.row + temp.column;
            button.Height = 75;
            button.Width = 75;
            button.Click += new RoutedEventHandler(Figure_Move_Click);
            stackPanel.Children.Add(button);
            Grid.SetRow(stackPanel, temp.row);
            Grid.SetColumn(stackPanel, temp.column);
            Board.Children.Add(stackPanel);
        }
        public void Figure_Move_Click(Object sender, RoutedEventArgs e)
        {
            Button temp = sender as Button;
            StackPanel stackPanel = temp.Parent as StackPanel;
            int col = Grid.GetColumn(stackPanel);
            int row = Grid.GetRow(stackPanel);
            if (moveCheck == null)
                moveCheck = new FigureMove();
            if (moveCheck.figure1 == null)
            {
                moveCheck.figure1 = new Figure(col, row);
                stackPanel.Background = Brushes.Green;
            }
            else
            {
                moveCheck.figure2 = new Figure(col, row);
                stackPanel.Background = Brushes.Green;
            }
            if ((moveCheck.figure1 != null) && (moveCheck.figure2 != null))
            {
                if (CheckMove())
                {
                    PlayerMakeMove();
                }
            }
        }

        private GameBoard GetGameBoard()
        {
            GameBoard gb = new GameBoard();
            for (int a = 1; a < 9; a++)
            {
                for (int b = 0; b < 8; b++)
                {
                    StackPanel stackPanel = GetGridElement(Board, a, b) as StackPanel;
                    if (stackPanel.Children.Count > 0)
                    {
                        Button button = stackPanel.Children[0] as Button;
                        if (button.Name.Contains("White"))
                        {
                            if (button.Name.Contains("King"))
                                gb.SetState(a - 1, b, 3);
                            else
                                gb.SetState(a - 1, b, -1);
                        }
                        else if (button.Name.Contains("Black"))
                        {
                            if (button.Name.Contains("King"))

                                gb.SetState(a - 1, b, 4);
                            else
                                gb.SetState(a - 1, b, 2);
                        }
                        else
                        {
                            gb.SetState(a - 1, b, 0);
                        }
                    }
                    else
                        gb.SetState(a - 1, b, -1);
                }
            }
            return gb;
        }
        private Boolean CheckMove()
        {
            StackPanel stackPanel1 = GetGridElement(Board, moveCheck.figure1.row, moveCheck.figure1.column) as StackPanel;
            Button button1 = stackPanel1.Children[0] as Button;
            stackPanel1.Background = Brushes.Black;
            StackPanel stackPanel2 = GetGridElement(Board, moveCheck.figure2.row, moveCheck.figure2.column) as StackPanel;
            Button button2 = stackPanel2.Children[0] as Button;
            stackPanel2.Background = Brushes.Black;
            if ((_turn == "Black") && (button1.Name.Contains("White")))
            {
                moveCheck.figure1 = null;
                moveCheck.figure2 = null;
                MessageBox.Show("It's Black turn", "Error");
                return false;
            }
            if ((_turn == "White") && (button1.Name.Contains("Black")))
            {
                moveCheck.figure1 = null;
                moveCheck.figure2 = null;
                MessageBox.Show("It's White turn", "Error");
                return false;
            }
            if (button1.Equals(button2))
            {
                moveCheck.figure1 = null;
                moveCheck.figure2 = null;
                return false;
            }
            if (button1.Name.Contains("White"))
            {
                return WhitePlayerCheckMove(button1, button2);
            }
            else if (button1.Name.Contains("Black"))
            {
                return BlackPlayerCheckMove(button1, button2);
            }
            else
            {
                moveCheck.figure1 = null;
                moveCheck.figure2 = null;
                return false;
            }
        }
        private bool WhitePlayerCheckMove(Button b1, Button b2)
        {
            GameBoard gb = GetGameBoard();
            List<FigureMove> moves = gb.CheckMove("White");
            if (moves.Count > 0)
            {
                bool error = true;
                foreach (FigureMove temp in moves)
                {
                    if (moveCheck.Equals(temp))
                        error = false;
                }
                if (error)
                {
                    MessageBox.Show("Make Move", "Error!!!");
                    moveCheck.figure1 = null;
                    moveCheck.figure2 = null;
                    return false;
                }
            }
            if (b1.Name.Contains("White"))
            {
                if (b1.Name.Contains("King"))
                {
                    if ((moveCheck.IsNear("King")) && (!b2.Name.Contains("Black")) && (!b2.Name.Contains("White")))
                        return true;
                    Figure tempFigure = moveCheck.IsPossibleToMove("King");
                    if ((tempFigure != null) && (!b2.Name.Contains("Black")) && (!b2.Name.Contains("White")))
                    {
                        StackPanel tempStackPanel = GetGridElement(Board, tempFigure.row, tempFigure.column) as StackPanel;
                        Button tempButton = tempStackPanel.Children[0] as Button;
                        if (tempButton.Name.Contains("Black"))
                        {
                            Board.Children.Remove(tempStackPanel);
                            AddFigure(tempFigure);
                            return true;
                        }
                    }
                }
                else
                {
                    if ((moveCheck.IsNear("White")) && (!b2.Name.Contains("Black")) && (!b2.Name.Contains("White")))
                        return true;
                    Figure tempFigure = moveCheck.IsPossibleToMove("White");
                    if ((tempFigure != null) && (!b2.Name.Contains("Black")) && (!b2.Name.Contains("White")))
                    {
                        StackPanel tempStackPanel = GetGridElement(Board, tempFigure.row, tempFigure.column) as StackPanel;
                        Button tempButton = tempStackPanel.Children[0] as Button;
                        if (tempButton.Name.Contains("Black"))
                        {
                            Board.Children.Remove(tempStackPanel);
                            AddFigure(tempFigure);
                            return true;
                        }
                    }
                }
            }
            moveCheck = null;
            MessageBox.Show("WRONG MOVE!", "Error!!!");
            return false;
        }
        private bool BlackPlayerCheckMove(Button b1, Button b2)
        {
            GameBoard gb = GetGameBoard();
            List<FigureMove> moves = gb.CheckMove("Black");
            if (moves.Count > 0)
            {
                bool error = true;
                foreach (FigureMove temp in moves)
                {
                    if (moveCheck.Equals(temp))
                        error = false;
                }
                if (error)
                {
                    MessageBox.Show("Make Move", "Error!!!");
                    moveCheck.figure1 = null;
                    moveCheck.figure2 = null;
                    return false;
                }
            }
            if (b1.Name.Contains("Black"))
            {
                if (b1.Name.Contains("King"))
                {
                    if ((moveCheck.IsNear("King")) && (!b2.Name.Contains("Black")) && (!b2.Name.Contains("White")))
                        return true;
                    Figure tempFigure = moveCheck.IsPossibleToMove("King");
                    if ((tempFigure != null) && (!b2.Name.Contains("Black")) && (!b2.Name.Contains("White")))
                    {
                        StackPanel tempStackPanel = GetGridElement(Board, tempFigure.row, tempFigure.column) as StackPanel;
                        Button tempButton = tempStackPanel.Children[0] as Button;
                        if (tempButton.Name.Contains("White"))
                        {
                            Board.Children.Remove(tempStackPanel);
                            AddFigure(tempFigure);
                            return true;
                        }
                    }
                }
            }
            else
            {
                if ((moveCheck.IsNear("Black")) && (!b2.Name.Contains("Black")) && (!b2.Name.Contains("White")))
                    return true;
                Figure tempFigure = moveCheck.IsPossibleToMove("Black");
                if ((tempFigure != null) && (!b2.Name.Contains("Black")) && (!b2.Name.Contains("White")))
                {
                    StackPanel tempStackPanel = GetGridElement(Board, tempFigure.row, tempFigure.column) as StackPanel;
                    Button tempButton = tempStackPanel.Children[0] as Button;
                    if (tempButton.Name.Contains("Black"))
                    {
                        Board.Children.Remove(tempStackPanel);
                        AddFigure(tempFigure);
                        return true;
                    }
                }
            }
            moveCheck = null;
            MessageBox.Show("WRONG MOVE!", "Error!!!");
            return false;
        }
        private void PlayerMakeMove()
        {
            if ((moveCheck.figure1 != null) && (moveCheck.figure2 != null))
            {
                StackPanel stackPanel1 = GetGridElement(Board, moveCheck.figure1.row, moveCheck.figure1.column) as StackPanel;
                Board.Children.Remove(stackPanel1);
                StackPanel stackPanel2 = GetGridElement(Board, moveCheck.figure2.row, moveCheck.figure2.column) as StackPanel;
                Board.Children.Remove(stackPanel2);
                Grid.SetRow(stackPanel1, moveCheck.figure2.row);
                Grid.SetColumn(stackPanel1, moveCheck.figure2.column);
                Board.Children.Add(stackPanel1);
                Grid.SetRow(stackPanel2, moveCheck.figure1.row);
                Grid.SetColumn(stackPanel2, moveCheck.figure1.column);
                Board.Children.Add(stackPanel2);
                KingCheck(moveCheck.figure2);
                moveCheck = null;
                if(_turn == "White")
                {
                    TurnTitle.Text = "Black Turn";
                }
                if (_turn == "Black")
                {
                    TurnTitle.Text = "White Turn";
                }
                WinnerCheck();
            }
        }
    }

}