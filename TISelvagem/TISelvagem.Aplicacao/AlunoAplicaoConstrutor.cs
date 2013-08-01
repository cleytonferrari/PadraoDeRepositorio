using TISelvagem.RepositorioEF;
using TISelvagem.RepositorioMongo;
using TiSelvagem.Repositorio;

namespace TISelvagem.Aplicacao
{
    public class AlunoAplicaoConstrutor
    {
        public static AlunoAplicacao AlunoAplicacaoMongo()
        {
            return new AlunoAplicacao(new AlunoRepositorioMongo());
        }

        public static AlunoAplicacao AlunoAplicacaoADO()
        {
            return new AlunoAplicacao(new AlunoRepositorioADO());
        }

        public static AlunoAplicacao AlunoAplicacaoEF()
        {
            return new AlunoAplicacao(new AlunoRepositorioEF());
        }
    }
}
