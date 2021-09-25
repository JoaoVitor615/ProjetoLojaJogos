using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace ProjetoLoja.Repositorio
{
    public class Conexao
    {

        MySqlConnection cn = new MySqlConnection("Server=localhost;DataBase=db_loja_jogos;user=root;pwd=06012005");
        public static string msg;

        public MySqlConnection ConectarBd()
        {
            try
            {
                cn.Open();
            }
            catch (Exception erro)
            {
                msg = "Ocorreu um erro ao conectar" + erro.Message;
            }
            return cn;
        }

        public MySqlConnection DesconectarBd()
        {
            try
            {
                cn.Close();
            }
            catch (Exception erro)
            {
                msg = "Ocorreu um erro ao desconectar" + erro.Message;
            }
            return cn;
        }
    }
}