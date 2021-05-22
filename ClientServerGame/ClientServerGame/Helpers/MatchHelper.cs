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
    public class MatchHelper
    {
        public static List<MatchID> GetAllMatches()
        {
            List<MatchID> list = null;

            using (Connection dal = new Connection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("GetAllMatchID").Tables[0];

                list = new List<MatchID>();

                foreach (DataRow dr in data.AsEnumerable())
                {
                    MatchID match = new MatchID();
                    match.id = dr.Field<string>("id");
                    match.player1 = dr.Field<string>("player1");
                    match.player2 = dr.Field<string>("player2");
                    match.player3 = dr.Field<string>("player3");
                    match.player4 = dr.Field<string>("player4");
                    match.maxPlayer = dr.Field<string>("maxPlayer");
                    match.maxPlayer = dr.Field<string>("isStart");
                    list.Add(match);
                }
            }
            return list;
        }

        public static void CreateMatch(string id, string max)
        {
            using (Connection db_conn = new Connection())
            {
                if (!db_conn.IsConnected) return;
                SqlParameter[] param = {
                                           new SqlParameter("@id",                   id),
                                           new SqlParameter("@player1",              DBNull.Value),
                                           new SqlParameter("@player2",              DBNull.Value),
                                           new SqlParameter("@player3",              DBNull.Value),
                                           new SqlParameter("@player4",              DBNull.Value),
                                           new SqlParameter("@maxPlayer",            max),
                                           new SqlParameter("@isStart",            DBNull.Value)

                                       };
                db_conn.ExecuteNonQuery("CreateMatch", param);
            }
        }

        public static void UpdateMatch2(MatchID match)
        {
            using (Connection db_conn = new Connection())
            {
                if (!db_conn.IsConnected) return;
                SqlParameter[] param = {
                                           new SqlParameter("@id",                   match.id),
                                           new SqlParameter("@player1",              match.player1),
                                           new SqlParameter("@player2",              match.player2)
                                       };
                db_conn.ExecuteNonQuery("update2Players", param);
            }
        }

        public static void UpdateMatch3(MatchID match)
        {
            using (Connection db_conn = new Connection())
            {
                if (!db_conn.IsConnected) return;
                SqlParameter[] param = {
                                           new SqlParameter("@id",                   match.id),
                                           new SqlParameter("@player1",              match.player1),
                                           new SqlParameter("@player2",              match.player2),
                                           new SqlParameter("@player3",              match.player3),
                                       };
                db_conn.ExecuteNonQuery("update3Players", param);
            }
        }

        public static void UpdateMatch4(MatchID match)
        {
            using (Connection db_conn = new Connection())
            {
                if (!db_conn.IsConnected) return;
                SqlParameter[] param = {
                                           new SqlParameter("@id",                   match.id),
                                           new SqlParameter("@player1",              match.player1),
                                           new SqlParameter("@player2",              match.player2),
                                           new SqlParameter("@player3",              match.player3),
                                           new SqlParameter("@player4",              match.player4)
                                       };
                db_conn.ExecuteNonQuery("update4Players", param);
            }
        }
    }
}
