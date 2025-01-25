using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public bool canSpawnHere = false;
    [SerializeField] private GameObject target;
    private PlayerController player;
    private AreaItem area;

    private void Awake() {
        if(canSpawnHere || player) spawn();
    }

    private void Update() {
        if(!canSpawnHere) return;

        if(!player) player = FindAnyObjectByType<PlayerController>();
        if(!area) area = FindAnyObjectByType<AreaItem>();

        if(player.health <= 0) spawn();
    }

    public void spawn()
    {
        target.gameObject.transform.position = gameObject.transform.position;
        try{
            player.healthReset();
            area.activeItem();
            player.movement._stop = false;
            player.stop_HealthDecreed = false;
        }
        catch{}
        StartCoroutine(spawnDelay());
        Debug.Log("Spawn");
    }

    public void assignTarget(GameObject target){
        this.target = target;
    }

    public void setSpawn(bool _bool){
        canSpawnHere = _bool;
    }

    IEnumerator spawnDelay(){
        canSpawnHere = false;
        yield return new WaitForSeconds(2f);
        canSpawnHere = true;
    }
}
