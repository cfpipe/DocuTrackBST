using System;
using System.Collections.Generic;

namespace Model
{
    public class ArbolBinario
    {
        public Nodo? Raiz;
        public int Comparaciones;

        public bool Insertar(string nombre, bool esCarpeta)
        {
            if (Buscar(nombre) != null)
                return false;

            Raiz = InsertarRec(Raiz, nombre, esCarpeta);
            return true;
        }

        private Nodo? InsertarRec(Nodo nodo, string nombre, bool esCarpeta)
        {
            if (nodo == null)
                return new Nodo(nombre, esCarpeta);

            int comp = string.Compare(nombre, nodo.Nombre, true);

            if (comp < 0)
                nodo.Izquierdo = InsertarRec(nodo.Izquierdo, nombre, esCarpeta);
            else
                nodo.Derecho = InsertarRec(nodo.Derecho, nombre, esCarpeta);

            return nodo;
        }

        public Nodo? Buscar(string nombre)
        {
            Comparaciones = 0;
            return BuscarRec(Raiz, nombre);
        }

        private Nodo? BuscarRec(Nodo nodo, string nombre)
        {
            if (nodo == null)
                return null;

            Comparaciones++;

            int comp = string.Compare(nombre, nodo.Nombre, true);

            if (comp == 0)
                return nodo;

            if (comp < 0)
                return BuscarRec(nodo.Izquierdo, nombre);

            return BuscarRec(nodo.Derecho, nombre);
        }

        public bool Actualizar(string viejo, string nuevo)
        {
            if (Buscar(viejo) == null)
                return false;

            Raiz = Eliminar(Raiz, viejo);
            Insertar(nuevo, true);

            return true;
        }

        public Nodo? Eliminar(Nodo nodo, string nombre)
        {
            if (nodo == null)
                return null;

            int comp = string.Compare(nombre, nodo.Nombre, true);

            if (comp < 0)
                nodo.Izquierdo = Eliminar(nodo.Izquierdo, nombre);

            else if (comp > 0)
                nodo.Derecho = Eliminar(nodo.Derecho, nombre);

            else
            {
                if (nodo.Izquierdo == null && nodo.Derecho == null)
                    return null;

                if (nodo.Izquierdo == null)
                    return nodo.Derecho;

                if (nodo.Derecho == null)
                    return nodo.Izquierdo;

                Nodo sucesor = Minimo(nodo.Derecho);

                nodo.Nombre = sucesor.Nombre;

                nodo.Derecho = Eliminar(nodo.Derecho, sucesor.Nombre);
            }

            return nodo;
        }

        private Nodo? Minimo(Nodo nodo)
        {
            while (nodo.Izquierdo != null)
                nodo = nodo.Izquierdo;

            return nodo;
        }

        public void InOrden(Nodo nodo)
        {
            if (nodo != null)
            {
                InOrden(nodo.Izquierdo);
                Console.Write(nodo.Nombre + " ");
                InOrden(nodo.Derecho);
            }
        }

        public int Altura(Nodo nodo)
        {
            if (nodo == null)
                return 0;

            return 1 + Math.Max(
                Altura(nodo.Izquierdo),
                Altura(nodo.Derecho)
            );
        }
    }
}