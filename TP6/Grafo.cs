using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TP6
{
	/// <summary>
	/// Description of Grafo.
	/// </summary>
	public class Grafo<T>
	{


		private List<Vertice<T>> vertices = new List<Vertice<T>>();

		public Grafo()
		{
		}

		public void agregarVertice(Vertice<T> v)
		{
			v.setPosicion(vertices.Count + 1);
			vertices.Add(v);
		}

		public void eliminarVertice(Vertice<T> v)
		{
			vertices.Remove(v);
		}

		public void conectar(Vertice<T> origen, Vertice<T> destino, int peso)
		{
			origen.getAdyacentes().Add(new Arista<T>(destino, peso));
		}

		public void desConectar(Vertice<T> origen, Vertice<T> destino)
		{
			Arista<T> arista = origen.getAdyacentes().Find(a => a.getDestino().Equals(destino));
			origen.getAdyacentes().Remove(arista);
		}


		public List<Vertice<T>> getVertices()
		{
			return vertices;
		}


		public Vertice<T> vertice(int posicion)
		{
			return this.vertices[posicion];
		}


		public void DFS(Vertice<T> origen)
		{
			bool[] visitados = new bool[this.vertices.Count];
			this._DFS(origen, visitados);
        }

        private void _DFS(Vertice<T> origen, bool[] visitados)
        {
            // Procesamos origen
            Console.Write(origen.getDato() + " ");

            // marcamos a origen como visitado
            visitados[origen.getPosicion() - 1] = true;

            foreach (var ady in origen.getAdyacentes())
            {
                if (!visitados[ady.getDestino().getPosicion() - 1])  // chequeo si adyacente fue visitado
                {
                    this._DFS(ady.getDestino(), visitados);
                }
            }
        }

        public List<Vertice<T>> BuscarCaminoMinimo(Vertice<T> origen, Vertice<T> destino)
        {
            List<Vertice<T>> caminoActual = new List<Vertice<T>>();
            List<Vertice<T>> caminoMinimo = new List<Vertice<T>>();
            bool[] visitados = new bool[vertices.Count];

            _CaminoCortoDFS(origen, destino, visitados, caminoActual, caminoMinimo);

            return caminoMinimo;
        }

        private void _CaminoCortoDFS(Vertice<T> actual, Vertice<T> destino, bool[] visitados, List<Vertice<T>> caminoActual, List<Vertice<T>> caminoMinimo)
        {
            visitados[actual.getPosicion() - 1] = true;
            caminoActual.Add(actual);

            if (actual == destino)
            {
                if (caminoMinimo.Count == 0 || caminoActual.Count < caminoMinimo.Count)
                {
                    caminoMinimo.Clear();
                    caminoMinimo.AddRange(caminoActual);
                }
            }
            else
            {
                foreach (var ady in actual.getAdyacentes())
                {
                    if (!visitados[ady.getDestino().getPosicion() - 1])
                    {
                        _CaminoCortoDFS(ady.getDestino(), destino, visitados, caminoActual, caminoMinimo);
                    }
                }
            }

            visitados[actual.getPosicion() - 1] = false; // Marcar el nodo como no visitado para otras búsquedas
            caminoActual.Remove(actual);
        }


        public void BFS(Vertice<T> origen)
		{
			bool[] visitados = new bool[this.vertices.Count];
			Cola<Vertice<T>> c = new Cola<Vertice<T>>();
			Vertice<T> vertAux;

			c.encolar(origen);
			visitados[origen.getPosicion() - 1] = true;

			while (!c.esVacia())
			{
				vertAux = c.desencolar();
				Console.Write(vertAux.getDato() + " ");

				foreach (var ady in vertAux.getAdyacentes())
				{
					if (!visitados[ady.getDestino().getPosicion() - 1])
					{
						c.encolar(ady.getDestino());
						visitados[ady.getDestino().getPosicion() - 1] = true;
					}
				}

			}

		}
        public void _BFS(Vertice<T> origen)
        {
            // Array para rastrear si un vértice ha sido visitado
            bool[] visitados = new bool[this.vertices.Count];

            // Cola para realizar el recorrido BFS
            Cola<Vertice<T>> cola = new Cola<Vertice<T>>();

            // Diccionario para rastrear los niveles de los vértices
            Dictionary<Vertice<T>, int> niveles = new Dictionary<Vertice<T>, int>();

            // Cola inicializa con el vértice de origen
            cola.encolar(origen);

            // Marcar el vértice de origen como visitado y su nivel como 0
            visitados[origen.getPosicion() - 1] = true;
            niveles[origen] = 0;

            while (!cola.esVacia())
            {
                Vertice<T> vertAux = cola.desencolar();
                int nivelActual = niveles[vertAux];

                // Imprimir el nivel actual y el valor del vértice
                Console.WriteLine($"Nivel {nivelActual}: {vertAux.getDato()}");

                // Recorrer los vértices adyacentes
                foreach (var ady in vertAux.getAdyacentes())
                {
                    if (!visitados[ady.getDestino().getPosicion() - 1])
                    {
                        // Encolar el vértice adyacente si no ha sido visitado
                        cola.encolar(ady.getDestino());

                        // Marcar el vértice adyacente como visitado y asignar su nivel
                        visitados[ady.getDestino().getPosicion() - 1] = true;
                        niveles[ady.getDestino()] = nivelActual + 1;
                    }
                }
            }
        }




    }


    public class Recorrido<T>
	{
		private Grafo<T> grafo;
		private List<Vertice<T>> recorrido;
		private List<Vertice<T>> visitados;

		public Recorrido(Grafo<T> grafo)
		{
			this.grafo = grafo;
			this.recorrido = new List<Vertice<T>>();
			this.visitados = new List<Vertice<T>>();
		}
        /*EJERCICIO 2A
        public List<Vertice<T>> CaminoSimpleConDFS(Vertice<T> origen, Vertice<T> destino)
        {
            List<Vertice<T>> camino = new List<Vertice<T>>();
            bool encontrado = BuscarCaminoSimpleDFS(origen, destino, camino);

            if (encontrado)
            {
                return camino; // No invertimos el camino
            }
            else
            {
                return null; // No se encontró un camino
            }
        }


		
        private bool BuscarCaminoSimpleDFS(Vertice<T> actual, Vertice<T> destino, List<Vertice<T>> camino)
        {
            // Procesamos el vértice actual
            camino.Add(actual);

            if (actual.Equals(destino))
            {
                return true; // Hemos encontrado el destino, hay un camino
            }

            // Recorremos los vértices adyacentes
            foreach (var adyacente in actual.getAdyacentes())
            {
                if (!camino.Contains(adyacente.getDestino()))
                {
                    if (BuscarCaminoSimpleDFS(adyacente.getDestino(), destino, camino))
                    {
                        return true; // Se encontró un camino, salimos
                    }
                }
            }

            // Si no se encontró un camino desde este vértice, lo eliminamos del camino
            camino.Remove(actual);
            return false;
        }

		*/

        public List<Vertice<T>> verticesADistanciaConBFS(Vertice<T> origen, int nroDeAristas)
        {
            List<Vertice<T>> verticesADistancia = new List<Vertice<T>>();

            if (nroDeAristas < 0)
            {
                // Si la distancia deseada es negativa, se devuelve una lista vacía.
                return verticesADistancia;
            }

            Cola<Vertice<T>> cola = new Cola<Vertice<T>>(); // Crear una cola para el BFS.
            bool[] visitados = new bool[grafo.getVertices().Count]; // Arreglo para llevar un registro de los vértices visitados.

            cola.encolar(origen); // Agregar el vértice origen a la cola.
            visitados[origen.getPosicion() - 1] = true; // Marcar el vértice origen como visitado.

            int distanciaActual = 0; // Inicializar la distancia actual en 0.

            while (!cola.esVacia()) // Mientras la cola no esté vacía.
            {
                int nodosEnNivelActual = cola.contar(); // Contar la cantidad de nodos en el nivel actual.

                if (distanciaActual == nroDeAristas)
                {
                    // Hemos alcanzado la distancia deseada, añadimos los vértices al resultado.
                    while (nodosEnNivelActual > 0)
                    {
                        Vertice<T> vertice = cola.desencolar();
                        verticesADistancia.Add(vertice);
                        nodosEnNivelActual--;
                    }
                    break;
                }

                while (nodosEnNivelActual > 0)
                {
                    Vertice<T> vertice = cola.desencolar();

                    foreach (var aristaVecino in vertice.getAdyacentes())
                    {
                        Vertice<T> verticeVecino = aristaVecino.getDestino();

                        if (!visitados[verticeVecino.getPosicion() - 1])
                        {
                            visitados[verticeVecino.getPosicion() - 1] = true; // Marcar el vértice vecino como visitado.
                            cola.encolar(verticeVecino); // Agregar el vértice vecino a la cola para su exploración.
                        }
                    }

                    nodosEnNivelActual--;
                }

                distanciaActual++; // Incrementar la distancia actual para seguir explorando niveles.
            }

            return verticesADistancia; // Devolver la lista de vértices a la distancia deseada.
        }



    }


}