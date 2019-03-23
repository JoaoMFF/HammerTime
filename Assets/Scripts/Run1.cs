using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Run1 : MonoBehaviour
{
    private bool isOn;
    private GameObject ErrorMessage;
    private SingleError1 singleError1;
    private GameObject OutputText;
    private GameObject[] Errors;
    public GameObject Level1;
    public GameObject Level2;

    // Start is called before the first frame update
    void Start()
    {
        isOn = false;

        OutputText = GameObject.Find("OutputText1");
        
        ErrorsDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        if(isOn && Input.GetKey(KeyCode.RightControl)){
            ErrorsDisplay();
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
        Errors =  GameObject.FindGameObjectsWithTag("Error2");
        foreach (GameObject error in Errors) 
        {
            singleError1 = error.GetComponent<SingleError1>();
            if(!singleError1.isCorrect){
                return singleError1.errorMessage;
            }
        }
        return "";
    }

    void ErrorsDisplay(){
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
