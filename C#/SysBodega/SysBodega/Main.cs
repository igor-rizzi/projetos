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

                } else if(opcao == 3) {
                    Console.WriteLine("Informe o nome da bebida:");
                    String nomeDrink = Console.ReadLine();
                    Console.WriteLine("Informe o teor alcóolico da bebida:");
                    String teor = Console.ReadLine();
                    Double teorAlcool = double.Parse(teor);
                    Console.WriteLine("Informe quantos Mls tem a bebida:");
                    String miliLitro = Console.ReadLine();
                    Double ml = double.Parse(miliLitro);
                    Console.WriteLine("Informe o preço da bebida:");
                    String price = Console.ReadLine();
                    double preco = double.Parse(price);

                    MySqlConnection conectar = new MySqlConnection("server=sysbodega.mysql.database.azure.com;database=bodega; Uid=sysadmin@sysbodega; pwd=admin123@;");
                    conectar.Open();

                    MySqlCommand Criar = new MySqlCommand();
                    Criar.Connection = conectar;
                    Criar.CommandText = "CREATE TABLE IF NOT EXISTS bebida(cod_drink integer not null primary key auto_increment, nome_bebida varchar(30), teor_alcoolico float, preco_bebida float, ml_bebida float, quatidade_bebida integer)";
                    Criar.ExecuteNonQuery();
                    Criar.CommandText = "INSERT INTO bebida(nome_bebida, teor_alcoolico, preco_bebida, ml_bebida) VALUES ('"
                        + nomeDrink + "','" + teorAlcool + "' , '" + preco + "' , '" + ml + "')";
                    Criar.ExecuteNonQuery();
                    conectar.Close();
                    Console.WriteLine("\nA bebida foi inserida com sucesso!\n");

                    Bebida drink = new Bebida(nomeDrink, codigoDrink, teorAlcool, ml, preco);
                    bebidas.Add(drink);
                    numero++;

                    Console.WriteLine("\n");

                } else if(opcao == 4) {
                    int id_fun;
                    int numBeb;

                    Console.WriteLine("\nInforme o código da bebida desejada:");
                    String num = Console.ReadLine();
                    numBeb = int.Parse(num);
                    MySqlConnection conectar = new MySqlConnection("server=sysbodega.mysql.database.azure.com;database=bodega; Uid=sysadmin@sysbodega; pwd=admin123@;");
                    conectar.Open();

                    MySqlCommand select = new MySqlCommand();
                    select.Connection = conectar;
                    select.CommandText = "SELECT * FROM bebida ORDER BY cod_drink";
                    select.Parameters.Clear();
                    select.Parameters.Add("@cod_drink", MySqlDbType.Int32).Value = numBeb;

                    select.CommandType = System.Data.CommandType.Text;

                    MySqlDataReader dr;
                    dr = select.ExecuteReader();
                    dr.Read();

                    Console.WriteLine("O código da bebida é: " + dr.GetString(0));
                    Console.WriteLine("O nome da bebida é: " + dr.GetString(1));
                    Console.WriteLine("O teor alcoolico da bebida é: " + dr.GetString(2));
                    Console.WriteLine("A quantidade em MLs é: " + dr.GetString(3));
                    Console.WriteLine("O preço da bebida é: " + dr.GetString(4));

                    conectar.Close();

                    Console.WriteLine("\n");
                } else if(opcao == 5) {
                    Console.WriteLine("Informe qual a bebida para ser comprada:");
                    String indice = Console.ReadLine();
                    int numBeb = int.Parse(indice);

                    Console.WriteLine("\nInforme a quantidade de compra:");
                    String qtd = Console.ReadLine();
                    int quantit = int.Parse(qtd);

                    MySqlConnection conect = new MySqlConnection("server=sysbodega.mysql.database.azure.com;database=bodega; Uid=sysadmin@sysbodega; pwd=admin123@;");
                    conect.Open();

                    MySqlCommand select = new MySqlCommand();
                    select.Connection = conect;
                    select.CommandText = "SELECT * FROM bebida ORDER BY cod_drink";
                    select.Parameters.Clear();
                    select.Parameters.Add("@cod_drink", MySqlDbType.Int32).Value = numBeb;

                    select.CommandType = System.Data.CommandType.Text;

                    MySqlDataReader dr;
                    dr = select.ExecuteReader();
                    dr.Read();
                    
                    Bebida bebi = new Bebida(dr.GetString("nome_bebida"), dr.GetInt16("cod_drink"), dr.GetDouble("teor_alcoolico"), dr.GetDouble("preco_bebida"), dr.GetDouble("ml_bebida"));

                    int quantidade = dr.GetInt32("quantidade") + quantit;
                    bebi.comprar(quantidade);

                    conect.Close();

                    double qtdEstoque = bebi.getQtd();

                    MySqlConnection conectar = new MySqlConnection("server=sysbodega.mysql.database.azure.com;database=bodega; Uid=sysadmin@sysbodega; pwd=admin123@;");
                    conectar.Open();

                    MySqlCommand update = new MySqlCommand();
                    update.Connection = conectar;

                    update.CommandText = "UPDATE bebida SET quantidade = @quantidade WHERE cod_drink = @numBeb";
                    update.Parameters.AddWithValue("@quantidade", qtdEstoque);
                    update.Parameters.AddWithValue("@numBeb", numBeb);


                    update.ExecuteNonQuery();

                    conectar.Close();

                    Console.WriteLine("\n");
                }else if(opcao == 6) { 

                    Console.WriteLine("Informe qual a bebida para ser vendida:");
                    String indice = Console.ReadLine();
                    int numBeb = int.Parse(indice);

                   
                    Console.WriteLine("\nInforme a quantidade de venda:");
                    String qtd = Console.ReadLine();
                    int quantidade = int.Parse(qtd);

                    MySqlConnection conect = new MySqlConnection("server=sysbodega.mysql.database.azure.com;database=bodega; Uid=sysadmin@sysbodega; pwd=admin123@;");
                    conect.Open();

                    MySqlCommand select = new MySqlCommand();
                    select.Connection = conect;
                    select.CommandText = "SELECT * FROM bebida ORDER BY cod_drink";
                    select.Parameters.Clear();
                    select.Parameters.Add("@cod_drink", MySqlDbType.Int32).Value = numBeb;

                    select.CommandType = System.Data.CommandType.Text;

                    MySqlDataReader dr;
                    dr = select.ExecuteReader();
                    dr.Read();

                    int quanti = dr.GetInt32("quantidade");
                    Bebida bebid = new Bebida(dr.GetString("nome_bebida"), dr.GetInt16("cod_drink"), dr.GetDouble("teor_alcoolico"), dr.GetDouble("preco_bebida"), dr.GetDouble("ml_bebida"));

                    bebid.setQtd(quanti);
                    conect.Close();

                    bebid.vender(quantidade);

                    double qtdEstoque = bebid.getQtd();

                    MySqlConnection conectar = new MySqlConnection("server=sysbodega.mysql.database.azure.com;database=bodega; Uid=sysadmin@sysbodega; pwd=admin123@;");
                    conectar.Open();

                    MySqlCommand update = new MySqlCommand();
                    update.Connection = conectar;

                    update.CommandText = "UPDATE bebida SET quantidade = @quantidade WHERE cod_drink = @numBeb";
                    update.Parameters.AddWithValue("@quantidade", qtdEstoque);
                    update.Parameters.AddWithValue("@numBeb", numBeb);

                    update.ExecuteNonQuery();

                    conectar.Close();

                    Console.WriteLine("\n");
                }
            } while (opcao != 9);

        }
    }
}
