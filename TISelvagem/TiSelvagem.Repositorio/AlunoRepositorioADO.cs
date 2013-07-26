using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TISelvagem.Dominio;
using TISelvagem.Dominio.Contratos;

namespace TiSelvagem.Repositorio
{
    public class AlunoRepositorioADO:IRepositorio<Aluno>
    {
        private Contexto contexto;

        public Aluno Salvar(Aluno entidade)
        {
            var strQuery = "";
            strQuery += " INSERT INTO ALUNO (Nome, Mae, DataNascimento) ";
            strQuery += string.Format(" VALUES ('{0}','{1}','{2}') ",
                entidade.Nome, entidade.Mae, entidade.DataNascimento
                );
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
            entidade.Id = "0"; //Pegar o id que foi gerado e retornar
            return entidade;
        }

        public Aluno Alterar(Aluno entidade)
        {
            var strQuery = "";
            strQuery += " UPDATE ALUNO SET ";
            strQuery += string.Format(" Nome = '{0}', ", entidade.Nome);
            strQuery += string.Format(" Mae = '{0}', ", entidade.Mae);
            strQuery += string.Format(" DataNascimento = '{0}' ", entidade.DataNascimento);
            strQuery += string.Format(" WHERE AlunoId = {0} ", entidade.Id);
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }

            return entidade;
        }

        public void Excluir(Aluno entidade)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" DELETE FROM ALUNO WHERE AlunoId = {0}", entidade.Id);
                contexto.ExecutaComando(strQuery);
            }
        }

        public Aluno Buscar(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Aluno> BuscarTodos()
        {
            using (contexto = new Contexto())
            {
                var strQuery = " SELECT * FROM ALUNO ";
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader);
            }
        }

        public IEnumerable<Aluno> BuscarPorFiltro(Func<Aluno, bool> filtro)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Aluno> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var alunos = new List<Aluno>();
            while (reader.Read())
            {
                var temObjeto = new Aluno()
                {
                    Id = reader["AlunoId"].ToString(),
                    Nome = reader["Nome"].ToString(),
                    Mae = reader["Mae"].ToString(),
                    DataNascimento = DateTime.Parse(reader["DataNascimento"].ToString())
                };
                alunos.Add(temObjeto);
            }
            reader.Close();
            return alunos;
        }
    }
}
