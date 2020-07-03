namespace AulaPOOWhatsapp
{
    public class Contato : Agenda
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }

        /// <summary>
        /// Construtor de Contato.
        /// </summary>
        /// <param name="_nome">Nome.</param>
        /// <param name="_telefone">Telefone.</param>
        public Contato (string _nome, string _telefone) {
            this.Nome = _nome;
            this.Telefone = _telefone;
        }
    }
}