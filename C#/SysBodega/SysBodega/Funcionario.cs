using System;

public class Funcionario{
	private String nomeFun;
	private int codigoFun;
	private int idade;
	private Double salario;

	public Funcionario(String nome, int numero, int idadeFun, Double salarioFun) {
		nomeFun = nome;
		codigoFun = numero;
		idade = idadeFun;
		salario = salarioFun;
    }
}
