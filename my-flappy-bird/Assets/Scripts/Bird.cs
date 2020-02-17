﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Bird : MonoBehaviour {
    public float upForce = 200;
    private bool isDead;
    private bool onPipe;
    private Rigidbody2D rb;
    private Animator anim;
    private static readonly int IsDead = Animator.StringToHash("IsDead");
    private Vector2 lastVelocity;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Start() {
    }

    private void Update() {
        if (!isDead) {
            Vector2 vel = rb.velocity;
            float ang = Mathf.Atan2(vel.y, 10) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, ang));
            if (!onPipe) {
                if (IsTapped()) {
                    rb.velocity = Vector2.zero;
                    rb.AddForce(new Vector2(0, upForce));
                }
            }
        } else {
            if (IsTapped()) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void FixedUpdate() {
        lastVelocity = rb.velocity;
    }

    private bool IsTapped() {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) {
                return true;
            }
        }
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) {
            return true;
        }
        return false;
    }

    public bool GetIsDead() {
        return isDead;
    }

    public bool GetOnPipe() {
        return onPipe;
    }

    private void OnCollisionEnter2D(Collision2D other) {
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
        if (!isDead && !onPipe && other.gameObject.name.Equals("Pointer")) {
            ScoreText.Score++;
        } else {
            onPipe = true;
            anim.SetBool(IsDead, true);
        }
    }
}