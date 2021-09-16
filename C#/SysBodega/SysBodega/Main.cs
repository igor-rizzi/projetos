using System;
using System.Collections.Generic;

namespace SysBodega {
    class Mae {
        static void Main(string[] args) {
            String nome;
            int numero = 0;
            String opt;
            int opcao;
            int idadeFun;
            Double salarioFun;
            int codCliente = 0;
            int codigoDrink = 0;

            List<Funcionario> bodegueiros = new List<Funcionario>();
            List<Bebida> bebidas = new List<Bebida>();
            List<Cliente> clientes = new List<Cliente>();

            Console.WriteLine("Seja muito bem-vindo ao sistema da Bodega do Juaum!");
            do {
                Console.WriteLine("Informe o que você quer fazer: \n1 - Criar funcionário \n2 - Listar Funcionários \n3 - Adicionar bebida \n4 - Listar bebidas \n5 - Comprar bebida \n6 - Vender bebida \n7 - Adicionar cliente \n8 - Listar clientes \n9 - Sair");
                opt = Console.ReadLine();
                opcao = int.Parse(opt);

                if (opcao == 1) {
                    Console.WriteLine("Informe o nome do funcionário:");
                    nome = Console.ReadLine();
                    Console.WriteLine("Informe a idade do funcionário:");
                    String idade = Console.ReadLine();
                    idadeFun = int.Parse(idade);
                    Console.WriteLine("Informe o salário do funcionário:");
                    String salario = Console.ReadLine();
                    salarioFun = double.Parse(salario);

                    Funcionario fun = new Funcionario(nome, numero, idadeFun, salarioFun);
                    bodegueiros.Add(fun);
                    numero++;
                }
                else if (opcao == 2) {
                    foreach (Funcionario bb in bodegueiros) {
                        Console.WriteLine("O nome do funcionario é:", bb.nomeFun);
                    }


                }
            } while (opcao != 9);

        }
    }
}
