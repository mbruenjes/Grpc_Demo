namespace Common
{
  public class Superhero
  {
    public string Alias { get; set; }
    public float Height { get; set; }
    public string Name { get; set; }
    public Universe Universe { get; set; }
    public float Weight { get; set; }
  }

  public enum Universe
  {
    Marvel,
    Dc
  }
}