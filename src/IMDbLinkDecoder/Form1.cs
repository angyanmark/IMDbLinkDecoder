using IMDbLinkDecoder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMDbLinkDecoder
{
    public partial class Form1 : Form
    {
        private readonly string inputPlaceholder = "Enter IMDb links here...";

        private bool Going { get; set; }

        public Form1()
        {
            InitializeComponent();

            tbIn.Text = inputPlaceholder;

            tbIn.GotFocus += RemoveText;
            tbIn.LostFocus += AddText;

            tbIn.MaxLength = int.MaxValue;
            tbOut.MaxLength = int.MaxValue;
        }

        private async Task LoadFilmsAsync()
        {
            var inputText = tbIn.Text.Replace(" ", string.Empty);
            var inputLines = new List<string>(inputText.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));

            var lines = inputLines.Select(inputLine => new Line(inputLine));

            var filmCount = 1;

            var options = new OutputOptions
            {
                Counter = cbCounter.Checked,
                Title = cbTitle.Checked,
                Date = cbDate.Checked,
                TMDb = cbTMDb.Checked,
                Link = cbInputLink.Checked,
                Separator = tbSeparator.Text,
            };

            foreach (var line in lines)
            {
                if (!Going) break;

                tbOut.AppendText(await line.GetOutputAsync(options, filmCount));

                lProgress.Text = $"{filmCount} / {lines.Count()} ({filmCount * 100 / lines.Count()}%)";
                filmCount++;
            }

            Stop();
        }

        private async void Start_Click(object sender, EventArgs e)
        {
            if (!Going)
            {
                await StartAsync();
            }
            else
            {
                Stop();
            } 
        }

        private async Task StartAsync()
        {
            Going = true;
            bStart.Text = "Stop";

            SetOptionsEnabled(false);

            tbOut.Clear();
            await LoadFilmsAsync();
        }

        private void Stop()
        {
            Going = false;
            bStart.Text = "Start";

            SetOptionsEnabled(true);
        }

        private void SetOptionsEnabled(bool enabled)
        {
            cbCounter.Enabled = enabled;
            cbTitle.Enabled = enabled;
            cbDate.Enabled = enabled;
            cbTMDb.Enabled = enabled;
            cbInputLink.Enabled = enabled;
            tbSeparator.Enabled = enabled;
        }

        private void RemoveText(object sender, EventArgs e)
        {
            if (tbIn.Text == inputPlaceholder)
            {
                tbIn.Text = string.Empty;
            }
        }

        private void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbIn.Text))
            {
                tbIn.Text = inputPlaceholder;
            }
        }
    }
}
