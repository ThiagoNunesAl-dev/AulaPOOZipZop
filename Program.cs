using System;
using System.Collections.Generic;
namespace AulaPOOWhatsapp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Primeiro contato instanciado e adicionado.
            Contato contato1 = new Contato("Thiago", "(11)91111-1111");
            contato1.Cadastrar(contato1);

            //Segundo contato instanciado e adicionado.
            Contato contato2 = new Contato("Paulo", "(11)92222-2222");
            contato2.Cadastrar(contato2);

            //Terceiro contato instanciado e adicionado.
            Contato contato3 = new Contato("SENAI", "(11)93333-3333");
            contato3.Cadastrar(contato3);

            //Lista criada para facilitar a exibição dos dados no terminal.
            List<Contato> contatos = new List<Contato>();
            contatos = contato1.Listar();

            //A agenda é mostrada no terminal pela primeira vez.
            Console.WriteLine("Agenda: ");
            foreach (Contato c in contatos)
            {
                Console.WriteLine($"{c.Nome} - {c.Telefone}");
            }

            //O primeiro contato é excluído.
            contato1.Excluir("Thiago");

            //Uma nova lista atualizada é criada.
            List<Contato> contatos_atualizados = new List<Contato>();
            contatos_atualizados = contato1.Listar();

            //A agenda atualizada é mostrada no terminal.
            Console.WriteLine("\nAgenda atualizada: ");
            foreach (Contato c in contatos_atualizados)
            {
                Console.WriteLine($"{c.Nome} - {c.Telefone}");
            }

            //Chat:
            //O destinatário é escolhido, o texto é escrito e a mensagem é enviada.
            //O nome que aparece no terminal é pra imitar a interface do Whatsapp de um jeito bem bobo.            
            Mensagem m1 = new Mensagem(contato2.Nome, "eae mankkk");
            Console.WriteLine($"\n{contato2.Nome}");

            Console.WriteLine(m1.Enviar(m1));
        }
    }
}
