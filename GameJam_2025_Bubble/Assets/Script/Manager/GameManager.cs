using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController player;

    private void Start() {
        player = FindAnyObjectByType<PlayerController>();
    }

    private void Update() {
        
    }

}
