using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBarrier : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (! other.CompareTag("Player") &&
            other.GetComponent<Pickup>().id == 0)
        {
            Destroy(other.gameObject);
            _animator.SetTrigger("hasWeapon");
        }
    }
}
