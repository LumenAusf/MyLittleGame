using System;
using UnityEngine;

namespace PureMVCContent.View
{
    public class Portal : MonoBehaviour
    {
        public Action Enter = delegate {  };
        private void OnTriggerEnter(Collider other)
        {
            Enter.Invoke();
        }
    }
}