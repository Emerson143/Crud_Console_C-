using crud_pessoa.entidades;
using crud_pessoa.util;
using MySqlConnector;
using System;
using System.Data;
using System.Linq;

public class Program
{

    public static List<int> _listaId;


    static void Main(string[] args)
    {
        

        MenuPrincipal();

    }

    private static void MenuPrincipal()
    {
        Console.WriteLine("******************************");
        Console.WriteLine("*                            *");
        Console.WriteLine("*         BEM-VINDO          *");
        Console.WriteLine("*                            *");
        Console.WriteLine("******************************");

        bool sair = false;
        Console.WriteLine("1 - Cadastra novo usuario.");
        Console.WriteLine("2 - Atualizar dados do usuario.");
        Console.WriteLine("3 - deletar usuario.");
        Console.WriteLine("4 - visualizar usuario.");
        
        do { 
            Console.Write("Digite sua opção:");
            var resposta = Console.ReadLine();
            sair = false;
            switch (resposta)
            {
                case "1":
                    AdicionarDados();
                    break;
                case "2":
                    AtualizarDados();
                    break;
                case "3":
                    DeletaDados();
                    break;
                case "4":
                    VisualizarDados();
                    break;
                default:
                    sair = true;
                    Console.WriteLine("Opção invalida, Digite novamente...");
                    break;

            }
        } while (sair);


    }

    private static void VisualizarDados()
    {
        ListaDados();
        bool sair = false;

        
        Console.WriteLine("1 - Voltar ao menu principal.");
        do
        {
            Console.Write("Digite sua opção:");
            var resposta = Console.ReadLine();
            sair = false;
            switch (resposta)
            {
                case "1":
                    Console.Clear();
                    MenuPrincipal();
                    break;

                default:
                    sair = true;
                    Console.WriteLine("Opção invalida, Digite novamente...");
                    break;

            }
        } while (sair);
    }

    private static void ListaDados() // read
    {
        Console.Clear();
        Console.WriteLine("******************************");
        Console.WriteLine("*                            *");
        Console.WriteLine("*    Lista de usuarios       *");
        Console.WriteLine("*                            *");
        Console.WriteLine("******************************");
        Console.WriteLine();

        MySqlCommand Query = new MySqlCommand(); // dar o comando
        Query.Connection = Conexao._connection;
        Conexao._connection.Open();//Abre conexão

        Query.CommandText = @"SELECT id, nome, cpf, dataNascimento, email, telefone FROM tb_usuario order by id asc";
        MySqlDataReader dtreader = Query.ExecuteReader();//Crie um objeto do tipo reader para ler os dados do banco

        Console.WriteLine("*********************************************");
        Console.WriteLine("ID - NOME - CPF - DATA DE NASCIMENTO - EMAIL - TELEFONE");
        Console.WriteLine();
        // _listaId = null;
        List<int>listaId = new List<int>();
        while (dtreader.Read())//Enquanto existir dados no select 
        {

            var id = dtreader["id"].ToString();//Preenche objeto do tipo pessoa com dados vindo do banco de dados
            var nome = dtreader["nome"].ToString();
            var cpf = dtreader["cpf"].ToString();
            var dataNascimento = dtreader["dataNascimento"].ToString();
            var email = dtreader["email"].ToString();
            var telefone = dtreader["telefone"].ToString();
            listaId.Add(Convert.ToInt32(id));
            Console.WriteLine(id +" - " + nome + " - " + cpf+ " - " + dataNascimento+ " - " + email+ " - "+ telefone);
           
        }
        _listaId = listaId;
        Console.WriteLine();
        Console.WriteLine("*********************************************");
        Console.WriteLine();
        Conexao._connection.Close();//Fecha Conexao

    }

