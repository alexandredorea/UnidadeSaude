using System.Collections.Generic;

namespace AMcom.Teste.DAL.Interfaces.Base
{
    public interface IRepositoryBase<TipoEntidade> where TipoEntidade : class
    {
        IEnumerable<TipoEntidade> Selecionar();
        TipoEntidade Selecionar(int id);
        void Inserir(TipoEntidade objeto);
        void Atualizar(TipoEntidade objeto);
        void Remover(TipoEntidade objeto);
        void Remover(int id);
    }
}
