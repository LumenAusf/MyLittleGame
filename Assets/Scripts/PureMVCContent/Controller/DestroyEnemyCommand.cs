using PureMVC.Interfaces;
using PureMVC.Patterns;
using PureMVCContent.Model;
using PureMVCContent.View;
using UnityEngine;

namespace PureMVCContent.Controller
{
    public class DestroyEnemyCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            var a = notification.Body as EnemyItem;
            PlayerDataProxy proxy = MyFacade.Instance.RetrieveProxy(PlayerDataProxy.NAME) as PlayerDataProxy;
            proxy.GetReward(a.GetModel().Reward * Random.Range(0,100));
            GameMediator mediator = MyFacade.Instance.RetrieveMediator(GameMediator.NAME) as GameMediator;
            mediator.RemoveItem(a);
            Object.Destroy(a.gameObject);
        }
    }
}