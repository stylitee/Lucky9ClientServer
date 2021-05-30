using ClientServerGame.CustomControls;
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
using System.Timers;
using System.Windows.Forms;

namespace ClientServerGame
{
    public partial class PlayersWaitingArea : Form
    {
        delegate void SetTextCallback(string text);
        delegate void LabelTextCallback(string text);
        bool timerrs = true, checker_ =true;
        int flag = 0;
        List<Player> lstPlayer = null;
        System.Timers.Timer aTimer = new System.Timers.Timer(999999999);
        public PlayersWaitingArea()
        {
            InitializeComponent();
            lblMatchID.Text = "Match ID: " + HostGame.id;
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            lblNumberOfPlayers.Text = "Max players: " + HostGame.maxPlayer;
            aTimer.Interval = 2000;
            aTimer.Enabled = timerrs;

            List<MatchID> matchIDs = new List<MatchID>();
        }


        private void SetText(string text)
        {
            if (this.btnStart.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.btnStart.Text = text;
            }
        }

        private void LblSetText(string text)
        {
            if (this.lblJoinedPlayers.InvokeRequired)
            {
                LabelTextCallback d = new LabelTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.lblJoinedPlayers.Text = text;
            }
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            
            if(timerrs == false)
            {
                
                aTimer.Enabled = false;
                aTimer.Stop();
                SetText("Start");
                
            }
            else
            {
                Task.Run(() => checkPlayers());
            }
                
        }

        public void checkPlayers()
        {
            try
            {
                lstPlayer = PlayerHelper.GetPlayers();
                if (lstPlayer.Count.ToString() != HostGame.maxPlayer)
                {
                    LblSetText("Joined Players: " + lstPlayer.Count.ToString());
                    if (flag == 0)
                    {
                        List<Player> players = PlayerHelper.GetPlayers();
                        if (players[0].playerName != Form1.PlayerName)
                        {
                            SetText("Waiting for the host to start");
                            flag = 1;
                        }
                    }
                    lstPlayer.Clear();
                }
                else
                {
                    LblSetText("Joined Players: " + lstPlayer.Count.ToString());
                    if (flag == 0)
                    {
                        List<Player> players = PlayerHelper.GetPlayers();
                        if (players.Count != 1 && players[0].playerName != Form1.PlayerName)
                        {
                            SetText("Waiting for the host to start");
                            flag = 1;
                        }
                    }
                    lstPlayer.Clear();
                    timerrs = false;
                }
                List<MatchID> matches = MatchHelper.GetAllMatches();
                if(matches[0].isStart != null)
                {
                    BattleBegins battleBegins = new BattleBegins();
                    battleBegins.Show();
                    this.Hide();

                }

            }
            catch (System.InvalidOperationException)
            {
                throw;
            }
        }

        public void addPlayers()
        {
            flpPlayers.Controls.Clear();
            foreach (var c in lstPlayer)
            {
                Players players = new Players();
                if(players.BackColor == Color.White)
                {
                    players.lblName.Text = c.playerName;
                    flpPlayers.Controls.Add(players);
                    players.BackColor = Color.FromArgb(62, 62, 66);
                }
                else
                {
                    players.lblName.Text = c.playerName;
                    flpPlayers.Controls.Add(players);
                    players.BackColor = Color.White;
                }
            }
        }

        private void btnStart_TextChanged(object sender, EventArgs e)
        {
            addPlayers();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "Waiting for other Players")
            {
                return;
            }
            else
            {
                lstPlayer.Clear();
                lstPlayer = PlayerHelper.GetPlayers();
                if (lstPlayer.Count == 2)
                {
                    MatchID matchHelper = new MatchID
                    {
                        id = HostGame.id,
                        player1 = lstPlayer[0].playerName,
                        player2 = lstPlayer[1].playerName
                    };

                    MatchHelper.UpdateMatch2(matchHelper);
                }
                else if (lstPlayer.Count == 3)
                {
                    MatchID matchHelper = new MatchID
                    {
                        id = HostGame.id,
                        player1 = lstPlayer[0].playerName,
                        player2 = lstPlayer[1].playerName,
                        player3 = lstPlayer[2].playerName
                    };

                    MatchHelper.UpdateMatch3(matchHelper);
                }
                else if (lstPlayer.Count == 4)
                {
                    MatchID matchHelper = new MatchID
                    {
                        id = HostGame.id,
                        player1 = lstPlayer[0].playerName,
                        player2 = lstPlayer[1].playerName,
                        player3 = lstPlayer[2].playerName
                    };
                    matchHelper.player3 = lstPlayer[3].playerName;

                    MatchHelper.UpdateMatch4(matchHelper);
                }
                foreach(var c in lstPlayer)
                {
                    if(c.playerName == Program.playerName)
                    {
                        PlayerHelper.updateReadyStatus(c.id, "Yes");
                    }
                }
                
                BattleBegins battle = new BattleBegins();
                battle.Show();
                this.Hide();
            }
        }
    }
}
