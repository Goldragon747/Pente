using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Pente
{
    [Serializable]
    public class Save
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
        public int[,] board;
        public bool currentPlayerBrush;
        public string player1Name;
        public string player2Name;
        public Save() { }
        public Save(bool isPlayer1Turn, int turnCount, bool computerEnabled, int tileSize, 
            int player1TriaCount, int player1TesseraCount, int player2TriaCount, int player2TesseraCount, 
            int tempPlayer1TriaCount, int tempPlayer1TesseraCount, int tempPlayer2TriaCount, int tempPlayer2TesseraCount, 
            int player1Win, int player2Win, int player1Captures, int player2Captures, int turnTime, 
            int[,] board, bool currentPlayerBrush, string player1Name, string player2Name)
        {
            this.isPlayer1Turn = isPlayer1Turn;
            this.turnCount = turnCount;
            this.computerEnabled = computerEnabled;
            this.tileSize = tileSize;
            this.player1TriaCount = player1TriaCount;
            this.player1TesseraCount = player1TesseraCount;
            this.player2TriaCount = player2TriaCount;
            this.player2TesseraCount = player2TesseraCount;
            this.tempPlayer1TriaCount = tempPlayer1TriaCount;
            this.tempPlayer1TesseraCount = tempPlayer1TesseraCount;
            this.tempPlayer2TriaCount = tempPlayer2TriaCount;
            this.tempPlayer2TesseraCount = tempPlayer2TesseraCount;
            this.player1Win = player1Win;
            this.player2Win = player2Win;
            this.player1Captures = player1Captures;
            this.player2Captures = player2Captures;
            this.turnTime = turnTime;
            this.board = board;
            this.currentPlayerBrush = currentPlayerBrush;
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }
        
    }
}
