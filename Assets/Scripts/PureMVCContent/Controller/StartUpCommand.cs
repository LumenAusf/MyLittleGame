using PureMVC.Interfaces;
using PureMVCContent.View;
using UnityEngine;

public class StartUpCommand : PureMVC.Patterns.SimpleCommand
{
    public override void Execute(INotification notification)
    {
        GameObject mainPanel = GameObjectUtility.Instance.CreateGameObject("Prefabs/MainPanelView");
        Facade.RegisterMediator(new MainPanelMediator(mainPanel));
        
        GameObject newLeader = GameObjectUtility.Instance.CreateGameObject("Prefabs/NewLeaderView");
        Facade.RegisterMediator(new NewLeaderMediator(newLeader));
        
        GameObject game = GameObjectUtility.Instance.CreateGameObject("Prefabs/GameView");
        Facade.RegisterMediator(new GameMediator(game));
        
        GameObject leaders = GameObjectUtility.Instance.CreateGameObject("Prefabs/LeadersView");
        Facade.RegisterMediator(new LeadersMediator(leaders));
    }
}