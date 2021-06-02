using System;
using System.Collections.Generic;
using System.Linq;
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
            var boundaries = new Boundaries(camera);
            var backgroundImage = new BackgroundMainImage(data);
            var dynamicStart = new BackgroundDynamicStars(data.LevelBackground);
            var weaponsListInitialization = new WeaponsListInit(data);
            var leftSpanPointInit = new SpawnPointsInit(data.SpawnPoints.LeftSpawnPoint);
            var centerSpanPointInit = new SpawnPointsInit(data.SpawnPoints.CenterpawnPoint);
            var rightSpanPointInit = new SpawnPointsInit(data.SpawnPoints.RightSpawnPoint);
            var viewServises = new ViewServices();
            var leftEnemyPool = new EnemyPool(leftSpanPointInit.GetSpwanPoint(), data.EnemyPoolsData);
            var centerEnemyPool = new EnemyPool(centerSpanPointInit.GetSpwanPoint(),data.EnemyPoolsData);
            var rightEnemyPool = new EnemyPool(rightSpanPointInit.GetSpwanPoint(),data.EnemyPoolsData);
            EnemyAddControllers(controllers, leftEnemyPool.GetDictionary());
            EnemyAddControllers(controllers, rightEnemyPool.GetDictionary());
            EnemyAddControllers(controllers, centerEnemyPool.GetDictionary());
            var activator = new EnemyActivator(leftEnemyPool, centerEnemyPool, rightEnemyPool);
            controllers.Add(new BackgroundStaticStars(data.LevelBackground));
            controllers.Add(inputInitialization);
            controllers.Add(playerInitialization);
            controllers.Add(backgroundImage);
            controllers.Add(dynamicStart);
            controllers.Add(new BackgroundSpriteMover(backgroundImage.GetBackgroundImage(), dynamicStart.GetBackgroundStars(), data.LevelBackground.SpeedBackground, data.LevelBackground.SpeedSmallStars));
            controllers.Add(new InputController(inputInitialization.GetInput()));
            controllers.Add(new MoveController(inputInitialization.GetInput(), playerInitialization.GetPlayer(), data.Player, boundaries.ScreenBounds));
            controllers.Add(new ShootingController(playerInitialization.GetPlayer(), data, weaponsListInitialization, viewServises));
            controllers.Add(activator);

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