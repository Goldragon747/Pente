﻿using System;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PvP_Click(object sender, RoutedEventArgs e)
        {
            PlayerPanel.Visibility = Visibility.Collapsed;
            NamePanel.Visibility = Visibility.Visible;
        }

        private void PvC_CLick(object sender, RoutedEventArgs e)
        {
            PlayerPanel.Visibility = Visibility.Collapsed;
            PvPNameDockPanel.Visibility = Visibility.Collapsed;
            NamePanel.Visibility = Visibility.Visible;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            PenteLabel.Visibility = Visibility.Collapsed;
            NamePanel.Visibility = Visibility.Collapsed;
            PNameBlock.Text = PlayerNameBox.Text;
            if (!string.IsNullOrEmpty(EnemyNameBox.Text))
                ENameBlock.Text = EnemyNameBox.Text;

            ControlPanel.Visibility = Visibility.Visible;
            GameBoardGrid.Visibility = Visibility.Visible;
        }
    }
}
