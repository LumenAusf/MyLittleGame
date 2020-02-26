using PureMVC.Interfaces;
using PureMVC.Patterns;
using PureMVCContent.Model;
using UnityEngine;

namespace PureMVCContent.Controller
{
    public class Play1SubCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            Debug.Log("Sub1");
            OtherDataProxy otherProxy = Facade.RetrieveProxy(OtherDataProxy.NAME) as OtherDataProxy;
            otherProxy.StartTry();
        }
    }
}