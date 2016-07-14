using System;
using System.Collections.Generic;

namespace TADGrafo
{
	public class Grafo
	{
		private int qtdVertices;
		private List<Aresta>[,] matrizGrafo;
		private List<Aresta> arestas;
		private List<Vertice> vertices;

		public Grafo ()
		{
			qtdVertices = 0;
			arestas = new List<Aresta> ();
			vertices = new List<Vertice> ();
		}


		public List<Vertice> finalVertices(Aresta a){
			List<Vertice> v = new List<Vertice> ();
			v.Add (a.VerticeOrigem);
			v.Add(a.VerticeFim);
			return v;
		}

		public Vertice oposto(Vertice v, Aresta a){
			if (a.VerticeOrigem == v)
				return a.VerticeFim;
			else if (a.VerticeFim == v)
				return a.VerticeOrigem;
			else
				throw new System.InvalidOperationException("Vertice e aresta não são incidentes.");
		}

		public void substituir(Vertice v, int valor){
			v.Valor = valor;
		}

		public void substituir(Aresta a, int valor){
			a.Valor = valor;
		}

		public void inserirVertice(int valor, int chave){
			qtdVertices++;
			Vertice v = new Vertice (valor, chave);
			vertices.Add (v);
			List<Aresta>[,] matrizTeste = new List<Aresta>[qtdVertices, qtdVertices];
			if (qtdVertices > 1) {
				for (int linha = 0; linha < qtdVertices - 1; linha++) {
					for (int coluna = 0; coluna < qtdVertices - 1; coluna++) {
						matrizTeste [linha, coluna] = matrizGrafo [linha, coluna];
					}
				}
			}
			matrizGrafo = matrizTeste;
			Console.WriteLine("Index do vertice adicionado:{0}", vertices.IndexOf(v));
		}

		public void imprimirMatriz(){
			Console.WriteLine ("\nMatriz: ");
			for(int linha = -1; linha < qtdVertices; linha++){
				
				for (int coluna = -1; coluna < qtdVertices; coluna++) {
					
					if (linha == -1 && coluna == -1)
						Console.Write (" x |");
					else if(linha == -1)
						Console.Write ("V" + (coluna+1) + " |");
					else if(coluna == -1)
						Console.Write ("V" + (linha+1) + " | ");
					else if (matrizGrafo [linha, coluna] == null || matrizGrafo [linha, coluna].Count == 0)
						Console.Write ("0 | ");
					else
						Console.Write ("A | ");
					
				}
				Console.Write("\n");

			}
		}

		public void imprimirVertices(){
			int index = 1;
			Console.WriteLine ("Vértices: ");
			foreach (Vertice v in vertices) {
				Console.WriteLine ("Vértice " + index + " => valor: " + v.Valor + "; chave: " + v.Chave + "; índice: " + vertices.IndexOf(v));
				index++;
			}
		}

		public void imprimirArestas(){
			int index = 1;
			Console.WriteLine ("Arestas: ");
			foreach (Aresta a in arestas) {
				Console.WriteLine ("Aresta " + index + " => valor: " + a.Valor );
				index++;
			}
		}

		public void inserirAresta(Vertice v1, Vertice v2, int valor){
			Aresta a = new Aresta (v1, v2, valor);
			arestas.Add (a);
			int index_v1 = vertices.IndexOf (v1);
			int index_v2 = vertices.IndexOf (v2);

			matrizGrafo [index_v1, index_v2] = new List<Aresta> ();
			matrizGrafo [index_v1, index_v2].Add (a);
			matrizGrafo [index_v2, index_v1] = new List<Aresta> ();
			matrizGrafo [index_v2, index_v1].Add (a);
		}

		public void inserirAresta(Vertice v1, Vertice v2){
			Aresta a = new Aresta (v1, v2);
			arestas.Add (a);
			int index_v1 = vertices.IndexOf (v1);
			int index_v2 = vertices.IndexOf (v2);

			matrizGrafo [index_v1, index_v2] = new List<Aresta> ();
			matrizGrafo [index_v1, index_v2].Add (a);
			matrizGrafo [index_v2, index_v1] = new List<Aresta> ();
			matrizGrafo [index_v2, index_v1].Add (a);
		}

