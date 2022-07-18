using System;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        bool isGetComponent = collision.gameObject.TryGetComponent(out CounterHP counter);
        if (isGetComponent)
            counter._currentHP -= 10;
        Debug.Log(isGetComponent);
    }
}
