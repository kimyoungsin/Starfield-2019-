using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Cannon : MonoBehaviour {

    private AudioSource audio;
    public AudioClip shootSound; // shoot 음원

    public GameObject bulletcreate; //총알이 생성되는 장소
    public Transform fireposition; // 총알을 생성하여 위치시키는 장소

	void Start () {
        // GameObject에<AudioSource> component 추가.
        this.audio = this.gameObject.AddComponent<AudioSource>();
        // 반복재생을않도록설정.
        this.audio.loop = false;
    }
	
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            GameObject bullet = Instantiate(bulletcreate);
            bullet.transform.position = fireposition.position;
            bullet.transform.forward = fireposition.forward;

            this.audio.clip = this.shootSound;
            this.audio.Play(); // audio clip에들어있는음원을재생.
        }
    }

    
}
