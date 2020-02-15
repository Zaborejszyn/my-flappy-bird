using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesSpawner : MonoBehaviour {
    public float waitTime;
    private float timer;
    public GameObject pipes;
    public float height;
    private Bird bird;
    
    void Start() {
        bird = GameObject.Find("Bird").GetComponent<Bird>();
        GameObject newPipes = Instantiate(pipes);
        newPipes.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
    }

    void Update() {
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