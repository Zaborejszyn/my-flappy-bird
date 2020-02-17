using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipesSpawner : MonoBehaviour {
    public float waitTime;
    private float timer;
    public GameObject pipes;
    public float height;
    private Bird bird;

    private void Awake() {
        bird = GameObject.Find("Bird").GetComponent<Bird>();
    }

    private void Start() {
        if (Bird.GameStarted) {
            GameObject newPipes = Instantiate(pipes);
            newPipes.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
        }
    }

    private void Update() {
        if (Bird.GameStarted) {
            if (!bird.GetIsDead()) {
                if (timer > waitTime) {
                    GameObject newPipes = Instantiate(pipes);
                    newPipes.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
                    timer = 0;
                }
                timer += Time.deltaTime;
            }
        }
    }
}