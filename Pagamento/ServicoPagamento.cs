namespace PagamentoNamespace
{
    public class PagamentoServico
    {
        public virtual void EfetuarPagamento(string quantia)
        {
            Console.WriteLine($"Pagamento de {quantia} efetuado com sucesso.");
        }
    }
}