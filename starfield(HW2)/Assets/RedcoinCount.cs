using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RedcoinCount : MonoBehaviour
{

    private Text redcoinText;
    private int currentRedcoin=0;

    public GameObject Star2;



    // Use this for initialization
    void Start()
    {
        redcoinText = GetComponent<Text>();
        Star2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
            redcoinText.text = "모은 레드 코인:" + currentRedcoin;
    }

    // 레드 코인 흭득시 개수 증가
    public void Puls()
    {
        currentRedcoin += 1;
    }

    //레드코인 모으면 별 등장
    void OnGUI()
    {


        if (currentRedcoin == 4)
        {
            Star2.SetActive(true);
        }
        if (currentRedcoin < 4)
        {
            Star2.SetActive(false);
        }
    }

}
