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
        bool[,] battlefieldPlayer1;
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
            Button_1_0_0.Background = Brushes.White;
            Button_1_1_0.Background = Brushes.White;
            Button_1_2_0.Background = Brushes.White;
            Button_1_3_0.Background = Brushes.White;
            Button_1_4_0.Background = Brushes.White;
            Button_1_5_0.Background = Brushes.White;
            Button_1_6_0.Background = Brushes.White;
            Button_1_7_0.Background = Brushes.White;
            Button_1_8_0.Background = Brushes.White;
            Button_1_9_0.Background = Brushes.White;

            Button_1_0_1.Background = Brushes.White;
            Button_1_1_1.Background = Brushes.White;
            Button_1_2_1.Background = Brushes.White;
            Button_1_3_1.Background = Brushes.White;
            Button_1_4_1.Background = Brushes.White;
            Button_1_5_1.Background = Brushes.White;
            Button_1_6_1.Background = Brushes.White;
            Button_1_7_1.Background = Brushes.White;
            Button_1_8_1.Background = Brushes.White;
            Button_1_9_1.Background = Brushes.White;

            Button_1_0_2.Background = Brushes.White;
            Button_1_1_2.Background = Brushes.White;
            Button_1_2_2.Background = Brushes.White;
            Button_1_3_2.Background = Brushes.White;
            Button_1_4_2.Background = Brushes.White;
            Button_1_5_2.Background = Brushes.White;
            Button_1_6_2.Background = Brushes.White;
            Button_1_7_2.Background = Brushes.White;
            Button_1_8_2.Background = Brushes.White;
            Button_1_9_2.Background = Brushes.White;

            Button_1_0_3.Background = Brushes.White;
            Button_1_1_3.Background = Brushes.White;
            Button_1_2_3.Background = Brushes.White;
            Button_1_3_3.Background = Brushes.White;
            Button_1_4_3.Background = Brushes.White;
            Button_1_5_3.Background = Brushes.White;
            Button_1_6_3.Background = Brushes.White;
            Button_1_7_3.Background = Brushes.White;
            Button_1_8_3.Background = Brushes.White;
            Button_1_9_3.Background = Brushes.White;

            Button_1_0_4.Background = Brushes.White;
            Button_1_1_4.Background = Brushes.White;
            Button_1_2_4.Background = Brushes.White;
            Button_1_3_4.Background = Brushes.White;
            Button_1_4_4.Background = Brushes.White;
            Button_1_5_4.Background = Brushes.White;
            Button_1_6_4.Background = Brushes.White;
            Button_1_7_4.Background = Brushes.White;
            Button_1_8_4.Background = Brushes.White;
            Button_1_9_4.Background = Brushes.White;

            Button_1_0_5.Background = Brushes.White;
            Button_1_1_5.Background = Brushes.White;
            Button_1_2_5.Background = Brushes.White;
            Button_1_3_5.Background = Brushes.White;
            Button_1_4_5.Background = Brushes.White;
            Button_1_5_5.Background = Brushes.White;
            Button_1_6_5.Background = Brushes.White;
            Button_1_7_5.Background = Brushes.White;
            Button_1_8_5.Background = Brushes.White;
            Button_1_9_5.Background = Brushes.White;

            Button_1_0_6.Background = Brushes.White;
            Button_1_1_6.Background = Brushes.White;
            Button_1_2_6.Background = Brushes.White;
            Button_1_3_6.Background = Brushes.White;
            Button_1_4_6.Background = Brushes.White;
            Button_1_5_6.Background = Brushes.White;
            Button_1_6_6.Background = Brushes.White;
            Button_1_7_6.Background = Brushes.White;
            Button_1_8_6.Background = Brushes.White;
            Button_1_9_6.Background = Brushes.White;

            Button_1_0_7.Background = Brushes.White;
            Button_1_1_7.Background = Brushes.White;
            Button_1_2_7.Background = Brushes.White;
            Button_1_3_7.Background = Brushes.White;
            Button_1_4_7.Background = Brushes.White;
            Button_1_5_7.Background = Brushes.White;
            Button_1_6_7.Background = Brushes.White;
            Button_1_7_7.Background = Brushes.White;
            Button_1_8_7.Background = Brushes.White;
            Button_1_9_7.Background = Brushes.White;

            Button_1_0_8.Background = Brushes.White;
            Button_1_1_8.Background = Brushes.White;
            Button_1_2_8.Background = Brushes.White;
            Button_1_3_8.Background = Brushes.White;
            Button_1_4_8.Background = Brushes.White;
            Button_1_5_8.Background = Brushes.White;
            Button_1_6_8.Background = Brushes.White;
            Button_1_7_8.Background = Brushes.White;
            Button_1_8_8.Background = Brushes.White;
            Button_1_9_8.Background = Brushes.White;

            Button_1_0_9.Background = Brushes.White;
            Button_1_1_9.Background = Brushes.White;
            Button_1_2_9.Background = Brushes.White;
            Button_1_3_9.Background = Brushes.White;
            Button_1_4_9.Background = Brushes.White;
            Button_1_5_9.Background = Brushes.White;
            Button_1_6_9.Background = Brushes.White;
            Button_1_7_9.Background = Brushes.White;
            Button_1_8_9.Background = Brushes.White;
            Button_1_9_9.Background = Brushes.White;




            Button_2_0_0.Background = Brushes.White;
            Button_2_1_0.Background = Brushes.White;
            Button_2_2_0.Background = Brushes.White;
            Button_2_3_0.Background = Brushes.White;
            Button_2_4_0.Background = Brushes.White;
            Button_2_5_0.Background = Brushes.White;
            Button_2_6_0.Background = Brushes.White;
            Button_2_7_0.Background = Brushes.White;
            Button_2_8_0.Background = Brushes.White;
            Button_2_9_0.Background = Brushes.White;

            Button_2_0_1.Background = Brushes.White;
            Button_2_1_1.Background = Brushes.White;
            Button_2_2_1.Background = Brushes.White;
            Button_2_3_1.Background = Brushes.White;
            Button_2_4_1.Background = Brushes.White;
            Button_2_5_1.Background = Brushes.White;
            Button_2_6_1.Background = Brushes.White;
            Button_2_7_1.Background = Brushes.White;
            Button_2_8_1.Background = Brushes.White;
            Button_2_9_1.Background = Brushes.White;

            Button_2_0_2.Background = Brushes.White;
            Button_2_1_2.Background = Brushes.White;
            Button_2_2_2.Background = Brushes.White;
            Button_2_3_2.Background = Brushes.White;
            Button_2_4_2.Background = Brushes.White;
            Button_2_5_2.Background = Brushes.White;
            Button_2_6_2.Background = Brushes.White;
            Button_2_7_2.Background = Brushes.White;
            Button_2_8_2.Background = Brushes.White;
            Button_2_9_2.Background = Brushes.White;

            Button_2_0_3.Background = Brushes.White;
            Button_2_1_3.Background = Brushes.White;
            Button_2_2_3.Background = Brushes.White;
            Button_2_3_3.Background = Brushes.White;
            Button_2_4_3.Background = Brushes.White;
            Button_2_5_3.Background = Brushes.White;
            Button_2_6_3.Background = Brushes.White;
            Button_2_7_3.Background = Brushes.White;
            Button_2_8_3.Background = Brushes.White;
            Button_2_9_3.Background = Brushes.White;

            Button_2_0_4.Background = Brushes.White;
            Button_2_1_4.Background = Brushes.White;
            Button_2_2_4.Background = Brushes.White;
            Button_2_3_4.Background = Brushes.White;
            Button_2_4_4.Background = Brushes.White;
            Button_2_5_4.Background = Brushes.White;
            Button_2_6_4.Background = Brushes.White;
            Button_2_7_4.Background = Brushes.White;
            Button_2_8_4.Background = Brushes.White;
            Button_2_9_4.Background = Brushes.White;

            Button_2_0_5.Background = Brushes.White;
            Button_2_1_5.Background = Brushes.White;
            Button_2_2_5.Background = Brushes.White;
            Button_2_3_5.Background = Brushes.White;
            Button_2_4_5.Background = Brushes.White;
            Button_2_5_5.Background = Brushes.White;
            Button_2_6_5.Background = Brushes.White;
            Button_2_7_5.Background = Brushes.White;
            Button_2_8_5.Background = Brushes.White;
            Button_2_9_5.Background = Brushes.White;

            Button_2_0_6.Background = Brushes.White;
            Button_2_1_6.Background = Brushes.White;
            Button_2_2_6.Background = Brushes.White;
            Button_2_3_6.Background = Brushes.White;
            Button_2_4_6.Background = Brushes.White;
            Button_2_5_6.Background = Brushes.White;
            Button_2_6_6.Background = Brushes.White;
            Button_2_7_6.Background = Brushes.White;
            Button_2_8_6.Background = Brushes.White;
            Button_2_9_6.Background = Brushes.White;

            Button_2_0_7.Background = Brushes.White;
            Button_2_1_7.Background = Brushes.White;
            Button_2_2_7.Background = Brushes.White;
            Button_2_3_7.Background = Brushes.White;
            Button_2_4_7.Background = Brushes.White;
            Button_2_5_7.Background = Brushes.White;
            Button_2_6_7.Background = Brushes.White;
            Button_2_7_7.Background = Brushes.White;
            Button_2_8_7.Background = Brushes.White;
            Button_2_9_7.Background = Brushes.White;

            Button_2_0_8.Background = Brushes.White;
            Button_2_1_8.Background = Brushes.White;
            Button_2_2_8.Background = Brushes.White;
            Button_2_3_8.Background = Brushes.White;
            Button_2_4_8.Background = Brushes.White;
            Button_2_5_8.Background = Brushes.White;
            Button_2_6_8.Background = Brushes.White;
            Button_2_7_8.Background = Brushes.White;
            Button_2_8_8.Background = Brushes.White;
            Button_2_9_8.Background = Brushes.White;

            Button_2_0_9.Background = Brushes.White;
            Button_2_1_9.Background = Brushes.White;
            Button_2_2_9.Background = Brushes.White;
            Button_2_3_9.Background = Brushes.White;
            Button_2_4_9.Background = Brushes.White;
            Button_2_5_9.Background = Brushes.White;
            Button_2_6_9.Background = Brushes.White;
            Button_2_7_9.Background = Brushes.White;
            Button_2_8_9.Background = Brushes.White;
            Button_2_9_9.Background = Brushes.White;


        }




    }
}
