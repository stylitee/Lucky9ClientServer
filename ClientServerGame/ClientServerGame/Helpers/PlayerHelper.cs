using ClientServerGame.DatabaseClass;
using ClientServerGame.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientServerGame.Helpers
{
    public class PlayerHelper
    {
        public static List<Player> GetPlayers()
        {
            List<Player> list = null;

            using (Connection dal = new Connection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("GetAllPlayers").Tables[0];

                list = new List<Player>();

                foreach (DataRow dr in data.AsEnumerable())
                {
                    Player player = new Player();
                    player.id = dr.Field<int>("id");
                    player.playerName = dr.Field<string>("playerName");
                    list.Add(player);
                }
            }
            return list;
        }

        public static void SavePlayer (Player player)
        {
            using (Connection db_conn = new Connection())
            {
                if (!db_conn.IsConnected) return;
                SqlParameter[] param = {
                                           new SqlParameter("@playerName",            player.playerName)
                                       };
                db_conn.ExecuteNonQuery("SavePlayer", param);
            }
        }
    }
}
