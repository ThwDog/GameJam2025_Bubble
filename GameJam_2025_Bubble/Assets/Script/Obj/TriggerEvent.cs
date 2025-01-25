using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    [SerializeField] private KeyCode key = KeyCode.Return;

    public UnityEvent onEnter;
    public UnityEvent onStay;
    public UnityEvent onExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")){
            onEnter.Invoke();
            Debug.Log("Enter");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player")){
            if (Input.GetKeyUp(key))
            {
                onStay.Invoke();
                Debug.Log("Stay");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")){
            onExit.Invoke();
            Debug.Log("Exit");
        }
    }
}
