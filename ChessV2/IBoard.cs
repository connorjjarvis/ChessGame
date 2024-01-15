namespace Chess
{
    public interface IBoard 
    {
        int boardSize { get; set; }
        bool CheckCell(int x, int y);
        bool IsLegalMove( int x, int y);
    }
}
