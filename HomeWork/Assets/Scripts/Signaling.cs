using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Signaling : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached;
    [SerializeField] Animator _otherObjectAnimator;
    
    public bool IsPlaying;
    
    private AudioSource _audioSource;
    private float delay;


    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        IsPlaying = false;
        delay = 0.01f;
    }

    private IEnumerator StartSignaling()
    {
        _otherObjectAnimator.SetBool("Alerm", true);

        while (IsPlaying)
        {
            for (float i = 0; i < 1; i += delay)
            {
                _audioSource.volume += Mathf.MoveTowards(0,1,delay);
                yield return null;
            }

            for (float i = 1; i > 0; i -= delay)
            {
                _audioSource.volume -= Mathf.MoveTowards(0,1,delay);
                yield return null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            _reached.Invoke();
            IsPlaying = true;
            StartCoroutine(StartSignaling());
        }
    }
}
