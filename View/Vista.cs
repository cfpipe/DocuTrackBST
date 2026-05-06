using System;
using Model;

namespace View
{
    public class Vista
    {
        public void MostrarTitulo(string texto)
        {
            Console.WriteLine("\n========== " + texto + " ==========");
        }

        public void MostrarBusqueda(string nombre, Nodo nodo, int comparaciones)
        {
            if (nodo != null)
                Console.WriteLine($"{nombre} encontrado | Comparaciones: {comparaciones}");
            else
                Console.WriteLine($"{nombre} NO encontrado | Comparaciones: {comparaciones}");
        }

        public void ImprimirArbol(Nodo nodo, string espacio = "", bool ultimo = true)
        {
            if (nodo == null)
                return;

            Console.WriteLine(espacio + (ultimo ? "└── " : "├── ") + nodo.Nombre);

            espacio += ultimo ? "    " : "│   ";

            ImprimirArbol(nodo.Izquierdo, espacio, false);
            ImprimirArbol(nodo.Derecho, espacio, true);
        }
    }
}