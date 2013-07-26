using System.Collections.Generic;
using TISelvagem.Dominio;
using TISelvagem.Dominio.Contratos;
using TiSelvagem.Repositorio;

namespace TISelvagem.Aplicacao
{
    public class AlunoAplicacao
    {

        private readonly IRepositorio<Aluno> repositorio;

        public AlunoAplicacao()
        {
            repositorio = new AlunoRepositorioADO();
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
