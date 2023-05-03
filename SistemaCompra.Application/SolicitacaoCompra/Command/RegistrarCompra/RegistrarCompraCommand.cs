using MediatR;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommand : IRequest<bool>
    {
        public string Nome { get; set; }
        public string NomeFornecedor { get; set; }
    }
}
