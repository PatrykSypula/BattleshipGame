using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Battleship_game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Player player1 = new Player();
        Player player2 = new Player();
        bool IsPlayer1Turn = true;
        bool[,] battlefieldPlayer1 = new bool[10, 10];//size of battlefield
        bool[,] battlefieldPlayer2;
        int checks = 0;
        bool leftChecked = false;
        bool rightChecked = false;
        bool topChecked = false;
        bool bottomChecked = false;
        bool tryToFindAllPossibilities = false;
        int howManyMoveRow = 0;
        int howManyMoveColumn = 0;
        int row = 0;
        int column = 0;

        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }
        /// <summary>
        /// Create new game
        /// </summary>
        public void NewGame()
        {
            ClearFields();
            battlefieldPlayer1 = GenerateBattlefield.GenerateField();
            battlefieldPlayer2 = GenerateBattlefield.GenerateField();
            player1 = new Player();//Set player's health to max
            player2 = new Player();
            GC.Collect();
        }
        public void ClearCheck()
        {
            checks = 0;
            leftChecked = false;
            rightChecked = false;
            topChecked = false;
            bottomChecked = false;
            howManyMoveRow = 0;
            howManyMoveColumn = 0;
            tryToFindAllPossibilities = false;
        }
        //Check if the button pressed contains ship (true value in array), if yes then reduces seconds player health
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            Regex regex = new Regex("_");

            string[] buttonValue = regex.Split(button.Name);
            if (buttonValue[1] == "1" && IsPlayer1Turn == true)
            {
                if (button.Background == Brushes.White)
                {
                    if (battlefieldPlayer1[int.Parse(buttonValue[2]), int.Parse(buttonValue[3])] == true)
                    {
                        button.Background = Brushes.Green;
                        player2.Health = player2.Health - 1;
                        IsPlayer1Turn ^= true;
                        EnemyTurn();
                    }
                    else
                    {
                        button.Background = Brushes.Gray;
                        IsPlayer1Turn ^= true;
                        EnemyTurn();
                    }
                    if (player2.Health == 0)
                    {
                        Player1Win();
                    }
                }
            }

        }

        public void EnemyTurn()
        {
            if (player2.Health == 0)
            {
                Player1Win();
            }
            if (!IsPlayer1Turn)
            {
                var button = new Button();
                Random random = new Random();
                bool didMove = false;
                while (!didMove)
                {
                    if (!tryToFindAllPossibilities)
                    {
                        row = random.Next(0, 10);
                        column = random.Next(0, 10);
                        button = FindButton();
                        GC.Collect();
                        TryMove(ref didMove);
                    }
                    else
                    {
                        if (checks == 4)
                        {
                            ClearCheck();
                        }
                        else if (!leftChecked)
                        {
                            howManyMoveRow++;
                            var buttonCheck = TryMove(ref didMove);
                            if (buttonCheck.Background != Brushes.Green)
                            {
                                leftChecked = true;
                                howManyMoveRow = 0;
                                checks++;
                            }
                        }
                        else if (!rightChecked)
                        {
                            howManyMoveRow--;
                            var buttonCheck = TryMove(ref didMove);
                            if (buttonCheck.Background != Brushes.Green)
                            {
                                rightChecked = true;
                                howManyMoveRow = 0;
                                checks++;
                            }
                        }
                        else if (!topChecked)
                        {
                            howManyMoveColumn--;
                            var buttonCheck = TryMove(ref didMove);
                            if (buttonCheck.Background != Brushes.Green)
                            {
                                topChecked = true;
                                howManyMoveColumn = 0;
                                checks++;
                            }
                        }
                        else if (!bottomChecked)
                        {
                            howManyMoveColumn++;
                            var buttonCheck = TryMove(ref didMove);
                            if (buttonCheck.Background != Brushes.Green)
                            {
                                bottomChecked = true;
                                howManyMoveColumn = 0;
                                checks++;
                            }
                        }
                    }
                    if (player1.Health == 0)
                    {
                        Player2Win();
                    }
                }
            }
        }
        /// <summary>
        /// Set all button colors to white
        /// </summary>
        public void ClearFields()
        {
            foreach (var x in gameGrid.Children.OfType<Button>())
            {
                x.Background = Brushes.White;
            }

        }
        public Button TryMove(ref bool didMove)
        {
            var button = FindButton();
            if (button.Background == Brushes.White && battlefieldPlayer2[row - howManyMoveRow, column - howManyMoveColumn] == true)
            {
                button.Background = Brushes.Green;
                player1.Health = player1.Health - 1;
                IsPlayer1Turn ^= true;
                didMove = true;
                tryToFindAllPossibilities = true;
            }
            else if (button.Background == Brushes.White && battlefieldPlayer2[row - howManyMoveRow, column - howManyMoveColumn] == false)
            {
                button.Background = Brushes.Gray;
                IsPlayer1Turn ^= true;
                didMove = true;
            }
            return button;
        }

        public Button FindButton()
        {
            var button = new Button();
            int rowNumber = row - howManyMoveRow;
            int columnNumber = column - howManyMoveColumn;
            foreach (var x in gameGrid.Children.OfType<Button>())
            {
                if (x.Name == "Button_2_" + rowNumber + "_" + columnNumber)
                    button = x;
            }
            return button;
        }
        public void Player1Win()
        {
            MessageBox.Show("Player 1 won. Player who lost starts next game");
            Player1Score.Text = (int.Parse(Player1Score.Text) + 1).ToString();
            NewGame();
            IsPlayer1Turn ^= true;
            EnemyTurn();
            return;
        }
        public void Player2Win()
        {
            MessageBox.Show("Player 2 won. Player who lost starts next game");
            Player2Score.Text = (int.Parse(Player2Score.Text) + 1).ToString();
            NewGame();
            return;
        }
    }
}
