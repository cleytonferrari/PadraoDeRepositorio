using System.Collections.Generic;
using TISelvagem.Dominio;
using TISelvagem.Dominio.Contratos;

namespace TISelvagem.Aplicacao
{
    public class AlunoAplicacao
    {

        private readonly IRepositorio<Aluno> repositorio;

        public AlunoAplicacao(IRepositorio<Aluno> repo)
        {
            repositorio = repo;
        }

        private void Inserir(Aluno aluno)
        {
            repositorio.Salvar(aluno);
        }

        private void Alterar(Aluno aluno)
        {
            repositorio.Alterar(aluno);
        }

        public void Salvar(Aluno aluno)
        {
            if (aluno.Id > 0)
                Alterar(aluno);
            else
                Inserir(aluno);
        }

        public void Excluir(Aluno aluno)
        {
            repositorio.Excluir(aluno);
        }

        public IEnumerable<Aluno> ListarTodos()
        {
            return repositorio.BuscarTodos();
        }


    }
}
