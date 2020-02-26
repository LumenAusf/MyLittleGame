using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using PureMVCContent.Model;
using UnityEngine;

namespace PureMVCContent.View
{
    public class LeadersMediator : Mediator
    {
        public new const string NAME = "LeadersMediator";
        
        private LeadersView View;
        
        private LeadersProxy leadersData;
        
        private List<GameObject> LeadersItemsLists = new List<GameObject>();
        
        
        public LeadersMediator(object viewComponent) : base(NAME, viewComponent)
        {
            View = ((GameObject) ViewComponent).GetComponentInChildren<LeadersView>(true);
            Debug.Log("leaders mediator");
            leadersData = Facade.RetrieveProxy(LeadersProxy.NAME) as LeadersProxy;
            
            View.ButtonBack.onClick.AddListener(OnClickBack);
            View.ButtonClearLeaders.onClick.AddListener(OnClickClearLeaders);
            foreach (var leaderModel in leadersData.LeadersLists)
            {
                SendNotification(MyFacade.LEADER_ADDED, leaderModel);
            }
        }

        private void OnClickBack()
        {
            View.gameObject.SetActive(false);
        }

        private void OnClickClearLeaders()
        {
            SendNotification(MyFacade.LEADERS_CLEARED);
        }

        public override void HandleNotification(INotification notification)
        {
            switch (notification.Name)
            {
                case MyFacade.LEADERS_CLEARED:
                    DestroyAllItems();
                    break;
            }
        }

        public void Show()
        {
            View.gameObject.SetActive(true);
        }

        public override IList<string> ListNotificationInterests()
        {
            IList<string> list = new List<string> {MyFacade.LEADERS_CLEARED};

            return list;
        }
        
        public void DestroyAllItems()
        {
            foreach (var leadersItem in LeadersItemsLists)
            {
                Object.Destroy(leadersItem);
            }
        }
        
        public void AddItems(GameObject obj)
        {
            LeadersItemsLists.Add(obj);
        }

        public GameObject LeaderItem(int index)
        {
            return LeadersItemsLists[index];
        }

        public int LeadersItemsCount
        {
            get { return LeadersItemsLists.Count; }
        }

        public GameObject InstanceLeaderItem()
        {
            return GameObjectUtility.Instance.CreateGameObject(View.LeaderTemplate, View.ParentTransform);
        }

        public override void OnRegister()
        {
        }

        public override void OnRemove()
        {
        }
    }
}