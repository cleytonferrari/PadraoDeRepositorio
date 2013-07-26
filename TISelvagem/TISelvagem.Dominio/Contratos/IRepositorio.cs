using System;
using System.Collections.Generic;

namespace TISelvagem.Dominio.Contratos
{
    public interface IRepositorio<T> where T : class
    {
        void Salvar(T entidade);

        void Alterar(T entidade);

        void Excluir(T entidade);

        T Buscar(int id);

        IEnumerable<T> BuscarTodos();

        IEnumerable<T> BuscarPorFiltro(Func<T, bool> filtro);
    }
}
