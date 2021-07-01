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

namespace WpfPractice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int Turn { get; set; }
        public class Player
        {
            public string Name;
            public int HP;
            public int Atk;

            public Player(string name)
            {
                Random rd = new Random();
                Name = name;
                HP = 100;
                Atk = rd.Next(0, 30);
                
            }
            public Player(string name, int atk)
            {
                Name = name;
                HP = 100;
                Atk = atk;
            }
        }
        
            Player playOne = new Player("matt");
            Player playTwo = new Player("evil Matt");
        
        public MainWindow()
        {
            InitializeComponent();
            Turn = 0;
            oneHPLbl.Content = playOne.HP;
            oneName.Content = playOne.Name;
            oneATK.Content = playOne.Atk;

            twoHPlbl.Content = playTwo.HP;
            twoname.Content = playTwo.Name;
            twoATK.Content = playTwo.Atk;
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            if (Turn == 0)
            {
                if (playTwo.HP <= 0)
                {
                    MessageBox.Show($"{playOne.Name} wins");
                    turnBar.Value = 100;
                    return;
                }
                playTwo.HP -= playOne.Atk;
                twoHPlbl.Content = playTwo.HP;
                twoHP.Value -= (playOne.Atk);
                if (playTwo.HP <= 0)
                {
                    MessageBox.Show($"{playOne.Name} wins");
                    turnBar.Value = 100;
                    return;
                }

                Turn = 1;
                turnBar.FlowDirection = FlowDirection.RightToLeft;
                turnBar.Foreground = Brushes.Red;
            } else
            {
                if (playOne.HP <= 0)
                {
                    MessageBox.Show($"{playTwo.Name} wins");
                    turnBar.Value = 100;
                    return;
                }
                playOne.HP -= playTwo.Atk;
                oneHPLbl.Content = playOne.HP;
                oneHP.Value -= (playTwo.Atk);
                if (playOne.HP <= 0)
                {
                    MessageBox.Show($"{playTwo.Name} wins");
                    turnBar.Value = 100;
                    return;
                }

                Turn = 0;
                turnBar.FlowDirection = FlowDirection.LeftToRight;
                turnBar.Foreground = Brushes.Blue;
            }
            
        }
    }
}
