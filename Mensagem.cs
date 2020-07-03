namespace AulaPOOWhatsapp
{
    public class Mensagem
    {
        public string Texto { get; set; }
        public string Destinatario { get; set; }

        /// <summary>
        /// Construtor de Mensagem.
        /// </summary>
        /// <param name="_destinatario">Destinatário da mensagem.</param>
        /// <param name="_texto">Texto da mensagem.</param>
        public Mensagem (string _destinatario, string _texto) {
            this.Destinatario = _destinatario;
            this.Texto = _texto;
        }

        /// <summary>
        /// Enviar a mensagem.
        /// </summary>
        /// <param name="m">Mensagem construída.</param>
        /// <returns>A mensagem.</returns>
        public string Enviar (Mensagem m) {
            return $"Mensagem enviada para {m.Destinatario}: {m.Texto}";
        }
    }
}