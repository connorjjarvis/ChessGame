namespace Chess
{
    public interface IMovable
    {
        int X { get; }
        int Y { get; }
        int LandminesHit { get; }
        int Lives { get; set; }
        bool Move(char direction);
        void HitLandmine();
        bool isAlive();
    }
}