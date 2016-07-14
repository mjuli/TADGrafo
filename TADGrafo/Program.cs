using System;
using System.Collections.Generic;
using System.Linq;


namespace TADGrafo
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Grafo Teste = new Grafo ();

			int op = 1;
			int chave1, chave2, valor;

			while (op != 0) {
				Console.WriteLine ("Digite:" +
					"\n1 - Para inserir vertice" +
					"\n2 - Para inserir aresta" +
					"\n3 - Para inserir aresta direcionada" +
					"\n4 - Para remover vertice" +
					"\n5 - Para remover a ultima aresta" +
					"\n6 - Para imprimir os vertices" +
					"\n7 - Para imprimir as arestas" +
					"\n8 - Para imprimir a matriz" +
					"\n9 - Para imprimir a menor distância em relação a um vértice" +
					"\n0 - Para terminar" );


				op = int.Parse (Console.ReadLine());

				switch (op) {
				case 0:
					Console.WriteLine ("Fim!");
					break;

				case 1:
					Console.WriteLine ("Digite uma chave:");
					chave1 = int.Parse (Console.ReadLine ());
					Console.WriteLine ("Digite um valor:");
					valor = int.Parse (Console.ReadLine ());
					Teste.inserirVertice (valor, chave1);
					Console.WriteLine ("Operação realizada com sucesso!");
					break;

				case 2:
					Console.WriteLine ("Digite um valor:");
					valor = int.Parse (Console.ReadLine ());
					Console.WriteLine ("Digite o valor da chave do primeiro vértice:");
					chave1 = int.Parse (Console.ReadLine ());
					Console.WriteLine ("Digite o valor da chave do segundo vértice:");
					chave2 = int.Parse (Console.ReadLine ());

					Vertice v1 = Teste.procurarVertice (chave1);
					Vertice v2 = Teste.procurarVertice (chave2);
					Teste.inserirAresta (v1, v2, valor);

					Console.WriteLine ("Operação realizada com sucesso!");
					break;

				case 3:
					Console.WriteLine ("Digite um valor:");
					valor = int.Parse (Console.ReadLine ());
					Console.WriteLine ("Digite o valor da chave do primeiro vértice:");
					chave1 = int.Parse (Console.ReadLine ());
					Console.WriteLine ("Digite o valor da chave do segundo vértice:");
					chave2 = int.Parse (Console.ReadLine ());

					Vertice v_1 = Teste.procurarVertice (chave1);
					Vertice v_2 = Teste.procurarVertice (chave2);
					Teste.inserirArestaDirecionada (v_1, v_2, valor, true);

					Console.WriteLine ("Operação realizada com sucesso!");
					break;

				case 4:
					Console.WriteLine ("Digite o valor da chave do vértice:");
					chave1 = int.Parse (Console.ReadLine ());

					Vertice v = Teste.procurarVertice (chave1);

					Console.WriteLine("Quantidade de vertices antes: " + Teste.Vertices.Count());
					Teste.removerVertice(v);
					Console.WriteLine("Quantidade de vertices depois: " + Teste.Vertices.Count());

					///Console.WriteLine ("Operação realizada com sucesso!");
					break;

				case 5:
					List<Aresta> a = Teste.Arestas;

					Teste.removerAresta (a[a.Count - 1]);
					Teste.imprimirMatriz ();
					Console.WriteLine ("Operação realizada com sucesso!");
					break;

				case 6:
					Teste.imprimirVertices ();
					break;
				
				case 7:

					Console.WriteLine ("Operação realizada com sucesso!");
					break;

				case 8:
					Teste.imprimirMatriz ();
					break;

				case 9:
					/*Console.WriteLine ("Digite o valor da chave do vértice:");
					chave1 = int.Parse (Console.ReadLine ());
		
					Vertice v0 = Teste.procurarVertice (chave1);*/
					Teste.inserirVertice (1, 1);
					Teste.inserirVertice (2, 2);
					Teste.inserirVertice (3, 3);
					Teste.inserirVertice (4, 4);
					Teste.inserirVertice (5, 5);

					Vertice v1 = Teste.procurarVertice (1);
					Vertice v2 = Teste.procurarVertice (2);
					Vertice v3 = Teste.procurarVertice (3);
					Vertice v4 = Teste.procurarVertice (4);
					Vertice v5 = Teste.procurarVertice (5);
						
						
					Teste.inserirAresta (v1, v2, valor);
					Teste.inserirAresta (v1, v2, valor);
					Teste.inserirAresta (v1, v2, valor);
					Teste.inserirAresta (v1, v2, valor);
					Teste.inserirAresta (v1, v2, valor);

					Teste.dijkstra(v0);

					Console.WriteLine ("Operação realizada com sucesso!");
					break;

				default:
					Console.WriteLine ("Operação inválida! Tente novamente!");
					break;
				}

			}
		}
	}
}
