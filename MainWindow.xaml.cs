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
        bool[,] battlefieldPlayer1 = new bool[10,10];
        bool[,] battlefieldPlayer2;
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
            player1.Health = 17;
            player2.Health = 17;
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
                    }
                    else
                    {
                        button.Background = Brushes.Gray;
                        IsPlayer1Turn ^= true;
                    }
                    if (player2.Health == 0)
                    {
                        MessageBox.Show("Player 1 won. Player who lost starts next game");
                        Player1Score.Text = (int.Parse(Player1Score.Text) + 1).ToString();
                        NewGame();
                        return;
                    }
                }
            }
            else if (buttonValue[1] == "2" && IsPlayer1Turn == false)
            {
                if (button.Background == Brushes.White)
                {
                    if (battlefieldPlayer2[int.Parse(buttonValue[2]), int.Parse(buttonValue[3])] == true)
                    {
                        button.Background = Brushes.Green;
                        player1.Health = player1.Health - 1;
                        IsPlayer1Turn ^= true;
                    }
                    else
                    {
                        button.Background = Brushes.Gray;
                        IsPlayer1Turn ^= true;
                    }
                    if (player1.Health == 0)
                    {
                        MessageBox.Show("Player 2 won. Player who lost starts next game");
                        Player2Score.Text = (int.Parse(Player2Score.Text) + 1).ToString() ;
                        NewGame();
                        return;
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
    }
}
