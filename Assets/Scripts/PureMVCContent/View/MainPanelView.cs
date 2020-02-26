using UnityEngine;
using UnityEngine.UI;

namespace PureMVCContent.View
{
    public class MainPanelView : MonoBehaviour
    {
        public Text TextLivesCount;
        public Button ButtonResetLives;
        public Button ButtonPlay;
        public Button ButtonLeaders;
        public Button ButtonExit;

        public void UpdateLives(int lives)
        {
            TextLivesCount.text = lives.ToString();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}