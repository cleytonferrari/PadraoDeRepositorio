using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TISelvagem.Dominio;
using TISelvagem.Dominio.Contratos;
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
    }
}
