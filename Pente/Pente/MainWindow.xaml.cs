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

namespace Pente
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
  
    // We can use outside libraries to help with unit testing; automated clicks and things
    public partial class MainWindow : Window
    {
        public Button VsComputerBtnProp
        {
            get { return VsComputerBtn; }
            set { VsComputerBtn = value; }
        }
        public Button VsPlayerBtnProp
        {
            get { return VsPlayerBtn; }
            set { VsPlayerBtn = value; }
        }
        public WrapPanel PlayerPanelProp {
            get { return PlayerPanel; }
            set { PlayerPanel = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        public void PvP_Click(object sender, RoutedEventArgs e)
        {
            PlayerPanel.Visibility = Visibility.Collapsed;
            NamePanel.Visibility = Visibility.Visible;
        }

        public void PvC_Click(object sender, RoutedEventArgs e)
        {
            PlayerPanel.Visibility = Visibility.Collapsed;
            PvPNameDockPanel.Visibility = Visibility.Collapsed;
            NamePanel.Visibility = Visibility.Visible;
        }

        public void Start_Click(object sender, RoutedEventArgs e)
        {
            PenteLabel.Visibility = Visibility.Collapsed;
            NamePanel.Visibility = Visibility.Collapsed;
            PNameBlock.Text = PlayerNameBox.Text;
            if (string.IsNullOrEmpty(PlayerNameBox.Text))
                PNameBlock.Text = "Player 1:";

            if (!string.IsNullOrEmpty(EnemyNameBox.Text))
                ENameBlock.Text = EnemyNameBox.Text;
            else
                ENameBlock.Text = "Player 2:";

            ControlPanel.Visibility = Visibility.Visible;
            GameBoardGrid.Visibility = Visibility.Visible;
            BoardBackground();
        }

        public void BoardBackground()
        {
            for(int i = 0; i < 19; i++)
            {
                for(int j = 0; j < 19; j++)
                {
                    Button b = new Button();
                    b.BorderThickness = new Thickness(0);
                    ImageBrush imgBrush = new ImageBrush();
                    imgBrush.ImageSource =
                    new BitmapImage(
                        new Uri(@"pack://application:,,,/Pente;component/Images/white.png", UriKind.RelativeOrAbsolute)
                    );
                    b.Background = imgBrush;

                    GameBoardGrid.Children.Add(b);
                }

            }
        }
    }
}
