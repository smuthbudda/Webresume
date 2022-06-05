namespace Webresume;

public class BirdModel
{
    public int DistanceFromGround { get; private set; } = 150;
    public int JumpStrength { get; private set; } = 30;

    public void Fall(int gravity)
    {
        DistanceFromGround -= gravity;
    }
    public bool BirdOnGround()
    {
        if(DistanceFromGround == 0)
        {
            return true;
        }
        return false;
    }
    public void Jump()
    {
        if(DistanceFromGround <= 530)
        {
            DistanceFromGround += JumpStrength;
        }
        
    }
}
