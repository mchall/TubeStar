using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using Xceed.Wpf.Toolkit;

namespace TubeStar
{
    /// <summary>
    /// Interaction logic for ViewVideoDialog.xaml
    /// </summary>
    public partial class ViewVideoDialog : ChildWindow
    {
        private Video _video;

        public ViewVideoDialog(Video video)
        {
            InitializeComponent();
            _video = video;

            Translate();
            if (video.GetCommentsCount() == 0)
            {
                lblComments.Visibility = commentStack.Visibility = Visibility.Collapsed;
            }
            Populate(video);

            string id = video.YouTubeVideoId;

            if (DateTime.Now.Day == 1 && DateTime.Now.Month == 4)
            {
                id = "oHg5SJYRHA0";
            }

            string html = "<div style=\"width:100%;height:100 %;width:610px;height:343px;float:none;clear:both;margin:2px auto;\">";
            html += "<embed src = \"http://www.youtube.com/v/" + id + "?version=3&amp;hl=en_US&amp;rel=0&amp;autohide=1\" wmode = \"transparent\" type = \"application/x-shockwave-flash\" width = \"100%\" height = \"100%\" allowfullscreen = \"true\" title = \"Adobe Flash Player\" >";
            html += "</div>";

            this.webView.NavigateToString(html);
        }

        private void wb_LoadCompleted(object sender, NavigationEventArgs e)
        {
            string script = "document.body.style.overflow ='hidden'";
            WebBrowser wb = (WebBrowser)sender;
            wb.InvokeScript("execScript", new Object[] { script, "JavaScript" });
        }

        private void Translate()
        {
            Caption = EnglishStrings.ViewVideo.Translate();
            lblComments.Text = String.Format("{0} ({1})", EnglishStrings.Comments.Translate(), _video.GetCommentsCount().ToNumberString());
            btnOk.Content = EnglishStrings.Ok.Translate();
        }

        private void Populate(Video video)
        {
            List<VideoComment> orderedComments = new List<VideoComment>();
            foreach (var item in video.Comments)
            {
                VideoComment likedComment = new VideoComment(item.Comment, item.Likes);
                orderedComments.Add(likedComment);
            }

            foreach (var comment in orderedComments)
            {
                CommentBlock block = new CommentBlock(comment.Comment, comment.Likes);
                commentStack.Children.Insert(0, block);
            }
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            webView.NavigateToString("<html></html>");
            this.DialogResult = true;
        }

        private void ChildWindow_Closed(object sender, EventArgs e)
        {
            webView.NavigateToString("<html></html>");
        }
    }
}