using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pente;
using System.Windows;

namespace PenteTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void VisibliltyAfterPvPClickedTest()
        {
            MainWindow main = new MainWindow();
            main.PvC_Click(null,null);
            Assert.IsTrue(main.PlayerPanelProp.Visibility == Visibility.Collapsed);
        }
    }
}
