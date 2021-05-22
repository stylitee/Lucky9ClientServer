using ClientServerGame.DatabaseClass;
using ClientServerGame.Helpers;
using ClientServerGame.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientServerGame
{
    public partial class Form1 : Form
    {
        public static string MatchID = "", PlayerName = "";
        List<string> listed = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HostGame hostGame = new HostGame();
            hostGame.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(txtMatchID.Text == "" || txtName.Text == "")
            {
                MessageBox.Show("Fields Cannot be Empty");
            }
            else
            {
                List<MatchID> matches = MatchHelper.GetAllMatches();
                List<Player> players = PlayerHelper.GetPlayers();
                if (matches[0].id == txtMatchID.Text)
                {
                    if (players.Count.ToString() != matches[0].maxPlayer)
                    {
                        Player player = new Player();
                        player.playerName = txtName.Text;
                        PlayerHelper.SavePlayer(player);

                        PlayersWaitingArea playersWaiting = new PlayersWaitingArea();
                        playersWaiting.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Match is full");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Match ID please try again");
                }
            }
        }  
    }
}
