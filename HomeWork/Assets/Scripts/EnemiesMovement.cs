using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemiesMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;

    private Rigidbody2D _rigidbody2D;
    private int _direction;
    private float _timer;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= 3)
        {
            _direction = Random.Range(-1,2);
            _timer = 0;
        }
        transform.Translate(_speed * Time.deltaTime * _direction,0,0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            _rigidbody2D.AddForce(new Vector2(0,_jumpPower));
        }
    }
}