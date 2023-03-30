Console.WriteLine("Informe alguns Número (somente inteiros):");
string texto = Console.ReadLine();

List<char> listadecaracteres = new List<char>();
List<string> listadecaracterespermitidos = new List<string>();
bool contemletras = false;

Conferesetemletras(ref texto, ref contemletras, ref listadecaracteres, ref listadecaracterespermitidos);

if(contemletras)
{
    Console.WriteLine("Erro: o texto informado contém letras ou caracteres inválidos.");
}
else
{
    

    foreach(char c in texto)
    {
        Dictionary<char, string> numerosPorExtenso = CriarDicionario();

        if (numerosPorExtenso.ContainsKey(c))
        {
            Console.WriteLine(numerosPorExtenso[c]);
        }
    }
}

/////////////////////////////////////FUNÇÕES////////////////////////////////////////////

static void Conferesetemletras(ref string texto, ref bool contemletras, ref List<char> listadecaracteres, ref List<string> listadecaracterespermitidos)
{

    foreach (char c in texto)
    {
        listadecaracteres.Add(c);
    }

    for (int i = 0; i <= 9; i++)
    {
        string caracterespermitidos = Convert.ToString(i);
        listadecaracterespermitidos.Add(caracterespermitidos);
    }

    foreach (char c in listadecaracteres)
    {
        string s = Convert.ToString(c);
        if (!listadecaracterespermitidos.Contains(s))
        {
            contemletras = true;
            break;
        }
    }
}

static Dictionary<char, string> CriarDicionario()
{
    Dictionary<char, string> numerosPorExtenso = new Dictionary<char, string>()
    {
        {'0', "Zero"},
        {'1', "Um"},
        {'2', "Dois"},
        {'3', "Três"},
        {'4', "Quatro"},
        {'5', "Cinco"},
        {'6', "Seis"},
        {'7', "Sete"},
        {'8', "Oito"},
        {'9', "Nove"}
    };

    return numerosPorExtenso;
}
