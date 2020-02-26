using System.Collections.Generic;
using PureMVC.Patterns;
using UnityEngine;

namespace PureMVCContent.Model
{
    public class LeadersProxy : Proxy
    {
        public new static string NAME = "Leaders";
        public List<LeaderModel> LeadersLists = new List<LeaderModel>();
        
        public LeadersProxy(string proxyName)
            : base(proxyName)
        {
            Debug.Log("LeadersProxy create");
        }

        public void AddLeader(LeaderModel leader)
        {
            LeadersLists.Add(leader);
            SendNotification(MyFacade.LEADER_ADDED,  leader);
        }

        public void ClearLeaders()
        {
            LeadersLists.Clear();
            SendNotification(MyFacade.LEADERS_CLEARED);
        }

        public override void OnRegister()
        {
            base.OnRegister();
            Debug.Log("LeadersProxy OnRegister");
        }
        
        public override void OnRemove()
        {
            base.OnRemove();
            Debug.Log("LeadersProxy OnRemove");
        }
    }
}