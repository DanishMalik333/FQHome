using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Forte.ForteQuestNS
{
    public class DBContext
    {
        private static string strcon = ConfigurationManager.ConnectionStrings["ForteQuestXConnectionString"].ConnectionString;
        public static void ExecuteNonScalor(string storedprocedure, Hashtable ht)
        {
            try
            {
                
                using (SqlCommand command = new SqlCommand(storedprocedure))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (ht != null)
                    {
                        foreach (DictionaryEntry item in ht)
                        {
                            command.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                        }

                        using (SqlConnection con = new SqlConnection(strcon))
                        {
                            if (con.State == System.Data.ConnectionState.Closed)
                            {
                                con.Open();
                            }

                            command.Connection = con;
                            command.ExecuteNonQuery();
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                //
            }
        }
    }
}