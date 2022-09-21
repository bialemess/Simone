using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudio
{
    class DAO_Conexao
    {


        private static MySqlConnection con;

        public static Boolean getConexao(String local, String banco, String user, String senha)
        {
            Boolean retorno = false;
            try {
                con = new MySqlConnection("server=" + local+ ";user ID=" + user+ ";database=" + banco+ ";password=" + senha+ ";SslMode = none");
                //con.Open();
                //con.Open();
                retorno = true;
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                //con.Open();
            }
            //finally{ //con.Open();} finally faz o comando independente do try/catch

            return retorno;
        }

        public static int login (String usuario, String senha)
        {
            int tipo = 0;

            try
            {
                con.Open();
                MySqlCommand login = new MySqlCommand("Select * from Estudio_Login where usuario='"+usuario+"' and senha = '"+senha+"'", con);


                    MySqlDataReader resultado = login.ExecuteReader();
                if (resultado.Read())
                {
                    tipo = Convert.ToInt32(resultado["tipo"].ToString());      
                } 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return tipo;
        }
    }
}
