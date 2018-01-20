using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        public bool isPlayer1Turn = true;
        public bool computerEnabled = false;
        public int tileSize = 11;
        public Button[,] board;
        ImageBrush imgBrushTile = new ImageBrush();
        ImageBrush imgBrushBlack = new ImageBrush();
        ImageBrush imgBrushWhite = new ImageBrush();
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
        public StackPanel NamePanelProp
        {
            get { return NamePanel; }
            set { NamePanel = value; }
        }
        public Label PenteLabelProp
        {
            get { return PenteLabel; }
            set { PenteLabel = value; }
        }

        public StackPanel ControlPanelProp
        {
            get { return ControlPanel; }
            set { ControlPanel = value; }
        }
        public UniformGrid GameBoardGridProp
        {
            get { return GameBoardGrid; }
            set { GameBoardGrid = value; }
        }
        public TextBlock PNameBlockProp
        {
            get { return PNameBlock; }
            set { PNameBlock = value; }
        }
        public DockPanel PvPNameDockPanelProp
        {
            get { return PvPNameDockPanel; }
            set { PvPNameDockPanel = value; }
        }
        public TextBox PlayerNameBoxProp
        {
            get { return PlayerNameBox; }
            set { PlayerNameBox = value; }
        }
        public Label TurnLabelProp
        {
            get { return TurnLabel; }
            set { TurnLabel = value; }
        }
        public TextBlock ENameBlockProp
        {
            get { return ENameBlock; }
            set { ENameBlock = value; }
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
            imgBrushTile.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Pente;component/Images/tile.png", UriKind.RelativeOrAbsolute));
            imgBrushBlack.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Pente;component/Images/black2.png", UriKind.RelativeOrAbsolute));
            imgBrushWhite.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Pente;component/Images/white2.png", UriKind.RelativeOrAbsolute));
            if (string.IsNullOrEmpty(PlayerNameBox.Text))
                PNameBlock.Text = "Player 1:";

            if (!string.IsNullOrEmpty(EnemyNameBox.Text))
                ENameBlock.Text = EnemyNameBox.Text;
            else
                ENameBlock.Text = "Player 2:";

            ControlPanel.Visibility = Visibility.Visible;
            GameBoardGrid.Visibility = Visibility.Visible;
            BoardBackground();
            InitalSetup();
        }
        public void InitalSetup()
        {
            int middle = ((tileSize - 1) / 2);
            SwitchButtonBackground(board[middle, middle]);
            SwitchPlayer();
        }


        public void BoardBackground()
        {
            board = new Button[tileSize,tileSize];
            for(int i = 0; i < tileSize; i++)
            {
                for(int j = 0; j < tileSize; j++)
                {
                    Button b = new Button();
                    b.BorderThickness = new Thickness(0);
                    b.Click += BoardClicked;
                    b.Background = imgBrushTile;

                    GameBoardGrid.Children.Add(b);
                    board[i, j] = b;
                }

            }
        }
        // M & G
        public void SwitchPlayer()
        {
            isPlayer1Turn = isPlayer1Turn ? false : true;
            TurnLabel.Content = isPlayer1Turn ? PNameBlock.Text + "'s Turn" : ENameBlock.Text + "'s Turn";
        }

        public void SwitchButtonBackground(Button sender)
        {
            ImageBrush imgBrush = new ImageBrush();
            imgBrush = isPlayer1Turn ? imgBrushBlack :
                                       imgBrushWhite;
            sender.Background = imgBrush;
        }

        public void BoardClicked(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (b.Background == imgBrushTile)
            {
                SwitchButtonBackground(b);
                SwitchPlayer();
            }
        }
    }
}
