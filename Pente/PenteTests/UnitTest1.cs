using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pente;
using System.Windows;
using System.Windows.Media;

namespace PenteTests
{
    [TestClass]
    public class UnitTest1
    {
        //GABE AND MICHAEL
        [TestMethod]
        public void PlayerPanelVisibliltyAfterPvPClickedTest()
        {
            MainWindow main = new MainWindow();
            main.PvP_Click(null, null);
            Assert.IsTrue(main.PlayerPanelProp.Visibility == Visibility.Collapsed);
        }
        [TestMethod]
        public void NamePanelVisibliltyAfterPvPClickedTest()
        {
            MainWindow main = new MainWindow();
            main.PvP_Click(null, null);
            Assert.IsTrue(main.NamePanelProp.Visibility == Visibility.Visible);
        }
        [TestMethod]
        public void PlayerPanelPropVisibilityAfterPvCClickedTest()
        {
            MainWindow main = new MainWindow();
            main.PvP_Click(null, null);
            Assert.IsTrue(main.PlayerPanelProp.Visibility == Visibility.Collapsed);
        }
        [TestMethod]
        public void PvPNameDockPanelVisibilityAfterPvPClickedTest()
        {
            MainWindow main = new MainWindow();
            main.PvP_Click(null, null);
            Assert.IsTrue(main.PvPNameDockPanelProp.Visibility == Visibility.Visible);
        }
        [TestMethod]
        public void PvCNameDockPanelVisibilityAfterPvPClickedTest()
        {
            MainWindow main = new MainWindow();
            main.PvC_Click(null, null);
            Assert.IsTrue(main.PvPNameDockPanelProp.Visibility == Visibility.Collapsed);
        }
        [TestMethod]
        public void PenteLabelVisibilityAfterStartClickedTest()
        {
            MainWindow main = new MainWindow();
            main.Start_Click(null, null);
            Assert.IsTrue(main.PenteLabelProp.Visibility == Visibility.Collapsed);
        }
        [TestMethod]
        public void NamePanelVisibilityAfterStartClickedTest()
        {
            MainWindow main = new MainWindow();
            main.Start_Click(null, null);
            Assert.IsTrue(main.NamePanelProp.Visibility == Visibility.Collapsed);
        }
        [TestMethod]
        public void ControlPanelVisibilityAfterStartClickedTest()
        {
            MainWindow main = new MainWindow();
            main.Start_Click(null, null);
            Assert.IsTrue(main.ControlPanelProp.Visibility == Visibility.Visible);
        }
        [TestMethod]
        public void GameBoardGridVisibilityAfterStartClickedTest()
        {
            MainWindow main = new MainWindow();
            main.Start_Click(null, null);
            Assert.IsTrue(main.GameBoardGridProp.Visibility == Visibility.Visible);
        }
        [TestMethod]
        public void PNameBlockTextChangedAfterStartClickedNullInput()
        {
            MainWindow main = new MainWindow();
            main.Start_Click(null, null);
            Assert.IsTrue(main.PNameBlockProp.Text == "Player 1:");
        }
        [TestMethod]
        public void EnemyNameBlockTextChangedAfterStartClickedPVPDockVisibleNullInput()
        {
            MainWindow main = new MainWindow();
            main.Start_Click(null, null);
            Assert.IsTrue(main.ENameBlockProp.Text == "Player 2:");
        }
        [TestMethod]
        public void EnemyNameBlockTextChangedAfterStartClickedPVPDockCollapsedNullInput()
        {
            MainWindow main = new MainWindow();
            main.PvPNameDockPanelProp.Visibility = Visibility.Collapsed;
            main.Start_Click(null, null);
            Assert.IsTrue(main.ENameBlockProp.Text == "Computer:");
        }
        [TestMethod]
        public void PNameBlockTextChangedAfterStartClickedGoodInput()
        {
            MainWindow main = new MainWindow();

            main.PlayerNameBoxProp.Text = "Gabe";
            main.Start_Click(null, null);
            Assert.IsTrue(main.PNameBlockProp.Text == main.PlayerNameBoxProp.Text);
        }
        [TestMethod]
        public void ENameBlockTextChangedAfterStartClickedGoodInput()
        {
            MainWindow main = new MainWindow();

            main.EnemyNameBoxProp.Text = "Gabe";
            main.Start_Click(null, null);
            Assert.IsTrue(main.ENameBlockProp.Text == main.EnemyNameBoxProp.Text);
        }
        [TestMethod]
        public void PVPNameDockPanelVisibilityAfterPvCClickedTest()
        {
            MainWindow main = new MainWindow();
            main.PvC_Click(null, null);
            Assert.IsTrue(main.PvPNameDockPanelProp.Visibility == Visibility.Collapsed);
        }
        [TestMethod]
        public void NamePanelPropVisibilityAfterPvCClickedTest()
        {
            MainWindow main = new MainWindow();
            main.PvC_Click(null, null);
            Assert.IsTrue(main.NamePanelProp.Visibility == Visibility.Visible);
        }
        [TestMethod]
        public void SetSaveVariablesPenteLblVisibilityChanged()
        {
            Visibility ExpectedResult = Visibility.Collapsed;
            MainWindow main = new MainWindow();
            main.SetSaveVariables("PenteTest.pente");
            Assert.IsTrue(main.PenteLabelProp.Visibility == ExpectedResult);
        }
        [TestMethod]
        public void SetSaveVariablesNamePanelVisibilityChanged()
        {
            Visibility ExpectedResult = Visibility.Collapsed;
            MainWindow main = new MainWindow();
            main.SetSaveVariables("PenteTest.pente");
            Assert.IsTrue(main.NamePanelProp.Visibility == ExpectedResult);
        }
        [TestMethod]
        public void SetSaveVariablesPlayerPanelVisibilityChanged()
        {
            Visibility ExpectedResult = Visibility.Collapsed;
            MainWindow main = new MainWindow();
            main.SetSaveVariables("PenteTest.pente");
            Assert.IsTrue(main.PlayerPanelProp.Visibility == ExpectedResult);
        }
        [TestMethod]
        public void SetSaveVariablesPvPNameDockPanelVisibilityChanged()
        {
            Visibility ExpectedResult = Visibility.Collapsed;
            MainWindow main = new MainWindow();
            main.SetSaveVariables("PenteTest.pente");
            Assert.IsTrue(main.PvPNameDockPanelProp.Visibility == ExpectedResult);
        }
        [TestMethod]
        public void SetSaveVariablesControlPanelVisibilityChanged()
        {
            Visibility ExpectedResult = Visibility.Visible;
            MainWindow main = new MainWindow();
            main.SetSaveVariables("PenteTest.pente");
            Assert.IsTrue(main.ControlPanelProp.Visibility == ExpectedResult);
        }
        [TestMethod]
        public void SetSaveVariablesGameBoardGridVisibilityChanged()
        {
            Visibility ExpectedResult = Visibility.Visible;
            MainWindow main = new MainWindow();
            main.SetSaveVariables("PenteTest.pente");
            Assert.IsTrue(main.GameBoardGridProp.Visibility == ExpectedResult);
        }
        [TestMethod]
        public void SetSaveVariablesisPlayer1TurnSet()
        {
            MainWindow main = new MainWindow();
            Save s = main.SetSaveVariables("PenteTest.pente");
            bool ExpectedResult = s.isPlayer1Turn;
            Assert.IsTrue(main.isPlayer1Turn == ExpectedResult);
        }
        [TestMethod]
        public void SetSaveVariablesComputerEnabledSet()
        {
            MainWindow main = new MainWindow();
            Save s = main.SetSaveVariables("PenteTest.pente");
            bool ExpectedResult = s.computerEnabled;
            Assert.IsTrue(main.computerEnabled == ExpectedResult);
        }
        [TestMethod]
        public void SetSaveVariablesPNameBlockSet()
        {
            MainWindow main = new MainWindow();
            Save s = main.SetSaveVariables("PenteTest.pente");
            string ExpectedResult = s.player1Name;
            Assert.IsTrue(main.PNameBlockProp.Text == ExpectedResult);
        }
        [TestMethod]
        public void SetSaveVariablesENameBlockSet()
        {
            MainWindow main = new MainWindow();
            Save s = main.SetSaveVariables("PenteTest.pente");
            string ExpectedResult = s.player2Name;
            Assert.IsTrue(main.ENameBlockProp.Text == ExpectedResult);
        }
        [TestMethod]
        public void SetSaveVariablesPlayerCaptureLabelSet()
        {
            MainWindow main = new MainWindow();
            Save s = main.SetSaveVariables("PenteTest.pente");
            int ExpectedResult = s.player1Captures;
            Assert.IsTrue((int)main.PlayerCaptureLabelProp.Content == ExpectedResult);
        }
        [TestMethod]
        public void SetSaveVariablesEnemyCaptureLabelSet()
        {
            MainWindow main = new MainWindow();
            Save s = main.SetSaveVariables("PenteTest.pente");
            int ExpectedResult = s.player2Captures;
            Assert.IsTrue((int)main.EnemyCaptureLabelProp.Content == ExpectedResult);
        }
        [TestMethod]
        public void SetSaveVariablesTurnCountSet()
        {
            MainWindow main = new MainWindow();
            Save s = main.SetSaveVariables("PenteTest.pente");
            int ExpectedResult = s.turnCount;
            Assert.IsTrue((int)main.turnCount == ExpectedResult);
        }
        [TestMethod]
        public void SetSaveVariablesTileSizeSet()
        {

            MainWindow main = new MainWindow();
            Save s = main.SetSaveVariables("PenteTest.pente");
            int ExpectedResult = s.tileSize;
            Assert.IsTrue((int)main.tileSize == ExpectedResult);
        }
        [TestMethod]
        public void SetSaveVariablesPlayer1TriaCountSet()
        {

            MainWindow main = new MainWindow();
            Save s = main.SetSaveVariables("PenteTest.pente");
            int ExpectedResult = s.player1TriaCount;
            Assert.IsTrue(main.player1TriaCount == ExpectedResult);
        }
        [TestMethod]
        public void SetSaveVariablesPlayer1TesseraCountSet()
        {

            MainWindow main = new MainWindow();
            Save s = main.SetSaveVariables("PenteTest.pente");
            int ExpectedResult = s.player1TesseraCount;
            Assert.IsTrue(main.player1TesseraCount == ExpectedResult);
        }
        [TestMethod]
        public void SetSaveVariablesPlayer2TriaCountSet()
        {

            MainWindow main = new MainWindow();
            Save s = main.SetSaveVariables("PenteTest.pente");
            int ExpectedResult = s.player2TriaCount;
            Assert.IsTrue(main.player2TriaCount == ExpectedResult);
        }
        [TestMethod]
        public void SetSaveVariablesPlayer2TesseraCountSet()
        {

            MainWindow main = new MainWindow();
            Save s = main.SetSaveVariables("PenteTest.pente");
            int ExpectedResult = s.player2TesseraCount;
            Assert.IsTrue(main.player2TesseraCount == ExpectedResult);
        }
        [TestMethod]
        public void SetSaveVariablesTempPlayer1TriaCountSet()
        {

            MainWindow main = new MainWindow();
            Save s = main.SetSaveVariables("PenteTest.pente");
            int ExpectedResult = s.tempPlayer1TriaCount;
            Assert.IsTrue(main.tempPlayer1TriaCount == ExpectedResult);
        }
        [TestMethod]
        public void SetSaveVariablesTempPlayer1TesseraCountSet()
        {

            MainWindow main = new MainWindow();
            Save s = main.SetSaveVariables("PenteTest.pente");
            int ExpectedResult = s.tempPlayer1TesseraCount;
            Assert.IsTrue(main.tempPlayer1TesseraCount == ExpectedResult);
        }
        [TestMethod]
        public void SetSaveVariablesTempPlayer2TriaCountSet()
        {

            MainWindow main = new MainWindow();
            Save s = main.SetSaveVariables("PenteTest.pente");
            int ExpectedResult = s.tempPlayer2TriaCount;
            Assert.IsTrue(main.tempPlayer2TriaCount == ExpectedResult);
        }
        [TestMethod]
        public void SetSaveVariablesTempPlayer2TesseraCountSet()
        {

            MainWindow main = new MainWindow();
            Save s = main.SetSaveVariables("PenteTest.pente");
            int ExpectedResult = s.tempPlayer2TesseraCount;
            Assert.IsTrue(main.tempPlayer1TesseraCount == ExpectedResult);
        }
        [TestMethod]
        public void SetSaveVariablesPlayer1WinSet()
        {

            MainWindow main = new MainWindow();
            Save s = main.SetSaveVariables("PenteTest.pente");
            int ExpectedResult = s.player1Win;
            Assert.IsTrue(main.player1Win == ExpectedResult);
        }
        [TestMethod]
        public void SetSaveVariablesPlayer2WinSet()
        {

            MainWindow main = new MainWindow();
            Save s = main.SetSaveVariables("PenteTest.pente");
            int ExpectedResult = s.player2Win;
            Assert.IsTrue(main.player2Win == ExpectedResult);
        }
        [TestMethod]
        public void SetSaveVariablesPlayer1CapturesSet()
        {

            MainWindow main = new MainWindow();
            Save s = main.SetSaveVariables("PenteTest.pente");
            int ExpectedResult = s.player1Captures;
            Assert.IsTrue(main.player1Captures == ExpectedResult);
        }
        [TestMethod]
        public void SetSaveVariablesPlayer2CapturesSet()
        {

            MainWindow main = new MainWindow();
            Save s = main.SetSaveVariables("PenteTest.pente");
            int ExpectedResult = s.player2Captures;
            Assert.IsTrue(main.player2Captures == ExpectedResult);
        }
        [TestMethod]
        public void SetSaveVariablesTurnTimeSet()
        {

            MainWindow main = new MainWindow();
            Save s = main.SetSaveVariables("PenteTest.pente");
            int ExpectedResult = s.turnTime;
            Assert.IsTrue(main.turnTime == ExpectedResult);
        }
        [TestMethod]
        public void AnnounceNewConditionsPlayer1WinEqualTo1()
        {
            Visibility ExpectedResult = Visibility.Collapsed;
            MainWindow main = new MainWindow();
            main.player1Win = 1;
            main.AnnounceNewConditions();
            Assert.IsTrue(main.ControlPanelProp.Visibility == ExpectedResult);
        }
        [TestMethod]
        public void AnnounceNewConditionsPlayer2WinEqualTo1()
        {
            Visibility ExpectedResult = Visibility.Collapsed;
            MainWindow main = new MainWindow();
            main.player2Win = 1;
            main.AnnounceNewConditions();
            Assert.IsTrue(main.ControlPanelProp.Visibility == ExpectedResult);
        }
        [TestMethod]
        public void AnnounceNewConditionsNoWinnerPlayer1TessaraCountsUneven()
        {
            int ExpectedResult = 2;
            MainWindow main = new MainWindow();
            main.isPlayer1Turn = true;
            main.tempPlayer1TesseraCount = 2;
            main.player1TesseraCount = 1;
            main.AnnounceNewConditions();
            Assert.IsTrue(main.player1TesseraCount == ExpectedResult);
        }
        [TestMethod]
        public void AnnounceNewConditionsNoWinnerPlayer1TriaCountsUneven()
        {
            int ExpectedResult = 2;
            MainWindow main = new MainWindow();
            main.isPlayer1Turn = true;
            main.tempPlayer1TriaCount = 2;
            main.player1TriaCount = 1;
            main.AnnounceNewConditions();
            Assert.IsTrue(main.player1TriaCount == ExpectedResult);
        }
        [TestMethod]
        public void AnnounceNewConditionsNoWinnerPlayer2TessaraCountsUneven()
        {
            int ExpectedResult = 2;
            MainWindow main = new MainWindow();
            main.isPlayer1Turn = false;
            main.tempPlayer2TesseraCount = 2;
            main.player2TesseraCount = 1;
            main.AnnounceNewConditions();
            Assert.IsTrue(main.player2TesseraCount == ExpectedResult);
        }
        [TestMethod]
        public void AnnounceNewConditionsNoWinnerPlayer2TriaCountsUneven()
        {
            int ExpectedResult = 2;
            MainWindow main = new MainWindow();
            main.isPlayer1Turn = false;
            main.tempPlayer2TriaCount = 2;
            main.player2TriaCount = 1;
            main.AnnounceNewConditions();
            Assert.IsTrue(main.player2TriaCount == ExpectedResult);
        }
        ////////////////////////////BEN & LIZ//////////////////

