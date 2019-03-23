using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Run : MonoBehaviour
{
    private bool isOn;
    private GameObject ErrorMessage;
    private SingleError singleError;
    private GameObject OutputText;
    private GameObject[] Errors;
    public GameObject Level1;
    public GameObject Level2;

    // Start is called before the first frame update
    void Start()
    {
        isOn = false;

        OutputText = GameObject.Find("OutputText");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isOn && Input.GetKey(KeyCode.LeftControl)){
            string Error = GetErrors();

            OutputText.GetComponent<UnityEngine.UI.Text> ().text = Error;

            if(Error == "" && Level1.active){
                Level1.SetActive(false);
                Level2.SetActive(true);
            }
            /* 
            else if(Error == "" && Level1.SetActive(true)){
                Level1.SetActive(false);
                Level2.SetActive(true);
            }
            */
        }
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

    string GetErrors()
    {
        Errors =  GameObject.FindGameObjectsWithTag("Error");
        foreach (GameObject error in Errors) 
        {
            singleError = error.GetComponent<SingleError>();
            if(!singleError.isCorrect){
                return singleError.errorMessage;
            }
        }
        return "";
    }
}
