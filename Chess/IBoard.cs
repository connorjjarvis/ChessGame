namespace Chess
{
    public interface IBoard
    {
        bool CheckLandmine(int x, int y);
        bool IsLegalMove(int x, int y);
    }
}
