using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Stopwatch : MonoBehaviour
{
    [SerializeField] private StartBorder _startBorder;
    [SerializeField] private FinishBorder _finishBorder;
    [SerializeField] private TMP_Text _textTime;

    private bool _isStartTime = false;
    private float _time = 0;
    private float _finishTime = 0;

    public event UnityAction<float> Finish;

    private void OnEnable()
    {
        _startBorder.StartTime += OnStartTime;
        _finishBorder.StopTime += OnStopTime;
    }

    private void OnDisable()
    {
        _startBorder.StartTime -= OnStartTime;
        _finishBorder.StopTime -= OnStopTime;
    }

    private void Update()
    {
        if (_isStartTime)
            _time += Time.deltaTime;

        _textTime.text = Mathf.Round(_time).ToString();
    }

    private void OnStartTime()
    {
        _isStartTime = true;
    }

    private void OnStopTime()
    {
        _isStartTime = false;
        _finishTime = Mathf.Round(_time);
        Finish?.Invoke(_finishTime);
    }
}
