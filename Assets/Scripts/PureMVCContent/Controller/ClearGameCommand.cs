using PureMVC.Interfaces;
using PureMVC.Patterns;
using PureMVCContent.Model;

namespace PureMVCContent.Controller
{
    public class ClearGameCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            var proxy = MyFacade.Instance.RetrieveProxy(PlayerDataProxy.NAME) as PlayerDataProxy;
            proxy.Clear();
        }
    }
}