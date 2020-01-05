using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            tbIn.MaxLength = Int32.MaxValue; //2147483647
            tbOut.MaxLength = Int32.MaxValue; //2147483647
        }

        private async Task LoadFilms()
        {
            string inputText = tbIn.Text.Replace(" ", string.Empty);
            List<string> inputLines = new List<string>(inputText.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));

            List<string> idLines = new List<string>();
            foreach (string line in inputLines)
            {
                idLines.Add("tt" + CleanStringOfNonDigits(line));
            }

            int filmCount = 1;

            foreach (string id in idLines)
            {
                if (!going) break;

                string filmLink = "imdb.com/title/" + id;

                Film f = await Task.Run(() => APICalls.GetFilmById(id));

                List<string> elements = new List<string>();

                if (f.movie_results.Count > 0)
                {
                    Movie_Results mr = f.movie_results[0];

                    if (cbCounter.Checked)
                    {
                        elements.Add(filmCount.ToString());
                    }
                    if (cbTitle.Checked)
                    {
                        elements.Add(mr.title);
                    }
                    if (cbDate.Checked)
                    {
                        elements.Add(mr.release_date);
                    }
                    if (cbTMDb.Checked)
                    {
                        elements.Add(mr.vote_average.ToString());
                    }
                    if (cbInputLink.Checked)
                    {
                        elements.Add(filmLink);
                    }
                }
                else if (f.tv_results.Count > 0)
                {
                    Tv_Results tr = f.tv_results[0];

                    if (cbCounter.Checked)
                    {
                        elements.Add(filmCount.ToString());
                    }
                    if (cbTitle.Checked)
                    {
                        elements.Add(tr.name);
                    }
                    if (cbDate.Checked)
                    {
                        elements.Add(tr.first_air_date);
                    }
                    if (cbTMDb.Checked)
                    {
                        elements.Add(tr.vote_average.ToString());
                    }
                    if (cbInputLink.Checked)
                    {
                        elements.Add(filmLink);
                    }
                }
                else if (f.tv_episode_results.Count > 0)
                {
                    Tv_Episode_Results ter = f.tv_episode_results[0];

                    if (cbCounter.Checked)
                    {
                        elements.Add(filmCount.ToString());
                    }
                    if (cbTitle.Checked)
                    {
                        elements.Add(ter.name);
                    }
                    if (cbDate.Checked)
                    {
                        elements.Add(ter.air_date);
                    }
                    if (cbTMDb.Checked)
                    {
                        elements.Add(ter.vote_average.ToString());
                    }
                    if (cbInputLink.Checked)
                    {
                        elements.Add(filmLink);
                    }
                }
                else if (f.person_results.Count > 0)
                {
                    Person_Results pr = f.person_results[0];

                    if (cbCounter.Checked)
                    {
                        elements.Add(filmCount.ToString());
                    }
                    if (cbTitle.Checked)
                    {
                        elements.Add(pr.name);
                    }
                    if (cbDate.Checked)
                    {
                        elements.Add(pr.known_for_department);
                    }
                    if (cbInputLink.Checked)
                    {
                        elements.Add(filmLink);
                    }
                }
                else if (f.tv_season_results.Count > 0)
                {
                    if (cbCounter.Checked)
                    {
                        elements.Add(filmCount.ToString());
                    }
                    if (cbInputLink.Checked)
                    {
                        elements.Add("TV Season: " + filmLink);
                    }
                }
                else
                {
                    if (cbCounter.Checked)
                    {
                        elements.Add(filmCount.ToString());
                    }
                    elements.Add("Movie not found on TMDb: " + filmLink);
                }

                tbOut.AppendText(string.Join(tbSeparator.Text, elements) + "\r\n");

                lProgress.Text = filmCount + " / " + inputLines.Count + " (" + (filmCount * 100 / inputLines.Count) + " %)";
                filmCount++;

                await Task.Delay(140);
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
            await LoadFilms();
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

        private string CleanStringOfNonDigits(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;

            Regex rxNonDigits = new Regex(@"[^\d]+");
            string cleaned = rxNonDigits.Replace(s, "");
            return cleaned;
        }

        private void RemoveText(object sender, EventArgs e)
        {
            if (tbIn.Text == inputPlaceholder)
            {
                tbIn.Text = "";
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
