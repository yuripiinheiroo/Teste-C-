using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemByCarros
{
    class Program
    {
        static List<Empresa> empresas = new List<Empresa>();
        static List<Cliente> clientes = new List<Cliente>();

        static void Main(string[] args)
        {
            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("=== Menu ===");
                Console.WriteLine("1. Cadastrar Empresa");
                Console.WriteLine("2. Cadastrar Carro");
                Console.WriteLine("3. Cadastrar Cliente");
                Console.WriteLine("4. Ver carros disponíveis");
                Console.WriteLine("5. Ver empresas disponíveis");
                Console.WriteLine("6. Minhas Parcelas");
                Console.WriteLine("7. Comprar Carro");
                Console.WriteLine("8. Sair");
                Console.WriteLine("============");

                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CadastrarEmpresa();
                        break;
                    case "2":
                        CadastrarCarro();
                        break;
                    case "3":
                        CadastrarCliente();
                        break;
                    case "4":
                        VerCarrosDisponiveis();
                        break;
                    case "5":
                        VerEmpresasDisponiveis();
                        break;
                    case "6":
                        VerParcelas();
                        break;
                    case "7":
                        ComprarCarro();
                        break;
                    case "8":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                        break;
                }
            }
        }

        static void CadastrarEmpresa()
        {
            Console.WriteLine("=== Cadastro da Empresa ===");
            Empresa novaEmpresa = new Empresa();
            Console.Write("Nome: ");
            novaEmpresa.Nome = Console.ReadLine();
            Console.Write("CNPJ: ");
            string cnpj = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(cnpj) || !cnpj.All(char.IsDigit))
            {
                Console.WriteLine("Por favor preencha o CNPJ corretamente (apenas números):");
                cnpj = Console.ReadLine();
            }
            novaEmpresa.CNPJ = cnpj;
            empresas.Add(novaEmpresa); // Adiciona a nova empresa à lista de empresas
            Console.WriteLine("Cadastro concluído.");
        }

        static void CadastrarCarro()
        {
            Console.WriteLine("=== Cadastro de Carro ===");
            // Código para cadastrar carro

            if (empresas.Count == 0)
            {
                Console.WriteLine("Não há empresas cadastradas para associar o carro. Por favor, cadastre uma empresa primeiro.");
                return;
            }

            // Escolher a empresa para associar o carro
            Console.WriteLine("Escolha a empresa para associar o carro:");
            for (int i = 0; i < empresas.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {empresas[i].Nome}");
            }
            Console.Write("Escolha o número da empresa: ");
            int escolhaEmpresa = int.Parse(Console.ReadLine()) - 1;
            Empresa empresaSelecionada = empresas[escolhaEmpresa];

            // Cadastrar o carro
            empresaSelecionada.CadastrarCarros();

            Console.WriteLine("Cadastro de carro concluído.");
        }

        static void CadastrarCliente()
        {
            Console.WriteLine("=== Cadastro do Cliente ===");
            Cliente novoCliente = new Cliente();
            // Código para cadastrar cliente

            Console.Write("Nome: ");
            novoCliente.Nome = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(novoCliente.Nome) || novoCliente.Nome.Any(char.IsDigit))
            {
                Console.WriteLine("Por favor, digite o nome corretamente (apenas letras):");
                Console.Write("Nome: ");
                novoCliente.Nome = Console.ReadLine();
            }

            Console.Write("CPF: ");
            novoCliente.CPF = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(novoCliente.CPF) || !novoCliente.CPF.All(char.IsDigit))
            {
                Console.WriteLine("Por favor, digite o CPF corretamente (apenas números):");
                Console.Write("CPF: ");
                novoCliente.CPF = Console.ReadLine();
            }

            Console.Write("Saldo: ");
            novoCliente.Saldo = double.Parse(Console.ReadLine());

            clientes.Add(novoCliente); // Adiciona o novo cliente à lista de clientes

            Console.WriteLine("Cadastro concluído.");
        }

        static void VerCarrosDisponiveis()
        {
            Console.WriteLine("=== Carros Disponíveis ===");
            // Código para visualizar carros

            if (empresas.Count == 0)
            {
                Console.WriteLine("Não há empresas cadastradas.");
                return;
            }

            // Escolher a empresa para visualizar os carros disponíveis
            Console.WriteLine("Escolha a empresa para visualizar os carros disponíveis:");
            for (int i = 0; i < empresas.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {empresas[i].Nome}");
            }
            Console.Write("Escolha o número da empresa: ");
            int escolhaEmpresa = int.Parse(Console.ReadLine()) - 1;

            // Verificar se a escolha é válida
            if (escolhaEmpresa < 0 || escolhaEmpresa >= empresas.Count)
            {
                Console.WriteLine("Escolha inválida.");
                return;
            }

            // Exibir os carros disponíveis da empresa selecionada
            empresas[escolhaEmpresa].VisualizarInformacoesEmpresa();
        }

        static void VerEmpresasDisponiveis()
        {
            Console.WriteLine("=== Empresas Disponíveis ===");
            foreach (var empresa in empresas)
            {
                Console.WriteLine($"Empresa: {empresa.Nome}, CNPJ: {empresa.CNPJ}");
            }
        }

        static void VerParcelas()
        {
            Console.WriteLine("=== Minhas Parcelas ===");
            // Código para visualizar parcelas

            Console.Write("Nome do cliente: ");
            string nomeCliente = Console.ReadLine();
            Console.Write("CPF do cliente: ");
            string cpfCliente = Console.ReadLine();

            // Verificar se o cliente existe
            Cliente clienteExistente = clientes.FirstOrDefault(c => c.Nome == nomeCliente && c.CPF == cpfCliente);
            if (clienteExistente != null && clienteExistente.Parcelas.Any())
            {
                clienteExistente.VisualizarInformacoesCliente();
            }
            else
            {
                Console.WriteLine("Não existe compra no nome ou CPF desse cliente.");
            }
        }

        static void ComprarCarro()
        {
            Console.WriteLine("=== Comprar Carro ===");
            // Código para comprar carro

            if (empresas.Count == 0)
            {
                Console.WriteLine("Não há empresas cadastradas.");
                return;
            }

            // Escolher a empresa para comprar carro
            Console.WriteLine("Escolha a empresa para comprar o carro:");
            for (int i = 0; i < empresas.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {empresas[i].Nome}");
            }
            Console.Write("Escolha o número da empresa: ");
            int escolhaEmpresa = int.Parse(Console.ReadLine()) - 1;

            // Verificar se a escolha é válida
            if (escolhaEmpresa < 0 || escolhaEmpresa >= empresas.Count)
            {
                Console.WriteLine("Escolha inválida.");
                return;
            }

            // Exibir os carros disponíveis da empresa selecionada
            empresas[escolhaEmpresa].VisualizarInformacoesEmpresa();

            // Escolher o carro para comprar
            Console.Write("Escolha o índice do carro para comprar: ");
            int carroIndex = int.Parse(Console.ReadLine()) - 1;

            // Realizar a compra
            Console.Write("Valor de entrada: ");
            double entrada = double.Parse(Console.ReadLine());

            Console.Write("Quantidade de parcelas (20x, 40x, 60x): ");
            int parcelas = int.Parse(Console.ReadLine());

            Cliente clienteSelecionado = SelecionarCliente();
            if (clienteSelecionado != null)
            {
                clienteSelecionado.EfeituarCompra(empresas, escolhaEmpresa, carroIndex, entrada, parcelas);
                Console.WriteLine("Compra concluída.");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }

        static Cliente SelecionarCliente()
        {
            Console.Write("Nome do cliente: ");
            string nomeCliente = Console.ReadLine();
            Console.Write("CPF do cliente: ");
            string cpfCliente = Console.ReadLine();

            // Verificar se o cliente existe
            Cliente clienteExistente = clientes.FirstOrDefault(c => c.Nome == nomeCliente && c.CPF == cpfCliente);
            return clienteExistente;
        }
    }
}