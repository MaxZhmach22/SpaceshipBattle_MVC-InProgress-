using System;
using UnityEngine;

namespace HellicopterGame
{
    internal sealed class PCInputHorizontal : IUserInputProxy
    {
        public event Action<float> AxisOnChange;
        public void GetAxis()
        {
            AxisOnChange.Invoke(Input.GetAxis(AxisManager.HORIZONTAL));
        }
    }
}