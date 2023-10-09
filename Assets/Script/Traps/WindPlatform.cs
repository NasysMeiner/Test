using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class WindPlatform : MonoBehaviour
{
    [SerializeField] private float _windPower;
    [SerializeField] private float _timeChangeDirectionWind = 2;
    [SerializeField] private GameObject _prticle;
    [SerializeField] private List<Quaternion> _quaternions = new List<Quaternion>() { Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 180, 0), Quaternion.Euler(0, -90, 0), Quaternion.Euler(0, 90, 0) };
    [SerializeField] private List<Vector3> _directions = new List<Vector3>() { new Vector3(0, 0, 1), new Vector3(0, 0, -1), new Vector3(-1, 0, 0), new Vector3(1, 0, 0) };

    private Movement _movement;
    private int _randomNumber;

    private Vector3 _currentDirectionWind;

    private Vector3 _directionWind => _directions[_randomNumber];
    private Quaternion _quaternion => _quaternions[_randomNumber];

    private void OnDisable()
    {
        StopCoroutine(ChageDirectionWind());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Movement movement))
        {
            _movement = movement;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Movement movement))
        {
            _movement = null;
        }
    }

    private void Start()
    {
        StartCoroutine(ChageDirectionWind());
    }

    private void FixedUpdate()
    {
        WindMove();
    }

    private void WindMove()
    {
        if (_movement != null)
            _movement.Rigidbody.AddForce(_windPower * _currentDirectionWind, ForceMode.Impulse);
    }

    private IEnumerator ChageDirectionWind()
    {
        while (true)
        {
            GenerateRandomNumber();
            _currentDirectionWind = _directionWind;
            _prticle.transform.rotation = _quaternion;

            yield return new WaitForSeconds(_timeChangeDirectionWind);
        }
    }

    private void GenerateRandomNumber()
    {
        _randomNumber = UnityEngine.Random.Range(0, _directions.Count);
    }
}
