using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameManager gameManager;

    [Header("UI")]
    [SerializeField] private TMP_Text air;

    private void Start() {
        gameManager = gameObject.GetComponent<GameManager>();
    }

    private void Update() {
        air.text = "Air : " + gameManager.player.health.ToString();
    }
}
