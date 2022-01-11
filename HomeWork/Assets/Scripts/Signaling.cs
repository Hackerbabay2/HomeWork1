using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Signaling : MonoBehaviour
{
    [SerializeField] private UnityEvent _signaling;

    private AudioSource _audioSource;
    private Coroutine playSound;
    private bool _isSignaling;
    private float _delay;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _delay = 0.01f;
    }

    public void StartSignaling()
    {
        _isSignaling = true;
        _audioSource.volume = 0;
        _audioSource.Play();
        playSound = StartCoroutine(Play());
    }

    public void StopSignaling()
    {
        _isSignaling = false;
        _audioSource.volume = 0;
        _audioSource.Stop();

        if (playSound != null)
        {
            StopCoroutine(playSound);
        }
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
            for (float i = 0; i < 1; i += _delay )
            {
                _audioSource.volume += Mathf.MoveTowards(0,1,_delay);
                yield return null;
            }

            for (float i = 1; i > 0; i -= _delay)
            {
                _audioSource.volume -= Mathf.MoveTowards(0,1,_delay);
                yield return null;
            }
        }
    }
}