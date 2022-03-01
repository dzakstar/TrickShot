namespace TrickShot
{
    public class Probe
    {
        public Velocity Velocity { get; private set; }
        public Position Position { get; private set; }
        public Trench Target { get; }
        public bool HasHitTarget { get; private set; }

        public Probe(Velocity initialVelocity, Trench target)
        {
            Velocity = initialVelocity;
            Target = target;
            Position = new Position(0,0);
        }

        public Probe NextStep()
        {
            Position = GetNewPosition();
            Velocity = GetNewVelocity();
            HasHitTarget = CheckForTargetHit();
            return this;
        }

        protected bool CheckForTargetHit()
        {
            return Target != null && Target.WillBeHit(Position);
        }

        protected Position GetNewPosition()
        {
            int newX = Position.X + Velocity.X;
            int newY = Position.Y + Velocity.Y;
            return new Position(newX, newY);
        }

        protected int GetNewHorizontalVelocity(int horizontalVelocity)
        {
            if (horizontalVelocity == 0)
            {
                return 0;
            }
            if (horizontalVelocity < 0)
            {
                return ++horizontalVelocity;
            }
            return --horizontalVelocity;
        }

        protected int GetNewVerticalVelocity(int verticalVelocity)
        {
            return --verticalVelocity;
        }

        protected Velocity GetNewVelocity()
        {
            int newHorizontalVelocity = GetNewHorizontalVelocity(Velocity.X);
            int newVerticalVelocity = GetNewVerticalVelocity(Velocity.Y);

            return new Velocity(newHorizontalVelocity, newVerticalVelocity);
        }
    }
}
