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
        private bool going = false;

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
            string inputText = tbIn.Text.Replace(" ", string.Empty);
            List<string> inputLines = new List<string>(inputText.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));

            var lines = inputLines.Select(inputLine => new Line(inputLine)).ToList();

            int filmCount = 1;

            OutputOptions options = new OutputOptions
            {
                Counter = cbCounter.Checked,
                Title = cbTitle.Checked,
                Date = cbDate.Checked,
                TMDb = cbTMDb.Checked,
                Link = cbInputLink.Checked,
                Separator = tbSeparator.Text,
            };

            foreach (Line line in lines)
            {
                if (!going) break;

                tbOut.AppendText(await line.GetOutputAsync(options, filmCount));

                lProgress.Text = filmCount + " / " + lines.Count + " (" + (filmCount * 100 / lines.Count) + "%)";
                filmCount++;
            }

            Stop();
        }

        private async void Start_Click(object sender, EventArgs e)
        {
            if (!going)
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
            going = true;
            bStart.Text = "Stop";

            cbCounter.Enabled = false;
            cbTitle.Enabled = false;
            cbDate.Enabled = false;
            cbTMDb.Enabled = false;
            cbInputLink.Enabled = false;
            tbSeparator.Enabled = false;

            tbOut.Clear();
            await LoadFilmsAsync();
        }

        private void Stop()
        {
            going = false;
            bStart.Text = "Start";

            cbCounter.Enabled = true;
            cbTitle.Enabled = true;
            cbDate.Enabled = true;
            cbTMDb.Enabled = true;
            cbInputLink.Enabled = true;
            tbSeparator.Enabled = true;
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
