namespace HellicopterGame
{
    public interface IMover
    {
        public float Speed { get; }
        void Move(float deltaTime);
    }
}