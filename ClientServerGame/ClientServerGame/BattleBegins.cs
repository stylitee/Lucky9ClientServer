using ClientServerGame.Helpers;
using ClientServerGame.Model;
using ClientServerGame.ProgramHelpers;
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
    public partial class BattleBegins : Form
    {
        public static List<Label> lstOfConnection = new List<Label>();
        List<MatchID> matches = new List<MatchID>();
        System.Timers.Timer aTimer = new System.Timers.Timer(999999999);
        int connectionFlagChecker = 0;
        public BattleBegins()
        {
            InitializeComponent();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 2000;
            aTimer.Enabled = true;

            lstOfConnection.Add(lblConnected1);
            lstOfConnection.Add(lblConnected2);
            lstOfConnection.Add(lblConnected3);
            lstOfConnection.Add(lblConnected4);

            LoadPlayers();
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            if(connectionFlagChecker == 0)
            {
                connectionChecker();
            }
        }
        public void connectionChecker()
        {
            int counter = 0;
            List<Player> players = new List<Player>();
            players = PlayerHelper.GetPlayers();
            foreach(var c in players)
            {
                if(c.isReady == "Yes")
                {
                    if(counter == 0)
                    {
                        string textSetter = "Connected";
                        FunctionHelper.ConnectionLabelChangers(textSetter, counter);
                        counter++;
                    }
                }
            }
        }

        private void LoadPlayers()
        {
            matches = MatchHelper.GetAllMatches();
            if(matches[0].player3 == null && matches[0].player4 == null)
            {
                lblPlayer1.Text = "Player 1:" + matches[0].player1;
                lblPlayer2.Text = "Player 2:" + matches[0].player2;
            }
            else if(matches[0].player4 == null)
            {
                lblPlayer1.Text = "Player 1:" + matches[0].player1;
                lblPlayer2.Text = "Player 2:" + matches[0].player2;
                lblPlayer3.Text = "Player 3:" + matches[0].player3;
            }
            else
            {
                lblPlayer1.Text = "Player 1:" + matches[0].player1;
                lblPlayer2.Text = "Player 2:" + matches[0].player2;
                lblPlayer3.Text = "Player 3:" + matches[0].player3;
                lblPlayer4.Text = "Player 4:" + matches[0].player4;
            }
        }


    }
}
