using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour {
    public float upForce = 200;
    private bool isDead;
    public Rigidbody2D rb;
    public Animator anim;
    private static readonly int IsDead = Animator.StringToHash("IsDead");
    private Vector2 lastVelocity;
    public GameObject pipes;

    void Start() {
        //Debug.Log(pipes.GetComponentsInChildren<Collider2D>()[1] + "; " + GetComponent<Collider2D>());
        //Physics2D.IgnoreCollision(GameObject.Find("Pipes(Clone)").GetComponentsInChildren<Collider2D>()[1], GetComponent<Collider2D>());
    }

    void Update() {
        Vector2 vel = rb.velocity;
        float ang = Mathf.Atan2(vel.y, 10) * Mathf.Rad2Deg;
        transform.root.rotation = Quaternion.Euler(new Vector3(0, 0, ang));
        if (!isDead) {
            if (IsTapped()) {
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(0, upForce));
            }
        } else {
            if (IsTapped()) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
    
    private void FixedUpdate() {
        lastVelocity = rb.velocity;
        //Physics2D.IgnoreCollision(GameObject.Find("Pipes(Clone)").GetComponentsInChildren<Collider2D>()[1], GetComponent<Collider2D>());
    }
    
    private bool IsTapped() {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) {
                return true;
            }
        }
        if (Input.GetMouseButtonDown(0)) {
            return true;
        }
        return false;
    }

    public bool GetIsDead() {
        return isDead;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name.Equals("Upper pipe") || other.gameObject.name.Equals("Lower pipe")) {
            Debug.Log("Hello pipe");
            //Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        if (!isDead) {
            if (other.gameObject.name.Equals("Ground")) {
                rb.AddForce(new Vector2(Mathf.Abs(lastVelocity.y) * 15, 15));
                rb.AddTorque(lastVelocity.y + 3);
            }
        }
        isDead = true;
        anim.SetBool(IsDead, true);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        isDead = true;
        anim.SetBool(IsDead, true);
    }
}