using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateriaisParaConstrucao
{
    public class Clientes
    {
        SqlCommand comandoSql = new SqlCommand();
        StringBuilder sql = new StringBuilder();
        DataTable dadosTabela = new DataTable();

        public void Salvar(string nome, string endereco, string bairro, string cep, string cidade, string estado, string telefone1,
                           string telefone2, string email, DateTime dataCadastro, DateTime nascimento, string observacoes)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(Conexao.stringConexao))
                {
                    conexao.Open();

                    sql.Append("INSERT INTO Cliente (NOME_CLIENTE, ENDERECO_CLIENTE, BAIRRO_CLIENTE, CEP_CLIENTE,");
                    sql.Append(" CIDADE_CLIENTE, ESTADO_CLIENTE, TELEFONE1_CLIENTE, TELEFONE2_CLIENTE, EMAIL_CLIENTE,");
                    sql.Append(" DATA_CADASTRO_CLIENTE, NASCIMENTO_CLIENTE, OBSERVACOES_CLIENTE)");
                    sql.Append(" VALUES (@nome, @endereco, @bairro, @cep, @cidade, @estado, @telefone1, @telefone2,");
                    sql.Append(" @email, @dataCadastro, @nascimento, @observacao)");

                    comandoSql.Parameters.Add(new SqlParameter("@nome", nome));
                    comandoSql.Parameters.Add(new SqlParameter("@endereco", endereco));
                    comandoSql.Parameters.Add(new SqlParameter("@bairro", bairro));
                    comandoSql.Parameters.Add(new SqlParameter("@cep", cep));
                    comandoSql.Parameters.Add(new SqlParameter("@cidade", cidade));
                    comandoSql.Parameters.Add(new SqlParameter("@estado", estado));
                    comandoSql.Parameters.Add(new SqlParameter("@telefone1", telefone1));
                    comandoSql.Parameters.Add(new SqlParameter("@telefone2", telefone2));
                    comandoSql.Parameters.Add(new SqlParameter("@email", email));
                    comandoSql.Parameters.Add(new SqlParameter("@dataCadastro", dataCadastro));
                    comandoSql.Parameters.Add(new SqlParameter("@nascimento", nascimento));
                    comandoSql.Parameters.Add(new SqlParameter("@observacao", observacoes));

                    comandoSql.CommandText = sql.ToString();
                    comandoSql.Connection = conexao;
                    comandoSql.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw new Exception("Ocorreu um erro no método Salvar. Caso o problema persista, entre em contato com o Administrador do Sistema.");
            }
        }

        public void SalvarPessoaFísica(int idCliente, string cpf, string rg)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(Conexao.stringConexao))
                {
                    conexao.Open();

                    sql.Append("INSERT INTO Pessoa_fisica (ID_CLIENTE, CPF_CLIENTE, RG_CLIENTE)");
                    sql.Append(" VALUES (@idCliente, @cpf, @rg)");

                    comandoSql.Parameters.Add(new SqlParameter("@idCliente", idCliente));
                    comandoSql.Parameters.Add(new SqlParameter("@cpf", cpf));
                    comandoSql.Parameters.Add(new SqlParameter("@rg", rg));

                    comandoSql.CommandText = sql.ToString();
                    comandoSql.Connection = conexao;
                    comandoSql.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw new Exception("Ocorreu um erro no método SalvarPessoaFísica. Caso o problema persista, entre em contato com o Administrador do Sistema.");
            }
        }

        public void SalvarPessoaJuridica(int idCliente, string cnpj, string ie)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(Conexao.stringConexao))
                {
                    conexao.Open();

                    sql.Append("INSERT INTO Pessoa_juridica (ID_CLIENTE, CNPJ_CLIENTE, IE_CLIENTE)");
                    sql.Append(" VALUES (@idCliente, @cnpj, @ie)");

                    comandoSql.Parameters.Add(new SqlParameter("@idCliente", idCliente));
                    comandoSql.Parameters.Add(new SqlParameter("@cnpj", cnpj));
                    comandoSql.Parameters.Add(new SqlParameter("@ie", ie));

                    comandoSql.CommandText = sql.ToString();
                    comandoSql.Connection = conexao;
                    comandoSql.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw new Exception("Ocorreu um erro no método SalvarPessoaJuridica. Caso o problema persista, entre em contato com o Administrador do Sistema.");
            }
        }

        public DataTable Listar()
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(Conexao.stringConexao))
                {
                    conexao.Open();

                    sql.Append("SELECT * FROM Cliente");
                    sql.Append(" ORDER BY ID_CLIENTE DESC");

                    comandoSql.CommandText = sql.ToString();
                    comandoSql.Connection = conexao;
                    dadosTabela.Load(comandoSql.ExecuteReader());
                    return dadosTabela;
                }
            }
            catch (Exception)
            {
                throw new Exception("Ocorreu um erro no método Listar. Caso o problema persista, entre em contato com o Administrador do Sistema.");
            }
        }
    }
}