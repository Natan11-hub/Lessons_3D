using System;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class IKController : MonoBehaviour
    {
        [SerializeField] private Transform rightHandObj;
        [SerializeField] private Transform leftHandOnj;
        [SerializeField] private Transform wallTouch;
        [SerializeField] private Transform lookObj;
        
        private Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        private void OnAnimatorIK()
        {
            if (animator != null && Vector3.Distance(gameObject.transform.position, lookObj.position) < 2)
            {
                animator.SetLookAtWeight(1);
                animator.SetLookAtPosition(lookObj.position);
                if(lookObj == null)
                    animator.SetLookAtWeight(0);
            }

            if (Vector3.Distance(gameObject.transform.position, wallTouch.position) < 2)
            {
                if (rightHandObj != null)
                    MoveHand(AvatarIKGoal.RightHand, rightHandObj);
                if (leftHandOnj != null)
                    MoveHand(AvatarIKGoal.LeftHand, leftHandOnj);
            }
        }

        private void MoveHand(AvatarIKGoal targetGoal, Transform positionObject)
        {
            animator.SetIKPositionWeight(targetGoal, 1);
            animator.SetIKPosition(targetGoal, positionObject.position);
            animator.SetIKRotation(targetGoal, positionObject.rotation);
        }
    }
}