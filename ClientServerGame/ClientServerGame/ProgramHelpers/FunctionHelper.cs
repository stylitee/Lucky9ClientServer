using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientServerGame.ProgramHelpers
{
    public class FunctionHelper
    {
        public static void ConnectionLabelChangers(string text, int counter)
        {
            if (BattleBegins.lstOfConnection[counter].InvokeRequired)
                BattleBegins.lstOfConnection[counter].Invoke(new Action(() => BattleBegins.lstOfConnection[counter].Text = text));
            else
                BattleBegins.lstOfConnection[counter].Text = text;
        }

        public static void ImageChanger(Bitmap bitmap, int counter)
        {
            if (BattleBegins.pictureBoxes[counter].InvokeRequired)
                BattleBegins.pictureBoxes[counter].Invoke(new Action(() => BattleBegins.pictureBoxes[counter].Image = bitmap));
            else
                BattleBegins.lstOfConnection[counter].Image = bitmap;
        }

        public static void ConnectionLabelChangers(string text)
        {
            if (BattleBegins.gameStatus[0].InvokeRequired)
                BattleBegins.gameStatus[0].Invoke(new Action(() => BattleBegins.gameStatus[0].Text = text));
            else
                BattleBegins.gameStatus[0].Text = text;
        }
    }
}
