using System;

namespace TADGrafo
{
	public class Aresta
	{
		private int valor;
		private  Vertice verticeOrigem;
		private  Vertice verticeFim;
		private Boolean direcionada;

		public Aresta ()
		{
			direcionada = false;
		}

		public Aresta (Vertice v1, Vertice v2)
		{
			verticeOrigem = v1;
			verticeFim = v2;
			direcionada = false;
		}

		public Aresta (Vertice v1, Vertice v2, int valor)
		{
			verticeOrigem = v1;
			verticeFim = v2;
			this.valor = valor;
			direcionada = false;
		}

		public Aresta (Vertice v1, Vertice v2, int valor, bool True)
		{
			verticeOrigem = v1;
			verticeFim = v2;
			this.valor = valor;
			direcionada = true;
		}

		public int Valor {
			get {
				return valor;
			}
			set {
				valor = value;
			}
		}

		public Vertice VerticeOrigem {
			get {
				return verticeOrigem;
			}
			set {
				verticeOrigem = value;
			}
		}

		public Vertice VerticeFim {
			get {
				return verticeFim;
			}
			set {
				verticeFim = value;
			}
		}

		public Boolean Direcionada {
			get {
				return direcionada;
			}
			set {
				direcionada = value;
			}
		}
	}
}

