using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    AudioSource audioSource;
    private void Awake() {
        if(Instance == null){
            Instance = this;
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip){
        audioSource.PlayOneShot(clip);
    }
}
