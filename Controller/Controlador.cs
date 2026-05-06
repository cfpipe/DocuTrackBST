using Model;
using View;

namespace Controller
{
    public class Controlador
    {
        private ArbolBinario arbol = new ArbolBinario();
        private Vista vista = new Vista();

        public void Run()
        {
            vista.MostrarTitulo("CREACION DEL BST");

            string[] datos =
            {
                "M","C","T","A","E","P","Z",
                "B","D","F","R","X","Y","Q"
            };

            foreach (var item in datos)
                arbol.Insertar(item, true);

            vista.ImprimirArbol(arbol.Raiz);

            vista.MostrarTitulo("BUSQUEDAS");

            Buscar("A");
            Buscar("F");
            Buscar("Z");
            Buscar("NOEXISTE");

            vista.MostrarTitulo("ACTUALIZACION");

            arbol.Actualizar("A", "AA");

            vista.ImprimirArbol(arbol.Raiz);

            vista.MostrarTitulo("ELIMINACION");

            arbol.Raiz = arbol.Eliminar(arbol.Raiz, "C");

            vista.ImprimirArbol(arbol.Raiz);

            vista.MostrarTitulo("RECORRIDO INORDEN");

            arbol.InOrden(arbol.Raiz);

            vista.MostrarTitulo("ALTURA");

            System.Console.WriteLine(arbol.Altura(arbol.Raiz));
        }

        private void Buscar(string nombre)
        {
            var nodo = arbol.Buscar(nombre);

            vista.MostrarBusqueda(
                nombre,
                nodo,
                arbol.Comparaciones
            );
        }
    }
}