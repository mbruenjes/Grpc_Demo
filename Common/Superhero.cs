namespace Common
{
    public class Superhero
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public Universe Universe { get; set; }
    }

    public enum Universe
    {
        Marvel,
        Dc
    }
}