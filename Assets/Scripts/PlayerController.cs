using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;
    public GameOverController gameOverController;
    public Animator animator;
    public float speed;
    public float jump;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        Debug.Log("Player Controller Awake");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    public void KillPlayer()
    {
        Debug.Log("Player killed by enemy");
        gameOverController.PlayerDied();
        this.enabled = false;
    }



    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        moveCharacter(horizontal, vertical);
        playMovementAnimation(horizontal, vertical);

    }

    public void PickUpKey()
    {
        Debug.Log("Player Picked up the key");
        scoreController.IncreaseScore(5);
    }

    private void moveCharacter(float horizontal, float vertical)
    {
        //move character horizontally
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        //move character vertically
        if (vertical>0)
        {
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }
    }

    private void playMovementAnimation(float horizontal, float vertical)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        if(vertical > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }
}
