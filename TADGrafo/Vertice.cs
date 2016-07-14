using System;

namespace TADGrafo
{
	public class Vertice
	{
		private int chave;
		private int valor;

		public Vertice ()
		{
		}

		public Vertice (int valor, int chave)
		{
			this.chave = chave;
			this.valor = valor;
		}
			
		public int Valor {
			get {
				return valor;
			}
			set {
				valor = value;
			}
		}


		public int Chave {
			get {
				return chave;
			}
			set {
				chave = value;
			}
		}
	}
}

