namespace Model
{
    public class Nodo
    {
        public string Nombre;
        public bool EsCarpeta;
        public Nodo? Izquierdo;
        public Nodo? Derecho;

        public Nodo(string nombre, bool esCarpeta)
        {
            Nombre = nombre;
            EsCarpeta = esCarpeta;
        }
    }
}