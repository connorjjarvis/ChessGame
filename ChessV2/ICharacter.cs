namespace Chess
{
    public interface ICharacter : IMovable
    {
        int X { get; }
        int Y { get; }
        int LandminesHit { get; }
        int Lives { get; set; }
        void HitLandmine();
        bool isAlive();
    }
}