using avl_tree;

Arvore arvore = new Arvore();

string binPath = Directory.GetCurrentDirectory();
string projectPath = Directory.GetParent(binPath)!.Parent!.Parent!.Parent!.FullName;

string filePath = Path.Combine(projectPath, "inputFile.txt");

if (!File.Exists(filePath))
{
    Console.WriteLine("Arquivo não encontrado!");
    return;
}

string[] linhas = File.ReadAllLines(filePath);

foreach (var line in linhas)
{
    string instruction = line.Split(" ")[0].ToLower();
    int value = 0;

    if(line.Count() > 2)
        value = Convert.ToInt32(line.Split(" ")[1].ToLower());

    switch (instruction)
    {
        case "i":
            arvore.Inserir(value);
            break;
        case "r":
            arvore.Remover(value);
            break;
        case "p":
            arvore.PreOrdem();
            break;
        case "b":
            arvore.Busca(value);
            break;
        case "f":
            arvore.ObterTodosFatoresBalanceamento();
            break;
        case "h":
            arvore.AlturaArvore();
            break;
        default:
            Console.WriteLine($"Erro: Instrução {instruction} não encontrada");
            break;
    }
}
