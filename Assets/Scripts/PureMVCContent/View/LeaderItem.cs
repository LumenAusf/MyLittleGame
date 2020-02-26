using PureMVCContent.Model;
using UnityEngine;
using UnityEngine.UI;

namespace PureMVCContent.View
{
    public class LeaderItem : MonoBehaviour
    {
        public Text TextName;
        public Text TextScore;
        
        private LeaderModel model;

        public void InitItem(LeaderModel leader)
        {
            model = leader;
            TextName.text = model.Name;
            TextScore.text = model.Score.ToString();
        }
    }
}