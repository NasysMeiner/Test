using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStock : MonoBehaviour
{
    [SerializeField] private float _timeFlight = 6;
    [SerializeField] private Ball _prefabBall;
    [SerializeField] private int _ballsNumber = 10;

    private List<Ball> _balls = new List<Ball>();

    private void Start()
    {
        SpawnBall();
    }

    public void ReturnBall(Ball ball)
    {
        ball.SetKinematic();
        ball.transform.position = transform.position;
    }

    public Ball SearchBall()
    {
        foreach(Ball ball in _balls)
        {
            if(ball.IsStock)
                return ball;
        }

        return null;
    }

    private void SpawnBall()
    {
        for(int i = 0; i < _ballsNumber; i++)
        {
            Ball newBall = Instantiate(_prefabBall, transform);
            newBall.Init(_timeFlight, this);
            newBall.SetKinematic();
            _balls.Add(newBall);
        }
    }
}
