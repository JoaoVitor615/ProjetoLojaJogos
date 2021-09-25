using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoLoja.Repositorio;
using MySql.Data.MySqlClient;
using ProjetoLoja.Models;

namespace ProjetoLoja.Repositorio
{
    public class Acoes
    {
        Conexao con = new Conexao();
        MySqlCommand cmd = new MySqlCommand();

        // AÇÕES JOGO
        public void CadastrarJogo(Jogo jogo)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbl_jogos values(@cd_jogo, @nm_jogo, @versao_jogo, @desenvolvedor_jogo, @genero_jogo," +
                " @etaria_jogo, @plataforma_jogo, @ano_jogo, @sinopse_jogo)", con.ConectarBd());
            cmd.Parameters.Add("@cd_jogo", MySqlDbType.VarChar).Value = jogo.Jogo_Cod;
            cmd.Parameters.Add("@nm_jogo", MySqlDbType.VarChar).Value = jogo.Jogo_Nome;
            cmd.Parameters.Add("@versao_jogo", MySqlDbType.VarChar).Value = jogo.Jogo_Versao;
            cmd.Parameters.Add("@desenvolvedor_jogo", MySqlDbType.VarChar).Value = jogo.Jogo_Desenv;
            cmd.Parameters.Add("@genero_jogo", MySqlDbType.VarChar).Value = jogo.Jogo_Genero;
            cmd.Parameters.Add("@etaria_jogo", MySqlDbType.VarChar).Value = jogo.Jogo_FxEtaria;
            cmd.Parameters.Add("@plataforma_jogo", MySqlDbType.VarChar).Value = jogo.Jogo_Plataforma;
            cmd.Parameters.Add("@ano_jogo", MySqlDbType.VarChar).Value = jogo.Jogo_Lanc;
            cmd.Parameters.Add("@sinopse_jogo", MySqlDbType.VarChar).Value = jogo.Jogo_Sinopse;
            cmd.ExecuteNonQuery();
            con.DesconectarBd();
        }

        public Jogo ListarCodJogo(int cod)
        {
            var comando = String.Format("select * from tbl_jogos where Jogo_Cod = {0}", cod);
            MySqlCommand cmd = new MySqlCommand(comando, con.ConectarBd());
            var DadosJogo = cmd.ExecuteReader();
            return ListCodJogo(DadosJogo).FirstOrDefault();
        }

        public List<Jogo> ListCodJogo(MySqlDataReader dt)
        {
            var AltAl = new List<Jogo>();
            while (dt.Read())
            {
                var AlTemp = new Jogo()
                {
                    Jogo_Cod = int.Parse(dt["cd_jogo"].ToString()),
                    Jogo_Nome = dt["nm_jogo"].ToString(),
                    Jogo_Versao = dt["versao_jogo"].ToString(),
                    Jogo_Desenv = dt["desenvolvedor_jogo"].ToString(),
                    Jogo_Genero = dt["genero_jogo"].ToString(),
                    Jogo_FxEtaria = dt["etaria_jogo"].ToString(),
                    Jogo_Plataforma = dt["plataforma_jogo"].ToString(),
                    Jogo_Lanc = int.Parse(dt["ano_jogo"].ToString()),
                    Jogo_Sinopse = dt["sinopse_jogo"].ToString()
                };
                AltAl.Add(AlTemp);
            }

            dt.Close();
            return AltAl;
        }

        public List<Jogo> ListarJogo()
        {
            MySqlCommand cmd = new MySqlCommand("Select * from tbl_jogos ", con.ConectarBd());
            var DadosJogos = cmd.ExecuteReader();
            return ListarTodosJogos(DadosJogos);
        }

