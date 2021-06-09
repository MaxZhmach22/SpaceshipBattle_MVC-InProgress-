namespace HellicopterGame
{
    public interface ILateExecute: IController
    {
        void LateExecute(float deltaTime);
    }
}