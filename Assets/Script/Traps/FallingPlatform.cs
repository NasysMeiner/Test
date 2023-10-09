using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

[RequireComponent(typeof(BoxCollider))]
public class FallingPlatform : MonoBehaviour
{
    [SerializeField] private float _activateTime = 2f;
    [SerializeField] private float _activeTime = 1f;
    [SerializeField] private float _cooldownTime = 5f;
    [SerializeField] private MeshRenderer _mesh;
    [SerializeField] private Color _standertColor;
    [SerializeField] private Color _activateColor;
    [SerializeField] private Color _activeColor;

    private BoxCollider _boxCollider;
    private bool _isActivate = true;
    private Player _player;

    private void OnDisable()
    {
        StopCoroutine(Disappear());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Player player))
        {
            _player = player;

            if (_isActivate)
                StartCoroutine(Disappear());
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            _player = null;
        }
    }

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    private IEnumerator Disappear()
    {
        _isActivate = false;
        _mesh.material.color = _activateColor;

        yield return new WaitForSeconds(_activateTime);

        _mesh.material.color = _activeColor;

        yield return new WaitForSeconds(_activeTime);

        _mesh.enabled = false;
        _boxCollider.enabled = false;
        _mesh.material.color = _standertColor;

        yield return new WaitForSeconds(_cooldownTime);

        _mesh.enabled = true;
        _boxCollider.enabled = true;
        _isActivate = true;

        if (_player != null)
            StartCoroutine(Disappear());
    }
}
