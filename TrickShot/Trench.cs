using System;

namespace TrickShot
{
    public class Trench
    {
        public Position TopLeft { get; }
        public Position BottomRight { get; }

        public Trench(Position topLeft, Position bottomRight)
        {
            //TODO: validate co-ordinates passed in
            TopLeft = topLeft ?? throw new ArgumentNullException(nameof(topLeft));
            BottomRight = bottomRight ?? throw new ArgumentNullException(nameof(bottomRight));
        }

        public bool WillBeHit(Position position)
        {
            if (position.X >= TopLeft.X && position.X <= BottomRight.X)
            {
                if (position.Y <= TopLeft.Y && position.Y >= BottomRight.Y)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
