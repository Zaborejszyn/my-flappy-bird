using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {
    private float horizontalSpeed;
    private Bird bird;
    private Vector3 startPosition;
    
    void Start() {
        horizontalSpeed = GameObject.Find("Background").GetComponent<Background>().horizontalSpeed;
        bird = GameObject.Find("Bird").GetComponent<Bird>();
        startPosition = transform.position;
    }

    void Update() {
        Transform transform1 = transform;
        if (!bird.GetIsDead()) {
            
            float newPosition = Mathf.Repeat(horizontalSpeed * Time.time, 1.68f);
            transform1.position = startPosition + Vector3.left * newPosition;
        }
    }
}
