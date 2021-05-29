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
        public static List<Panel> lspnlActions = new List<Panel>();
        public static List<ComboBox> comboBoxes = new List<ComboBox>();
        public static List<PictureBox> pictureBoxes = new List<PictureBox>();

        List<MatchID> matches = new List<MatchID>();

        List<Bitmap> alas = new List<Bitmap>();
        List<Bitmap> two = new List<Bitmap>();
        List<Bitmap> three = new List<Bitmap>();
        List<Bitmap> four = new List<Bitmap>();
        List<Bitmap> five = new List<Bitmap>();
        List<Bitmap> six = new List<Bitmap>();
        List<Bitmap> seven = new List<Bitmap>();
        List<Bitmap> eight = new List<Bitmap>();
        List<Bitmap> nine = new List<Bitmap>();
        List<Bitmap> buklo = new List<Bitmap>();

        List<int> listCardValue = new List<int>();
        System.Timers.Timer aTimer = new System.Timers.Timer(999999999);
        int connectionFlagChecker = 0, generation = 0, stoper = 0;
        public BattleBegins()
        {
            InitializeComponent();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 2000;
            aTimer.Enabled = true;
            comboBoxes.Add(cmbActions);
            lspnlActions.Add(pnlActions);
            lstOfConnection.Add(lblConnected1);
            lstOfConnection.Add(lblConnected2);
            lstOfConnection.Add(lblConnected3);
            lstOfConnection.Add(lblConnected4);
            pictureBoxes.Add(player1Card1);
            pictureBoxes.Add(player1Card2);
            pictureBoxes.Add(player1Card3);
            lspnlActions[0].Hide();
            comboBoxes[0].Items.Add("Laban na");
            comboBoxes[0].Items.Add("hirit pa");
            LoadPlayers();
            LoadImages();
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            if(connectionFlagChecker == 0)
            {
                connectionChecker();
            }
            
            if(generation == 1)
            {
                generateCard();
            }
        }

        public void generateCard()
        {
            int counter = 0;
            listCardValue.Clear();
            listCardValue.Add(GenerateOTP());
            listCardValue.Add(GenerateOTP());
            for(counter = 0; counter < listCardValue.Count; counter++)
            {
                if (listCardValue[counter] == 1)
                {
                    FunctionHelper.ImageChanger(alas[generateCardNum()], counter);
                }
                else if(listCardValue[counter] == 2)
                {
                    FunctionHelper.ImageChanger(two[generateCardNum()], counter);
                }
                else if (listCardValue[counter] == 3)
                {
                    FunctionHelper.ImageChanger(three[generateCardNum()], counter);
                }
                else if (listCardValue[counter] == 4)
                {
                    FunctionHelper.ImageChanger(four[generateCardNum()], counter);
                }
                else if (listCardValue[counter] == 5)
                {
                    FunctionHelper.ImageChanger(five[generateCardNum()], counter);
                }
                else if (listCardValue[counter] == 6)
                {
                    FunctionHelper.ImageChanger(six[generateCardNum()], counter);
                }
                else if (listCardValue[counter] == 7)
                {
                    FunctionHelper.ImageChanger(seven[generateCardNum()], counter);
                }
                else if (listCardValue[counter] == 8)
                {
                    FunctionHelper.ImageChanger(eight[generateCardNum()], counter);
                }
                else if (listCardValue[counter] == 9)
                {
                    FunctionHelper.ImageChanger(nine[generateCardNum()], counter);
                }
                else
                {
                    FunctionHelper.ImageChanger(buklo[generateBukloCardNum()], counter);
                }
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
                    string textSetter = "Connected";
                    FunctionHelper.ConnectionLabelChangers(textSetter, counter);
                    counter++;
                }
            }
            if(players.Count == counter && stoper == 0)
            {
                connectionFlagChecker = 1;
                stoper = 1;
                generation = 1;
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

        public int GenerateOTP()
        {
            return new Random().Next(0, 9);
        }

        public int generateCardNum()
        {
            return new Random().Next(0, 3);
        }

        public int generateBukloCardNum()
        {
            return new Random().Next(0, 15);
        }



        private void LoadImages()
        {
            alas.Add(Properties.Resources.AC);
            alas.Add(Properties.Resources.AD);
            alas.Add(Properties.Resources.AH);
            alas.Add(Properties.Resources.AS);

            two.Add(Properties.Resources._2C);
            two.Add(Properties.Resources._2D);
            two.Add(Properties.Resources._2H);
            two.Add(Properties.Resources._2S);

            three.Add(Properties.Resources._3C);
            three.Add(Properties.Resources._3D);
            three.Add(Properties.Resources._3H);
            three.Add(Properties.Resources._3S);

            four.Add(Properties.Resources._4C);
            four.Add(Properties.Resources._4D);
            four.Add(Properties.Resources._4H);
            four.Add(Properties.Resources._4S);

            five.Add(Properties.Resources._5C);
            five.Add(Properties.Resources._5D);
            five.Add(Properties.Resources._5H);
            five.Add(Properties.Resources._5S);

            six.Add(Properties.Resources._6C);
            six.Add(Properties.Resources._6D);
            six.Add(Properties.Resources._6H);
            six.Add(Properties.Resources._6S);

            seven.Add(Properties.Resources._7C);
            seven.Add(Properties.Resources._7D);
            seven.Add(Properties.Resources._7H);
            seven.Add(Properties.Resources._7S);

            eight.Add(Properties.Resources._8C);
            eight.Add(Properties.Resources._8D);
            eight.Add(Properties.Resources._8H);
            eight.Add(Properties.Resources._8S);

            nine.Add(Properties.Resources._9C);
            nine.Add(Properties.Resources._9D);
            nine.Add(Properties.Resources._9H);
            nine.Add(Properties.Resources._9S);

            buklo.Add(Properties.Resources._10C);
            buklo.Add(Properties.Resources._10D);
            buklo.Add(Properties.Resources._10H);
            buklo.Add(Properties.Resources._10S);
            buklo.Add(Properties.Resources.JC);
            buklo.Add(Properties.Resources.JD);
            buklo.Add(Properties.Resources.JH);
            buklo.Add(Properties.Resources.JS);
            buklo.Add(Properties.Resources.QC);
            buklo.Add(Properties.Resources.QD);
            buklo.Add(Properties.Resources.QH);
            buklo.Add(Properties.Resources.QS);
            buklo.Add(Properties.Resources.KC);
            buklo.Add(Properties.Resources.KD);
            buklo.Add(Properties.Resources.KH);
            buklo.Add(Properties.Resources.KS);
        }
    }
}
