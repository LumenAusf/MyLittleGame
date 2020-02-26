using PureMVC.Interfaces;
using PureMVC.Patterns;
using PureMVCContent.View;

namespace PureMVCContent.Controller
{
    public class ShowLeaderCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            LeadersMediator mediator = Facade.RetrieveMediator(LeadersMediator.NAME) as LeadersMediator;
            mediator.Show();
        }
    }
}