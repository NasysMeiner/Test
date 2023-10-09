using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealPoint : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _healPointText;
    [SerializeField] private Image _healPointImage;

    private void OnEnable()
    {
        _player.ChangeHealPoint += ViewHealPoint;
    }

    private void OnDisable()
    {
        _player.ChangeHealPoint -= ViewHealPoint;
    }

    private void ViewHealPoint(int maxHealPoint, int currentHealPoint)
    {
        ViewImageHealPoint(maxHealPoint, currentHealPoint);
        ViewTextHealPoint(maxHealPoint, currentHealPoint);
    }

    private void ViewImageHealPoint(int maxHealPoint, int currentHealPoint)
    {
        _healPointImage.fillAmount = (float)currentHealPoint / maxHealPoint;
    }

    private void ViewTextHealPoint(int maxHealPoint, int currentHealPoint)
    {
        _healPointText.text = $"{currentHealPoint}/{maxHealPoint}";
    }
}
