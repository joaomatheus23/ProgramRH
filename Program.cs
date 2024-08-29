using System;

string[] historico = new string[10];
int indiceHistorico = 0;

while (true)
{
    Console.Clear();
    Console.WriteLine("\t\t\t\t\tMenu");
    Console.WriteLine();
    Console.WriteLine("Pressione K para calcular o salário líquido");
    Console.WriteLine("Pressione L para calcular o 13º salário");
    Console.WriteLine("Pressione P para exibir o histórico de cálculos");
    Console.WriteLine("Pressione Z para sair");

    ConsoleKeyInfo tecla = Console.ReadKey();

    if (tecla.Key == ConsoleKey.K)
    {
        Console.Clear();
        Console.WriteLine("Digite o valor da hora trabalhada: ");
        double valorHora = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Digite o número de horas trabalhadas: ");
        double horasTrabalhadas = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Digite o desconto total (em %): ");
        double desconto = Convert.ToDouble(Console.ReadLine());

        double salarioBruto = valorHora * horasTrabalhadas;
        double salarioLiquido = salarioBruto * (1 - desconto / 100);

        Console.WriteLine($"O salário bruto é R$ {salarioBruto:F2}");
        Console.WriteLine($"O salário líquido é R$ {salarioLiquido:F2}");

        // Armazenar no vetor de histórico
        if (indiceHistorico < historico.Length)
        {
            historico[indiceHistorico] = $"Salário líquido: R$ {salarioLiquido:F2}";
            indiceHistorico++;
        }

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
    else if (tecla.Key == ConsoleKey.L)
    {
        Console.Clear();

        Console.WriteLine("Digite o salário bruto: ");
        double salarioBruto = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Digite os meses trabalhados: ");
        int mesesTrabalhados = Convert.ToInt32(Console.ReadLine());

        // Garantir que os meses trabalhados estejam entre 1 e 12
        if (mesesTrabalhados < 1 || mesesTrabalhados > 12)
        {
            Console.WriteLine("Número de meses inválido! Deve estar entre 1 e 12");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            continue;
        }

        double decimoTerceiro = (salarioBruto / 12) * mesesTrabalhados;
        Console.WriteLine($"O 13º salário proporcional é: R$ {decimoTerceiro:F2}");

        // Armazenar no histórico
        if (indiceHistorico < historico.Length)
        {
            historico[indiceHistorico] = $"13º salário: R$ {decimoTerceiro:F2}";
            indiceHistorico++;
        }

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
    else if (tecla.Key == ConsoleKey.P)
    {
        Console.Clear();
        Console.WriteLine("Histórico de cálculos:");
        Console.WriteLine();

        for (int i = 0; i < indiceHistorico; i++)
        {
            Console.WriteLine(historico[i]);
        }

        if (indiceHistorico == 0)
        {
            Console.WriteLine("Nenhum cálculo realizado até o momento.");
        }

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
    else if (tecla.Key == ConsoleKey.Z)
    {
        break; // Sair do loop e encerrar o programa
    }
}