		public void inserirArestaDirecionada(Vertice v1, Vertice v2, int valor, bool T){
			Aresta a = new Aresta (v1, v2, valor, true);
			arestas.Add (a);
			int index_v1 = vertices.IndexOf (v1);
			int index_v2 = vertices.IndexOf (v2);
			matrizGrafo [index_v1, index_v2] = new List<Aresta> ();
			matrizGrafo [index_v1, index_v2].Add (a);
		}

		public Vertice procurarVertice(int chave){
			Vertice v1 = new Vertice();
			foreach (Vertice v in vertices) {
				if (v.Chave == chave) {
					v1 = v;
				}
			}
			return v1;
		}


		public Boolean ehAdjacente(Vertice v1, Vertice v2){
			foreach (Aresta a in arestas) {
				if (a.VerticeOrigem == v1 || a.VerticeOrigem == v2) {
					if (a.VerticeFim == v1 || a.VerticeFim == v2)
						return true;
				}
			}
			return false;
		}

		public int valorDistanciaEntreVertices(Vertice v1, Vertice v2){
			foreach (Aresta a in arestas) {
				if (a.VerticeOrigem == v1 || a.VerticeOrigem == v2) {
					if (a.VerticeFim == v1 || a.VerticeFim == v2)
						return a.Valor;
				}
			}
			return 99999;
		}

		public Boolean ehDirecionada(Aresta a){
			return a.Direcionada;
		}

		public List<Aresta> Arestas {
			get {
				return arestas;
			}
		}

		public List<Vertice> Vertices {
			get {
				return vertices;
			}
		}

		public List<Aresta> arestasIncidentes(Vertice v){
			List<Aresta> a = new List<Aresta> ();
			foreach (Aresta aresta in arestas) {
				if (aresta.VerticeOrigem == v || aresta.VerticeFim == v)
					a.Add (aresta);
			}
			return a;
		}

		public int ordem(){
			return qtdVertices;
		}

		public void removerAresta(Aresta a){

			if (arestas.Contains (a)) {
				arestas.Remove (a);
			}

			int index_v1 = vertices.IndexOf (a.VerticeOrigem);
			int index_v2 = vertices.IndexOf (a.VerticeFim);

			matrizGrafo [index_v1, index_v2].Remove (a);

			if (!a.Direcionada) {
				matrizGrafo [index_v2, index_v1].Remove (a);
			} 

		}

		public void removerVertice(Vertice v){

			qtdVertices--;
			int indice = vertices.IndexOf (v);

			if (vertices.Contains (v))
				vertices.Remove (v);

			List<Aresta> arestas_incidentes = new List<Aresta> ();
			arestas_incidentes = arestasIncidentes (v);

			foreach (Aresta aresta in arestas_incidentes) {
				if (arestas.Contains (aresta)) {
					arestas.Remove (aresta);
				}
			}

			List<Aresta>[,] matrizTeste = new List<Aresta>[qtdVertices, qtdVertices];

			int lin, col;

			if (qtdVertices > 0) {
				for (int linha = 0; linha < qtdVertices; linha++) {
					lin = linha;

					if (linha >= indice) 
						lin++;
					
					for (int coluna = 0; coluna < qtdVertices; coluna++) {
						col = coluna;

						if (coluna >= indice) {
							col++;
						}

						matrizTeste [linha, coluna] = matrizGrafo [lin, col];
					}
				}
			}

			matrizGrafo = matrizTeste;

		
		}

		public void dijkstra(Vertice v0){

			Dictionary<Vertice, int> S = new Dictionary<Vertice, int> ();
			S.Add (v0, 0); 
			Dictionary<Vertice, int> D = new Dictionary<Vertice, int> ();

			foreach (Vertice v in vertices) {
				if (v != v0)
					D.Add (v, valorDistanciaEntreVertices (v0, v));
			}

			//var ordenado = D.OrderBy(x => x.Value);

			while (S.Count != vertices.Count) {
				
				Vertice W = new Vertice ();
				int dW = 99999;
				
				foreach (var item in D) {
					if (item.Value < dW) {
						W = item.Key;
						dW = item.Value;
					}
				}
			
				S.Add (W, dW);
				D.Remove (W);

				foreach (var item in D) {
					if (item.Value > (dW + valorDistanciaEntreVertices(item.Key, W))) {
						D[item.Key] = dW + valorDistanciaEntreVertices(item.Key, W);
					}
				}
			}

			//imprimir
			foreach(var item in S){
				Console.WriteLine ("Vértice: {0} - Distância: {1}", item.Key.Chave, item.Value);
			}


		}




	
	}
}

