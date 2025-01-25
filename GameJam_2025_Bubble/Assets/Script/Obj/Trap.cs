using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour , IDamageable
{
    public TrapScriptable trap;

    private void OnTriggerEnter(Collider other) {
        if(other.TryGetComponent<PlayerController>(out PlayerController player)){
            hit(player);
        }
    }

    public void hit(PlayerController player)
    {
        player.health = Mathf.Clamp(player.health - trap.dmg, 0, player.health);
    }
}
