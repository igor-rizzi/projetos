using System;

public class Cliente{
	private String nomeCliente;
	private int codigoCliente;
	private String cpf;
	private Boolean vendaFiado;

	public Cliente(String nomeCli, String cpfCliente, int codCliente, String venderFiado) {
		nomeCliente = nomeCli;
		cpf = cpfCliente;
		codigoCliente = codCliente;
    }

	public void vendeFiado(String venderFiado) {
		if(venderFiado == "Sim") {
			Console.WriteLine("Este cliente pode comprar fiado!");
			vendaFiado = true;
        }else if (venderFiado == "Nao"){
			Console.WriteLine("Este cliente não pode comprar fiado!");
			vendaFiado = false;
        }else {
			Console.WriteLine("Informe um valor válido!");
        }
    }
}
