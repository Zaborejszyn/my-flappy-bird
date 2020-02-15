using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour {
    public GameObject ground;
    private GameObject newGround;
    
    void Start() {
        newGround = Instantiate(ground);
    }

    void Update() {
        if (newGround.transform.position.x <= 0.011f) {
            newGround = Instantiate(ground);
        }
    }
}