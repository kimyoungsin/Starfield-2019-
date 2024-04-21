using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woodbox : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip breaksound; // 나무상자박살내는 음원

    void Start()
    {
        // GameObject에<AudioSource> component 추가.
        this.audio = this.gameObject.AddComponent<AudioSource>();
    }

    void OnDestroy()
    {
            this.audio.clip = this.breaksound;
            this.audio.Play();
    }
}
