using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour {
    private Canvas deathCanvas;
    public Animator deathCanvasAnimator;
    private static readonly int DeathCanvas = Animator.StringToHash("DeathCanvas");

    private void Awake() {
        deathCanvas = GameObject.Find("Death Canvas").GetComponent<Canvas>();
    }

    private void Start() {
    }

    private void Update() {
    }

    public void ShowRestartMenu() {
        deathCanvas.enabled = true;
        deathCanvasAnimator.SetTrigger(DeathCanvas);
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}