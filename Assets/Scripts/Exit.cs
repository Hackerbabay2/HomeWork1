using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] private Animator _otherObjectAnimator;

    private Signaling _signaling;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponentInParent<AudioSource>();
        _signaling = GetComponentInParent<Signaling>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            _signaling.IsPlaying = false;
            _otherObjectAnimator.SetBool("Alerm", false);
            _audioSource.Stop();
        }
    }
}