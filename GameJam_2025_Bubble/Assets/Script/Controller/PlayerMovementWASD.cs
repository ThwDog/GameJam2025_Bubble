using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementWASD : PlayerMovement
{
    [Header("Setting")]
    public float water_power = 2f;
    [SerializeField] private float maxHeight;


    public override void move()
    {
        Vector3 move = new Vector3(control.movement.x,control.movement.y,0);
        if(move.sqrMagnitude > 1.0f)
            move.Normalize();
        if(move.x != 0){
            rb.AddForce(new Vector3(control.movement.x,0,0) * player.current_speed * Time.deltaTime,ForceMode.Impulse);
        }

        if(move.y != 0 == false){
            // gravity_realistic(1);
            gravity_custom();
        }
        else{
            // if(transform.position.y > maxHeight) return;
            rb.AddForce(new Vector3(0,control.movement.y,0) * (player.current_speed) * Time.deltaTime,ForceMode.Impulse);
        }
    }

    public override void action(){

    }

    public override void passive(){
        base.passive();
        rb.AddForce(-transform.up * water_power, ForceMode.Force);
    }
}
