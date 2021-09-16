using System;
using System.Collections.Generic;

namespace SysBodega {
    class Mae {
        static void Main(string[] args) {
            String nome;
            int numero = 0;
            int opt;
            int opcao;
            String idadeFun;
            Double salarioFun;
            int codCliente = 0;
            int codigoDrink = 0;

            List<Funcionario> bodegueiros = new List<Funcionario>();
            List<Bebida> bebidas = new List<Bebida>();
            List<Cliente> clientes = new List<Cliente>();

            Console.WriteLine("Seja muito bem-vindo ao sistema da Bodega do Juaum!");
            Console.WriteLine("Informe o que você quer fazer: \n1 - Criar funcionário \n2 - Listar Funcionários \n3 - Adicionar bebida \n4 - Listar bebidas \n5 - Comprar bebida \n6 - Vender bebida \n7 - Adicionar cliente \n8 - Listar clientes \n9 - Sair");
            opt = Console.ReadLine();

            if(opt == 1) {

            }




        }
    }
}
