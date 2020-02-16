using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour {
    private float horizontalSpeed;
    private Bird bird;
    
    void Start() {
        horizontalSpeed = GameObject.Find("Background").GetComponent<Background>().horizontalSpeed;
        bird = GameObject.Find("Bird").GetComponent<Bird>();
    }
    
    void Update() {
        Transform transform1 = transform;
        if (!bird.GetIsDead()) {
            transform1.position += Vector3.left * (horizontalSpeed * Time.deltaTime);
            if (transform1.position.x <= -2) {
                Destroy(gameObject);
            }
        }
    }
}
