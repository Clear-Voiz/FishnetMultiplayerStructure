using System;
using System.Collections;
using System.Collections.Generic;
using FishNet.Component.Animating;
using FishNet.Object;
using UnityEngine;

public class Animating : MonoBehaviour
{
    private Animator _anima;
    private NetworkAnimator _netAnima;

    private void Awake()
    {
        _anima = GetComponent<Animator>();
        _netAnima = GetComponent<NetworkAnimator>();
    }

    public void SetMoving(bool value)
    {
        _anima.SetBool("Moving",value);
    }
    
    public void Jump()
    {
        _netAnima.SetTrigger("Jump");
    }
}
