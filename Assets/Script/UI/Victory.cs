using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Victory : MonoBehaviour
{
    [SerializeField] private Stopwatch _stopwatch;
    [SerializeField] private GameObject _victoryPanel;
    [SerializeField] private TMP_Text _timeText;

    private void OnEnable()
    {
        _stopwatch.Finish += ViewVictory;
    }

    private void OnDisable()
    {
        _stopwatch.Finish -= ViewVictory;
    }

    private void ViewVictory(float time)
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
        _victoryPanel.SetActive(true);
        _timeText.text = $"Ваше время: {time}";
    }
}
