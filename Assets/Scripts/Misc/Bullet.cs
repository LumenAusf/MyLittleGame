using System;
using PureMVCContent.View;
using UnityEngine;

namespace Misc
{
    public class Bullet : MonoBehaviour
    {
        public float TTL = 2;
        public int Damage = 1;
        public float Speed = 30;

        public DateTime start;

        public void Fire()
        {
            gameObject.SetActive(true);
            start = DateTime.UtcNow;
        }

        public void Update()
        {
            if (DateTime.UtcNow > start + TimeSpan.FromSeconds(TTL))
            {
                BulletOver();
                return;
            }

            transform.position += transform.forward * (Speed * Time.deltaTime);
        }

        public void BulletOver()
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        private void OnCollisionEnter(Collision other)
        {
            var a = other.gameObject.TryGetComponent(typeof(EnemyItem), out _);
            if(!a) return;
            BulletOver();
        }
    }
}