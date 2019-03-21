using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    private bool isOn;
    private bool keyDown;
    // Start is called before the first frame update
    void Start()
    {
        keyDown = false;
        isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            keyDown = true;
        }

        if(isOn && keyDown){
            Debug.Log("RUN!");
        }
    }

    void LateUpdate(){
        keyDown = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Hammer"){
            isOn = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Hammer"){
            isOn = false;
        }
    }
}
