namespace AulaPOOWhatsapp
{
    using System.Collections.Generic;
    public interface IAgenda
    {
        void Cadastrar (Contato contato);
        void Excluir (Contato c);
        List<Contato> Listar ();
    }
}