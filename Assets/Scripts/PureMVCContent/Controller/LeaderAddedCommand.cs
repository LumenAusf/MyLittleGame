using PureMVC.Interfaces;
using PureMVC.Patterns;
using PureMVCContent.Model;
using PureMVCContent.View;

namespace PureMVCContent.Controller
{
    public class LeaderAddedCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            LeadersMediator leaders = MyFacade.Instance.RetrieveMediator(LeadersMediator.NAME) as LeadersMediator;
            if (leaders != null)
            {
                var itemObject = leaders.InstanceLeaderItem();
                var item = itemObject.GetComponentInChildren<LeaderItem>(true);
                item.InitItem(notification.Body as LeaderModel);
                itemObject.SetActive(true);
                leaders.AddItems(itemObject);
            }
        }
    }
}