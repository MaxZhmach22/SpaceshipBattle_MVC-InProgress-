using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HellicopterGame
{
    public sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers, MainData data)
        {
            Camera camera = Camera.main;
            var inputInitialization = new InputInitialization();
            var playerFactory = new PlayerFactory(data.Player);
            var playerInitialization = new PlayerInitialization(playerFactory, data.Player);
            var boundaries = new BoundariesOfApp(camera);
            var backgroundImage = new BackgroundMainImage(data);
            var dynamicStars = new BackgroundDynamicStars(data.LevelBackground);
            var weaponsListInitialization = new WeaponsListInit(data);
            var leftSpanPointInit = new SpawnPointsInit(data.SpawnPoints.LeftSpawnPoint);
            var centerSpanPointInit = new SpawnPointsInit(data.SpawnPoints.CenterpawnPoint);
            var rightSpanPointInit = new SpawnPointsInit(data.SpawnPoints.RightSpawnPoint);
            var viewServises = new ViewServices();
            var leftEnemyPool = new EnemyPool(leftSpanPointInit.GetSpwanPoint(), data.EnemyPoolsData);
            var centerEnemyPool = new EnemyPool(centerSpanPointInit.GetSpwanPoint(),data.EnemyPoolsData);
            var rightEnemyPool = new EnemyPool(rightSpanPointInit.GetSpwanPoint(),data.EnemyPoolsData);
            ServiceLocator.SetService<IService>(leftEnemyPool); 
            EnemyAddControllers(controllers, ServiceLocator.Resolve<IService>().GetPoolDictionary());
            EnemyAddControllers(controllers, rightEnemyPool.GetPoolDictionary());
            EnemyAddControllers(controllers, centerEnemyPool.GetPoolDictionary());
            var activator = new EnemyActivator(leftEnemyPool, centerEnemyPool, rightEnemyPool, data);
            controllers.Add(new BackgroundStaticStars(data.LevelBackground));
            controllers.Add(inputInitialization);
            controllers.Add(playerInitialization);
            controllers.Add(backgroundImage);
            controllers.Add(dynamicStars);
            controllers.Add(new BackgroundSpriteMover(backgroundImage.GetBackgroundImage(), dynamicStars.GetBackgroundStars(), data.LevelBackground.SpeedBackground, data.LevelBackground.SpeedSmallStars));
            controllers.Add(new InputController(inputInitialization.GetInput()));
            controllers.Add(new MoveController(inputInitialization.GetInput(), playerInitialization.GetPlayer(), data.Player, boundaries.ScreenBounds));
            controllers.Add(new ShootingController(playerInitialization.GetPlayer(), data, weaponsListInitialization, viewServises));
            controllers.Add(activator);
            new ChainOfPespInit(playerInitialization.GetPlayer()); //?????? ChainOfResponsobility
        }

        private void EnemyAddControllers(Controllers controllers, Dictionary<string, Queue<Enemy>> poolDictionary)
        {
            foreach (var queue in poolDictionary.Values)
            {
                foreach (var enemy in queue)
                {
                    if (enemy is AttackAircraft attackAircraft)
                    {
                        controllers.Add(attackAircraft);
                    }

                    if (enemy is BomberAircraft bomberAircraft)
                    {
                        controllers.Add(bomberAircraft);
                    }

                    if (enemy is CruisAircraft cruisAircraft)
                    {
                        controllers.Add(cruisAircraft);
                    }
                }
            }
        }
    }
}