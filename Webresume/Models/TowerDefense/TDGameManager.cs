using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Webresume;

public class TDGameManager
{

    public bool IsRunning { get; set; } = false;
    public bool IsPause { get; set; } = false;
    public event EventHandler MainLoopCompleted;
    public Car Cars { get; set; }
    public Obstacle Obstacle { get; set; }
    //each tower will have a key as an int and a position x,y
    public Dictionary<int, List<string>> TowerPositions { get; set; } = new Dictionary<int, List<string>>();

    public List<int> temp = new List<int>() { 0 };


    public TDGameManager()
    {
        Obstacle = new Obstacle();
        Cars = new Car();
    }
    public async void GameLoop()
    {
        IsRunning = true;
        while(IsRunning)
        {
            
            MainLoopCompleted?.Invoke(this, EventArgs.Empty);

            await Task.Delay(20);
        }
    }

    public void StartGame()
    {
        if(!IsRunning)
        {
            GameLoop();

        }
    }

    public void AddTower(int key, List<string> position)
    {
        TowerPositions.Add(key, position);
    }
    public void GameOver()
    {
        IsRunning = false;
    }
}
  
