using AMcom.Teste.DAL.ContextoBanco.Banco;
using AMcom.Teste.DAL.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AMcom.Teste.DAL.Repositorios.Base
{
    public class RepositoryBase<TipoEntidade> : IRepositoryBase<TipoEntidade> where TipoEntidade : class
    {
        protected readonly ContextAmcom Context;
        protected readonly DbSet<TipoEntidade> Set;

        public RepositoryBase(ContextAmcom context)
        {
            Context = context;
            Set = Context.Set<TipoEntidade>();
        }

        public void Atualizar(TipoEntidade objeto)
        {
            Set.Update(objeto);
        }

        public void Inserir(TipoEntidade objeto)
        {
            Set.Add(objeto);
        }

        public void Remover(TipoEntidade objeto)
        {
            Set.Remove(objeto);
        }

        public void Remover(int id)
        {
            Set.Remove(this.Selecionar(id));
        }

        public IEnumerable<TipoEntidade> Selecionar()
        {
            return Set.ToList();
        }

        public TipoEntidade Selecionar(int id)
        {
            return Set.Find(id);
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}