using PureMVC.Interfaces;
using PureMVC.Patterns;
using PureMVCContent.Model;

namespace PureMVCContent.Controller
{
    public class ResetTriesCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            OtherDataProxy proxy = MyFacade.Instance.RetrieveProxy(OtherDataProxy.NAME) as OtherDataProxy;
            proxy.ResetTries();
        }
    }
}