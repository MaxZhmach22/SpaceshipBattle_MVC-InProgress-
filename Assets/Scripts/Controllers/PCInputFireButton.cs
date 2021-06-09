using System;
using UnityEngine;

namespace HellicopterGame
{
    public class PCInputFireButton : IUserInputProxy
    {
        public event Action<float> AxisOnChange;
        public void GetAxis()
        {
            AxisOnChange.Invoke(Input.GetAxis(AxisManager.FIRE1));
        }
    }
}