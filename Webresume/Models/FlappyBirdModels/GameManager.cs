using System;
using System.ComponentModel;
using System.Threading.Tasks;


namespace Webresume;

public class GameManager//this is an interface
{
    private readonly int _gravity = 2;

    public event EventHandler MainLoopCompleted;

    public BirdModel Bird { get; set; }
    public List<PipeModel> Pipes { get; set; }
    public bool IsRunning { get; set; } = false;
    public GameManager()
    {
        Bird = new BirdModel();
        Pipes = new List<PipeModel>();
    }
       

    public async void Gameloop()
    {
        IsRunning = true;
        while (IsRunning)
        {
            CheckCollisions();
            MoveObjects();
            ManagePipes();
            MainLoopCompleted?.Invoke(this, EventArgs.Empty);

            await Task.Delay(20);
        }
    }

    public void StartGame()
    {
        if(!IsRunning)
        {
            Bird = new BirdModel();
            Pipes = new List<PipeModel>();
            Gameloop();
        }
    }
    public void Jump()
    {
        if(IsRunning)
        {
            Bird.Jump();
        }
    }
    public void MoveObjects()
    {
        Bird.Fall(_gravity);

        foreach (var pipe in Pipes)
        {
            pipe.Move();
        }
    }

    public void CheckCollisions()
    {
        if (Bird.BirdOnGround())
        {
            GameOver();
        }
        var centeredPipe = Pipes.FirstOrDefault(p => p.IsCentered());

        if(centeredPipe != null)
        {
            bool hasCollidedWithBottom = Bird.DistanceFromGround < centeredPipe.GapBottom - 150;
            bool hasCollidedWithTop = Bird.DistanceFromGround + 45 > centeredPipe.GapTop - 150;
            if(hasCollidedWithBottom || hasCollidedWithTop)
            {
                GameOver();
            }
        }

    }

    public void ManagePipes()
    {
        if(!Pipes.Any() || Pipes.Last().DistanceFromLeft <= 200)
        {
            Pipes.Add(new PipeModel());
        }
        if (Pipes.First().IsOffScreen())
        {
            Pipes.Remove(Pipes.First());
        }
    }
    
    public void GameOver()
    {
        IsRunning = false;
    }
}
