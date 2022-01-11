using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MobMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _powerJump;

    private Rigidbody2D _rigidbody2D;
    private Transform _transform;
    private int _direction;
    private float _timer;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= 2)
        {
            _direction = Random.Range(-1,2);
            _timer = 0;
        }
        _transform.position = Vector3.MoveTowards(_transform.position,Vector3.right, _speed * Time.deltaTime * _direction);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out Ground ground))
        {
            _rigidbody2D.AddForce(new Vector2(0,_powerJump));
        }
    }
}