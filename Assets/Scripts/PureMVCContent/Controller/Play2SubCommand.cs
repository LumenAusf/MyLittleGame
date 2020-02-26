using PureMVC.Interfaces;
using PureMVC.Patterns;
using PureMVCContent.Model;
using PureMVCContent.View;
using UnityEngine;

namespace PureMVCContent.Controller
{
    public class Play2SubCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            Debug.Log("Sub2");
            GameMediator mediator = Facade.RetrieveMediator(GameMediator.NAME) as GameMediator;

            int id = (int) notification.Body;
            
            LevelProxy levelProxy = Facade.RetrieveProxy(LevelProxy.NAME) as LevelProxy;
            EnemyProxy enemyProxy = Facade.RetrieveProxy(EnemyProxy.NAME) as EnemyProxy;
            var level = levelProxy.LevelsLists[id];

            foreach (var enemy in level.Enemies)
            {
                var a = mediator.InstanceEnemyItem();
                var aa = a.GetComponentInChildren<EnemyItem>(true);
                aa.UpdateItem(enemyProxy.GetEnemy(enemy.EnemyId));
                a.transform.position = new Vector3(enemy.EnemyPosX * 3, 1.5f,enemy.EnemyPosY * 3);
                a.SetActive(true);
                aa.Destroyed += () => SendNotification(MyFacade.ENEMY_DESTROYED, aa);
                mediator.AddItems(aa);
            }

            mediator.Show();
        }
    }
}