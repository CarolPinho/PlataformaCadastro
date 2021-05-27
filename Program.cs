using System;

namespace DIO.RealityShows
{
    class Program
    {
        static RealityShowsRepositorio repositorio = new RealityShowsRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarRealityShows();
						break;
					case "2":
						InserirRealityShows();
						break;
					case "3":
						AtualizarRealityShows();
						break;
					case "4":
						ExcluirRealityShows();
						break;
					case "5":
						VisualizarRealityShows();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Esperamos que tenha se divertido! Até a próxima!");
			Console.ReadLine();
        }

        private static void ExcluirRealityShows()
		{
			Console.Write("Digite o id do reality show: ");
			int indiceRealityShows = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceRealityShows);
		}

        private static void VisualizarRealityShows()
		{
			Console.Write("Digite o id do reality show: ");
			int indiceRealityShows= int.Parse(Console.ReadLine());

			var realityshows = repositorio.RetornaPorId(indiceRealityShows);

			Console.WriteLine(realityshows);
		}

        private static void AtualizarRealityShows()
		{
			Console.Write("Digite o id do reality show: ");
			int indiceRealityShows = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Reality Show: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do Reality Show: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Reality Show: ");
			string entradaDescricao = Console.ReadLine();

			RealityShows atualizaRealityShows = new RealityShows(Id: indiceRealityShows,
										Genero: (Genero)entradaGenero,
										Titulo: entradaTitulo,
										Ano: entradaAno,
										Descricao: entradaDescricao);

			repositorio.Atualiza(indiceRealityShows, atualizaRealityShows);
		}
        private static void ListarRealityShows()
		{
			Console.WriteLine("Listar Reality Shows");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum reality show cadastrado.");
				return;
			}

			foreach (var realityshows in lista)
			{
                var excluido = realityshows.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", realityshows.retornaId(), realityshows.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirRealityShows()
		{
			Console.WriteLine("Inserir novo Reality Show");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Reality Show: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do Reality Show: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Reality Show: ");
			string entradaDescricao = Console.ReadLine();

			RealityShows novoRealityShow = new RealityShows(Id: repositorio.ProximoId(),
										Genero: (Genero)entradaGenero,
										Titulo: entradaTitulo,
										Ano: entradaAno,
										Descricao: entradaDescricao);

			repositorio.Insere(novoRealityShow);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Reality Shows!");
            Console.WriteLine();
			Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();
			Console.WriteLine("1- Listar reality shows");
			Console.WriteLine("2- Inserir novo reality show");
			Console.WriteLine("3- Atualizar reality show");
			Console.WriteLine("4- Excluir reality show");
			Console.WriteLine("5- Visualizar reality show");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}

