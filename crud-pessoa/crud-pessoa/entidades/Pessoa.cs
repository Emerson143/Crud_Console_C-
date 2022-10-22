using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_pessoa.entidades
{
    public class Pessoa
    {
       public int Id { get; set; }
       public string Nome { get; set; }
       public string Cpf { get; set; }
       public  string DataNascimento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public Pessoa(int id, string nome, string cpf, string dataNascimento, string email, string telefone)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Email = email;
            Telefone = telefone;
        }

        public Pessoa()
        {
          
        }
        public Pessoa(string nome)
        {
            Console.WriteLine(nome);
        }
    }
}
