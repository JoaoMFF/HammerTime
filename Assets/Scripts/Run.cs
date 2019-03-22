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
    public GameObject[] Errors;

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

            if(Error == "" && SceneManager.GetActiveScene().name == "L1"){
                SceneManager.LoadScene("L2", LoadSceneMode.Single);
            }
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
