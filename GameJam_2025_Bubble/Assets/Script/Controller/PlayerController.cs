using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    internal PlayerMovement movement;
    [Header("Control")]
    [Range(0,100)] public float health = 100f;
    [SerializeField] private float healthDecreedTime = 1f;
    [Range(0,1000)] public float speed;
    internal float current_speed;
    public bool stop_HealthDecreed = false;

    private Vector3 defaultScale;


    private void Start() {
        movement = GetComponent<PlayerMovement>();
        speedReset();
        defaultScale = gameObject.transform.localScale;
        StartCoroutine(startDelay());
    }

    private void Update() {
        // Debug.Log(checkHealthStage());

        objSize();

        if(health <= 0) {
            stop_HealthDecreed = true;
        }
    }

    private void FixedUpdate() {
        movement.movement();
    }

    public int checkHealthStageRevert(){
        int i = (int)health / 25;

        switch (i){
            case 4:
                return 1;
            case 3:
                return 2;
            case 2:
                return 3;
            case 1:
                return 4;
            default:
                return 4;
        }
    }

    public void speedReset(){
        current_speed = speed;
    }

    public void healthReset(){
        health = 100;
    }

    public void objSize(){
        gameObject.transform.localScale = (defaultScale * 2) / (checkHealthStageRevert() / 1.5f);
        if(gameObject.transform.localScale.x > defaultScale.x) gameObject.transform.localScale = defaultScale;
    }

    IEnumerator healthDecreed(){
        if(!stop_HealthDecreed) health = Mathf.Clamp(health - 2.5f,0,health);
        if(health <= 0) health = 0;
        yield return new WaitForSeconds(healthDecreedTime);
        StartCoroutine(healthDecreed());
    }

    IEnumerator startDelay(){
        yield return null;
        StartCoroutine(healthDecreed());
    }

    public void setStopDecreed(bool _bool){
        stop_HealthDecreed = _bool;
    }
}
