using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    public GameObject prompt;
    public Text question;
    public Text remaining;
    public int counter;
    public string scene;
    public GameObject Answer;
    public GameObject door;
    private string codeCurrent;
    public string codeword;
    public string questoin;
    bool passed = false;
    bool counted = false;
    // Start is called before the first frame update
    void Start()
    {
        question.text = questoin;
        counter = System.Convert.ToInt32(remaining.text);
    }

    // Update is called once per frame
    void Update()
    {
        counter = System.Convert.ToInt32(remaining.text);
        if (passed == true)
        {
            if(counted != true)
            {
                counter -= 1;
                counted = true;
            }

        }

        if(counter == 0)
        {
            remaining.text = System.Convert.ToString(counter);
            question.text = question.text;
            SceneManager.LoadScene(scene);
        }
        else
        {
            remaining.text = System.Convert.ToString(counter);
            question.text = question.text;
            if (codeCurrent == codeword)
            {
                door.SetActive(false);
                Answer.SetActive(false);
                passed = true;
            }
            else if (codeCurrent != codeword && codeCurrent != " " && codeCurrent != null && codeCurrent != "Enter text.")
            {
                question.text = question.text + "| Incorrect";
            }
        }
        
    }

    public void ReadAsString(string code)
    {
        codeCurrent = code;
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            prompt.SetActive(false);
            Answer.SetActive(true);


        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        counted = false;
        passed = false;
    }
}
