using UnityEngine;

namespace HellicopterGame
{
    public sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers, Data data)
        {
            Camera camera = Camera.main;
            var inputInitialization = new InputInitialization();
            var level = new LevelInitialization(data);
            controllers.Add(inputInitialization);
            controllers.Add(new InputController(inputInitialization.GetInput()));
            controllers.Add(new MoveController(inputInitialization.GetInput(), level.GetPlayer(), data.Player));
            controllers.Add(new PlaneShift());

        }
    }
}