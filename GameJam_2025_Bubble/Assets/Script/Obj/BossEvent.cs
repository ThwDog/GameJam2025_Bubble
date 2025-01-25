using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BossEvent : MonoBehaviour
{
    [SerializeField] private float playerPer = 50 , bossPer = 50; // percentPool Default value

    [SerializeField] private Slider playerBar , bossBar ;
    [SerializeField] private TMP_Text playerText , bossText ;
    [SerializeField] private GameObject pullingBar;
    [Header("setting")]
    [SerializeField] [Range(0f,100f)] private float bossPushDelay;
    bool IsPlaying;
    bool bossCanPush = true;
    bool playerCanPush = true;

    public UnityEvent winEvent;
    public UnityEvent loseEvent;

    private void OnEnable() {
        _Reset();
    }

    // private void OnDisable() {
    //     pullingBar.SetActive(false);
    //     _Reset();
    // }

    private void Update() {
        playerPer = Mathf.Clamp(playerPer, 0, 100);
        bossPer = Mathf.Clamp(bossPer,0,100);
        
        // playerBar.value = playerPer;
        // FishBar.value = fishPer;
        playerText.text = playerPer.ToString();
        bossText.text = bossPer.ToString();
        
        if(!IsPlaying) return;
        winCheck();
        
        if(playerCanPush){
            if(Input.GetKeyUp(KeyCode.Space)){
                pushNPull(ref playerPer,ref bossPer,5);
                StartCoroutine(playerPushDelay(0.5f));
            }
        }

        if(bossCanPush){
            pushNPull(ref bossPer,ref playerPer , 5f);
            StartCoroutine(fishPushDelay(bossPushDelay));
        }
    }

    private void winCheck(){
        if(playerPer >= 100 ) {
            // Debug.Log("player Win");
            playerPer = 100;
            IsPlaying = false;
            winEvent.Invoke();
        } 
        else if(bossPer >= 100){
            bossPer = 100;
            IsPlaying = false;
            loseEvent.Invoke();
            _Reset();
        }
    }

    IEnumerator playerPushDelay(float delay){
        playerCanPush = false;
        yield return new WaitForSeconds(delay);
        playerCanPush = true; 
    }

    IEnumerator fishPushDelay(float delay){
        bossCanPush = false;
        yield return new WaitForSeconds(delay);
        bossCanPush = true; 
    }

    // push is the side who is press space bar 
    private void pushNPull(ref float push,ref float pull, float value){
        // Debug.Log("Push N Pull");
        push += value;
        pull -= value;
    }

    private void _Reset(){
        playerPer = 50;
        bossPer = 50;
    }

    public void _SetPlaying(bool _bool){
        pullingBar.SetActive(true);
        IsPlaying = _bool;
    }
}