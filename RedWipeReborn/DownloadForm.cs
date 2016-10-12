using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RedditSharp.Things;

namespace RedWipeReborn
{
    public partial class DownloadForm : Form
    {
        Comment[] _comments = null;
        Post[] _posts = null;
        string[] _exceptions = null;
        
        Dictionary<string, int> _exceptedCommentCounts = new Dictionary<string, int>();
        Dictionary<string, int> _exceptedPostCounts = new Dictionary<string, int>();

        public DownloadForm()
        {
            InitializeComponent();
        }

        private void Log(string message)
        {
            this.Invoke(new Action<string>((m) => {
                StatusLabel.Text = m;
                StatusLabel.Invalidate();
                LogTextBox.AppendText(m + "\n");
                LogTextBox.SelectionStart = LogTextBox.TextLength;
                LogTextBox.ScrollToCaret();
                LogTextBox.Invalidate();
            }), message);
        }

        private void SetProgress(int value)
        {
            this.Invoke(new Action<int>((v) => { DownloadProgressBar.Value = v; DownloadProgressBar.Invalidate(); }), value);
        }
        private void SetProgressMax(int value)
        {
            this.Invoke(new Action<int>((v) => { DownloadProgressBar.Value = 0; DownloadProgressBar.Maximum = value; DownloadProgressBar.Invalidate(); }), value);
        }

        private async void ReviewForm_Load(object sender, EventArgs e)
        {
            SetProgressMax(5);

            SetProgress(1);
            Log("Downloading comment history...");
            _comments = await Program.Engine.GetAllCommentsAsync();

            SetProgress(2);
            Log("Downloading post history...");
            _posts = await Program.Engine.GetAllPostsAsync();
            
            SetProgress(3);
            Log("Downloading exemption list...");
            _exceptions = await Program.Engine.GetSubredditExceptionsAsync();

            SetProgress(4);
            Log(string.Format("Filtering {0} posts and {1} comments...", _posts.Length, _comments.Length));
            int exceptedCommentCount = 0;
            int exceptedPostCount = 0;
            foreach (string subreddit in _exceptions)
            {
                int ecc = _comments.Count(c => c.Subreddit.Equals(subreddit, StringComparison.InvariantCultureIgnoreCase));
                int epc = _posts.Count(p => p.SubredditName.Equals(subreddit, StringComparison.InvariantCultureIgnoreCase));

                _exceptedCommentCounts.Add(subreddit, ecc);
                _exceptedPostCounts.Add(subreddit, epc);
                
                exceptedCommentCount += ecc;
                exceptedPostCount += epc;
            }
            _comments = _comments.Where(c => _exceptions.Contains(c.Subreddit, StringComparer.InvariantCultureIgnoreCase)).ToArray();
            _posts = _posts.Where(p => _exceptions.Contains(p.SubredditName, StringComparer.InvariantCultureIgnoreCase)).ToArray();

            SetProgress(5);
            Log(string.Format("Added exceptions for {0} posts and {1} comments in exempt subreddits.", exceptedPostCount, exceptedCommentCount));
        }
    }
}
