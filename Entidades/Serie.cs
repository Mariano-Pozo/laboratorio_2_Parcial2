namespace Entidades
{
    public class Serie
    {
        private string genero;
        private string nombre;

        public string Genero { get => genero; set => genero = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public Serie() { }
        public Serie(string nombre, string genero)
        {
            this.nombre = nombre;
            this.genero = genero;
        }

        public override string ToString()
        {
            return $"Nombre: {nombre}, Genero: {genero}";
        }
    }
}