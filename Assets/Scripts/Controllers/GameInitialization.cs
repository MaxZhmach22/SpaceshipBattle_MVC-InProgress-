using System.Collections.Generic;
using UnityEngine;

namespace HellicopterGame
{
    public sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers, Data data)
        {
            Camera camera = Camera.main;
            var inputInitialization = new InputInitialization();
            var playerFactory = new PlayerFactory(data.Player);
            var playerInitialization = new PlayerInitialization(playerFactory, data.Player);
            var backgroundImage = new BackgroundMainImage(data);
            var dynamicStart = new BackgroundDynamicStars(data.LevelBackground);
            var weaponsListInitialization = new WeaponsListInit(data);
            var leftSpanPointInit = new SpawnPointsInit(data.SpawnPoints.LeftSpawnPoint);
            var centerSpanPointInit = new SpawnPointsInit(data.SpawnPoints.CenterpawnPoint);
            var rightSpanPointInit = new SpawnPointsInit(data.SpawnPoints.RightSpawnPoint);
            var viewServises = new ViewServices();
            var leftEnemyPool = new EnemyPool(10, leftSpanPointInit.GetSpwanPoint());
            var centerEnemyPool = new EnemyPool(10, centerSpanPointInit.GetSpwanPoint());
            var rightEnemyPool = new EnemyPool(10, rightSpanPointInit.GetSpwanPoint());
            controllers.Add(new BackgroundStaticStars(data.LevelBackground));
            controllers.Add(inputInitialization);
            controllers.Add(playerInitialization);
            controllers.Add(backgroundImage);
            controllers.Add(dynamicStart);
            controllers.Add(new BackgroundSpriteMover(backgroundImage.GetBackgroundImage(), dynamicStart.GetBackgroundStars(), data.LevelBackground.SpeedBackground, data.LevelBackground.SpeedSmallStars));
            controllers.Add(new InputController(inputInitialization.GetInput()));
            controllers.Add(new MoveController(inputInitialization.GetInput(), playerInitialization.GetPlayer(), data.Player));
            controllers.Add(new ShootingController(playerInitialization.GetPlayer(), data, weaponsListInitialization, viewServises));
            var enemy = leftEnemyPool.GetEnemy("Attack Aircraft");
            
            centerEnemyPool.GetEnemy("Attack Aircraft");
            rightEnemyPool.GetEnemy("Attack Aircraft");
            
           
        }
    }
}