    private static void AdicionarDados() // insert
    {
        Console.Clear();
        Console.WriteLine("******************************");
        Console.WriteLine("*                            *");
        Console.WriteLine("*    Adicionar usuarios      *");
        Console.WriteLine("*                            *");
        Console.WriteLine("******************************");
        Console.WriteLine();
        Console.Write("Digite o nome: ");
        var nome = Console.ReadLine();
        Console.Write("Digite o cpf: ");
        var cpf = Console.ReadLine();
        Console.Write("Digite sua data de nascimento: ");
        var data = Console.ReadLine();
        Console.Write("Digite o seu email: ");
        var email = Console.ReadLine();
        Console.Write("Digite o seu telefone ");
        var telefone = Console.ReadLine();

        Conexao._connection.Open();//Abre conexão
        MySqlCommand comm = Conexao._connection.CreateCommand();

        comm.CommandText = "INSERT INTO tb_usuario (nome, cpf, dataNascimento,email, telefone) " +
            "VALUES(@nome, @cpf, @dataNascimento, @email, @telefone)";// inserindo os dados as variaveis
        comm.Parameters.AddWithValue("@nome", nome);
        comm.Parameters.AddWithValue("@cpf", cpf);
        comm.Parameters.AddWithValue("@dataNascimento", data);
        comm.Parameters.AddWithValue("@email", email);
        comm.Parameters.AddWithValue("@telefone", telefone);
        comm.ExecuteNonQuery();// executa o comando 
        Console.Clear();

        Conexao._connection.Close();//Fecha Conexao
        MenuPrincipal();
    }
    private static void DeletaDados()//Deleta dados
    {
        Console.Clear();
        Console.WriteLine("******************************");
        Console.WriteLine("*                            *");
        Console.WriteLine("*    Deletar usuarios        *");
        Console.WriteLine("*                            *");
        Console.WriteLine("******************************");
        Console.WriteLine();
        ListaDados();

        

        bool sair;
        do
        {
            Console.Write("Digite o ID que deseja deletar: ");
            var idResposta = Convert.ToInt32(Console.ReadLine());
            sair = false;
            if 
                (_listaId.Contains(idResposta))

            {

                Conexao._connection.Open();//Abre conexão
                MySqlCommand comm = Conexao._connection.CreateCommand();

                comm.CommandText = "DELETE FROM tb_usuario where id = " + idResposta.ToString();// deletando os dados no Mysql
               
                comm.ExecuteNonQuery();// executa o comando 
                Console.Clear();

                Conexao._connection.Close();//Fecha Conexao
                MenuPrincipal();
            }
            else 
            {
                sair = true;
                Console.WriteLine("opção invalida, digite novamente: ");
            }

        }while(sair);


        
    }       
    private static void AtualizarDados()//atualizar dados
    {
        Console.Clear();
        Console.WriteLine("******************************");
        Console.WriteLine("*                            *");
        Console.WriteLine("*    Atualizar usuarios      *");
        Console.WriteLine("*                            *");
        Console.WriteLine("******************************");
        Console.WriteLine();
        ListaDados();



        bool sair;
        do
        {
            Console.Write("Digite o ID que deseja atualizar: ");
            var idResposta = Convert.ToInt32(Console.ReadLine());
            sair = false;
            if
                (_listaId.Contains(idResposta))

            {
                Console.WriteLine();
                Console.Write("Digite o nome: ");
                var nome = Console.ReadLine();
                Console.Write("Digite o cpf: ");
                var cpf = Console.ReadLine();
                Console.Write("Digite sua data de nascimento: ");
                var data = Console.ReadLine();
                Console.Write("Digite o seu email: ");
                var email = Console.ReadLine();
                Console.Write("Digite o seu telefone: ");
                var telefone = Console.ReadLine();

                Conexao._connection.Open();//Abre conexão
                MySqlCommand comm = Conexao._connection.CreateCommand(); // comandos para o mtsql

                comm.CommandText = "UPDATE tb_usuario set " +   // inserindo os dados as variaveis
                    " nome = @nome," +
                    " cpf = @cpf," +
                    " dataNascimento = @dataNascimento," +
                    " email = @email" +
                    " telefone = @telefone"+
                    " where id =  " + idResposta.ToString(); // where vai procurar o id que desejo atualizar
                 
                comm.Parameters.AddWithValue("@nome", nome);
                comm.Parameters.AddWithValue("@cpf", cpf);
                comm.Parameters.AddWithValue("@dataNascimento", data);
                comm.Parameters.AddWithValue("@email", email);
                comm.Parameters.AddWithValue("@telefone", email);
                comm.ExecuteNonQuery(); // executa o comando 
                Conexao._connection.Close();//Fecha Conexao
                Console.Clear();
                MenuPrincipal();

            }
            else
            {
                sair = true;
                Console.WriteLine("opção invalida, digite novamente: ");
            }

        } while (sair);
    }
}
