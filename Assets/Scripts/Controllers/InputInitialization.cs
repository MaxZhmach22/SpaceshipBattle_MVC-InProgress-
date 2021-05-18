
using UnityEngine;

namespace HellicopterGame
{
    internal sealed class InputInitialization : IInitialization
    {
        private IUserInputProxy _pcInputHorizontal; 
        private IUserInputProxy _pcInputVertical;
        private IUserInputProxy _pcInputFireButton;
        
        public InputInitialization() 
        {
            if (Application.platform == RuntimePlatform.Android) 
            {
                _pcInputHorizontal = new MobileInput(); 
            }
            _pcInputHorizontal = new PCInputHorizontal();
            _pcInputVertical = new PCInputVertical();
            _pcInputFireButton = new PCInputFireButton();
        }

        public void Initialization()
        {
        }
        
        public (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical, IUserInputProxy inputFireButton) GetInput() 
        {
            (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical, IUserInputProxy inputFireButton) result = (_pcInputHorizontal, _pcInputVertical, _pcInputFireButton);
            return result;
        }
    }
}