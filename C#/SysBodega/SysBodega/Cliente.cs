using System;

public class Cliente{
	private String nomeCliente;
	private int codigoCliente;
	private String cpf;
	private Boolean vendaFiado;

	public Cliente(String nomeCli, String cpfCliente, int codCliente, int venderFiado) {
		nomeCliente = nomeCli;
		cpf = cpfCliente;
		codigoCliente = codCliente;
    }

	void vendeFiado(int venderFiado) {
		if(venderFiado == 1) {
			Console.WriteLine("Este cliente pode comprar fiado!");
			vendaFiado = true;
        }else if (venderFiado == 2){
			Console.WriteLine("Este cliente não pode comprar fiado!");
			vendaFiado = false;
        }else {
			Console.WriteLine("Informe um valor válido!");
        }
    }
}
