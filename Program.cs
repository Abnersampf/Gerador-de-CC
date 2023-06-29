using System;
using System.Linq;

namespace Gerador_de_C.C
{
    class Program
    {
        static void Main(string[] args)
        {
            string resposta = "s";
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("_______________________________________________________________________");
            Console.WriteLine("\\    ____ ____ ____ ____ ___  ____ ____    ___  ____    ____  ____    /");
            Console.WriteLine(" |   | __ |___ |__/ |__| |  \\ |  | |__/    |  \\ |___    |     |      |");
            Console.WriteLine(" |   |__] |___ |  \\ |  | |__/ |__| |  \\    |__/ |___    |___ .|___   |");
            Console.WriteLine("/_____________________________________________________________________\\");
            do
            {
                int[] numeros = new int[16];

                Random numAleatorio = new Random();
                int final0, armazenar_numAleatorio, limite = 10, soma = 0, flag = 0;

                // Gera um número aleatório de 0 a 140 que termina com 0 (e armazena na variável "final0")
                do
                {
                    final0 = numAleatorio.Next(141);
                } while (final0 % 10 != 0);

                // Gera 16 números de 0 a 10 cuja soma de todos seja igual ao valor da variável "final0"
                do
                {
                    for (int contador = 0; contador < 16; contador++)
                    {
                        if (flag == 0)
                        {
                            if (final0 < limite)
                            {
                                limite = final0 + 1;
                            }
                            armazenar_numAleatorio = numAleatorio.Next(limite);
                            final0 -= armazenar_numAleatorio;

                            numeros[contador] = armazenar_numAleatorio;
                        }
                        else
                        {
                            if (numeros[contador] != 9)
                            {
                                numeros[contador] += 1;
                                final0--;
                                if (final0 == 0)
                                {
                                    contador = 16;
                                }
                            }
                        }
                    }
                    flag++;
                } while (final0 > 0);

                // Embaralha o vetor
                numeros = numeros.OrderBy(x => numAleatorio.Next()).ToArray();

                // Faz a engenharia reversa da 1ª e 2ª etapa do algoritmo de Lhun
                for (int contador = 0; contador < 16; contador += 2)
                {
                    if (numeros[contador] % 2 != 0)
                    {
                        numeros[contador] = ((numeros[contador] - 1) + 10) / 2;
                    }
                    else
                    {
                        numeros[contador] /= 2;
                    }
                }

                // Imprime o número do cartão
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                     ------------------------------");
                Console.Write("                     Nº DO CARTÃO: ");
                for (int contador = 0; contador < 16; contador++)
                {
                    Console.Write(numeros[contador]);
                }
                Console.WriteLine();
                Console.WriteLine("                     ------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("- Deseja gerar outro número ?");
                Console.Write("  [s - SIM | n - NÃO]: ");
                resposta = Console.ReadLine();
            } while (resposta == "s" || resposta == "S" || resposta == "sim" || resposta == "SIM");
        }
    }
}
