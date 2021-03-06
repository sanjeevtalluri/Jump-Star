using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBehaviourScript : MonoBehaviour
{
    public static PlayerBehaviourScript instance;
    private Rigidbody2D myBody;
    private bool jumpState;
    [SerializeField]
    private float forceX, forceY;

    private float tersholdX = 7f;
    private float tresholdY = 14f;
    private bool didJump;
    private void Awake()
    {
        MakeInstance();
        myBody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        SetJumpState();
    }
    private void MakeInstance()
    {
        instance = this;
    }
    public void SetJumpState(bool jumpState)
    {
        this.jumpState = jumpState;
        if (!jumpState)
        {
            Jump();
        }
    }
    private void SetJumpState()
    {
        if (jumpState)
        {
            forceX += tersholdX * Time.deltaTime;
            forceY += tresholdY * Time.deltaTime;

            if (forceX > 6.5f)
                forceX = 6.5f;

            if (forceY > 13.5f)
                forceY = 13.5f;

        }
    }

    private void Jump()
    {
        myBody.velocity = new Vector2(forceX, forceY);
        forceX = forceY = 0f;
        didJump = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (didJump)
        {
            didJump = false;
            if (other.tag == "Platform")
            {
                if (GameManagerScript.instance != null)
                {
                    GameManagerScript.instance.CreateNewPlatformAndLerp(other.transform.position.x);
                }
            }
        }

    }
}
