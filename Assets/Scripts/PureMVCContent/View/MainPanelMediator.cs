using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using PureMVCContent.Model;
using UnityEngine;

namespace PureMVCContent.View
{
    public class MainPanelMediator : Mediator
    {
        public new const string NAME = "MainPanelMediator";

        private MainPanelView View;

        OtherDataProxy otherData;


        public MainPanelMediator(object viewComponent) : base(NAME, viewComponent)
        {
            View = ((GameObject) ViewComponent).GetComponent<MainPanelView>();
            View.gameObject.SetActive(true);
            Debug.Log("panel mediator");
            otherData = Facade.RetrieveProxy(OtherDataProxy.NAME) as OtherDataProxy;

            View.ButtonPlay.onClick.AddListener(OnClickPlay);
            View.ButtonLeaders.onClick.AddListener(OnClickLeaders);
            View.ButtonResetLives.onClick.AddListener(OnClickResetLives);
            View.ButtonExit.onClick.AddListener(OnClickExit);
            View.UpdateLives(otherData.OtherData.LivesCurrent);
        }

        private void OnClickExit()
        {
            SendNotification(MyFacade.EXIT);
        }

        private void OnClickResetLives()
        {
            SendNotification(MyFacade.RESET_TRIES);
        }

        private void OnClickLeaders()
        {
            SendNotification(MyFacade.SHOW_LEADERS);
        }

        public void OnClickPlay()
        {
            Debug.Log("start game");
            SendNotification(MyFacade.PLAY, otherData.GetCurrentLevel());
        }

        public override void HandleNotification(INotification notification)
        {
            switch (notification.Name)
            {
                case MyFacade.OTHER_DATA_UPDATED:
                    View.UpdateLives(((OtherDataModel) notification.Body).LivesCurrent);
                    break;
                case MyFacade.PLAY:
                    View.Hide();
                    break;
                case MyFacade.GAME_IS_DONE:
                    View.gameObject.SetActive(true);
                    break;
            }
        }

        public override IList<string> ListNotificationInterests()
        {
            IList<string> list = new List<string>
            {
                MyFacade.OTHER_DATA_UPDATED,
                MyFacade.PLAY,
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