using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

Console.WriteLine("Informe alguns números (somente inteiros):");
string texto = Console.ReadLine();

if (!Regex.IsMatch(texto, @"^\d+$"))
{
    Console.WriteLine("Erro: o texto informado deve conter somente números.");
}
else
{
    List<string> numeros = ObterNumeros(texto);

    if (!numeros.Any())
    {
        Console.WriteLine("Erro: o texto informado não contém números.");
    }
    else
    {
        var numerosPorExtenso = CriarDicionario();

        foreach (string numero in numeros)
        {
            if (int.TryParse(numero, out int valor))
            {
                string numeroPorExtenso = TranscreverNumero(valor, numerosPorExtenso);
                Console.WriteLine(numeroPorExtenso);
            }
            else
            {
                Console.WriteLine("Erro: o valor informado não é um número inteiro.");
            }
        }
    }


    static List<string> ObterNumeros(string texto)
    {
        return texto.Split().Where(s => int.TryParse(s, out _)).ToList();
    }

    static Dictionary<int, string> CriarDicionario()
    {
        return new Dictionary<int, string>()
        {
            {0, "Zero"},
            {1, "Um"},
            {2, "Dois"},
            {3, "Três"},
            {4, "Quatro"},
            {5, "Cinco"},
            {6, "Seis"},
            {7, "Sete"},
            {8, "Oito"},
            {9, "Nove"},
            {10, "Dez"},
            {11, "Onze"},
            {12, "Doze"},
            {13, "Treze"},
            {14, "Quatorze"},
            {15, "Quinze"},
            {16, "Dezesseis"},
            {17, "Dezessete"},
            {18, "Dezoito"},
            {19, "Dezenove"},
            {20, "Vinte"},
            {30, "Trinta"},
            {40, "Quarenta"},
            {50, "Cinquenta"},
            {60, "Sessenta"},
            {70, "Setenta"},
            {80, "Oitenta"},
            {90, "Noventa"},
            {100, "Cem"},
            {200, "Duzentos"},
            {300, "Trezentos"},
            {400, "Quatrocentos"},
            {500, "Quinhentos"},
            {600, "Seiscentos"},
            {700, "Setecentos"},
            {800, "Oitocentos"},
            {900, "Novecentos"}
        };
    }

    static string TranscreverNumero(int numero, Dictionary<int, string> numerosPorExtenso)
    {
        if (numerosPorExtenso.ContainsKey(numero))
        {
            return numerosPorExtenso[numero];
        }
        else if (numero < 100)
        {
            int dezena = numero / 10 * 10;
            int unidade = numero % 10;
            return numerosPorExtenso[dezena] + " e " + numerosPorExtenso[unidade];
        }
        else if (numero < 1000)
        {
            int centena = numero / 100 * 100;
            int resto = numero % 100;
            if (resto == 0)
            {
                return numerosPorExtenso[centena];
            }
            else
            {
                return numerosPorExtenso[centena] + " e " + TranscreverNumero(resto, numerosPorExtenso);
            }
        }
        else
        {
            return "Número inválido.";
        }
    }
}