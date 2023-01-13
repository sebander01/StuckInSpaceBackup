using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchCounter : MonoBehaviour
{
    public string scene;
    public int Maxcounter;
    private int counter;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        counter = Maxcounter;
    }

    // Update is called once per frame
    void Update()
    {
        if(counter == 0)
        {
            SceneManager.LoadScene(scene);
        }
    }

    public void CountDown()
    {
        if(text.text == "")
        {
            counter -= 1;
            Debug.Log(counter);
        }
    }
}
