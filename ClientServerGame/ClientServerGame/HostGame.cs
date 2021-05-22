using ClientServerGame.Helpers;
using ClientServerGame.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientServerGame
{
    public partial class HostGame : Form
    {
        public static string id = "", maxPlayer = "";
        string MatchID = Guid.NewGuid().ToString("N").Substring(0, 6);
        public HostGame()
        {
            InitializeComponent();
            lblMatchID.Text = MatchID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(cmbNumberOfPlayers.Text == "" || txtName.Text == "")
            {
                MessageBox.Show("Fields cannot be empty");
            }
            else
            {
                List<MatchID> matches = MatchHelper.GetAllMatches();
                if (matches.Count == 0)
                {
                    id = MatchID;
                    MatchHelper.CreateMatch(id, cmbNumberOfPlayers.Text);

                    Player player = new Player();
                    player.playerName = txtName.Text;
                    PlayerHelper.SavePlayer(player);
                    maxPlayer = cmbNumberOfPlayers.Text;
                    PlayersWaitingArea playersWaitingArea = new PlayersWaitingArea();
                    playersWaitingArea.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("There is an ongoing match please wait for the match to finish and try again later");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
