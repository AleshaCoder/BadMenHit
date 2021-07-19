using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePeople : MonoBehaviour
{
    public enum GeneratingWay
    {
        Time,
        Sex
    }

    [SerializeField] private Planet _planet;
    [SerializeField] private GameObject _human;
    [Space]

    [Header("Type of generating")]
    [SerializeField] private GeneratingWay _generatingWay;

    [Space]
    [Header("Time Generator Settings")]
    [SerializeField] private float _timeOfGeneration = 5;
    private int _maxPeople = 0;
    [SerializeField] private bool _randomTime = false;
    [SerializeField] private float _deltaTime = 0;
    private float _currentDeltaTime = 0;
    private float _waitingTime => _randomTime ? _timeOfGeneration + _currentDeltaTime : _timeOfGeneration;
    private IEnumerator _waitingCoroutine;

    private bool _canGenerate => !Menu.Active;


    private float RandomDeltaTime()
    {
        return Random.Range(-_deltaTime, _deltaTime);
    }

    private void GenerateHuman()
    {
        if (_canGenerate == true)
        {
            var angle = Random.Range(0, 360);
            var x = Mathf.Cos(angle) * _planet.Radius;
            var y = Mathf.Sin(angle) * _planet.Radius;
            var position = new Vector3(x, y, default) + _planet.Position;
            var newHuman = Instantiate(_human, position, Quaternion.identity);
            newHuman.transform.up = newHuman.transform.position - _planet.gameObject.transform.position;
            newHuman.transform.parent = _planet.transform;
            var sprite = newHuman.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
            sprite.sortingOrder = _maxPeople + 1;

            _maxPeople += 1;
        }
        StopCoroutine(_waitingCoroutine);
        _currentDeltaTime = RandomDeltaTime();
        _waitingCoroutine = WaitForGeneration();
        StartCoroutine(_waitingCoroutine);
    }

    private IEnumerator WaitForGeneration()
    {
        float currentTime = 0;
        while (currentTime < _waitingTime)
        {
            currentTime += 1;
            yield return new WaitForSeconds(1);
        }
        GenerateHuman();
    }

    private void Start()
    {
        if (_generatingWay == GeneratingWay.Time)
        {
            _waitingCoroutine = WaitForGeneration();
            StartCoroutine(_waitingCoroutine);
        }
    }
}
