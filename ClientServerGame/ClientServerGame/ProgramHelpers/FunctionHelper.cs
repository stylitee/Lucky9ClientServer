using System;
using System.Collections.Generic;
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
    }
}
