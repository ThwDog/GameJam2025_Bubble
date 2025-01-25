using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementFloat : PlayerMovement
{
    [Header("setting")]
    [SerializeField][Range(0f,10f)] private float jump_Delay = 1.5f;
    [SerializeField][Range(0,100)] private float normalForce;
    [SerializeField] private float maxHeight;
    private float currentForce;

    
    private bool canJump = true;

    public override void Start() {
        base.Start();
        currentForce = normalForce;
    }

    public override void move()
    {
        if(control.jump != true){
            gravity_custom();
        }
        else{
            if(transform.position.y > maxHeight) return;
            if(canJump){
                StartCoroutine(delay(jump_Delay));
                rb.AddForce((transform.forward * currentForce) + (transform.up * player.current_speed),ForceMode.Impulse);
            }
        }
    }

    public override void passive()
    {
        base.passive();
    }

    private void healthLogic(){

    }

    IEnumerator delay(float delay){
        canJump = false;
        yield return new WaitForSeconds(delay);
        canJump = true;
    }
}
