using SistemaCompra.Domain.Core;
using System;
using System.Collections.Generic;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate.Events
{
    public class CondicaoPagamentoAtualizadaEvent : Event
    {
        public Guid Id { get; }
        public CondicaoPagamento CondicaoPagamento { get; }

        public CondicaoPagamentoAtualizadaEvent(Guid id, CondicaoPagamento condicaoPagamento)
        {
            Id = id;
            this.CondicaoPagamento = condicaoPagamento;
        }
    }
}
