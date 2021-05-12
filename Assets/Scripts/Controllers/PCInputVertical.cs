using System;
using UnityEngine;

namespace HellicopterGame
{
    internal sealed class PCInputVertical : IUserInputProxy
    {
        public event Action<float> AxisOnChange;
        public void GetAxis()
        {
            AxisOnChange.Invoke(Input.GetAxis(AxisManager.VERTICAL));
        }
    }
}