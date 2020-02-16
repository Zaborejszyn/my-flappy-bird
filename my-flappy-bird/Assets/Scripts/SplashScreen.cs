using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour {
    public float splashSpeed;
    public SpriteRenderer sr;
    private Bird bird;
    private bool once;
    private float a;
    
    void Start() {
        bird = GameObject.Find("Bird").GetComponent<Bird>();
    }

    void Update() {
        if (bird.GetIsDead() || bird.GetOnPipe()) {
            if (a < 1 && !once) {
                a += Time.deltaTime * splashSpeed;
            } else {
                a -= Time.deltaTime * splashSpeed;
                if (a < 0) {
                    Destroy(gameObject);
                }
                once = true;
            }
            Color srColor = sr.color;
            sr.color = new Color(srColor.r, srColor.g, srColor.b, a);
        }
    }
}