        public void ChangeIsPlayer1TurntoFalse()
        {
            bool result = false;
            MainWindow main = new MainWindow();
            main.isPlayer1Turn = true;
            main.SwitchPlayer();
            Assert.AreEqual(result, main.isPlayer1Turn);
        }

        [TestMethod]
        public void ChangeIsPlayer1TurntoTrue()
        {
            bool result = false;
            MainWindow main = new MainWindow();
            main.isPlayer1Turn = true;
            main.SwitchPlayer();
            Assert.AreEqual(result, main.isPlayer1Turn);
        }
        [TestMethod]
        public void ChangePlayerTurnLabeltoDefaultPlayer2Name()
        {
            string result = "Player 2:'s Turn";
            MainWindow main = new MainWindow();
            main.Start_Click(null, null);
            Assert.AreEqual(result, main.TurnLabelProp.Content);
        }
        [TestMethod]
        public void ChangePlayerTurnLabeltoDefaultPlayer1Name()
        {
            string result = "Player 1:'s Turn";
            MainWindow main = new MainWindow();
            main.isPlayer1Turn = false;
            main.Start_Click(null, null);
            Assert.AreEqual(result, main.TurnLabelProp.Content);
        }
        [TestMethod]
        public void ChangePlayerTurnLabeltoPlayer1Name()
        {
            string result = "Kindle's Turn";

            MainWindow main = new MainWindow();
            main.PlayerNameBoxProp.Text = "Kindle";
            main.Start_Click(null, null);
            main.SwitchPlayer();

            Assert.AreEqual(result, main.TurnLabelProp.Content);
        }
        [TestMethod]
        public void ChangePlayerTurnLabeltoPlayer2Name()
        {
            string result = "Mindle's Turn";

            MainWindow main = new MainWindow();
            main.EnemyNameBoxProp.Text = "Mindle";
            main.Start_Click(null, null);

            Assert.AreEqual(result, main.TurnLabelProp.Content);
        }
        [TestMethod]
        public void SwitchButtonBackgroundToBlack()
        {
            MainWindow main = new MainWindow();
            Brush result = main.imgBrushBlack;

            main.Start_Click(null, null);
            main.BoardClicked(main.board[0, 0], null);
            main.SwitchButtonBackground(main.board[0, 0]);

            Assert.AreEqual(result, main.board[0, 0].Background);
        }
        [TestMethod]
        public void SwitchButtonBackgroundToWhite()
        {
            MainWindow main = new MainWindow();
            Brush result = main.imgBrushWhite;

            main.Start_Click(null, null);
            main.SwitchPlayer();
            main.BoardClicked(main.board[0, 0], null);
            main.SwitchButtonBackground(main.board[0, 0]);

            Assert.AreEqual(result, main.board[0, 0].Background);
        }
        [TestMethod]
        public void TestIfOutsideBoardforXlower()
        {
            MainWindow main = new MainWindow();
            main.Start_Click(null, null);
            bool result = false;
            Assert.AreEqual(result, main.CheckIfInBounds(-1, 2));
        }
        [TestMethod]
        public void TestIfOutsideBoardforXupper()
        {
            MainWindow main = new MainWindow();
            main.Start_Click(null, null);
            bool result = false;
            Assert.AreEqual(result, main.CheckIfInBounds(10, 2));
        }
        [TestMethod]
        public void TestIfOutsideBoardforYlower()
        {
            MainWindow main = new MainWindow();
            main.Start_Click(null, null);
            bool result = false;
            Assert.AreEqual(result, main.CheckIfInBounds(1, -1));
        }
        [TestMethod]
        public void TestIfOutsideBoardforYupper()
        {
            MainWindow main = new MainWindow();
            main.Start_Click(null, null);
            bool result = false;
            Assert.AreEqual(result, main.CheckIfInBounds(2, 10));
        }
        [TestMethod]
        public void TestIfInsideBoardforX()
        {
            MainWindow main = new MainWindow();
            main.Start_Click(null, null);
            bool result = true;
            Assert.AreEqual(result, main.CheckIfInBounds(1, 2));
        }
        [TestMethod]
        public void TestIfInsideBoardforY()
        {
            MainWindow main = new MainWindow();
            main.Start_Click(null, null);
            bool result = true;
            Assert.AreEqual(result, main.CheckIfInBounds(1, 2));
        }
        [TestMethod]
        public void CheckTimeResetAfterExpired()
        {
            MainWindow main = new MainWindow();
            int result = 20;
            main.Start_Click(null, null);
            main.OnTimedEvent(null, null);
            main.PlayerTurnExpired();
            Assert.AreEqual(result, main.turnTime);
        }
        [TestMethod]
        public void CheckBlackPlayerTurnAfterExpired()
        {
            MainWindow main = new MainWindow();
            ImageBrush result = main.imgBrushBlack;

            main.Start_Click(null, null);
            main.OnTimedEvent(null, null);
            main.PlayerTurnExpired();

            Assert.AreEqual(result, main.currentPlayerBrush);
        }
        [TestMethod]
        public void CheckWhitePlayerTurnAfterExpired()
        {
            MainWindow main = new MainWindow();
            ImageBrush result = main.imgBrushWhite;

            main.Start_Click(null, null);
            main.SwitchPlayer();
            main.OnTimedEvent(null, null);
            main.PlayerTurnExpired();

            Assert.AreEqual(result, main.currentPlayerBrush);
        }
        [TestMethod]
        public void CheckTimerCountdown()
        {
            MainWindow main = new MainWindow();
            int result = 19;

            main.Start_Click(null, null);
            main.OnTimedEvent(null, null);

            Assert.AreEqual(result, main.turnTime);
        }
        [TestMethod]
        public void CheckIfTimeStop()
        {
            MainWindow main = new MainWindow();
            int result = 1;

            main.turnTime = 2;
            main.Start_Click(null, null);
            main.OnTimedEvent(null, null);
            main.EndTimer();

            Assert.AreEqual(result, main.turnTime);
        }
        [TestMethod]
        public void CheckIfPlayer1CaptureLabelIncreases()
        {
            int result = 1;

            MainWindow main = new MainWindow();
            main.Start_Click(null, null);
            main.isPlayer1Turn = true;
            main.Capture(4, 4, 3, 3);

            Assert.AreEqual(result, main.PlayerCaptureLabelProp.Content);
        }
        [TestMethod]
        public void CheckIfPlayer2CaptureLabelIncreases()
        {
            int result = 1;

            MainWindow main = new MainWindow();
            main.Start_Click(null, null);
            main.isPlayer1Turn = false;
            main.Capture(4, 4, 3, 3);

            Assert.AreEqual(result, main.EnemyCaptureLabelProp.Content);
        }
        [TestMethod]
        public void CheckAppropriateTurnForComputer()
        {
            bool result = true;

            MainWindow main = new MainWindow();
            main.computerEnabled = true;
            main.Start_Click(null, null);
            main.TakeAppropriateTurn(null);

            Assert.AreEqual(result, main.computerEnabled);
        }
        [TestMethod]
        public void CheckAppropriateTurnForPlayer2()
        {
            bool result = false;

            MainWindow main = new MainWindow();
            main.Start_Click(null, null);
            main.TakeAppropriateTurn(null);

            Assert.AreEqual(result, main.computerEnabled);
        }
        [TestMethod]
        public void CheckComputerTakeTurnThenSwitchToPlayer1()
        {
            bool result = true;

            MainWindow main = new MainWindow();
            main.computerEnabled = true;
            main.Start_Click(null, null);
            main.TakeAppropriateTurn(null);

            Assert.AreEqual(result, main.isPlayer1Turn);
        }
        [TestMethod]
        public void CheckPlayer2TakeTurnThenSwitchToPlayer1()
        {
            bool result = true;

            MainWindow main = new MainWindow();
            main.Start_Click(null, null);
            main.TakeAppropriateTurn(null);

            Assert.AreEqual(result, main.isPlayer1Turn);
        }
    }
}