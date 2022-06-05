namespace Webresume;

public class PipeModel
{
    public int DistanceFromLeft { get; private set; } = 500;
    public int DistanceFromBottom { get; private set; } = new Random().Next(0, 60);
    public int Speed { get; set; } = 4;
    public int Gap { get; private set; } = 100;
    public int GapBottom => DistanceFromBottom + 300;
    public int GapTop => GapBottom + Gap;

    public bool IsOffScreen()
    {
        if (DistanceFromLeft <= -60)
        {
            return true;
        }
        return false;
    }
    public void Move()
    {
        DistanceFromLeft -= Speed;
    }
    public bool IsCentered()
    {
        bool hasEnteredCenter = DistanceFromLeft <= (500 / 2) + (60 / 2);
        bool hasExitedCenter = DistanceFromLeft <= (500 / 2) - (60 / 2) - 60;
        return hasEnteredCenter && !hasExitedCenter;
    }
}

