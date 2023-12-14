using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using ConectionBD;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace Controller
{
    public class Curso_Controller
    {
        #region INSERT
        //###########################################################################################################################
        //######################################################## CADSTRAR #########################################################
        public static void GravarCurso(CursoModel curso)
        {
            MySqlCommand cmd = null;
            MySqlConnection conn = null;
            try
            {
                conn = Conexao.GetMyConnection();
                conn.Open();

                string sql = "INSERT INTO tb_curso(nome,criado_em,actualizado_em)VALUES(?,?,?)";
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("nome", curso.nome);
                cmd.Parameters.AddWithValue("criado_em", curso.criado_em);
                cmd.Parameters.AddWithValue("actualizado_em", curso.actualizado_em);

                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show("Curso cadastrado com sucesso \n", "CONFIRNMAÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar cadastrar o curso no banco de dados" + Environment.NewLine
                    + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }
        }
        #endregion

        #region UPDATE
        //###########################################################################################################################
        //######################################################## ATUALIZAR ########################################################
        public static void atualizarCurso(CursoModel curso)
        {
            MySqlCommand cmd = null;
            MySqlConnection conn = null;
            try
            {
                conn = Conexao.GetMyConnection();
                conn.Open();

                string sql = "UPDATE tb_curso SET nome=@nome,actualizado_em=@actualizado_em WHERE id_curso=@id_curso";
                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@id_curso", curso.id_curso);
                cmd.Parameters.AddWithValue("@nome", curso.nome);
                cmd.Parameters.AddWithValue("@actualizado_em", curso.actualizado_em);

                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show("Curso atualizado com sucesso \n", "CONFIRNMAÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar atualizar o curso no banco de dados" + Environment.NewLine
                    + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }
        }
        #endregion

        #region DELETE
        //###########################################################################################################################
        //######################################################## EXCLUIR ##########################################################
        public static void excluirCurso(CursoModel curso)
        {
            MySqlCommand cmd = null;
            MySqlConnection conn = null;
            try
            {
                conn = Conexao.GetMyConnection();
                conn.Open();

                string sql = "DELETE FROM tb_curso WHERE id_curso=?";
                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("id_curso", curso.id_curso);

                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show("Curso excluido com sucesso \n", "CONFIRNMAÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar excluir o curso no banco de dados" + Environment.NewLine
                      + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }
        }
        #endregion

        #region SELECT
        //#############################################################################################################################
        //######################################################## CONSULTAR ##########################################################
        public static List<CursoModel> getAll()
        {
            MySqlCommand cmd = null;
            MySqlConnection conn = null;
            MySqlDataReader reader = null;
            List<CursoModel> lista = new List<CursoModel>();

            try
            {
                conn = Conexao.GetMyConnection();
                conn.Open();

                string sql = "SELECT * FROM tb_curso";
                cmd = new MySqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CursoModel curso = new CursoModel();
                    curso.id_curso = int.Parse(reader["id_curso"].ToString());
                    curso.nome = reader["nome"].ToString();
                    curso.criado_em = DateTime.Parse(reader["criado_em"].ToString());
                    curso.actualizado_em = DateTime.Parse(reader["actualizado_em"].ToString());
                    lista.Add(curso);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar consultar o curso no banco de dados" + Environment.NewLine
                    + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                reader.Dispose();
            }
            return lista;
        }

        #endregion

        #region GET BY ID (CONSULTAR PELO ID)
        //#############################################################################################################################
        //################################################ CONSULTAR PELO ID ##########################################################
        public static CursoModel getById(int id)
        {
            MySqlCommand cmd = null;
            MySqlConnection conn = null;
            MySqlDataReader reader = null;
            CursoModel curso = null;
            try
            {
                conn = Conexao.GetMyConnection();
                conn.Open();
                string sql = "SELECT * FROM tb_curso WHERE id_curso=?";
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("id_curso", id);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    curso = new CursoModel();
                    curso.id_curso = int.Parse(reader["id_curso"].ToString());
                    curso.nome = reader["nome"].ToString();
                    curso.criado_em = DateTime.Parse(reader["criado_em"].ToString());
                    curso.actualizado_em = DateTime.Parse(reader["actualizado_em"].ToString());

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar consultar o curso pelo ID no banco de dados" + Environment.NewLine
                      + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                reader.Dispose();
            }
            return curso;

        }

        #endregion

        #region GET BY NAME (CONSULTA PELO NOME)
        public static CursoModel getByName(string nome)
        {
            MySqlCommand cmd = null;
            MySqlConnection conn = null;
            MySqlDataReader reader = null;
            CursoModel curso = null;
            try
            {
                conn = Conexao.GetMyConnection();
                conn.Open();
                string sql = "SELECT * FROM tb_curso WHERE nome=?";
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("nome", nome);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    curso = new CursoModel();
                    curso.id_curso = int.Parse(reader["id_curso"].ToString());
                    curso.nome = reader["nome"].ToString();
                    curso.criado_em = DateTime.Parse(reader["criado_em"].ToString());
                    curso.actualizado_em = DateTime.Parse(reader["actualizado_em"].ToString());

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar consultar o curso pelo NOME no banco de dados" + Environment.NewLine
                      + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                reader.Dispose();
            }
            return curso;

        }
        #endregion

    }
}
