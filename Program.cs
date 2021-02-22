using System;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        public static void Main(string[] args)
        {
            
            string opcao = obterOpcaoUsuario();
            while(!opcao.ToUpper().Equals("X"))
            {
                switch (opcao)
                {
                    case "1":
                    listarSeries();
                    break;
                    case "2":
                    inserirSerie();
                    break;
                    case "3":
                    atualizarSerie();
                    break;
                    case "4":
                    excluirSerie();
                    break;
                    case "5":
                    visualizarSerie();
                    break;
                    case "c":
                    Console.Clear();
                    break;
                    case "X":
                    Console.WriteLine("Obrigado por utilizar nossos servicos");
                    break;

                    default:
                    Console.WriteLine("Informe uma das opcoes!");
                    break; 
                }
                Console.WriteLine("");
                opcao = obterOpcaoUsuario();
            }
        }

        public static void listarSeries()
        {
            Console.WriteLine("Lista de Series");

            var lista =  repositorio.lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma serie cadastrada!");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), excluido ? "*Excluido*" : "");
            }

        }

        public static void inserirSerie()
        {
            Console.WriteLine("Inserir nova Serie.. ");

            foreach (int item in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", item, Enum.GetName(typeof(Genero), item));   
            }
            Console.Write("Digite o genero entre as opcoes acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de inicio da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descricao da serie: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.proximoId(), 
                                        genero: (Genero) entradaGenero, 
                                        titulo: entradaTitulo, 
                                        descricao: entradaDescricao, 
                                        ano: entradaAno);
            repositorio.insere(novaSerie);

        }

        public static void atualizarSerie()
        {
            Console.Write("Digite o ID da Serie: ");
            int entradaId = int.Parse(Console.ReadLine());

            Console.WriteLine("");

            Console.WriteLine("id: " + entradaId +" : " + repositorio.retornaPorId(entradaId).retornaTitulo());
            Console.WriteLine("");

            foreach (int item in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", item, Enum.GetName(typeof(Genero), item));   
            }
            Console.Write("Digite o genero entre as opcoes acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de inicio da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descricao da serie: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: entradaId, 
                                        genero: (Genero) entradaGenero, 
                                        titulo: entradaTitulo, 
                                        descricao: entradaDescricao, 
                                        ano: entradaAno);
            repositorio.atualiza(entradaId, atualizaSerie);
        }
  
        public static void excluirSerie()
        {
            Console.Write("Digite o id da serie que deseja excluir.. ");
            int entradaId = int.Parse(Console.ReadLine());
            repositorio.exclui(entradaId);

            Console.Write("{0} excluido com sucesso!", repositorio.retornaPorId(entradaId).retornaTitulo());
        }

        public static void visualizarSerie()
        {
            Console.Write("Digite o ID da serie que deseja visualizar: ");
            int entradaId = int.Parse(Console.ReadLine());

            Console.WriteLine(repositorio.retornaPorId(entradaId).ToString());
            Console.WriteLine("");
        }
        public static string obterOpcaoUsuario()
        {
            string opcaoUsuario = "";
            Console.WriteLine("Dio Series a seu Dispor!");
            Console.WriteLine("Digite a opcao desejada : ");
            Console.WriteLine("1- Listar series");
            Console.WriteLine("2- Inserir nova serie");
            Console.WriteLine("3- Atualizar serie");
            Console.WriteLine("4- Excluir serie");
            Console.WriteLine("5- Visualizar serie");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");

            opcaoUsuario = Console.ReadLine();
            return opcaoUsuario;
        }
    }
}
