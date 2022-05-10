using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameSetterCanvas : MonoBehaviour
{
    [SerializeField] private TMP_InputField _input;

    private void Awake()
    {
        _input.onSubmit.AddListener(_input_onSubmit);
    }

    private void _input_onSubmit(string text)
    {
       PlayerNameTracker.SetName(text); 
    }
}
