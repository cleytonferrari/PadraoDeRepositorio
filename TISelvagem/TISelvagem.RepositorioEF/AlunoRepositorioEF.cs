using System;
using System.Collections.Generic;
using System.Linq;
using TISelvagem.Dominio;
using TISelvagem.Dominio.Contratos;

namespace TISelvagem.RepositorioEF
{
    public class AlunoRepositorioEF : IRepositorio<Aluno>
    {

        private readonly Contexto contexto;

        public AlunoRepositorioEF()
        {
            contexto = new Contexto();
        }

        public Aluno Salvar(Aluno entidade)
        {
            var alunoDto = GetAlunoDto(entidade);
            contexto.Alunos.Add(alunoDto);
            contexto.SaveChanges();
            return GetAluno(alunoDto);
        }

        public Aluno Alterar(Aluno entidade)
        {
            var alunoDto = GetAlunoDto(entidade);

            AlunoDTO alunoSalvar = contexto.Alunos.First(x => x.Id == alunoDto.Id);
            alunoSalvar.Nome = entidade.Nome;
            alunoSalvar.Mae = entidade.Mae;
            alunoSalvar.DataNascimento = entidade.DataNascimento;

            contexto.SaveChanges();
            return GetAluno(alunoDto);
        }

        public void Excluir(Aluno entidade)
        {
            var alunoDto = GetAlunoDto(entidade);
            AlunoDTO alunoExcluir = contexto.Alunos.First(x => x.Id == alunoDto.Id);
            contexto.Set<AlunoDTO>().Remove(alunoExcluir);
            contexto.SaveChanges();
        }

        public Aluno Buscar(string id)
        {
            int idInt;
            var resultado = Int32.TryParse(id, out idInt);

            var alunoDto = contexto.Alunos.First(x => x.Id == idInt);

            return GetAluno(alunoDto);
        }

        public IEnumerable<Aluno> BuscarTodos()
        {
            var listaDto = contexto.Alunos.ToList();
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
            int id;
            var resultado = Int32.TryParse(entidade.Id, out id);

            var alunoDto = new AlunoDTO
            {
                Id = id,
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
                Id = entidade.Id.ToString(),
                Nome = entidade.Nome,
                Mae = entidade.Mae,
                DataNascimento = entidade.DataNascimento
            };
            return aluno;
        }
    }
}
