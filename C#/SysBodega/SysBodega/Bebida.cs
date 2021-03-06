using System;

class Bebida{
	private int codigo;
	private String nomeBebida;
	private double teorAlcoolico;
	private double qtdMl;
	private double precoVenda;
	private double qtdEstoque;

	public Bebida(String nomeDrink, int codigoDrink, double teorAlcool, double ml, double preco) {
		codigo = codigoDrink;
		nomeBebida = nomeDrink;
		teorAlcoolico = teorAlcool;
		qtdMl = ml;
		precoVenda = preco;
	}

	public void vender(int quantidade) {
		if(quantidade < qtdEstoque) {
			qtdEstoque -= quantidade;
			Console.WriteLine("A quantidade em estoque foi alterada com sucesso!");
        } else {
			Console.WriteLine("A quantidade de venda não pode ser maior do que a quantidade em estoque!");
        }
	}

	public void comprar(int quantidade) {
        qtdEstoque += quantidade;
		Console.WriteLine("A quantidade foi alterada com sucesso!");
    }

	public double getQtd() {
		return qtdEstoque;
    }

	public void setQtd(int quanti) {
		qtdEstoque = quanti;
    }
	
}
