using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text counter;
    private int counterN;
    public string scene;
    // Start is called before the first frame update
    void Start()
    {
        counterN = System.Convert.ToInt32(counter.text);
    }

    // Update is called once per frame
    void Update()
    {
        if(counterN != 0)
        {
            counterN -= 1;
            counter.text = System.Convert.ToString(counterN);
        }
        else
        {
            SceneManager.LoadScene(scene);
        }

    }
}
