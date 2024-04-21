using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip breaksound; // 나무상자박살내는 음원
    public AudioClip blocksound; // 퍼플 블럭과 부딫히는 음원

    public float speed;         // 총알 속도
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);

        // GameObject에<AudioSource> component 추가.
        this.audio = this.gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 게임오브젝트가트리거와충돌시호출
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            Destroy(other.gameObject);
            GameObject go = GameObject.Find("Player") as GameObject;
            go.GetComponent<Timerhealth>().OnTriggerEnter(other); // Timerhealth의 함수 호출
        }
        if (other.tag == "Redcoin")
        {
            Destroy(other.gameObject);
            GameObject go = GameObject.Find("Player") as GameObject;
            go.GetComponent<Timerhealth>().OnTriggerEnter(other); // Timerhealth의 함수 호출
        }
        if (other.tag == "Box")
        {
            this.audio.clip = this.breaksound;
            this.audio.Play();
            Destroy(other.gameObject);
            Destroy(gameObject);

            
        }
        if (other.tag == "Block")
        {

            this.audio.clip = this.blocksound;
            this.audio.Play();
        }
        if (other.tag == "Filed" || other.tag == "Deadzone")
        {

            Destroy(gameObject);
        }
    }
}
