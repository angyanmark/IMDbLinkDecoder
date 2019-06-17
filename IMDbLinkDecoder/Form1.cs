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
                string idString = link.Replace(" ", string.Empty);
                Console.WriteLine(idString.Length);

                if(idString.Length > 0)
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

                if (f.movie_results.Count > 0)
                {
                    Movie_Results mr = f.movie_results[0];
                    tbOut.AppendText(count + ". " + mr.title + " (" + mr.release_date + ") - " + mr.vote_average + " - " + link + "\r\n");
                }
                else if (f.tv_results.Count > 0)
                {
                    Tv_Results tr = f.tv_results[0];
                    tbOut.AppendText(count + ". " + tr.name + " (" + tr.first_air_date + ") - " + tr.vote_average + " - " + link + "\r\n");
                }
                else if (f.tv_episode_results.Count > 0)
                {
                    Tv_Episode_Results ter = f.tv_episode_results[0];
                    tbOut.AppendText(count + ". " + ter.name + " (" + ter.air_date + ") - " + ter.vote_average + " - " + link + "\r\n");
                }
                else if (f.person_results.Count > 0)
                {
                    Person_Results pr = f.person_results[0];
                    tbOut.AppendText(count + ". " + pr.name + " (" + pr.known_for_department + ") - " + link + "\r\n");
                }
                else if (f.tv_season_results.Count > 0)
                {
                    tbOut.AppendText(count + ". " + "TV Season: " + link + "\r\n");
                }
                else
                {
                    tbOut.AppendText(count + ". " + "Movie not found on TMDb: \"" + link + "\"\r\n");
                }

                lProgress.Text = count++ + " / " + imdbLinks.Count;

                await Task.Delay(140);
            }
        }

        private async void bGo_Click(object sender, EventArgs e)
        {
            tbOut.Clear();
            imdbLinks.Clear();
            count = 0;

            LoadFilms();
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
                tbIn.Text = "Enter IMDb links here...";
        }
    }
}
