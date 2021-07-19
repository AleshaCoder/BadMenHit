using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlanet : MonoBehaviour
{
    [Range(-20.0f,20.0f)]
    [SerializeField] private float _speed = 1.0f;

    [Space]
    [SerializeField] private bool _randomSpeed = false;
    [Range(-10.0f, 10.0f)]
    [SerializeField] private float _deltaSpeed = 0.5f;
    [SerializeField] private float _speedChangeTime = 5f;
    [Range(0.0f, 15.0f)]
    [SerializeField] private float _deltaTime = 0f;
    [SerializeField] private People _people=null; //xmenbro

    private float _timeMoving = 0;
    private bool _moving => _timeMoving>0||_randomSpeed==false;

    private IEnumerator _mover;

    private void StartNewMoving()
    {
        _speed = _speed + _deltaSpeed * Random.Range(-1.0f, 1.0f);
        _timeMoving = _speedChangeTime + Random.Range(-1.0f, 1.0f) * _deltaTime;
        _mover = Move();
        StartCoroutine(_mover);
    }

    public void ResetSpeed() => _speed = 0; //xmenbro

    private void Start()
    {
        StartNewMoving();
    }

    private IEnumerator Move()
    {
        while (_moving == true)
        {
            _timeMoving -= Time.deltaTime;
            transform.Rotate(0, 0, _speed * Time.deltaTime);
            yield return null;
        }
        StartNewMoving();
    }
}
