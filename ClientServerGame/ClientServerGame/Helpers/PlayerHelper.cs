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
                    player.id = dr.Field<int>("player_id");
                    player.playerName = dr.Field<string>("player_name");
                    player.card_values = dr.Field<string>("card_values");
                    player.UpForSteal = dr.Field<string>("up_for_steal");
                    player.isReady = dr.Field<string>("is_ready");
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
                                           new SqlParameter("@player_name",            player.playerName),
                                           new SqlParameter("@card_values",            DBNull.Value),
                                           new SqlParameter("@up_for_steal",           DBNull.Value),
                                           new SqlParameter("@is_ready",              DBNull.Value)
                                       };
                db_conn.ExecuteNonQuery("SavePlayer", param);
            }
        }

        public static void updateReadyStatus(int player_id)
        {
            using (Connection db_conn = new Connection())
            {
                if (!db_conn.IsConnected) return;
                SqlParameter[] param = {
                                           new SqlParameter("@isReady",               "Yes"),
                                           new SqlParameter("@player_id",             player_id),
                                       };
                db_conn.ExecuteNonQuery("isReadyPlayer", param);
            }
        }
    }
}
