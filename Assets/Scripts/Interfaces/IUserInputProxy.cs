using System;

namespace HellicopterGame
{
    public interface IUserInputProxy
    {
        event Action<float> AxisOnChange; 
        void GetAxis(); 
    }
}