using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Signaling : MonoBehaviour
{
    [SerializeField] private UnityEvent _signaling;
    private AudioSource _audioSource;
    private bool _isSignaling;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void StartSignaling()
    {
        _isSignaling = true;
        _audioSource.volume = 0;
        _audioSource.Play();
        StartCoroutine(Play());
    }

    public void StopSignaling()
    {
        _isSignaling = false;
        _audioSource.volume = 0;
        _audioSource.Stop();
        StopCoroutine(Play());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            _signaling.Invoke();
        }
    }

    private IEnumerator Play()
    {
        while (_isSignaling)
        {
            for (float i = 0; i < 1; i += 0.01f )
            {
                _audioSource.volume += Mathf.MoveTowards(0,1,0.01f);
                yield return null;
            }

            for (float i = 1; i > 0; i -= 0.01f)
            {
                _audioSource.volume -= Mathf.MoveTowards(0,1,0.01f);
                yield return null;
            }
        }
    }
}