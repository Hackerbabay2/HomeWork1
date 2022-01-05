using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SwitchAnimation : MonoBehaviour
{
    private Animator _animator;
    private const string Alerm = "Alerm";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        _animator.SetBool(Alerm, true);
    }

    public void StopAnimation()
    {
        _animator.SetBool(Alerm,false);
    }
}