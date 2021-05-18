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
            var backgroundImage = new BackgroundMainImage(data);
            var dynamicStart = new BackgroundDynamicStars(data.LevelBackground);
            controllers.Add(new BackgroundStaticStars(data.LevelBackground));
            controllers.Add(inputInitialization);
            controllers.Add(backgroundImage);
            controllers.Add(dynamicStart);
            controllers.Add(new BackgroundSpriteMover(backgroundImage.GetBackgroundImage(), dynamicStart.GetBackgroundStars(), data.LevelBackground.SpeedBackground, data.LevelBackground.SpeedSmallStars));
            controllers.Add(new InputController(inputInitialization.GetInput()));
            controllers.Add(new MoveController(inputInitialization.GetInput(), level.GetPlayer(), data.Player));
        }
    }
}