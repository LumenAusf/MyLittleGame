using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using PureMVCContent.Model;
using UnityEngine;

namespace PureMVCContent.View
{
    public class NewLeaderMediator : Mediator
    {
        public new const string NAME = "NewLeaderMediator";

        private NewLeaderView View;

        PlayerDataProxy playerData;


        public NewLeaderMediator(object viewComponent) : base(NAME, viewComponent)
        {
            View = ((GameObject) ViewComponent).GetComponentInChildren<NewLeaderView>(true);
            // View.gameObject.SetActive(true);
            Debug.Log("new leader mediator");
            playerData = Facade.RetrieveProxy(PlayerDataProxy.NAME) as PlayerDataProxy;

            View.ButtonApply.onClick.AddListener(OnClickApply);
        }

        public void OnClickApply()
        {
            var data = View.FieldName.text;
            if (string.IsNullOrEmpty(data)) return;
            SendNotification(MyFacade.LEADER_ADDED, new LeaderModel(View.FieldName.text, playerData.GetScore()));
            View.gameObject.SetActive(false);
        }

        public override void HandleNotification(INotification notification)
        {
            switch (notification.Name)
            {
                case MyFacade.GAME_IS_DONE:
                    View.gameObject.SetActive(true);
                    View.Clear();
                    break;
                case MyFacade.PLAYER_REWARD_UPDATED:
                    View.SetReward(playerData.GetScore());
                    break;
            }
        }

        public override IList<string> ListNotificationInterests()
        {
            IList<string> list = new List<string>
            {
                MyFacade.PLAYER_REWARD_UPDATED,
                MyFacade.GAME_IS_DONE
            };

            return list;
        }

        public override void OnRegister()
        {
        }

        public override void OnRemove()
        {
        }
    }
}