        public List<Jogo> ListarTodosJogos(MySqlDataReader dt)
        {
            var TodosJogos = new List<Jogo>();
            while (dt.Read())
            {
                var JogoTemp = new Jogo()
                {
                    Jogo_Cod = int.Parse(dt["cd_jogo"].ToString()),
                    Jogo_Nome = dt["nm_jogo"].ToString(),
                    Jogo_Versao = dt["versao_jogo"].ToString(),
                    Jogo_Desenv = dt["desenvolvedor_jogo"].ToString(),
                    Jogo_Genero = dt["genero_jogo"].ToString(),
                    Jogo_FxEtaria = dt["etaria_jogo"].ToString(),
                    Jogo_Plataforma = dt["plataforma_jogo"].ToString(),
                    Jogo_Lanc = int.Parse(dt["ano_jogo"].ToString()),
                    Jogo_Sinopse = dt["sinopse_jogo"].ToString()
                };
                TodosJogos.Add(JogoTemp);
            }
            dt.Close();
            return TodosJogos;
        }

        //AÇÕES DO CLIENTE
        public void CadastrarCliente(Cliente cliente)
        {
            string data_sistema = Convert.ToDateTime(cliente.Cliente_DataNasc).ToString("yyyy-MM-dd");
            MySqlCommand cmd = new MySqlCommand("insert into tbl_cliente values(@nm_cliente , @cpf_cliente, @dt_nasc_cliente , @email_cliente , @celular_cliente ," +
                " @endereco_cliente )", con.ConectarBd());
            cmd.Parameters.Add("@nm_cliente ", MySqlDbType.VarChar).Value = cliente.Cliente_Nome;
            cmd.Parameters.Add("@cpf_cliente ", MySqlDbType.VarChar).Value = cliente.Cliente_Cpf;
            cmd.Parameters.Add("@dt_nasc_cliente ", MySqlDbType.DateTime).Value = data_sistema;
            cmd.Parameters.Add("@email_cliente ", MySqlDbType.VarChar).Value = cliente.Cliente_Email;
            cmd.Parameters.Add("@celular_cliente ", MySqlDbType.VarChar).Value = cliente.Cliente_Celular;
            cmd.Parameters.Add("@endereco_cliente ", MySqlDbType.VarChar).Value = cliente.Cliente_Endereco;
            cmd.ExecuteNonQuery();
            con.DesconectarBd();
        }

        public Cliente ListarCodCli(int cod)
        {
            var comando = String.Format("select * from tbl_cliente where cpf_cliente  = {0}", cod);
            MySqlCommand cmd = new MySqlCommand(comando, con.ConectarBd());
            var DadosCliente = cmd.ExecuteReader();
            return ListCodCliente(DadosCliente).FirstOrDefault();
        }

        public List<Cliente> ListCodCliente(MySqlDataReader dt)
        {
            var AltAl = new List<Cliente>();
            while (dt.Read())
            {
                var AlTemp = new Cliente()
                {
                    Cliente_Nome = dt["nm_cliente"].ToString(),
                    Cliente_Cpf = dt["cpf_cliente"].ToString(),
                    Cliente_DataNasc = DateTime.Parse(dt["dt_nasc_cliente"].ToString()),
                    Cliente_Email = dt["email_cliente"].ToString(),
                    Cliente_Celular = dt["celular_cliente"].ToString(),
                    Cliente_Endereco = dt["endereco_cliente"].ToString(),
                };
                AltAl.Add(AlTemp);
            }

            dt.Close();
            return AltAl;
        }

        public List<Cliente> ListarCliente()
        {
            MySqlCommand cmd = new MySqlCommand("Select * from tbl_cliente", con.ConectarBd());
            var DadosCliente = cmd.ExecuteReader();
            return ListarTodosClientes(DadosCliente);
        }

        public List<Cliente> ListarTodosClientes(MySqlDataReader dt)
        {
            var TodosClientes = new List<Cliente>();
            while (dt.Read())
            {
                var ClienteTemp = new Cliente()
                {
                    Cliente_Nome = dt["nm_cliente "].ToString(),
                    Cliente_Cpf = dt["cpf_cliente "].ToString(),
                    Cliente_DataNasc = DateTime.Parse(dt["dt_nasc_cliente"].ToString()),
                    Cliente_Email = dt["email_cliente"].ToString(),
                    Cliente_Celular = dt["celular_cliente"].ToString(),
                    Cliente_Endereco = dt["endereco_cliente"].ToString(),
                };
                TodosClientes.Add(ClienteTemp);
            }
            dt.Close();
            return TodosClientes;
        }



        //AÇÕES FUNCIONARIO

