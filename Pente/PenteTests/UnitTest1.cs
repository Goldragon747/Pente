using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pente;
using System.Windows;

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
            Assert.IsTrue(main.PenteLabel.Visibility == Visibility.Collapsed);
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
        public void PNameBlockTextChangedAfterStartClicked()
        {
            MainWindow main = new MainWindow();
            main.Start_Click(null, null);
            Assert.IsTrue(main.PNameBlockProp.Text == main.PlayerNameBoxProp.Text);
        }
        [TestMethod]
        public void PVPNameDockPanelVisibilityAfterPvCClickedTest()
        {
            MainWindow main = new MainWindow();
            main.PvC_Click(null, null);
            Assert.IsTrue(main.PVPNameDockPanelProp.Visibility == Visibility.Collapsed);
        }
        [TestMethod]
        public void NamePanelPropVisibilityAfterPvCClickedTest()
        {
            MainWindow main = new MainWindow();
            main.PvC_Click(null, null);
            Assert.IsTrue(main.NamePanelProp.Visibility == Visibility.Visible);
        }


        ///////////////////////////////////BEN AND ELIZABETH//////////////////
    }
}
