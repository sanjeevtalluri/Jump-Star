using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static SoundManagerScript instance;

    private static AudioClip jumpSound, playerDeathSound;
    private static AudioSource src;
    void Awake()
    {
        MakeInstance();
        jumpSound = Resources.Load<AudioClip>("JumpSound");
        playerDeathSound = Resources.Load<AudioClip>("PlayerDeathSound");
        src = GetComponent<AudioSource>();
    }

    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "jump":
                src.PlayOneShot(jumpSound);
                break;
            case "death":
                src.PlayOneShot(playerDeathSound);
                break;
        }
    }

    private void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
   
}
