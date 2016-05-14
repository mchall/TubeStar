using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Xceed.Wpf.Toolkit;

namespace TubeStar
{
    /// <summary>
    /// Interaction logic for UpdateDialog.xaml
    /// </summary>
    public partial class UpdateDialog : Window
    {
        public UpdateDialog()
        {
            InitializeComponent();
            Translate();
        }

        private void Translate()
        {
            btnOk.Content = EnglishStrings.Ok.Translate();
        }

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://gamejolt.com/games/tubestar-2016/145575/");
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}