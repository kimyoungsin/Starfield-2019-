using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateflat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //회전
        this.transform.Rotate(60.0f * Time.deltaTime, 0.0f, 0.0f);
    }
}
