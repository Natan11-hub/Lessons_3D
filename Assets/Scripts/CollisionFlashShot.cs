using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class CollisionFlashShot : MonoBehaviour
    {
        [SerializeField] private GameObject lightBullet;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject)
            {
                lightBullet.SetActive(true);
                Destroy(gameObject, 2.0f);
            }
        }
    }
}