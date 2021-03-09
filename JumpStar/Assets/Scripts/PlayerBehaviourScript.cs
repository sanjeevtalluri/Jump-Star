using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private Slider powerBar;

    private float powerBarThreshold = 10.0f;
    private float powerBarCurrValue = 0f;

    private Animator playerAnim;
    private void Awake()
    {
        MakeInstance();
        myBody = GetComponent<Rigidbody2D>();
        powerBar = GameObject.Find("PowerBar").GetComponent<Slider>();
        powerBar.minValue = 0;
        powerBar.maxValue = 10;
        powerBar.value = powerBarCurrValue;
        playerAnim = GetComponent<Animator>();
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

            powerBarCurrValue += powerBarThreshold * Time.deltaTime;
            powerBar.value = powerBarCurrValue;

        }
    }

    private void Jump()
    {
        myBody.velocity = new Vector2(forceX, forceY);
        forceX = forceY = 0f;
        didJump = true;
        playerAnim.SetBool("jump", didJump);
        
        powerBarCurrValue = 0f;
        powerBar.value = powerBarCurrValue;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (didJump)
        {
            didJump = false;
            playerAnim.SetBool("jump", didJump);
            if (other.tag == "Platform")
            {
                if (GameManagerScript.instance != null)
                {
                    GameManagerScript.instance.CreateNewPlatformAndLerp(other.transform.position.x);
                }
                if (ScoreManagerScript.instance != null)
                {
                    ScoreManagerScript.instance.IncrementScore();
                }
            }     
        }
        if (other.tag == "Dead")
        {
            Debug.Log("in dead state");
            if (GameOverManager.instance != null)
            {
                Debug.Log("1");
                GameOverManager.instance.GameOverShowPanel();
            }
            else
            {
                Debug.Log("0");
            }
            Destroy(gameObject);
        }

    }
}
