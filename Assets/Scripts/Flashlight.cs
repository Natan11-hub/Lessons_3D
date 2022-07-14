using System;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace 
{
    public class Flashlight : MonoBehaviour
    {
        [SerializeField] private GameObject flashlight;
        private bool checkIs = true;

        private void Update()
        {
            IsActive();
        }

        private void IsActive()
        {
            if (Input.GetKeyDown(KeyCode.F))
                if (checkIs == true)
                {
                    flashlight.SetActive(true);
                    checkIs = false;
                }
                else
                {
                    flashlight.SetActive(false);
                    checkIs = true;
                }
        }
    }
}