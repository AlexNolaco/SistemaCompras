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
        
        public void RegistrarCompra(List<Item> itens)
        {
            Itens = new List<Item>();
            AdicionarItem(new Produto("vassoura", "vassoura", "Madeira", 20), 10);
        }

        public void ObterTotalGeral() {
            decimal soma = 0;
            foreach (var item in Itens)
                soma += item.Subtotal.Value;
            TotalGeral = new Money(soma);
        }

        public void VerificarCondicaoPagamentoTrintaDias()
        {
            ObterTotalGeral();
            if (TotalGeral.Value > 50000)
            {
                CondicaoPagamento = new CondicaoPagamento(30);
                AddEvent(new CondicaoPagamentoAtualizadaEvent(Guid.NewGuid(), CondicaoPagamento));
            }
        }

        public void VerificarItensCompraMaiorQueZero()
        {
            if (Itens == null || !Itens.Any())
                throw new BusinessRuleException("O total de itens de compra deve ser maior que 0");
        }
    }
}
