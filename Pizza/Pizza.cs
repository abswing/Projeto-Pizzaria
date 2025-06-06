
using System.Text;
using System.Collections;



namespace Pizza
{
    // class que representa uma pizza
    // Esta classe é abstrata, pois não deve ser instanciada diretamente
    public abstract class Pizza
    {
        protected string Nome { get; set; }
        protected string massa;
        protected string molho;
        protected ArrayList ingredientes = new ArrayList();

        // Metodo que prepara a pizza
        public string Preparar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Preparando a pizza" + Nome + "...");
            sb.AppendLine(massa + "\n");
            sb.AppendLine(molho + "\n");
            sb.AppendLine("Ingredientes:" + "\n");
            foreach (string ingrediente in ingredientes)
            {
                sb.AppendLine("\n" + ingrediente + "\n");
            }

            sb.AppendLine(Cozinhar());
            sb.AppendLine(Fatiar());
            sb.AppendLine(Embalar());
            return sb.ToString();
        }
        // Metodos que podem ser sobrescritos pelas subclasses

        // metodo que cozinha a pizza
        public virtual string Cozinhar() => "Cozinhando a pizza por 25 minutos a 180 graus. \n";
        // metodo que fatiar a pizza
        public virtual string Fatiar() => "Fatiando a pizza em 8 pedaços. \n";
        // metodo que embalar a pizza
        public virtual string Embalar() => "Embalando a pizza na caixa. \n";
    }
}
