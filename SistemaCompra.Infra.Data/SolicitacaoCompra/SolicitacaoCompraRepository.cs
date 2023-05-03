using System;
using System.Linq;
using SolicitacaoCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
    public class SolicitacaoCompraRepository : SolicitacaoCompraAgg.ISolicitacaoCompraRepository
    {
        private readonly SistemaCompraContext context;

        public SolicitacaoCompraRepository(SistemaCompraContext context)  {
            this.context = context;
        }

        public void Atualizar(SolicitacaoCompraAgg.SolicitacaoCompra entity)
        {
            context.Set<SolicitacaoCompraAgg.SolicitacaoCompra>().Update(entity);
        }

        public void Excluir(SolicitacaoCompraAgg.SolicitacaoCompra entity)
        {
            context.Set<SolicitacaoCompraAgg.SolicitacaoCompra>().Remove(entity);
        }

        public SolicitacaoCompraAgg.SolicitacaoCompra Obter(Guid id)
        {
            return context.Set<SolicitacaoCompraAgg.SolicitacaoCompra>().Where(c=> c.Id == id).FirstOrDefault();
        }

        public void RegistrarCompra(SolicitacaoCompraAgg.SolicitacaoCompra solicitacaoCompra)
        {
            context.Set<SolicitacaoCompraAgg.SolicitacaoCompra>().Add(solicitacaoCompra);
        }
    }
}
