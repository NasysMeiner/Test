using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abyss : MonoBehaviour
{
    [SerializeField] private Player _playerTransform;
    [SerializeField] private int _maxDamage = 1000;

    private void Update()
    {
        if (_playerTransform.transform.position.y <= transform.position.y)
            _playerTransform.TakeDamage(_maxDamage);
    }
}
