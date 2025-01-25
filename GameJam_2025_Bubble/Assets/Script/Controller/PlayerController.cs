using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement movement;
    [Header("Control")]
    [SerializeField] [Range(0,100)] private float health = 100f;
    [SerializeField] private float healthDecreedTime = 1f;
    [Range(0,1000)] public float speed;


    private void Start() {
        movement = GetComponent<PlayerMovement>();
    }

    private void Update() {
        // Debug.Log(checkHealthStage());
    }

    private void FixedUpdate() {
        movement.move();
        movement.action();
        movement.passive();
    }

    public int checkHealthStage(){
        return (int)health / 25;
    }
}
