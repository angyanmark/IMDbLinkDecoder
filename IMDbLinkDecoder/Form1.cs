using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMDbLinkDecoder
{
    public partial class Form1 : Form
    {
        private List<string> imdbLinks = new List<string>();

        private int count = 0;

        private bool going = false;

        public Form1()
        {
            InitializeComponent();

            tbIn.GotFocus += RemoveText;
            tbIn.LostFocus += AddText;

            tbIn.MaxLength = Int32.MaxValue; //2147483647
            tbOut.MaxLength = Int32.MaxValue; //2147483647
        }

        private async Task LoadFilms()
        {
            string inText = tbIn.Text.Replace(" ", string.Empty);

            imdbLinks = new List<string>(inText.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));

            lProgress.Text = count++ + " / " + imdbLinks.Count;

            foreach (string link in imdbLinks)
            {
                if (!going) break;

                string idString = link;

                if (idString.Length > 0)
                {
                    if (idString[idString.Length - 1].Equals('/'))
                    {
                        idString = idString.Remove(idString.Length - 1);
                    }

                    if (idString.Length > 9)
                    {
                        idString = idString.Substring(idString.Length - 9);
                    }
                }

                Film f = await Task.Run(() => APICalls.FilmById(idString));

                List<string> elements = new List<string>();

                if (f.movie_results.Count > 0)
                {
                    Movie_Results mr = f.movie_results[0];

                    if (cbCounter.Checked)
                    {
                        elements.Add(count.ToString());
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
                        elements.Add(link);
                    }
                }
                else if (f.tv_results.Count > 0)
                {
                    Tv_Results tr = f.tv_results[0];

                    if (cbCounter.Checked)
                    {
                        elements.Add(count.ToString());
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
                        elements.Add(link);
                    }
                }
                else if (f.tv_episode_results.Count > 0)
                {
                    Tv_Episode_Results ter = f.tv_episode_results[0];

                    if (cbCounter.Checked)
                    {
                        elements.Add(count.ToString());
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
                        elements.Add(link);
                    }
                }
                else if (f.person_results.Count > 0)
                {
                    Person_Results pr = f.person_results[0];

                    if (cbCounter.Checked)
                    {
                        elements.Add(count.ToString());
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
                        elements.Add(link);
                    }
                }
                else if (f.tv_season_results.Count > 0)
                {
                    if (cbCounter.Checked)
                    {
                        elements.Add(count.ToString());
                    }
                    if (cbInputLink.Checked)
                    {
                        elements.Add("TV Season: " + link);
                    }
                }
                else
                {
                    if (cbCounter.Checked)
                    {
                        elements.Add(count.ToString());
                    }
                    elements.Add("Movie not found on TMDb: " + link);
                }

                for(int i = 0; i < elements.Count - 1; i++)
                {
                    tbOut.AppendText(elements[i] + tbSeparator.Text);
                }

                tbOut.AppendText(elements[elements.Count - 1] + "\r\n");

                lProgress.Text = count++ + " / " + imdbLinks.Count;

                await Task.Delay(140);
            }
            stop();
        }

        private async void bStart_Click(object sender, EventArgs e)
        {
            if (!going)
            {
                start();
            }
            else
            {
                stop();
            } 
        }

        private void start()
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
            imdbLinks.Clear();
            count = 0;

            LoadFilms();
        }

        private void stop()
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
            if (tbIn.Text == "Enter IMDb links here...")
            {
                tbIn.Text = "";
            }
        }

        private void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbIn.Text))
            {
                tbIn.Text = "Enter IMDb links here...";
            }
        }
    }
}
