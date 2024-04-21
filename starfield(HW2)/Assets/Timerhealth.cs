using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timerhealth : MonoBehaviour {

    public Slider healthBarSlider;      //reference for slider

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {

        healthBarSlider.value -= Time.deltaTime*1;  //reduce health

        if(healthBarSlider.value==0)// 시간이 0이 되면
        {
            SceneManager.LoadScene("loss");
        }
        
    }

    // 게임오브젝트가트리거와충돌시호출
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            healthBarSlider.value += 1;
        }
        if (other.tag == "Redcoin")
        {
            healthBarSlider.value += 5;
            GameObject go = GameObject.Find("RedcoinCount") as GameObject;
            go.GetComponent<RedcoinCount>().Puls(); // ItemCount의 함수 호출
        }
        if (other.tag == "Star")
        {
            healthBarSlider.value += 20;
            GameObject go = GameObject.Find("StarCount") as GameObject;
            go.GetComponent<StarCount>().Puls(); // ItemCount의 함수 호출
        }
    }

}
