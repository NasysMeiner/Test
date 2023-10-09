using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Material))]
public class DamagePlatform : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _activationTime = 1;
    [SerializeField] private int _cooldownTime = 5;
    [SerializeField] private Color _standartColor;
    [SerializeField] private Color _activatedColor;
    [SerializeField] private Color _activeColor;
    [SerializeField] private MeshRenderer _mesh;

    private Player _player;

    private bool _isActivate = true;

    private void OnDisable()
    {
        StopCoroutine(Activeted());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Player player))
        {
            _player = player;

            if (_isActivate)
                StartCoroutine(Activeted());
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            _player = null;
        }
    }

    private IEnumerator Activeted()
    {
        _isActivate = false;

        _mesh.material.color = _activatedColor;

        yield return new WaitForSeconds(_activationTime);

        _mesh.material.color = _activeColor;

        yield return new WaitForSeconds(1f / 5);

        if (_player != null)
            _player.TakeDamage(_damage);

        _mesh.material.color = _standartColor;

        yield return new WaitForSeconds(_cooldownTime);

        _isActivate = true;

        if(_player != null)
            StartCoroutine(Activeted());
    }
}
