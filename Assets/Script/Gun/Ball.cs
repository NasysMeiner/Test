using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    private float _timeFlight;
    private BallStock _ballStock;
    private Rigidbody _rigidbody;

    private bool _isStock = true;

    public bool IsStock => _isStock;

    public void Init(float timeFlight, BallStock ballStock)
    {
        _timeFlight = timeFlight;
        _ballStock = ballStock;
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void SetVelocity(Vector3 speed)
    {
        _rigidbody.velocity = speed;
    }

    public void SetKinematic()
    {
        _rigidbody.isKinematic = true;
        StopCoroutine(ReturnInStock());
    }

    public void SetNotKinematic()
    {
        _rigidbody.isKinematic = false;
    }

    public void GetOutStock()
    {
        _isStock = false;
        StartCoroutine(ReturnInStock());
    }

    private IEnumerator ReturnInStock()
    {
        yield return new WaitForSeconds(_timeFlight);

        _isStock = true;
        _ballStock.ReturnBall(this);
    }
}
