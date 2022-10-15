using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_pessoa.entidades
{
    public class Pessoa
    {
       private int Id { get; set; }
       private string Nome { get; set; }
       private string Cpf { get; set; }
       private  string DataNascimento { get; set; }

        public Pessoa(int id, string nome, string cpf, string dataNascimento)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
        }

        public Pessoa()
        {
          
        }
    }
}
