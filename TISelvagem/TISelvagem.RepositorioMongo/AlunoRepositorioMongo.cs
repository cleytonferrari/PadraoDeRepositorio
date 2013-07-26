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
        private readonly Contexto<AlunoDTO> contexto;

        public AlunoRepositorioMongo()
        {
            contexto = new Contexto<AlunoDTO>();
        }

        public Aluno Salvar(Aluno entidade)
        {
            var alunoDto = GetAlunoDto(entidade);
            contexto.Collection.Save(alunoDto);
            return GetAluno(alunoDto);
        }

        public Aluno Alterar(Aluno entidade)
        {
            var alunoDto = GetAlunoDto(entidade);
            contexto.Collection.Save(alunoDto);
            return GetAluno(alunoDto);
        }

        public void Excluir(Aluno entidade)
        {
            //contexto.Collection.Remove(Query.EQ("_id", new ObjectId(entidade.Id)));
        }

        public Aluno Buscar(string id)
        {
            var alunoDto = contexto.Collection.AsQueryable().FirstOrDefault(x => x.Id == id);

            return GetAluno(alunoDto);
        }

        public IEnumerable<Aluno> BuscarTodos()
        {
            var listaDto = contexto.Collection.AsQueryable().ToList();
            foreach (var alunoDTO in listaDto)
            {
                var aluno = GetAluno(alunoDTO);
                yield return aluno;
            }
        }

        public IEnumerable<Aluno> BuscarPorFiltro(Func<Aluno, bool> filtro)
        {
            throw new NotImplementedException();
        }

        private static AlunoDTO GetAlunoDto(Aluno entidade)
        {
            var alunoDto = new AlunoDTO
            {
                Id = entidade.Id,
                Nome = entidade.Nome,
                Mae = entidade.Mae,
                DataNascimento = entidade.DataNascimento
            };
            return alunoDto;
        }

        private static Aluno GetAluno(AlunoDTO entidade)
        {
            var aluno = new Aluno
            {
                Id = entidade.Id,
                Nome = entidade.Nome,
                Mae = entidade.Mae,
                DataNascimento = entidade.DataNascimento
            };
            return aluno;
        }
    }
}
