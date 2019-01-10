using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsHelper : MonoBehaviour {


    public static SoundEffectsHelper Instance;

    public AudioClip playerShotSound;
    
    void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("Multiple instances of SoundEffectsHelper!");
        }
        Instance = this;
    }

    private void MakeSound(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }

    public void MakePlayerShotSound()
    {
        MakeSound(playerShotSound);
    }
}
