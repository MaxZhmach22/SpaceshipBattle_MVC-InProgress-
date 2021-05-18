using UnityEngine;

namespace HellicopterGame
{
    public sealed class MoveController : IExecute, ICleanup
    {
        private readonly Transform _unit;
        private readonly IUnit _unitData;
        private float _horizontal;
        private float _vertical;
        private float _fire;
        private Vector3 _move;
        private IUserInputProxy _horizontalInputProxy;
        private IUserInputProxy _verticalInputProxy;
        private IUserInputProxy _fireInputProxy;

        public MoveController((IUserInputProxy inputHorizontal, IUserInputProxy inputVertical, IUserInputProxy fireInputProxy) input,
            Transform unit, IUnit unitData)
        {
            _unit = unit;
            _unitData = unitData;
            _horizontalInputProxy = input.inputHorizontal;
            _verticalInputProxy = input.inputVertical;
            _fireInputProxy = input.fireInputProxy;
            _horizontalInputProxy.AxisOnChange += HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange += VerticalOnAxisOnChange;
            _fireInputProxy.AxisOnChange += FireButtonOnChange;
        }

        private void VerticalOnAxisOnChange(float value)
        {
            _vertical = value;
        }

        private void HorizontalOnAxisOnChange(float value)
        {
            _horizontal = value;
        }

        private void FireButtonOnChange(float value)
        {
            _fire = value;
        }

        public void Execute(float deltaTime)
        {
            var speed = deltaTime * _unitData.Speed;
            _move.Set(_horizontal * speed, _vertical * speed, 0.0f);
            _unit.localPosition += _move;
            if (Input.GetMouseButton(1))
            {
                Debug.Log(_fire.ToString());
            }
        }

        public void Cleanup()
        {
            _horizontalInputProxy.AxisOnChange -= HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange -= VerticalOnAxisOnChange;
            _fireInputProxy.AxisOnChange -= FireButtonOnChange;
        }
    }
}