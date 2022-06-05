namespace Webresume;

public class Car
{
    public int Position { get; set; }
    public int Range { get; set; }
    public int Size { get; set; } = 1;
    public List<int> StartingPosition { get; set; } 
        = new List<int> { new Random().Next(0, 400), new Random().Next(0, 400) };


    
}
