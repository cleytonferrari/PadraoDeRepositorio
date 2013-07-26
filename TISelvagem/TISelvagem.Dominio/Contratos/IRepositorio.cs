using System;
using System.Collections.Generic;

namespace TISelvagem.Dominio.Contratos
{
    public interface IRepositorio<T> where T : class
    {
        T Salvar(T entidade);

        T Alterar(T entidade);

        void Excluir(T entidade);

        T Buscar(int id);

        IEnumerable<T> BuscarTodos();

        IEnumerable<T> BuscarPorFiltro(Func<T, bool> filtro);
    }
}
