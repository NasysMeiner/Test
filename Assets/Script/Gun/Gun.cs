using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private BallStock _ballStock;
    [SerializeField] private float _angle = 45;
    [SerializeField] private float _timeToShot = 2;

    private Ball _currentBall;
    private float _g = Physics.gravity.y;
    private bool _isFire = true;
    private float _time = 0;

    private Vector3 _directionTarget => _targetPoint.position - _firePoint.position;

    private void FixedUpdate()
    {
        Vector3 directionNotY = new Vector3(_directionTarget.x, 0, _directionTarget.z);
        transform.rotation = Quaternion.LookRotation(directionNotY, Vector3.up);

        if (_isFire && _time >= _timeToShot)
        {
            TakeFire();
            _time = 0;
        }

        _time += Time.fixedDeltaTime;
    }

    private float CalculeitSpeed()
    {
        Vector3 directionNotY = new Vector3(_directionTarget.x, 0, _directionTarget.z);
        float x = directionNotY.magnitude;
        float y = _directionTarget.y;
        float angleRadian = _angle * Mathf.PI / 180;

        return Mathf.Sqrt(Mathf.Abs(_g * Mathf.Pow(x, 2) / (2 * (y - Mathf.Tan(angleRadian) * x) * Mathf.Pow(Mathf.Cos(angleRadian), 2))));
    }

    private void TakeFire()
    {
        _currentBall = _ballStock.SearchBall();

        if (_currentBall != null)
        {
            float speed = CalculeitSpeed();
            _currentBall.transform.position = _firePoint.position;
            _currentBall.SetNotKinematic();
            _currentBall.GetOutStock();
            _currentBall.SetVelocity(_firePoint.forward * speed);
        }
    }
}
