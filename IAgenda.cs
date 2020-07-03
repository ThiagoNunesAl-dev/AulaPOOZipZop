namespace AulaPOOWhatsapp
{
    using System.Collections.Generic;
    public interface IAgenda
    {
        void Cadastrar (Contato contato);
        void Excluir (string _termo);
        List<Contato> Listar ();
    }
}