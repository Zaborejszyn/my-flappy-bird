using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundStartMenu : MonoBehaviour {
    private float horizontalSpeed;
    private Vector3 startPosition;

    private void Awake() {
        horizontalSpeed = GameObject.Find("Background").GetComponent<Background>().horizontalSpeed;
    }

    private void Start() {
        startPosition = transform.position;
    }

    private void Update() {
        Transform transform1 = transform;
        float newPosition = Mathf.Repeat(horizontalSpeed * Time.time, 1.68f);
        transform1.position = startPosition + Vector3.left * newPosition;
    }
}