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
            System.Diagnostics.Process.Start("https://play.google.com/store/apps/details?id=co.za.mikehall.tubestar");
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}