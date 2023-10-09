using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defeat : MonoBehaviour
{
    [SerializeField] private GameObject _defeatPanel;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.DeadPlayer += ViewDefeat;
    }

    private void OnDisable()
    {
        _player.DeadPlayer -= ViewDefeat;
    }

    private void ViewDefeat()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
        _defeatPanel.SetActive(true);
    }
}
