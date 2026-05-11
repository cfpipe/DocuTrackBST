using System;
using System.Collections.Generic;

namespace Model
{
    public class ArbolBinario
    /* implementa el algoritmo de arbol binaro para un sistema de archivos, si el nombre es menor va a la
    izquierda, si es mayor a la derecha
    */
    {
        public Nodo? Raiz;
        public int Comparaciones;

        public bool Insertar(string nombre, bool esCarpeta)
        // inserta un nuevo nodo, al ingresar ek nombre y si es carpeta
        {
            if (Buscar(nombre) != null)
                // si no encuentra el nombre, no existe, devuelve nulo
                return false;

            Raiz = InsertarRec(Raiz, nombre, esCarpeta);
            // Funcion recursiva que inserta a izquierda o derecha dependiendo el nodo
            return true;
        }

        private Nodo? InsertarRec(Nodo nodo, string nombre, bool esCarpeta)
        // Funcion para insetar nodo, devuelve un objeto tipo Nodod, tiene entrada nombre y carpeta
        {
            if (nodo == null)
                // Si el nodo no existe, lo crea
                return new Nodo(nombre, esCarpeta);

            int comp = string.Compare(nombre, nodo.Nombre, true);
            // compara el nombre ingresado con el nombre de la raiz actual, si es menor devuelve -1, si es mayor 1

            if (comp < 0)
                nodo.Izquierdo = InsertarRec(nodo.Izquierdo, nombre, esCarpeta);
                // mientras el nombre sea menor que el nombre de la raiz, se llama recursivamente
            else
                nodo.Derecho = InsertarRec(nodo.Derecho, nombre, esCarpeta);
                // mientras el nombre sea mayor que el nombre de la raiz, se llama recursivamente

            return nodo;
        }

        public Nodo? Buscar(string nombre)
        // metodo que busca el nombre de una carpeta y devuelve el nodo
        {
            Comparaciones = 0;
            return BuscarRec(Raiz, nombre);
        }

        private Nodo? BuscarRec(Nodo nodo, string nombre)
        // metodo recursivo que busca un nodo por nombre
        {
            if (nodo == null)   // El dato no existe
                return null;

            Comparaciones++;    // contador de comparaciones

            int comp = string.Compare(nombre, nodo.Nombre, true);

            if (comp == 0)
                return nodo;

            if (comp < 0)  // El nombre buscado  es menor - busca a la izquierda
                return BuscarRec(nodo.Izquierdo, nombre);

            return BuscarRec(nodo.Derecho, nombre);  // El nombre es mayor, busca a la derecha
        }

        public bool Actualizar(string viejo, string nuevo)
        {
            if (Buscar(viejo) == null) // verifica que el arbol viejo existe
                return false;

            Raiz = Eliminar(Raiz, viejo);  //Eliminar el nodo con el nombre viejo
            Insertar(nuevo, true);         //Reinsertar con el nombre nuevo

            return true;
        }

        public Nodo? Eliminar(Nodo nodo, string nombre)
        // Este metodo contempla los 3 casos, 1- el que desaparece es una hoja 2- desaparece un padre con 1 hijo
        // desaparece un padre con 2 hijos
        {
            if (nodo == null) // El nodo no existe, na hay que eliminar nada
                return null;

            int comp = string.Compare(nombre, nodo.Nombre, true);

            if (comp < 0)     // El nombre a eliminar es menor
                nodo.Izquierdo = Eliminar(nodo.Izquierdo, nombre);

            else if (comp > 0)  // El nombre a eliminar es mayor
                nodo.Derecho = Eliminar(nodo.Derecho, nombre);

            else
            {
                if (nodo.Izquierdo == null && nodo.Derecho == null)
                // caso 1 - nodo sin hijos
                    return null;

                if (nodo.Izquierdo == null)
                // caso 2 solo tiene hijo izquierdo
                    return nodo.Derecho;

                if (nodo.Derecho == null)
                // caso 2 solo tiene hijo derecho
                    return nodo.Izquierdo;

                Nodo sucesor = Minimo(nodo.Derecho);
                // caso 3 -  tiene 2 hijos

                nodo.Nombre = sucesor.Nombre;

                nodo.Derecho = Eliminar(nodo.Derecho, sucesor.Nombre);
            }

            return nodo;  // devuelve el nodo
        }

        private Nodo? Minimo(Nodo nodo)
        {
            while (nodo.Izquierdo != null) // baja siempre a la izquierda, al minimo
                nodo = nodo.Izquierdo;

            return nodo;
        }

        public void InOrden(Nodo nodo)
        // Inorder (izquierda - raiz -derecha)
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
        public void PreOrden(Nodo nodo)
        // Preorder (Raiz - izquierda -derecha) 
{
            if (nodo != null)
           {
               Console.Write(nodo.Nombre + " ");

               PreOrden(nodo.Izquierdo);

               PreOrden(nodo.Derecho);
    }
}

public void PostOrden(Nodo nodo)
// postorden (izquierda - derecha - raiz)
{
    if (nodo != null)
    {
        PostOrden(nodo.Izquierdo);

        PostOrden(nodo.Derecho);

        Console.Write(nodo.Nombre + " ");
    }
}

public void PorNiveles()
{
    if (Raiz == null)
        return;

    Queue<Nodo> cola = new Queue<Nodo>();

    cola.Enqueue(Raiz);

    while (cola.Count > 0)
    {
        Nodo actual = cola.Dequeue();

        Console.Write(actual.Nombre + " ");

        if (actual.Izquierdo != null)
            cola.Enqueue(actual.Izquierdo);

        if (actual.Derecho != null)
            cola.Enqueue(actual.Derecho);
    }
}
    }
}