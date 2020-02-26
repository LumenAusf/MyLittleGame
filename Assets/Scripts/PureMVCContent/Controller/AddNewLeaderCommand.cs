using PureMVC.Interfaces;
using PureMVC.Patterns;
using PureMVCContent.Model;

namespace PureMVCContent.Controller
{
    public class AddNewLeaderCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            var a = notification.Body as LeaderModel;
            var proxy = MyFacade.Instance.RetrieveProxy(LeadersProxy.NAME) as LeadersProxy;
            proxy.AddLeader(a);
        }
    }
}