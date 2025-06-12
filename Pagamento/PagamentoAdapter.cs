
namespace PagamentoNamespace
{
    public class PagamentoAdapter : Pagamentos
    {
        private readonly PagamentoServico _servico;

        public PagamentoAdapter(PagamentoServico servico)
        {
            _servico = servico;
        }

        public void Pagar(string valor)
        {
            _servico.EfetuarPagamento(valor);
        }
    }
}