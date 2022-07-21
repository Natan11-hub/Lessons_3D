using System;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        private float forceJump;
        private Vector3 moveVector;

        private Animator m_Animator;
        private Rigidbody r_Rigidbody;
        private void Start()
        {
            m_Animator = GetComponent<Animator>();
        }

        private void Update()
        {
            MoveCharacter();
        }

        private void MoveCharacter()
        {
            moveVector.x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
            moveVector.z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        }
    }
}