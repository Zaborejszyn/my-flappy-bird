using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour {
    private Canvas deathCanvas;

    private void Awake() {
        deathCanvas = GameObject.Find("Death Canvas").GetComponent<Canvas>();
    }

    private void Start() {
    }

    private void Update() {
    }

    public void ShowRestartMenu() {
        deathCanvas.enabled = true;
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}