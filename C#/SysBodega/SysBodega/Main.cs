using MySql.Data.MySqlClient;
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

                    MySqlConnection conectar = new MySqlConnection("server=sysbodega.mysql.database.azure.com;database=bodega; Uid=sysadmin@sysbodega; pwd=admin123@;");
                    conectar.Open();

                    MySqlCommand Criar = new MySqlCommand();
                    Criar.Connection = conectar;
                    Criar.CommandText = "CREATE TABLE IF NOT EXISTS funcionario(id_fun integer not null primary key auto_increment, nome_fun varchar(30), idade_fun integer, salario_fun float)";
                    Criar.ExecuteNonQuery();
                    Criar.CommandText = "INSERT INTO funcionario (nome_fun, idade_fun, salario_fun) VALUES ('"
                        + nome + "','" + idadeFun + "' , '" + salarioFun + "')";
                    Criar.ExecuteNonQuery();
                    conectar.Close();
                    Console.WriteLine("\nO funcionário foi inserido com sucesso!\n");

                    Funcionario fun = new Funcionario(nome, numero, idadeFun, salarioFun);
                    bodegueiros.Add(fun);
                    numero++;
                }
                else if (opcao == 2) {
                    int id_fun;
                    int numFun;
                    

                    Console.WriteLine("Informe o código do funcionário desejado:");
                    String num = Console.ReadLine();
                    numFun = int.Parse(num);
                    MySqlConnection conectar = new MySqlConnection("server=sysbodega.mysql.database.azure.com;database=bodega; Uid=sysadmin@sysbodega; pwd=admin123@;");
                    conectar.Open();

                    MySqlCommand select = new MySqlCommand();
                    select.Connection = conectar;
                    select.CommandText = "SELECT * FROM funcionario ORDER BY id_fun";
                    select.Parameters.Clear();
                    select.Parameters.Add("@id_fun", MySqlDbType.Int32).Value = numFun;

                    select.CommandType = System.Data.CommandType.Text;

                    MySqlDataReader dr;
                    dr = select.ExecuteReader();
                    dr.Read();

                    Console.WriteLine("O id do funcionário é: " + dr.GetString(0));
                    Console.WriteLine("O nome do funcionário é: " + dr.GetString(1));
                    Console.WriteLine("A idade do funcionário é: " + dr.GetString(2));
                    Console.WriteLine("O salário do funcionário é: " + dr.GetString(3));

                    conectar.Close();

                    Console.WriteLine("\n");

                }
            } while (opcao != 9);

        }
    }
}
