using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public sealed class CalculateScore : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    private readonly char[] _buffer = new char[5];

    private float _awakeTime;
    private int _lastSecondsSinceAwake;

    private void Awake()
    {
        _awakeTime = Time.realtimeSinceStartup;
    }

    private void Update()
    {
        var secondsSinceAwake = (int)(Time.realtimeSinceStartup - _awakeTime);
        if (_lastSecondsSinceAwake != secondsSinceAwake && Time.timeScale != 0)
        {
            _text.text = secondsSinceAwake.ToString("F0");
            _lastSecondsSinceAwake = secondsSinceAwake;
        }
    }
}
