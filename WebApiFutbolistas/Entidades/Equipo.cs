namespace WebApiFutbolistas.Entidades
{
    public class Equipo
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Division { get; set; }

        public int FutbolistaId { get; set; }

        public Futbolista Futbolista { get; set; }
    }
}
