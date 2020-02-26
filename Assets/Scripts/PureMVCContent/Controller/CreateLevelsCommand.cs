using PureMVC.Interfaces;
using PureMVC.Patterns;
using PureMVCContent.Model;

namespace PureMVCContent.Controller
{
    public class CreateLevelsCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            EnemyProxy proxyEnemies = MyFacade.Instance.RetrieveProxy(EnemyProxy.NAME) as EnemyProxy;
            var enemy0 = new EnemyModel(0, 1, 1, 666);
            var enemy1 = new EnemyModel(1, 2, 2, 666);
            var enemy2 = new EnemyModel(2, 3, 3, 666);

            proxyEnemies.AddEnemy(enemy0);
            proxyEnemies.AddEnemy(enemy1);
            proxyEnemies.AddEnemy(enemy2);


            LevelProxy proxyLevels = MyFacade.Instance.RetrieveProxy(LevelProxy.NAME) as LevelProxy;


            var lvl0Enemies = new[]
            {
                new LevelEnemy(0, -2, -2),
                new LevelEnemy(0, 0, 0),
                new LevelEnemy(0, 2, 2)
            };
            var lvl0 = new LevelModel(0, lvl0Enemies);
            proxyLevels.AddLevel(lvl0);
            
            var lvl1Enemies = new[]
            {
                new LevelEnemy(1, -2, 0),
                new LevelEnemy(1, 0, 0),
                new LevelEnemy(1, 2, 0)
            };
            var lvl1 = new LevelModel(1, lvl1Enemies);
            proxyLevels.AddLevel(lvl1);
            
            var lvl2Enemies = new[]
            {
                new LevelEnemy(2, -2, 2),
                new LevelEnemy(2, 0, 0),
                new LevelEnemy(2, 2, -2)
            };
            var lvl2 = new LevelModel(2, lvl2Enemies);
            proxyLevels.AddLevel(lvl2);
        }
    }
}