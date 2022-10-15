using System;
using System.Data;

public class Program
{
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
                    
                    break;
                case "2":
                    
                    break;
                case "3":
                    
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

    private static void ListaDados()
    {
        Console.WriteLine("******************************");
        Console.WriteLine("*                            *");
        Console.WriteLine("*    Lista de usuarios       *");
        Console.WriteLine("*                            *");
        Console.WriteLine("******************************");


    }
}
