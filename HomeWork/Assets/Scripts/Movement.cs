using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;

    private Transform _transform;
    private Rigidbody2D _rigidbody2D;
    private bool _isJump;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _transform.Translate(_speed * Time.deltaTime,0,0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _transform.Translate(-_speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.Space) && _isJump == false)
        {
            _isJump = true;
            _rigidbody2D.AddForce(new Vector2(0,_jumpPower));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out Ground ground))
        {
            _isJump = false;
        }
    }
}
