using Series;
using series;

SerieRepositorio repositorio = new SerieRepositorio();

string opcaoUsuario = ObterOpcaoUsuario();
while(opcaoUsuario.ToUpper() != "X"){
    switch(opcaoUsuario)
    {
        case "1":
            ListarSeries();
        break;

        case "2":
            InserirSerie();
        break;

        case "3":
            AtualizarSerie();
        break;

        case "4":
            ExcluirSerie();
        break;
        
        case "5":
            VisualizarSerie();
        break;

        case "C":
            Console.Clear();
            opcaoUsuario = ObterOpcaoUsuario();
        break;

        default:
            throw new ArgumentOutOfRangeException();
    }
}

static string ObterOpcaoUsuario()
{   
    Console.Clear();
    System.Console.WriteLine();
    System.Console.WriteLine("Dio Séries a seu dispor!");
    System.Console.WriteLine("Informe a opção desejada:");
    System.Console.WriteLine();
    System.Console.WriteLine("1- Listar Séries");
    System.Console.WriteLine("2- Inserir nova série");
    System.Console.WriteLine("3- Atualizar Série");
    System.Console.WriteLine("4- Excluir série");
    System.Console.WriteLine("5- Vizualizar Série");
    System.Console.WriteLine("C- Limpar Tela");
    System.Console.WriteLine("X- Sair");
    System.Console.WriteLine();

    string opcaoUsuario = Console.ReadLine()!.ToUpper();
    System.Console.WriteLine();
    return opcaoUsuario;
}

void ListarSeries(){
    System.Console.WriteLine("Listar Séries");

    var lista = repositorio.Lista();

    if (lista.Count == 0){
        System.Console.WriteLine("Nenhuma série cadastrada. ");
        System.Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
        opcaoUsuario = ObterOpcaoUsuario();
        return;
    }else{
        foreach( var serie in lista){
            bool excluido = serie.retornaExcluido();
            System.Console.WriteLine("#ID {0}: - {1} - {2}" ,  serie.retornaId(), serie.retornaTitulo(), (excluido ? "- Excluído ": ""));
        }
        Console.ReadKey();
        opcaoUsuario = ObterOpcaoUsuario();   
    }


}

void InserirSerie(){
    System.Console.WriteLine("Inserir nova série");

    foreach(int i in Enum.GetValues(typeof(Genero))){
        System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
    }

    System.Console.WriteLine("Digite o genêro entre as opções acima: ");
    int entradaGenero = int.Parse(Console.ReadLine()!);

    System.Console.WriteLine("Digite o Título da Série: ");
    string entradaTitulo = Console.ReadLine()!;
    
    System.Console.WriteLine("Digite o Ano de Início da Série: ");
    int entradaAno = int.Parse(Console.ReadLine()!);

    System.Console.WriteLine("Digit a Descrição da Série: ");
    string entradaDescricao = Console.ReadLine()!;

    Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                genero: (Genero)entradaGenero,
                                titulo: entradaTitulo,
                                ano: entradaAno,
                                descricao: entradaDescricao);
    repositorio.Insere(novaSerie);
    opcaoUsuario = ObterOpcaoUsuario();
}

void AtualizarSerie()
{
    System.Console.WriteLine("Digite o id da série: ");
    int indiceSerie = int.Parse(Console.ReadLine()!);

    foreach(int i in Enum.GetValues(typeof(Genero))){
        System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
    }

    System.Console.WriteLine("Digite o genêro entre as opções acima: ");
    int entradaGenero = int.Parse(Console.ReadLine()!);

    System.Console.WriteLine("Digite o Título da Série: ");
    string entradaTitulo = Console.ReadLine()!;
    
    System.Console.WriteLine("Digite o Ano de Início da Série: ");
    int entradaAno = int.Parse(Console.ReadLine()!);

    System.Console.WriteLine("Digit a Descrição da Série: ");
    string entradaDescricao = Console.ReadLine()!;

    Serie atualizaSerie = new Serie(id: indiceSerie,
                                genero: (Genero)entradaGenero,
                                titulo: entradaTitulo,
                                ano: entradaAno,
                                descricao: entradaDescricao);
    repositorio.Atualiza(indiceSerie, atualizaSerie);
    opcaoUsuario = ObterOpcaoUsuario();

} 

void ExcluirSerie(){
    System.Console.WriteLine("Digite o id da série: ");
    int indiceSerie = int.Parse(Console.ReadLine()!);

    repositorio.Exclui(indiceSerie);

    System.Console.WriteLine("Série excluída com sucesso.");
    System.Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
    Console.ReadKey();
    opcaoUsuario = ObterOpcaoUsuario();
}

void VisualizarSerie(){
    System.Console.WriteLine("Digite o id da série: ");
    int indiceSerie = int.Parse(Console.ReadLine()!);

    var serie = repositorio.RetornaPorId(indiceSerie);

    System.Console.WriteLine(serie);
    
    System.Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
    Console.ReadKey();
    opcaoUsuario = ObterOpcaoUsuario();

}