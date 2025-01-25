using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Heal : MonoBehaviour, IHealable , IResetable
{
    public HpItemScriptable hpItem;
    
    public UnityEvent useEvent; 
    public UnityEvent resetEvent; 


    private void OnTriggerEnter(Collider other) {
        if(other.TryGetComponent<PlayerController>(out PlayerController player)){
            HealPoint(player);
        }
    }

    public void _reset(){
        resetEvent.Invoke();
    }

    public void HealPoint(PlayerController player)
    {
        player.health = Mathf.Clamp(player.health + hpItem.HpPoint , player.health , 100);
        Debug.Log("Heal" + Mathf.Clamp(player.health + hpItem.HpPoint , player.health , 100));
        useEvent.Invoke();
    }
}
