using System;
using UnityEngine;

public class CounterHP : MonoBehaviour
{
    public float _currentHP;
    private float _maxHP = 100;

    private void Start()
    {
        _currentHP = _maxHP;
    }

    private void OnGUI()
    {
        GUI.HorizontalSlider(new Rect(Screen.width / 4, Screen.height / 4, 100, 100), _currentHP, 0, _maxHP);
    }
}
