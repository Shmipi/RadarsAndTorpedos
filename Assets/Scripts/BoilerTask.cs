using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoilerTask : MonoBehaviour
{

    [SerializeField] BoilerScript boilerScript;

    private int coolerOffset;
    private int thisOffset;

    // Start is called before the first frame update
    void Start()
    {
        coolerOffset = Random.Range(1, 300);
        thisOffset = Random.Range(100, 200);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TempUp()
    {
        thisOffset += 1;
    }

    public void TempDown()
    {
        thisOffset -= 1;
    }

    public void ExitScreen()
    {
        if (thisOffset == coolerOffset)
        {
            boilerScript.temperature = boilerScript.minTemperature;
            Debug.Log("Temperature stabilized " + boilerScript.temperature);
        }
        else
        {
            Debug.Log("Temperature not stabilized" + boilerScript.temperature);
        }

        boilerScript.StopTask();
        gameObject.SetActive(false);
    }
}