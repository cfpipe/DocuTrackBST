namespace Model
{
    public class Nodo
    /*
        clase nodo, objeto que contiene nombre, dice si es carpetra y guarda otros objetos tipo nodo
        en la izquierda y la derecha 
    */
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