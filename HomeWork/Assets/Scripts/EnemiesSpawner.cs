using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _path;

    private List<Transform> _points;
    private int _pointIndex;
    private float _timer;

    private void Start()
    {
        _points = new List<Transform>();

        if (_path.childCount > 0)
        {
            for (int i = 0; i < _path.childCount; i++)
            {
                _points.Add(_path.GetChild(i));
            }
        }
        else
        {
            Debug.Log("Нету спавн точек");
        }
    }

    private void Update()
    {
        if (_points.Count > 0)
        {
            _timer += Time.deltaTime;
        }

        if (_timer >= 2)
        {
            _timer = 0;
            _pointIndex = Random.Range(0, _points.Count);
            Instantiate(_enemy, new Vector3(_points[_pointIndex].position.x, _points[_pointIndex].position.y, 1), Quaternion.identity);
        }
    }
}