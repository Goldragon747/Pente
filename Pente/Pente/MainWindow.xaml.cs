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
using System.Windows.Threading;

namespace Pente
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
  
    // We can use outside libraries to help with unit testing; automated clicks and things
    public partial class MainWindow : Window
    {
        public bool isPlayer1Turn = true;
        public int turnCount = 0;
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
        public DispatcherTimer t = new DispatcherTimer();
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
        public Label PlayerCaptureLabelProp
        {
            get { return PlayerCaptureLabel; }
            set { PlayerCaptureLabel = value; }
        }
        public Label EnemyCaptureLabelProp
        {
            get { return EnemyCaptureLabel; }
            set { EnemyCaptureLabel = value; }
        }
        public TextBox EnemyNameBoxProp
        {
            get { return EnemyNameBox; }
            set { EnemyNameBox = value; }
        }


        public MainWindow()
        {
            InitializeComponent();
        }
        // B & E
        public void PvP_Click(object sender, RoutedEventArgs e)
        {
            PlayerPanel.Visibility = Visibility.Collapsed;
            PvPNameDockPanel.Visibility = Visibility.Visible;
            NamePanel.Visibility = Visibility.Visible;
            computerEnabled = false;
        }
        // B & E
        public void PvC_Click(object sender, RoutedEventArgs e)
        {
            PlayerPanel.Visibility = Visibility.Collapsed;
            PvPNameDockPanel.Visibility = Visibility.Collapsed;
            NamePanel.Visibility = Visibility.Visible;
            computerEnabled = true;
        }
        // M & B
        public void StartTimer()
        {
            t.Start();
            
        }
        // M & B
        public void OnTimedEvent(object source, EventArgs e)
        { 
            if (turnTime <= 0)
            {
                PlayerTurnExpired();
            } else
            {
                turnTime--;
                TimerLabel.Content = "Time Remaining: " + turnTime;
            }
        }
        public void PlayerTurnExpired()
        {
            MessageBox.Show("Your turn expired!");
            turnTime = 20;
            TimerLabel.Content = "Time Remaining: " +  turnTime;
            TakeAppropriateTurn(null);
            //EndTimer();
        }
        // M & B
        public void EndTimer()
        {
            t.Stop();
        }
        public void SetBrushes()
        {
            imgBrushTile.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Pente;component/Images/tile4.png", UriKind.RelativeOrAbsolute));
            imgBrushBlack.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Pente;component/Images/black4.png", UriKind.RelativeOrAbsolute));
            imgBrushWhite.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Pente;component/Images/white4.png", UriKind.RelativeOrAbsolute));

        }
        // B & E
        public void Start_Click(object sender, RoutedEventArgs e)
        {
            PenteLabel.Visibility = Visibility.Collapsed;
            NamePanel.Visibility = Visibility.Collapsed;
            PNameBlock.Text = PlayerNameBox.Text;
            PlayBoardBackground.Visibility = Visibility.Visible;
            SetBrushes();
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
        // G & M
        public void InitalSetup()
        {
            int middle = ((tileSize - 1) / 2);
            SwitchButtonBackground(board[middle, middle]);
            TakeAppropriateTurn(null);
            t.Interval = new TimeSpan(0, 0, 1);
            t.Tick += new EventHandler(OnTimedEvent);
            StartTimer();
        }
        // G & M
        public void TakeComputerTurn()
        {
            bool validTurnTaken = false;
            while (!validTurnTaken)
            {
                Random r = new Random();
                int ranX = r.Next(tileSize);
                int ranY = r.Next(tileSize);
                if(board[ranX,ranY].Background == imgBrushTile)
                {
                    board[ranX, ranY].Background = imgBrushWhite;
                    validTurnTaken = true;
                    CheckConditions(board[ranX, ranY]);
                    SwitchPlayer();
                }
            }
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
            turnCount++;
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
                
                if (turnCount == 2)
                {
                    for (int i = 0; i < tileSize; i++)
                    {
                        for (int j = 0; j < tileSize; j++)
                        {
                            if(board[i, j] == b && TournamentRules(i,j))
                            {
                                SwitchButtonBackground(b);
                                turnTime = 20;
                                TimerLabel.Content = "Time Remaining: " + turnTime;
                                TakeAppropriateTurn(b);
                            }
                        }
                    }
                    
                } else
                {
                    SwitchButtonBackground(b);
                    turnTime = 20;
                    TimerLabel.Content = "Time Remaining: " + turnTime;
                    TakeAppropriateTurn(b);
                }
                //player1TurnsTakenCount = currentPlayerBrush == imgBrushBlack ? player1TurnsTakenCount++ : player1TurnsTakenCount;
            }
        }
        // M & B
        public void TakeAppropriateTurn(Button b)
        {
            if(b != null)
                CheckConditions(b);
            SwitchPlayer();
            if (computerEnabled)
            {
                TakeComputerTurn();
            }
        }
        public void CheckConditions(Button b)
        {
            for (int i = 0; i < tileSize; i++)
            {
                for (int j = 0; j < tileSize; j++)
                {
                    if (board[i, j] == b)
                        CheckForCapture(i, j);
                }
            }
            for (int i = 0; i < tileSize; i++)
            {
                for (int j = 0; j < tileSize; j++)
                {
                    if (board[i, j].Background == currentPlayerBrush)
                    {
                        CheckForSpecialConditions(i, j, 0, 0,false,false);
                    }
                }
            }
            AnnounceNewConditions();
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
            if (CheckIfInBounds(x, y + 3) &&
                board[x, y + 3].Background == currentPlayerBrush &&
                board[x, y + 2].Background == enemyBrush &&
                board[x, y + 1].Background == enemyBrush)
            {
                Capture(x, y + 1, x, y + 2);
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
        public void Capture(int x1, int y1, int x2, int y2)
        {
            if (isPlayer1Turn)
            {
                player1Captures++;
                PlayerCaptureLabel.Content = player1Captures;
            }
            else
            {
                player2Captures++;
                EnemyCaptureLabel.Content = player2Captures;
            }
            board[x1, y1].Background = imgBrushTile;
            board[x2, y2].Background = imgBrushTile;
        }

        // G & M
        public void AnnounceNewConditions()
        {
            if(player1Win > 0  || player1Captures >= 5)
            {
                ControlPanel.Visibility = Visibility.Collapsed;
                PlayBoardBackground.Visibility = Visibility.Collapsed;
                WinScreenPanel.Visibility = Visibility.Visible;
                WinLabel.Content = PNameBlock.Text+" Wins!";
            } else if(player2Win > 0 || player2Captures >= 5)
            {
                ControlPanel.Visibility = Visibility.Collapsed;
                PlayBoardBackground.Visibility = Visibility.Collapsed;
                WinScreenPanel.Visibility = Visibility.Visible;
                WinLabel.Content = ENameBlock.Text + " Wins!";
            } else
            {
                if (isPlayer1Turn)
                {
                    if(tempPlayer1TesseraCount != player1TesseraCount)
                    {
                        if(tempPlayer1TesseraCount > player1TesseraCount)
                        {
                            ConsoleViewer.Content = "PLAYER 1 TESSERA\n" + ConsoleViewer.Content;
                        }

                            
                        player1TesseraCount = tempPlayer1TesseraCount;
                    }
                    else if(tempPlayer1TriaCount > player1TriaCount)
                    {
                        ConsoleViewer.Content = "PLAYER 1 TRIA\n" + ConsoleViewer.Content;
                    }
                    if (tempPlayer1TriaCount != player1TriaCount)
                    {
                        player1TriaCount = tempPlayer1TriaCount;
                    }
                    tempPlayer1TriaCount = 0;
                    tempPlayer1TesseraCount = 0;
                } else
                {
                    if (tempPlayer2TesseraCount != player2TesseraCount)
                    {
                        if (tempPlayer2TesseraCount > player2TesseraCount)
                        {
                            ConsoleViewer.Content = "PLAYER 2 TESSERA\n" + ConsoleViewer.Content;
                        }
                        player2TesseraCount = tempPlayer2TesseraCount;
                    }
                    else if (tempPlayer2TriaCount > player2TriaCount)
                    {
                        ConsoleViewer.Content = "PLAYER 2 TRIA\n" + ConsoleViewer.Content;
                    }
                    if (tempPlayer2TriaCount != player2TriaCount)
                    {
                        player2TriaCount = tempPlayer2TriaCount;
                    }
                    tempPlayer2TriaCount = 0;
                    tempPlayer2TesseraCount = 0;
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
        public void CheckForSpecialConditions(int x, int y, int direction, int countInARow,bool isBlockedFirst, bool isBlockedSecond)
        {
            if (countInARow == 2)
            {
                if(!isBlockedFirst && !isBlockedSecond)
                    if (isPlayer1Turn)
                        tempPlayer1TriaCount++;
                    else
                        tempPlayer2TriaCount++;
            }
            if(countInARow == 3)
            {
                if(!isBlockedFirst || !isBlockedSecond)
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
            if((direction == 0 || direction == 1) && CheckIfInBounds(x - 1, y - 1) && board[x - 1, y - 1].Background == currentPlayerBrush)
            {
                if (direction == 0)
                {
                    countInARow = 0;
                    isBlockedFirst = (!CheckIfInBounds(x + 1, y + 1) || board[x + 1, y + 1].Background != imgBrushTile);
                }
                isBlockedSecond = (!CheckIfInBounds(x - 2, y - 2) || board[x - 2, y - 2].Background != imgBrushTile);
                CheckForSpecialConditions(x - 1, y - 1, 1, ++countInARow, isBlockedFirst, isBlockedSecond);
            }
            if ((direction == 0 || direction == 2) && CheckIfInBounds(x, y - 1) && board[x, y - 1].Background == currentPlayerBrush)
            {
                if (direction == 0)
                {
                    countInARow = 0;
                    isBlockedFirst = (!CheckIfInBounds(x, y + 1) || board[x, y + 1].Background != imgBrushTile);
                }
                isBlockedSecond = (!CheckIfInBounds(x, y - 2) || board[x, y - 2].Background != imgBrushTile);
                CheckForSpecialConditions(x, y - 1, 2, ++countInARow, isBlockedFirst, isBlockedSecond);
            }
            if ((direction == 0 || direction == 3) && CheckIfInBounds(x + 1, y - 1) && board[x + 1, y - 1].Background == currentPlayerBrush)
            {
                if (direction == 0)
                {
                    countInARow = 0;
                    isBlockedFirst = (!CheckIfInBounds(x - 1, y + 1) || board[x - 1, y + 1].Background != imgBrushTile);
                }
                isBlockedSecond = (!CheckIfInBounds(x + 2, y - 2) || board[x + 2, y - 2].Background != imgBrushTile);
                CheckForSpecialConditions(x + 1, y - 1, 3, ++countInARow, isBlockedFirst, isBlockedSecond);
            }
            if ((direction == 0 || direction == 4) && CheckIfInBounds(x + 1, y) && board[x + 1, y].Background == currentPlayerBrush)
            {
                if (direction == 0)
                {
                    countInARow = 0;
                    isBlockedFirst = (!CheckIfInBounds(x - 1, y) || board[x - 1, y].Background != imgBrushTile);
                }
                isBlockedSecond = (!CheckIfInBounds(x + 2, y) || board[x + 2, y].Background != imgBrushTile);
                CheckForSpecialConditions(x + 1, y, 4, ++countInARow, isBlockedFirst, isBlockedSecond);
            }
            if ((direction == 0 || direction == 5) && CheckIfInBounds(x + 1, y + 1) && board[x + 1, y + 1].Background == currentPlayerBrush)
            {
                if (direction == 0)
                {
                    countInARow = 0;
                    isBlockedFirst = (!CheckIfInBounds(x - 1, y - 1) || board[x - 1, y - 1].Background != imgBrushTile);
                }
                isBlockedSecond = (!CheckIfInBounds(x + 2, y + 2) || board[x + 2, y + 2].Background != imgBrushTile);
                CheckForSpecialConditions(x + 1, y + 1, 5, ++countInARow, isBlockedFirst, isBlockedSecond);
            }
            if ((direction == 0 || direction == 6) && CheckIfInBounds(x, y + 1) && board[x, y + 1].Background == currentPlayerBrush)
            {
                if (direction == 0)
                {
                    countInARow = 0;
                    isBlockedFirst = (!CheckIfInBounds(x, y - 1) || board[x, y - 1].Background != imgBrushTile);
                }
                isBlockedSecond = (!CheckIfInBounds(x, y + 2) || board[x, y + 2].Background != imgBrushTile);
                CheckForSpecialConditions(x, y + 1, 6, ++countInARow, isBlockedFirst, isBlockedSecond);
            }
            if ((direction == 0 || direction == 7) && CheckIfInBounds(x - 1, y + 1) && board[x - 1, y + 1].Background == currentPlayerBrush)
            {
                if (direction == 0)
                {
                    countInARow = 0;
                    isBlockedFirst = (!CheckIfInBounds(x + 1, y - 1) || board[x + 1, y - 1].Background != imgBrushTile);
                }
                isBlockedSecond = (!CheckIfInBounds(x - 2, y + 2) || board[x - 2, y + 2].Background != imgBrushTile);
                CheckForSpecialConditions(x - 1, y + 1, 7, ++countInARow, isBlockedFirst, isBlockedSecond);
            }
            if ((direction == 0 || direction == 8) && CheckIfInBounds(x - 1, y) && board[x - 1, y].Background == currentPlayerBrush)
            {
                if (direction == 0)
                {
                    countInARow = 0;
                    isBlockedFirst = (!CheckIfInBounds(x + 1, y) || board[x + 1, y].Background != imgBrushTile);
                }
                isBlockedSecond = (!CheckIfInBounds(x - 2, y) || board[x - 2, y].Background != imgBrushTile);
                CheckForSpecialConditions(x - 1, y, 8, ++countInARow, isBlockedFirst, isBlockedSecond);
            }
        }

        public void ResetGame()
        {
            isPlayer1Turn = true;
            turnCount = 0;
            computerEnabled = false;
            tileSize = 0;
            player1TriaCount = 0;
            player1TesseraCount = 0;
            player2TriaCount = 0;
            player2TesseraCount = 0;
            tempPlayer1TriaCount = 0;
            tempPlayer1TesseraCount = 0;
            tempPlayer2TriaCount = 0;
            tempPlayer2TesseraCount = 0;
            player1Win = 0;
            player2Win = 0;
            player1Captures = 0;
            player2Captures = 0;
            turnTime = 20;
            GameBoardGrid.Children.Clear();
            ConsoleViewer.Content = "";
            t.Tick -= OnTimedEvent;
        }
        public void ResetVisibility()
        {
            PenteLabel.Visibility = Visibility.Visible;
            PlayerPanel.Visibility = Visibility.Visible;
            PvPNameDockPanel.Visibility = Visibility.Collapsed;
            ControlPanel.Visibility = Visibility.Collapsed;
            PlayBoardBackground.Visibility = Visibility.Collapsed;
            GameBoardGrid.Visibility = Visibility.Collapsed;
            NamePanel.Visibility = Visibility.Collapsed;
        }
        // B & E
        public void LoadGame_Click(object sender, RoutedEventArgs e)
        {
            EndTimer();
            
            openFileDialog.Filter = "pente files (*.pente)|*.pente";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == true)
            {
                SetSaveVariables(openFileDialog.FileName);
                
            }
            
            
            StartTimer();
        }

        public void SetSaveVariables(string fileName)
        {
            Save save = new Save();
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            if (stream.Length != 0)
            {
                save = (Save)formatter.Deserialize(stream);
            }
            stream.Close();
            if (PlayBoardBackground.Visibility == Visibility.Collapsed)
            {
                t.Interval = new TimeSpan(0, 0, 1);
                t.Tick += new EventHandler(OnTimedEvent);
            }
            PenteLabel.Visibility = Visibility.Collapsed;
            NamePanel.Visibility = Visibility.Collapsed;
            PlayerPanel.Visibility = Visibility.Collapsed;
            PvPNameDockPanel.Visibility = Visibility.Collapsed;
            ControlPanel.Visibility = Visibility.Visible;
            PlayBoardBackground.Visibility = Visibility.Visible;
            GameBoardGrid.Visibility = Visibility.Visible;

            isPlayer1Turn = save.isPlayer1Turn;
            PNameBlock.Text = save.player1Name;
            ENameBlock.Text = save.player2Name;
            PlayerCaptureLabel.Content = save.player1Captures;
            EnemyCaptureLabel.Content = save.player2Captures;
            turnCount = save.turnCount;
            computerEnabled = save.computerEnabled;
            tileSize = save.tileSize;
            player1TriaCount = save.player1TriaCount;
            player1TesseraCount = save.player1TesseraCount;
            player2TriaCount = save.player2TriaCount;
            player2TesseraCount = save.player2TesseraCount;
            tempPlayer1TriaCount = save.tempPlayer1TriaCount;
            tempPlayer1TesseraCount = save.tempPlayer1TesseraCount;
            tempPlayer2TriaCount = save.tempPlayer2TriaCount;
            tempPlayer2TesseraCount = save.tempPlayer2TesseraCount;
            player1Win = save.player1Win;
            player2Win = save.player2Win;
            player1Captures = save.player1Captures;
            player2Captures = save.player2Captures;
            turnTime = save.turnTime;
            currentPlayerBrush = save.currentPlayerBrush ? imgBrushBlack : imgBrushWhite;
            board = new Button[tileSize, tileSize];
            GameBoardGrid.Children.Clear();
            SetBrushes();
            for (int i = 0; i < tileSize; i++)
            {
                for (int j = 0; j < tileSize; j++)
                {
                    Button b = new Button();
                    b.BorderThickness = new Thickness(0);
                    b.Click += BoardClicked;
                    if (save.board[j, i] == 1)
                        b.Background = imgBrushBlack;
                    else if (save.board[j, i] == 2)
                        b.Background = imgBrushWhite;
                    else
                        b.Background = imgBrushTile;
                    GameBoardGrid.Children.Add(b);
                    board[j, i] = b;
                }
            }
        }

        // B & E
        public void SaveGame_Click(object sender, RoutedEventArgs e)
        {
            EndTimer();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "pente files (*.pente)|*.pente";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == true)
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                int[,] saveboard = new int[tileSize, tileSize];
                for (int i = 0; i < tileSize; i++)
                {
                    for (int j = 0; j < tileSize; j++)
                    {
                        if (board[i, j].Background == imgBrushBlack)
                            saveboard[i, j] = 1;
                        else if (board[i, j].Background == imgBrushWhite)
                            saveboard[i, j] = 2;
                        else
                            saveboard[i, j] = 0;
                    }
                }
                Save s = new Save(isPlayer1Turn, turnCount, computerEnabled, tileSize, player1TriaCount
                    , player1TesseraCount, player2TriaCount, player2TesseraCount, tempPlayer1TesseraCount, tempPlayer1TesseraCount
                    , tempPlayer2TriaCount, tempPlayer2TesseraCount, player1Win, player2Win, player1Captures, player2Captures
                    , turnTime, saveboard, (currentPlayerBrush == imgBrushBlack), PNameBlock.Text, ENameBlock.Text);
                formatter.Serialize(stream, s);
                stream.Close();
            }
            StartTimer();
        }
        // G & M
        public bool TournamentRules(int x, int y)
        {
            int invalidMiddleSpot = (tileSize - 1) / 2;
            return x > invalidMiddleSpot + 2 || x < invalidMiddleSpot - 2 ||
                   y > invalidMiddleSpot + 2 || y < invalidMiddleSpot - 2;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if(PlayBoardBackground.Visibility == Visibility.Visible)
            {
                if (MessageBox.Show("Exit without saving?", "W A R N I N G", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    ResetGame();
                    ResetVisibility();
                }
            } else
            {
                ResetGame();
                ResetVisibility();
            }
        }

        private void ResetGame_Click(object sender, RoutedEventArgs e)
        {
            ResetGame();
            WinScreenPanel.Visibility = Visibility.Collapsed;

            PenteLabel.Visibility = Visibility.Visible;
            PlayerPanel.Visibility = Visibility.Visible;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
