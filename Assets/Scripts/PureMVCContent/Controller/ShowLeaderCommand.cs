using PureMVC.Interfaces;
using PureMVC.Patterns;
using PureMVCContent.View;
using UnityEngine;

namespace PureMVCContent.Controller
{
    public class ShowLeaderCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            LeadersMediator mediator = Facade.RetrieveMediator(LeadersMediator.NAME) as LeadersMediator;
            // if (mediator == null) {
            //     GameObject obj = GameObjectUtility.Instance.CreateGameObject ("Prefabs/LeadersView");
            //     mediator = new LeadersMediator (obj);
            //     Facade.RegisterMediator (mediator);
            // }
            mediator.Show();
        }
    }
}