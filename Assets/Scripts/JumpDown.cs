using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDown : MonoBehaviour
{

    public GameObject Platform;
    private bool isOn;
    
    void Awake()
    {
        isOn = false;
    }

    void Start()
    {
        isOn = false;
    }

    void Update()
    {
        if(isOn && Input.GetKey("s")){
            Platform.GetComponent<BoxCollider2D> ().enabled = false;
            StartCoroutine(waitEnable());
        }
    }

    IEnumerator waitEnable()
    {
        yield return new WaitForSeconds(0.3f);

        Platform.GetComponent<BoxCollider2D> ().enabled = true;
    }

    void OnTriggerStay2D(Collider2D col){
        if(col.tag == "Player"){
            isOn = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Player"){
            isOn = false;
        }
    }
}