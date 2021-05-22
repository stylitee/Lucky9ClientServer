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
    public partial class BattleBegins : Form
    {
        List<MatchID> matches = new List<MatchID>();
        public BattleBegins()
        {
            InitializeComponent();
            LoadPlayers();
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
