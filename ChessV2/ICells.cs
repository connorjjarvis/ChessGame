using System;

namespace Chess
{
    public interface ICell
    {
        bool HasLandmine { get; set; }
        bool HasHealthPack { get; set; }
    }
    public class EmptyCell : ICell
    {
        public bool HasLandmine { get; set; } = false;
        public bool HasHealthPack { get; set; } = false;

    }
}
