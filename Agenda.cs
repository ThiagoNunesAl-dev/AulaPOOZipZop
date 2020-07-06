using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

namespace AulaPOOWhatsapp
{
    public class Agenda : IAgenda
    {
        //É criado o caminho para a pasta csv.
        public const string Path = "Database/Agenda.csv";

        /// <summary>
        /// Se não existir o documento csv que represente uma agenda, ele é criado automaticamente.
        /// </summary>
        public Agenda () {
            if (!File.Exists(Path)) {
                File.Create(Path).Close();
            }
        }

        /// <summary>
        /// Prepara uma linha no formato csv.
        /// </summary>
        /// <param name="contato">Contato da agenda.</param>
        /// <returns>Linha no formato csv com nome e telefone.</returns>
        public string PrepararLinhaCSV (Contato contato) {
            return $"Nome:{contato.Nome};Telefone:{contato.Telefone}";
        }

        /// <summary>
        /// Insere o novo contato na agenda.
        /// </summary>
        /// <param name="contato">Contato com nome e telefone já descritos.</param>
        public void Cadastrar(Contato contato)
        {
            //Transforma a linha em uma lista de strings, com o intuito de facilitar a manipulação da agenda.
            string[] linha = new string[] {PrepararLinhaCSV(contato)};
            //Acrescenta ao documento csv as linhas já preparadas, por meio do caminho estabelecido (Path).
            File.AppendAllLines(Path, linha);
        }

        /// <summary>
        /// Separa as instâncias da classe "Contato" de seus enunciados.
        /// </summary>
        /// <param name="qualquer">Qualquer string.</param>
        /// <returns>Instâncias da classe "Contato" (nome e/ou telefone) sem seus enunciados.</returns>
        public string Separar (string qualquer) {
            //Esse método é importante para mostrar as informações da agenda no terminal.
            return qualquer.Split(":")[1];
        }

        /// <summary>
        /// Lista os contatos no terminal.
        /// </summary>
        /// <returns>A lista de contatos preenchida.</returns>
        public List<Contato> Listar()
        {
            //É criada a lista de contatos vazia.
            List<Contato> contatos = new List<Contato>();
            //As linhas criadas são transformadas em um array de strings.
            string[] linhas = File.ReadAllLines(Path);

            //O array é varrido.
            foreach (var linha in linhas)
            {
                //A linha preparada tem seus componentes separados.
                string[] dados = linha.Split(";");

                //As informações instanciadas são separadas de cada componente da linha preparada.
                Contato c = new Contato(Separar(dados[0]), Separar(dados[1]));

                //Cada informação instanciada é colocada na lista vazia.
                contatos.Add(c);
            } 

            //A nova lista preenchida é retornada.
            return contatos;
        }

        public void Excluir(Contato c)
        {
            //Cria-se uma lista de itens para servir como "backup".
            List<string> linhasBackup = new List<string>();

            //O arquivo é aberto e lido.
            using(StreamReader file = new StreamReader (Path)) {
                string linhaBackup;
                while ((linhaBackup = file.ReadLine()) != null) {
                    linhasBackup.Add(linhaBackup);
                }
                //São removidos os itens da linha que contém as informações do objeto dado como argumento.
                linhasBackup.RemoveAll(l => l.Contains(c.Nome));
            }
            //O arquivo agora é reescrito, sem o item removido.
            using (StreamWriter output = new StreamWriter(Path)) {
                output.Write(String.Join(Environment.NewLine, linhasBackup.ToArray()));
            }
        }

    }
}