using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StarCount : MonoBehaviour
{

    private Text StarText;
    private int currentStar = 0;

    // Use this for initialization
    void Start()
    {
        StarText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        StarText.text = "흭득한 별: " + currentStar;
        if(currentStar==3)
        {
            SceneManager.LoadScene("Win");
        }
    }

    // 레드 코인 흭득시 개수 증가
    public void Puls()
    {
        currentStar += 1;
    }

}
