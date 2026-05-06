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
                "Programacion",
                "Calculo",
                "Redes",
                "BaseDatos",
                "ParcialPOO",
                "Talleres",
                "Fotos",
                "Musica",
                "Documentos",
                "Horarios",
                "Vacaciones",
                "Recibos",
                "Videos",
                "Trabajos",
                "Descargas"
            };

            foreach (var item in datos)
                arbol.Insertar(item, true);

            vista.ImprimirArbol(arbol.Raiz);

            // BUSQUEDAS

            vista.MostrarTitulo("BUSQUEDAS");

            Buscar("Calculo");
            Buscar("BaseDatos");

            Buscar("Vacaciones");
            Buscar("Videos");

            Buscar("NoExiste1");
            Buscar("NoExiste2");

            // ACTUALIZACIONES

            vista.MostrarTitulo("ACTUALIZACION HOJA");

            arbol.Actualizar("Videos", "Videos2025");

            vista.ImprimirArbol(arbol.Raiz);

            vista.MostrarTitulo("ACTUALIZACION NODO CON HIJO");

            arbol.Actualizar("Musica", "MusicaMP3");

            vista.ImprimirArbol(arbol.Raiz);

            vista.MostrarTitulo("ACTUALIZACION RAIZ");

            arbol.Actualizar("Programacion", "ProgramacionIII");

            vista.ImprimirArbol(arbol.Raiz);

            // ELIMINACIONES

            vista.MostrarTitulo("ELIMINAR HOJA");

            arbol.Raiz = arbol.Eliminar(arbol.Raiz, "Recibos");

            vista.ImprimirArbol(arbol.Raiz);

            vista.MostrarTitulo("ELIMINAR NODO CON HIJO");

            arbol.Raiz = arbol.Eliminar(arbol.Raiz, "MusicaMP3");

            vista.ImprimirArbol(arbol.Raiz);

            vista.MostrarTitulo("ELIMINAR RAIZ");

            arbol.Raiz = arbol.Eliminar(arbol.Raiz, "ProgramacionIII");

            vista.ImprimirArbol(arbol.Raiz);

            // RECORRIDOS

            vista.MostrarTitulo("RECORRIDO PREORDEN");

            arbol.PreOrden(arbol.Raiz);

            System.Console.WriteLine();

            vista.MostrarTitulo("RECORRIDO INORDEN");

            arbol.InOrden(arbol.Raiz);

            System.Console.WriteLine();

            vista.MostrarTitulo("RECORRIDO POSTORDEN");

            arbol.PostOrden(arbol.Raiz);

            System.Console.WriteLine();

            vista.MostrarTitulo("RECORRIDO POR NIVELES");

            arbol.PorNiveles();

            System.Console.WriteLine();

            // ALTURA

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