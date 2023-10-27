/*
 * Created by SharpDevelop.
 * User: nahue
 * Date: 15/9/2023
 * Time: 21:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace TP6
{
    class Program
    {
        static void Main(string[] args)
        {
            Grafo<string> miGrafo = new Grafo<string>();

            Vertice<string> A = new Vertice<string>("A");
            Vertice<string> B = new Vertice<string>("B");
            Vertice<string> C = new Vertice<string>("C");
            Vertice<string> D = new Vertice<string>("D");
            Vertice<string> E = new Vertice<string>("E");

            miGrafo.agregarVertice(A);
            miGrafo.agregarVertice(B);
            miGrafo.agregarVertice(C);
            miGrafo.agregarVertice(D);
            miGrafo.agregarVertice(E);

            miGrafo.conectar(A, B, 0);
            miGrafo.conectar(A, C, 0);
            miGrafo.conectar(B, D, 0);
            miGrafo.conectar(C, E, 0);

            Vertice<string> origen = A;
            Vertice<string> destino = D;

            Console.WriteLine(miGrafo.BuscarCaminoMinimo(origen, destino));


          
            //List<Vertice<string>> camino = recorrido.CaminoSimpleConDFS(origen, destino);

            //if (camino != null)
            //{
            //    Console.WriteLine("Camino encontrado:");
            //    foreach (Vertice<string> vertice in camino)
            //    {
            //        Console.WriteLine(vertice.getDato());
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("No se encontró un camino desde el origen hasta el destino.");
            //}

            // Llama al método verticesADistanciaConBFS para encontrar los vértices a una distancia específica
            //int distanciaDeseada = 1; // Cambia la distancia deseada según tus necesidades
            //List<Vertice<string>> verticesADistancia = recorrido.verticesADistanciaConBFS(origen, distanciaDeseada);

            //Console.WriteLine($"Vértices a {distanciaDeseada} aristas de distancia desde {origen.getDato()}:");

            //foreach (Vertice<string> vertice in verticesADistancia)
            //{
            //    Console.WriteLine(vertice.getDato());
            //}


           Console.ReadKey(true);
        }

    }
    //class Program
    //{
    //	public static void Main(string[] args)
    //	{
    //           Grafo<string> gr = new Grafo<string>();

    //		Vertice<string> lp = new Vertice<string>("La Plata");
    //		gr.agregarVertice(lp);
    //           Vertice<string> pi = new Vertice<string>("Pila");
    //		gr.agregarVertice(pi);
    //           Vertice<string> ta = new Vertice<string>("Tandil");
    //           gr.agregarVertice(ta);
    //           Vertice<string> ma = new Vertice<string>("Madariaga");
    //           gr.agregarVertice(ma);
    //           Vertice<string> le = new Vertice<string>("Lezama");
    //           gr.agregarVertice(le);
    //           Vertice<string> mda = new Vertice<string>("Mar de Ajo");
    //           gr.agregarVertice(mda);
    //           Vertice<string> mdq = new Vertice<string>("Mar del Plata");
    //           gr.agregarVertice(mdq);
    //           Vertice<string> vg = new Vertice<string>("Villa Gessel");
    //           gr.agregarVertice(vg);
    //           Vertice<string> pin = new Vertice<string>("Pinamar");
    //           gr.agregarVertice(pin);

    //           gr.conectar(lp, ta, 0);
    //           gr.conectar(ta, lp, 0);
    //           gr.conectar(lp, le, 0);
    //           gr.conectar(le, lp, 0);
    //           gr.conectar(le, pi, 0);
    //           gr.conectar(pi, le, 0);
    //           gr.conectar(le, mda, 0);
    //           gr.conectar(mda, le, 0);
    //           gr.conectar(ta, pi, 0);
    //           gr.conectar(pi, ta, 0);
    //           gr.conectar(ta, ma, 0);
    //           gr.conectar(ma, ta, 0);
    //           gr.conectar(mdq, ta, 0);
    //           gr.conectar(ta, mdq, 0);
    //           gr.conectar(pi, ma, 0);
    //           gr.conectar(ma, pi, 0);
    //           gr.conectar(pi, mda, 0);
    //           gr.conectar(mda, pi, 0);
    //           gr.conectar(mda, pin, 0);
    //           gr.conectar(pin, mda, 0);
    //           gr.conectar(mdq, vg, 0);
    //           gr.conectar(vg, mdq, 0);
    //           gr.conectar(pin, ma, 0);
    //           gr.conectar(ma, pin, 0);
    //           gr.conectar(pin, vg, 0);
    //           gr.conectar(vg, pin, 0);

    //           Console.WriteLine("Imprimimos recorrido DFS desde La Plata");
    //           gr.DFS(lp);
    //           Console.WriteLine();
    //           Console.WriteLine();

    //           Console.WriteLine("Imprimimos recorrido BFS desde La Plata");
    //           gr.BFS(lp); 
    //           Console.WriteLine();
    //           Console.WriteLine();


    //           Console.WriteLine();
    //           Console.WriteLine();
    //		Console.Write("Press any key to continue . . . ");
    //		Console.ReadKey(true);
    //	}
    //}
}