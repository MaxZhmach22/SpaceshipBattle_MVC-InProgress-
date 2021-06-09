namespace HellicopterGame
{
    public sealed class InputController : IExecute
    {
        private readonly IUserInputProxy _horizontal;
        private readonly IUserInputProxy _vertical;
        private readonly IUserInputProxy _fireButton;
        
        public InputController((IUserInputProxy inputHorizontal, IUserInputProxy inputVertical, IUserInputProxy fireButton) input)
        {
            _horizontal = input.inputHorizontal;
            _vertical = input.inputVertical;
            _fireButton = input.fireButton;
        }

        public void Execute(float deltaTime)
        {
            _horizontal.GetAxis();
            _vertical.GetAxis();
            _fireButton.GetAxis();
        }
    }
}