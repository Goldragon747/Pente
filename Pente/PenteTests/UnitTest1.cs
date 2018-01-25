﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            main.PvP_Click(null,null);
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
        public void PNameBlockTextChangedAfterStartClickedGoodInput()
        {
            MainWindow main = new MainWindow();
            
            main.PlayerNameBoxProp.Text = "Gabe";
            main.Start_Click(null, null);
            Assert.IsTrue(main.PNameBlockProp.Text == main.PlayerNameBoxProp.Text);
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

            Assert.AreEqual(result, main.board[0,0].Background);
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
            main.Capture(4,4,3,3);

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
