using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealPoints = 100;
    [SerializeField] private Animator _animator;

    private int _currentHealPoints;
    private string _nameTrigger = "Damage";

    public event UnityAction DeadPlayer;
    public event UnityAction<int, int> ChangeHealPoint;

    private bool _isLive => _currentHealPoints > 0 ? true : false;

    private void Start()
    {
        _currentHealPoints = _maxHealPoints;
        ChangeHealPoint?.Invoke(_maxHealPoints, _currentHealPoints);
    }

    public void TakeDamage(int damage)
    {
        if (_currentHealPoints > 0)
        {
            _currentHealPoints -= damage;
            _animator.SetTrigger(_nameTrigger);
        }

        if (_isLive == false)
            DeadPlayer?.Invoke();

        ChangeHealPoint?.Invoke(_maxHealPoints, _currentHealPoints);
    }

}
