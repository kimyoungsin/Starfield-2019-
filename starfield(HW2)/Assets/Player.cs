using UnityEngine;
using System.Collections;
[RequireComponent(typeof(CharacterController))]

public class Player : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

    private AudioSource audio;
    public AudioClip jumpSound; // jump 음원
    public AudioClip jumpblockSound; // jump블럭 음원
    public AudioClip coinSound; // 코인 흭득시 음원
    public AudioClip starSound; // 스타 흭득시 음원
    public AudioClip exitSound; // 맵 탈출 시 음원

    public GameObject Playerp;
    public Transform Respwanposition; // 총알을 생성하여 위치시키는 장소

    void Start()
    {
        // GameObject에<AudioSource> component 추가.
        this.audio = this.gameObject.AddComponent<AudioSource>();
        // 반복재생을않도록설정.
        this.audio.loop = false;
    }

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>(); // 캐릭터 콘트롤러 
        if (controller.isGrounded)// 땅에 있으면
        { 
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); // 전후좌우 조정
            moveDirection = transform.TransformDirection(moveDirection); // 월드좌표로 축을 바꿈
            moveDirection *= speed;  // 움직임 속도를 제어
            if (Input.GetButton("Jump")) // 점프 버튼
            {
                moveDirection.y = jumpSpeed;  // 점프
                this.audio.clip = this.jumpSound;
                this.audio.Play(); // audio clip에들어있는음원을재생.
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;  // y값 중력 가속도
        controller.Move(moveDirection * Time.deltaTime); 
    }

    // 게임오브젝트가트리거와충돌시호출
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            Destroy(other.gameObject);
            this.audio.clip = this.coinSound;
            this.audio.Play(); 
        }
        if (other.tag == "Redcoin")
        {
            Destroy(other.gameObject);
            this.audio.clip = this.coinSound;
            this.audio.Play();
        }
        if (other.tag == "Star")
        {
            Destroy(other.gameObject);
            this.audio.clip = this.starSound;
            this.audio.Play();
        }
        if (other.tag == "Jumpblock") // 점프블럭 밟으면 점프
        {
            moveDirection.y = 20;
            this.audio.clip = this.jumpblockSound;
            this.audio.Play();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Deadzone") // 데스존에 닿으면 처음 위치로
        {
            this.Playerp.transform.position = Respwanposition.position;
            moveDirection.y = 0;
            moveDirection.x = 0;
            moveDirection.z = 0;
            this.audio.clip = this.exitSound;
            this.audio.Play(); 
        }
    }

}