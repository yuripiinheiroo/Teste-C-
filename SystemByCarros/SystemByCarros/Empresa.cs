using System;
using System.Collections.Generic;
using SystemByCarros;

public class Empresa
{
    public string Nome { get; set; } // Propriedade para armazenar o nome da empresa
    public string CNPJ { get; set; } // Propriedade para armazenar o CNPJ da empresa
    public List<Carro> Carros { get; set; } = new List<Carro>(); // Lista de carros associados à empresa
    public List<Cliente> Clientes { get; set; } = new List<Cliente>(); // Lista de clientes associados à empresa

    // Método para cadastrar carros na empresa
    public void CadastrarCarros()
    {
        Console.Write("Quantos carros deseja cadastrar? "); // Solicitação para o usuário informar a quantidade de carros que vão ser cadastrados
        int quantidade = int.Parse(Console.ReadLine()); // pega a quantidade de carros que vão ser cadastrados e fornecida pelo usuário

        // Loop para cadastrar cada carro
        for (int i = 0; i < quantidade; i++)
        {
            Console.WriteLine($"\nCadastro do carro {i + 1}");
            Console.Write("Modelo: ");
            string modelo = Console.ReadLine(); // Captura o modelo do carro fornecido pelo usuário

            // Loop para validar se o modelo contém pelo menos uma letra
            while (string.IsNullOrWhiteSpace(modelo) || modelo.All(char.IsDigit))
            {
                Console.WriteLine("Por favor, digite o modelo corretamente (deve conter pelo menos uma letra):");
                Console.Write("Modelo: ");
                modelo = Console.ReadLine();
            }

            Console.Write("Marca: ");
            string marca = Console.ReadLine(); // Captura a marca do carro fornecida pelo usuário

            // Loop para validar se a marca contém apenas letras
            while (string.IsNullOrWhiteSpace(marca) || marca.Any(char.IsDigit))
            {
                Console.WriteLine("Por favor, digite a marca corretamente (apenas letras):");
                Console.Write("Marca: ");
                marca = Console.ReadLine();
            }

            Console.Write("Ano: ");
            int ano = int.Parse(Console.ReadLine()); // Captura o ano do carro fornecido pelo usuário

            Console.Write("Cor: ");
            string cor = Console.ReadLine(); // Captura a cor do carro fornecida pelo usuário

            // Loop para validar se a cor contém apenas letras
            while (string.IsNullOrWhiteSpace(cor) || cor.Any(char.IsDigit))
            {
                Console.WriteLine("Por favor, digite a cor corretamente (apenas letras):");
                Console.Write("Cor: ");
                cor = Console.ReadLine();
            }

            Console.Write("Valor: ");
            double valor = double.Parse(Console.ReadLine()); // Captura o valor do carro fornecido pelo usuário

            // Adiciona o carro à lista de carros da empresa
            Carros.Add(new Carro
            {
                Modelo = modelo,
                Marca = marca,
                Ano = ano,
                Cor = cor,
                Valor = valor,
                IsDisponivel = true
            });
        }
    }

    // Método para visualizar as informações da empresa e os carros disponíveis
    public void VisualizarInformacoesEmpresa()
    {
        Console.WriteLine($"\nEmpresa: {Nome}, CNPJ: {CNPJ}"); // Exibe o nome e o CNPJ da empresa
        Console.WriteLine("\nCarros disponíveis:");

        // Loop para percorrer os carros da empresa e exibir caso estejam disponíveis
        foreach (var carro in Carros)
        {
            if (carro.IsDisponivel)
            {
                Console.WriteLine($"\n{carro.Modelo}, {carro.Marca}, {carro.Ano}, Cor: {carro.Cor}, Valor: {carro.Valor}");
            }
        }
    }
}


