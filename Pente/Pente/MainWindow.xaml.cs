using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
        public int tileSize = 0;
        public int player1TriaCount = 0;
        public int player1TesseraCount = 0;
        public int player2TriaCount = 0;
        public int player2TesseraCount = 0;
        public int tempPlayer1TriaCount = 0;
        public int tempPlayer1TesseraCount = 0;
        public int tempPlayer2TriaCount = 0;
        public int tempPlayer2TesseraCount = 0;
        public int player1Win = 0;
        public int player2Win = 0;
        public int player1Captures = 0;
        public int player2Captures = 0;
        public int turnTime = 20;
        public Button[,] board;
        public ImageBrush imgBrushTile = new ImageBrush();
        public ImageBrush imgBrushBlack = new ImageBrush();
        public ImageBrush imgBrushWhite = new ImageBrush();
        public ImageBrush currentPlayerBrush;
        public Timer t = new Timer(1000);
        public OpenFileDialog openFileDialog = new OpenFileDialog();
        public Button VsComputerBtnProp
        {
            get { return VsComputerBtn; }
            set { VsComputerBtn = value; }
        }
        public Label TimerLabelProp
        {
            get { return TimerLabel; }
            set { TimerLabel = value; }
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
        // B & E
        public void PvP_Click(object sender, RoutedEventArgs e)
        {
            PlayerPanel.Visibility = Visibility.Collapsed;
            NamePanel.Visibility = Visibility.Visible;
        }
        // B & E
        public void PvC_Click(object sender, RoutedEventArgs e)
        {
            PlayerPanel.Visibility = Visibility.Collapsed;
            PvPNameDockPanel.Visibility = Visibility.Collapsed;
            NamePanel.Visibility = Visibility.Visible;
        }
        // M & B
        public void StartTimer()
        {
            t.Elapsed += new ElapsedEventHandler(OnTimedEvent);
           
            t.Start();
            
        }
        // M & B
        public void OnTimedEvent(object source, ElapsedEventArgs e)
        { 

            turnTime--;
            
            if (turnTime <= 0)
            {
                PlayerTurnExpired();
            }
            
        }
        // M & B
        public void PlayerTurnExpired()
        {
            turnTime = 20;
            SwitchPlayer();
            //EndTimer();
        }
        // M & B
        public void EndTimer()
        {
            t.Stop();
        }
        // B & E
        public void Start_Click(object sender, RoutedEventArgs e)
        {
            PenteLabel.Visibility = Visibility.Collapsed;
            NamePanel.Visibility = Visibility.Collapsed;
            PNameBlock.Text = PlayerNameBox.Text;
            PlayBoardBackground.Visibility = Visibility.Visible;
            imgBrushTile.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Pente;component/Images/tile4.png", UriKind.RelativeOrAbsolute));
            imgBrushBlack.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Pente;component/Images/black4.png", UriKind.RelativeOrAbsolute));
            imgBrushWhite.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Pente;component/Images/white4.png", UriKind.RelativeOrAbsolute));

            if (string.IsNullOrEmpty(PlayerNameBox.Text))
                PNameBlock.Text = "Player 1:";
            if (!string.IsNullOrEmpty(EnemyNameBox.Text))
                ENameBlock.Text = EnemyNameBox.Text;
            else if (PvPNameDockPanel.Visibility == Visibility.Collapsed)
                ENameBlock.Text = "Computer:";
            else
                ENameBlock.Text = "Player 2:";
            
            tileSize = (int)GridSlider.Value;
            ControlPanel.Visibility = Visibility.Visible;
            GameBoardGrid.Visibility = Visibility.Visible;
            BoardBackground();
            InitalSetup();
        }
        // M & B
        public void InitalSetup()
        {
            int middle = ((tileSize - 1) / 2);
            SwitchButtonBackground(board[middle, middle]);
            SwitchPlayer();
            Binding b = new Binding();
            b.Source = turnTime;
            TimerLabel.DataContext = b;
            StartTimer();
            // FIX DATA BINDING ON TIMER 
            TimerLabel.Foreground = Brushes.White;
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
                    board[j, i] = b;
                }

            }
        }
        // G & M
        public void SwitchPlayer()
        {
            isPlayer1Turn = isPlayer1Turn ? false : true;
            TurnLabel.Content = isPlayer1Turn ? PNameBlock.Text + "'s Turn" : ENameBlock.Text + "'s Turn";
            currentPlayerBrush = isPlayer1Turn ? imgBrushBlack : imgBrushWhite;
        }
        // G & M
        public void SwitchButtonBackground(Button sender)
        {
            ImageBrush imgBrush = new ImageBrush();
            imgBrush = isPlayer1Turn ? imgBrushBlack :
                                       imgBrushWhite;
            sender.Background = imgBrush;
        }
        // G & M
        public void BoardClicked(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (b.Background == imgBrushTile)
            {
                SwitchButtonBackground(b);
               
                for (int i = 0; i < tileSize; i++)
                {
                    for (int j = 0; j < tileSize; j++)
                    {
                        if(board[i,j] == b)
                            CheckForCapture(i, j);
                        if (board[i,j].Background == currentPlayerBrush)
                        {
                            CheckForSpecialConditions(i, j, 0, 0);
                        }
                    }
                }
                AnnounceNewConditions();
                SwitchPlayer();
            }
        }
        // G & M
        public void CheckForCapture(int x, int y)
        {
            ImageBrush enemyBrush = isPlayer1Turn ? imgBrushWhite : imgBrushBlack;
            if (CheckIfInBounds(x - 3, y - 3) && 
               board[x - 3, y - 3].Background == currentPlayerBrush &&
               board[x - 2, y - 2].Background == enemyBrush &&
               board[x - 1, y - 1].Background == enemyBrush)
            {
                Capture(x - 1, y - 1, x - 2, y - 2);
            }
            if (CheckIfInBounds(x, y - 3) &&
               board[x, y - 3].Background == currentPlayerBrush &&
               board[x, y - 2].Background == enemyBrush &&
               board[x, y - 1].Background == enemyBrush)
            {
                Capture(x, y - 1, x, y - 2);
            }
            if (CheckIfInBounds(x + 3, y - 3) &&
               board[x + 3, y - 3].Background == currentPlayerBrush &&
               board[x + 2, y - 2].Background == enemyBrush &&
               board[x + 1, y - 1].Background == enemyBrush)
            {
                Capture(x + 1, y - 1, x + 2, y - 2);
            }
            if (CheckIfInBounds(x + 3, y) &&
               board[x + 3, y].Background == currentPlayerBrush &&
               board[x + 2, y].Background == enemyBrush &&
               board[x + 1, y].Background == enemyBrush)
            {
                Capture(x + 1, y, x + 2, y);
            }
            if (CheckIfInBounds(x + 3, y + 3) &&
               board[x + 3, y + 3].Background == currentPlayerBrush &&
               board[x + 2, y + 2].Background == enemyBrush &&
               board[x + 1, y + 1].Background == enemyBrush)
            {
                Capture(x + 1, y + 1, x + 2, y + 2);
            }
            if (CheckIfInBounds(x, y - 3) &&
               board[x, y - 3].Background == currentPlayerBrush &&
               board[x, y - 2].Background == enemyBrush &&
               board[x, y - 1].Background == enemyBrush)
            {
                Capture(x, y - 1, x, y - 2);
            }
            if (CheckIfInBounds(x - 3, y + 3) &&
               board[x - 3, y + 3].Background == currentPlayerBrush &&
               board[x - 2, y + 2].Background == enemyBrush &&
               board[x - 1, y + 1].Background == enemyBrush)
            {
                Capture(x - 1, y + 1, x - 2, y + 2);
            }
            if (CheckIfInBounds(x - 3, y) &&
               board[x - 3, y].Background == currentPlayerBrush &&
               board[x - 2, y].Background == enemyBrush &&
               board[x - 1, y].Background == enemyBrush)
            {
                Capture(x - 1, y, x - 2, y);
            }
        }
        // G & M
        private void Capture(int x1, int y1, int x2, int y2)
        {
            if (isPlayer1Turn)
                player1Captures++;
            else
                player2Captures++;
            board[x1, y1].Background = imgBrushTile;
            board[x2, y2].Background = imgBrushTile;
        }

        // G & M
        public void AnnounceNewConditions()
        {
            if(player1Win > 0)
            {
                MessageBox.Show("PLAYER 1 WINS");
            } else if(player2Win > 0)
            {
                MessageBox.Show("PLAYER 2 WINS");
            } else
            {
                if (isPlayer1Turn)
                {
                    if(tempPlayer1TesseraCount > player1TesseraCount)
                    {
                        MessageBox.Show("PLAYER 1 TESSERA");
                        player1TesseraCount = tempPlayer1TesseraCount;
                    }
                    else if(tempPlayer1TriaCount > player1TriaCount)
                    {
                        MessageBox.Show("PLAYER 1 TRIA");
                    }
                    if (tempPlayer1TriaCount > player1TriaCount)
                    {
                        player1TriaCount = tempPlayer1TriaCount;
                    }
                    tempPlayer1TriaCount = 0;
                    tempPlayer1TesseraCount = 0;
                } else
                {
                    if (tempPlayer2TesseraCount > player2TesseraCount)
                    {
                        player2TesseraCount = tempPlayer2TesseraCount;
                        tempPlayer2TesseraCount = 0;
                        MessageBox.Show("PLAYER 2 TESSERA");
                    }
                    else if (tempPlayer2TriaCount > player2TriaCount)
                    {
                        player2TriaCount = tempPlayer2TriaCount;
                        tempPlayer2TriaCount = 0;
                        MessageBox.Show("PLAYER 2 TRIA");
                    }
                }
            }
        }

        // G & M

        public bool CheckIfInBounds(int x, int y)
        {
            if (x < board.GetLowerBound(0) ||
                x > board.GetUpperBound(0) ||
                y < board.GetLowerBound(1) ||
                y > board.GetUpperBound(1)) return false;
            return true;
        }
        // G & M

        //  Direction Values for 2D array 0 = no direction
        //  1 | 2 | 3
        //  8 | 0 | 4
        //  7 | 6 | 5
        public void CheckForSpecialConditions(int x, int y, int direction, int countInARow)
        {
            
            if (countInARow == 2)
            {
                if (isPlayer1Turn)
                    tempPlayer1TriaCount++;
                else
                    tempPlayer2TriaCount++;
            }
            if(countInARow == 3)
            {
                if (isPlayer1Turn)
                    tempPlayer1TesseraCount++;
                else
                    tempPlayer2TesseraCount++;
            }
            if(countInARow == 4)
            {
                if (isPlayer1Turn)
                    player1Win++;
                else
                    player2Win++;
            }
            if((direction == 0 || direction == 1) && CheckIfInBounds(x - 1, y - 1) && board[x - 1,y - 1].Background == currentPlayerBrush)
            {
                if (direction == 0)
                    countInARow = 0;
                CheckForSpecialConditions(x - 1, y - 1, 1, ++countInARow);
            }
            if ((direction == 0 || direction == 2) && CheckIfInBounds(x, y - 1) && board[x, y - 1].Background == currentPlayerBrush)
            {
                if (direction == 0)
                    countInARow = 0;
                CheckForSpecialConditions(x, y - 1, 2, ++countInARow);
            }
            if ((direction == 0 || direction == 3) && CheckIfInBounds(x + 1, y - 1) && board[x + 1, y - 1].Background == currentPlayerBrush)
            {
                if (direction == 0)
                    countInARow = 0;
                CheckForSpecialConditions(x + 1, y - 1, 3, ++countInARow);
            }
            if ((direction == 0 || direction == 4) && CheckIfInBounds(x + 1, y) && board[x + 1, y].Background == currentPlayerBrush)
            {
                if (direction == 0)
                    countInARow = 0;
                CheckForSpecialConditions(x + 1, y, 4, ++countInARow);
            }
            if ((direction == 0 || direction == 5) && CheckIfInBounds(x + 1, y + 1) && board[x + 1, y + 1].Background == currentPlayerBrush)
            {
                if (direction == 0)
                    countInARow = 0;
                CheckForSpecialConditions(x + 1, y + 1, 5, ++countInARow);
            }
            if ((direction == 0 || direction == 6) && CheckIfInBounds(x, y + 1) && board[x, y + 1].Background == currentPlayerBrush)
            {
                if (direction == 0)
                    countInARow = 0;
                CheckForSpecialConditions(x, y + 1, 6, ++countInARow);
            }
            if ((direction == 0 || direction == 7) && CheckIfInBounds(x - 1, y + 1) && board[x - 1, y + 1].Background == currentPlayerBrush)
            {
                if (direction == 0)
                    countInARow = 0;
                CheckForSpecialConditions(x - 1, y + 1, 7, ++countInARow);
            }
            if ((direction == 0 || direction == 8) && CheckIfInBounds(x - 1, y) && board[x - 1, y].Background == currentPlayerBrush)
            {
                if (direction == 0)
                    countInARow = 0;
                CheckForSpecialConditions(x - 1, y - 1, 8, ++countInARow);
            }
        }

        
        // B & E
        private void LoadGame_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog.Filter = "pente files (*.pente)|*.pente";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == true)
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                if (stream.Length != 0)
                {
                    //gameData = (GameData)formatter.Deserialize(stream);
                }
                stream.Close();
            }
        }
        // B & E
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
        // B & E
        private void SaveGame_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "pente files (*.pente)|*.pente";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, null);
            stream.Close();
        }

    }
}
