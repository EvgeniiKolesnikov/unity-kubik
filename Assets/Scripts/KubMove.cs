using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KubMove : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed = 5.0f;
    private UIFunctions uiFunctions;

    private void Awake()
    {
        rb = GetComponent < Rigidbody2D>();
    }
    // Use this for initialization
    void Start () {
        uiFunctions = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UIFunctions>();

    }

    // Update is called once per frame
    void Update () {
        if (uiFunctions.gameStarted == true)
        {
            float move = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(move * speed, rb.velocity.y);
        }
    }
}
