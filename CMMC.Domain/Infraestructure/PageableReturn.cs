using System.Collections.Generic;
using CMMC.Domain.Entities;

namespace CMMC.Domain.Infraestructure
{
    public class PageableReturn<TEntity> where TEntity : BasicEntity
    {
        public PageableReturn()
        {
            Itens = new List<TEntity>();
            Total = 0;
        }

        public PageableReturn(List<TEntity> itens, int total)
        {
            this.Itens = itens;
            this.Total = total;
        }

        public List<TEntity> Itens { get; set; }
        public int Total { get; set; }
    }
}