        public void CadastrarFunc(Funcionario func)
        {
            string data_sistema = Convert.ToDateTime(func.Func_DataNasc).ToString("yyyy-MM-dd");
            MySqlCommand cmd = new MySqlCommand("insert into tbl_funcionario values(@cd_func, @nm_func , @rg_func , @dt_nasc_func, @cpf_func ," +
                " @endereco_func , @celular_func , @email_func , @cargo_func )", con.ConectarBd());
            cmd.Parameters.Add("@cd_func ", MySqlDbType.VarChar).Value = func.Func_Cod;
            cmd.Parameters.Add("@nm_func ", MySqlDbType.VarChar).Value = func.Func_Nome;
            cmd.Parameters.Add("@cpf_func ", MySqlDbType.VarChar).Value = func.Func_Cpf;
            cmd.Parameters.Add("@rg_func ", MySqlDbType.VarChar).Value = func.Func_Rg;
            cmd.Parameters.Add("@dt_nasc_func ", MySqlDbType.DateTime).Value = data_sistema;
            cmd.Parameters.Add("@endereco_func ", MySqlDbType.VarChar).Value = func.Func_Endereco;
            cmd.Parameters.Add("@cellfunc", MySqlDbType.VarChar).Value = func.Func_Celular;
            cmd.Parameters.Add("@email_func ", MySqlDbType.VarChar).Value = func.Func_Email;
            cmd.Parameters.Add("@cargo_func ", MySqlDbType.VarChar).Value = func.Func_Cargo;
            cmd.ExecuteNonQuery();
            con.DesconectarBd();
        }

        public Funcionario ListarCodFunc(int cod)
        {
            var comando = String.Format("select * from tbl_funcionario  where Func_Cod  = {0}", cod);
            MySqlCommand cmd = new MySqlCommand(comando, con.ConectarBd());
            var DadosFunc = cmd.ExecuteReader();
            return ListCodFunc(DadosFunc).FirstOrDefault();
        }

        public List<Funcionario> ListCodFunc(MySqlDataReader dt)
        {
            var AltAl = new List<Funcionario>();
            while (dt.Read())
            {
                var AlTemp = new Funcionario()
                {
                    Func_Cod = int.Parse(dt["cd_func"].ToString()),
                    Func_Nome = dt["nm_func"].ToString(),
                    Func_Cpf = dt["cpf_func"].ToString(),
                    Func_Rg = dt["rg_func"].ToString(),
                    Func_DataNasc = DateTime.Parse(dt["dt_nasc_func "].ToString()),
                    Func_Endereco = dt["endereco_func"].ToString(),
                    Func_Celular = dt["celular_func"].ToString(),
                    Func_Email = dt["email_func"].ToString(),
                    Func_Cargo = dt["cargo_func "].ToString(),
                };
                AltAl.Add(AlTemp);
            }

            dt.Close();
            return AltAl;
        }

        public List<Funcionario> ListarFuncionario()
        {
            MySqlCommand cmd = new MySqlCommand("Select * from tbl_funcionario", con.ConectarBd());
            var DadosFunc = cmd.ExecuteReader();
            return ListarTodosFuncs(DadosFunc);
        }

        public List<Funcionario> ListarTodosFuncs(MySqlDataReader dt)
        {
            var TodosFuncs = new List<Funcionario>();
            while (dt.Read())
            {
                var FuncTemp = new Funcionario()
                {
                    Func_Cod = int.Parse(dt["cd_func"].ToString()),
                    Func_Nome = dt["nm_func"].ToString(),
                    Func_Cpf = dt["cpf_func"].ToString(),
                    Func_Rg = dt["rg_func"].ToString(),
                    Func_DataNasc = DateTime.Parse(dt["dt_nasc_func"].ToString()),
                    Func_Endereco = dt["endereco_func"].ToString(),
                    Func_Celular = dt["celular_func"].ToString(),
                    Func_Email = dt["email_func"].ToString(),
                    Func_Cargo = dt["cargo_func"].ToString(),
                };
                TodosFuncs.Add(FuncTemp);
            }
            dt.Close();
            return TodosFuncs;
        }

    }
}