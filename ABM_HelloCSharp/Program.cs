using System;
using System.Collections.Generic;
using System.IO;

// Classe principal do programa
public class Program
{
    // Lista estática para armazenar os nomes digitados
    static List<string> nomes = new List<string>();
    
    // Caminho do arquivo para persistência dos dados
    static string caminhoArquivo = "nomes.txt";

    // Método principal de entrada do programa
    public static void Main()
    {
        try
        {
            Console.WriteLine("Welcome to C# Programming!");

            bool executando = true;

            // Loop principal do programa
            while (executando)
            {
                MostrarMenu();

                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                // Estrutura de controle para as opções do menu
                switch (opcao)
                {
                    case "1":
                        Saudacao();  // Opção de saudação personalizada
                        break;
                    case "2":
                        ContarCaracteres();  // Opção para contar caracteres
                        break;
                    case "3":
                        MostrarTodosOsNomes();  // Opção para listar nomes
                        break;
                    case "4":
                        SalvarEmArquivo();  // Opção para salvar em arquivo
                        break;
                    case "5":
                        executando = false;  // Opção para sair do programa
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                Console.WriteLine();  // Linha em branco para melhor legibilidade
            }
        }
        catch (Exception ex)
        {
            // Tratamento genérico de exceções
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    // Método para exibir o menu de opções
    static void MostrarMenu()
    {
        Console.WriteLine("=== MENU ===");
        Console.WriteLine("1. Saudação personalizada");
        Console.WriteLine("2. Contar caracteres do nome");
        Console.WriteLine("3. Mostrar todos os nomes digitados");
        Console.WriteLine("4. Salvar nomes em arquivo");
        Console.WriteLine("5. Sair");
    }

    // Método para realizar saudação personalizada
    static void Saudacao()
    {
        Console.Write("Digite seu nome: ");
        string nome = Console.ReadLine();

        // Validação de entrada vazia ou apenas espaços em branco
        if (string.IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("Nome inválido!");
            return;
        }

        // Adiciona o nome à lista após remover espaços extras
        nomes.Add(nome.Trim());
        Console.WriteLine(SaudacaoPersonalizada(nome));
    }

    // Método para contar caracteres de um nome
    static void ContarCaracteres()
    {
        Console.Write("Digite seu nome: ");
        string nome = Console.ReadLine();

        // Validação de entrada
        if (string.IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("Nome inválido!");
            return;
        }

        // Adiciona à lista e exibe o tamanho
        nomes.Add(nome.Trim());
        Console.WriteLine($"Seu nome tem {CalcularTamanhoNome(nome)} caracteres.");
    }

    // Método para exibir todos os nomes armazenados
    static void MostrarTodosOsNomes()
    {
        // Verifica se há nomes na lista
        if (nomes.Count == 0)
        {
            Console.WriteLine("Nenhum nome registrado ainda.");
            return;
        }

        // Lista todos os nomes com formatação
        Console.WriteLine("Nomes digitados:");
        foreach (var nome in nomes)
        {
            Console.WriteLine($"- {nome}");
        }
    }

    // Método para salvar os nomes em arquivo
    static void SalvarEmArquivo()
    {
        try
        {
            // Escreve todas as linhas (nomes) no arquivo
            File.WriteAllLines(caminhoArquivo, nomes);
            Console.WriteLine($"Nomes salvos em '{caminhoArquivo}' com sucesso!");
        }
        catch (Exception ex)
        {
            // Tratamento de erros de I/O
            Console.WriteLine($"Erro ao salvar arquivo: {ex.Message}");
        }
    }

    // Método auxiliar para gerar saudação personalizada com data
    public static string SaudacaoPersonalizada(string nome)
    {
        return $"Olá, {nome}! Hoje é {DateTime.Now:D}.";
    }

    // Método auxiliar para calcular tamanho do nome (sem espaços extras)
    public static int CalcularTamanhoNome(string nome)
    {
        return nome.Trim().Length;
    }
}