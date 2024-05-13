using System;
using System.Collections.Generic;
using SystemByCarros;

public class Cliente
{
    public string Nome { get; set; } // Propriedade para guardar o nome do cliente
    public string CPF { get; set; } // Propriedade para guardar o CPF do cliente
    public double Saldo { get; set; } // Propriedade para guardar o saldo do cliente
    public List<Parcela> Parcelas { get; set; } = new List<Parcela>(); // Lista de parcelas do cliente
    public List<Carro> CarrosComprados { get; set; } = new List<Carro>(); // Lista de carros comprados pelo cliente
    public int QuantidadeParcelas { get; set; } // Propriedade para guardar a quantidade de parcelas
    public double TotalAPagar { get; set; } // Propriedade para guardar o total a pagar pelo cliente

    // Para visualizar as parcelas do cliente
    public void VisualizarParcelas()
    {
        if (Parcelas.Count == 0)
        {
            Console.WriteLine("Não há parcelas disponíveis."); // Exibe uma mensagem se não houver parcelas
            return;
        }

        Console.WriteLine("Parcelas do Cliente:");
        foreach (var parcela in Parcelas)
        {
            Console.WriteLine($"Índice: {parcela.Index}, Data: {parcela.Data}, Valor: {parcela.Valor}"); // Exibe as informações de cada parcela
        }
    }

    // Método para selecionar uma empresa e visualizar os carros disponíveis
    public void SelecionarEmpresa(List<Empresa> empresas)
    {
        Console.WriteLine("Empresas disponíveis:");
        for (int i = 0; i < empresas.Count; i++) // Percorrendo a lista de empresas
        {
            Console.WriteLine($"{i + 1}: {empresas[i].Nome}"); //Exibe o índice (incrementado em 1 para começar do 1) e o nome de cada empresa disponível.
        }

        Console.Write("Escolha uma empresa pelo número: ");
        int escolha = int.Parse(Console.ReadLine()) - 1;

        Empresa empresaSelecionada = empresas[escolha];

        Console.WriteLine($"Empresa selecionada: {empresaSelecionada.Nome}");
    }

    // Método para visualizar os carros disponíveis de uma empresa
    public void VisualizarCarros(List<Empresa> empresas, int empresaIndex)
    {
        var empresa = empresas[empresaIndex];
        Console.WriteLine("Carros disponíveis:");
        foreach (var carro in empresa.Carros)
        {
            if (carro.IsDisponivel)
            {
                Console.WriteLine($"{carro.Modelo}, {carro.Marca}, {carro.Ano}, Cor: {carro.Cor}, Valor: {carro.Valor}");
            }
        }
    }

    // Método para visualizar todas as informações do cliente
    public void VisualizarInformacoesCliente()
    {
        Console.WriteLine($"Cliente: {Nome}, CPF: {CPF}"); // Exibe o nome e CPF do cliente
        Console.WriteLine($"Saldo: {Saldo}"); // Exibe o saldo do cliente
        Console.WriteLine($"Total a pagar: {TotalAPagar}"); // Exibe o total a pagar pelo cliente
        Console.WriteLine("Carros comprados:");
        foreach (var carro in CarrosComprados) // Estou usando o var porque torna o código mais conciso e fácil de ler, especialmente quando se está iterando sobre coleções genéricas como listas.
        {
            Console.WriteLine($"{carro.Modelo}, {carro.Marca}, {carro.Ano}"); // Exibe os carros comprados pelo cliente
        }

        Console.WriteLine("Parcelas:");
        foreach (var parcela in Parcelas)
        {
            Console.WriteLine($"Parcela {parcela.Index}, Data: {parcela.Data}, Valor: {parcela.Valor}"); // Exibe as parcelas do cliente
        }
    }

    // Método para efetuar uma compra de carro pelo cliente
    public void EfeituarCompra(List<Empresa> empresas, int empresaIndex, int carroIndex, double entrada, int parcelas)
    {
        var empresa = empresas[empresaIndex];
        var carro = empresa.Carros[carroIndex];

        // Descontar entrada do saldo do cliente
        Saldo -= entrada;

        // Remover valor da entrada do valor total do carro
        carro.Valor -= entrada;

        // Verificar se o carro ainda está disponível
        if (!carro.IsDisponivel)
        {
            Console.WriteLine("O carro já foi vendido.");
            return;
        }

        // Atualizar carro como vendido
        carro.IsDisponivel = false;
        CarrosComprados.Add(carro);

        // Calcular parcelas
        double valorParcela = carro.Valor / parcelas;
        DateTime data = DateTime.Now;

        for (int i = 0; i < parcelas; i++)
        {
            Parcela parcela = new Parcela
            {
                Index = i + 1,
                Data = data.AddMonths(i + 1),
                Valor = valorParcela
            };

            Parcelas.Add(parcela); // Adicionar a parcela à lista de parcelas do cliente
        }

        Console.WriteLine($"Compra efetuada com sucesso! {parcelas} parcelas de {valorParcela}.");
    }
}
