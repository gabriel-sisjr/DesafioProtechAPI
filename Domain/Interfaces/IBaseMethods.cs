using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IBaseMethods<T>
    {
        T Inserir(T objeto);
        T Atualizar(T objeto);
        bool Excluir(T objeto);
        List<T> ObterTodos();
        T ObterPorId(int id);
    }
}
