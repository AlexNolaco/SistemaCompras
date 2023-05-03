using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.SolicitacaoCompraAggregate.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class SolicitacaoCompra : Entity
    {
        public UsuarioSolicitante UsuarioSolicitante { get; private set; }
        public NomeFornecedor NomeFornecedor { get; private set; }
        public IList<Item> Itens { get; private set; }
        public DateTime Data { get; private set; }
        public Money TotalGeral { get; private set; }
        public Situacao Situacao { get; private set; }
        public CondicaoPagamento CondicaoPagamento { get; private set; }
        
        private SolicitacaoCompra() { }

        public SolicitacaoCompra(string usuarioSolicitante, string nomeFornecedor)
        {
            Id = Guid.NewGuid();
            UsuarioSolicitante = new UsuarioSolicitante(usuarioSolicitante);
            NomeFornecedor = new NomeFornecedor(nomeFornecedor);
            Data = DateTime.Now;
            Situacao = Situacao.Solicitado;
        }

        public void AdicionarItem(Produto produto, int qtde)
        {
            Itens.Add(new Item(produto, qtde));
        }
        
        public void RegistrarCompra(IEnumerable<Item> itens)
        {
           
        }

        public void VerificarCondicaoPagamentoTrintaDias()
        {
            if (TotalGeral.Value <= 50000)
                throw new BusinessRuleException("O Total geral é menor ou igual a 50000, a condição de pagamento não será de 30 dias");
            else
            {
                CondicaoPagamento = new CondicaoPagamento(30);
                AddEvent(new CondicaoPagamentoAtualizadaEvent(Guid.NewGuid(), CondicaoPagamento));
            }
        }

        public void VerificarItensCompraMaiorQueZero()
        {
            if (!Itens.Any())
                throw new BusinessRuleException("O total de itens de compra deve ser maior que 0");
        }
    }
}
