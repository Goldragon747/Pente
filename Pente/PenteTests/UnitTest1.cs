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


        ////////////////////////////BEN & LIZ//////////////////
        [TestMethod]
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
    }
}
