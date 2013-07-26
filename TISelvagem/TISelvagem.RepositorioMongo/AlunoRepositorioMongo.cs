using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver.Linq;
using TISelvagem.Dominio;
using TISelvagem.Dominio.Contratos;

namespace TISelvagem.RepositorioMongo
{
    public class AlunoRepositorioMongo : IRepositorio<Aluno>
    {
        private readonly Contexto<Aluno> contexto;

        public AlunoRepositorioMongo()
        {
            contexto = new Contexto<Aluno>();
        }

        public Aluno Salvar(Aluno entidade)
        {
            contexto.Collection.Save(entidade);
            return entidade;
        }

        public Aluno Alterar(Aluno entidade)
        {
            contexto.Collection.Save(entidade);
            return entidade;
        }

        public void Excluir(Aluno entidade)
        {
            //contexto.Collection.Remove(Query.EQ("_id", new ObjectId(entidade.Id)));
        }

        public Aluno Buscar(int id)
        {
            return contexto.Collection.AsQueryable().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Aluno> BuscarTodos()
        {
            return contexto.Collection.AsQueryable();
        }

        public IEnumerable<Aluno> BuscarPorFiltro(Func<Aluno, bool> filtro)
        {
            throw new NotImplementedException();
        }
    }
}
