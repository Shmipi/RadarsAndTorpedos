using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoilerTask : MonoBehaviour
{

    [SerializeField] private BoilerScript boilerScript;

    [SerializeField] private Text tempDisplay;
    [SerializeField] private Text offsetDisplay;
    [SerializeField] private Text status;
    [SerializeField] private Text thisOffsetDisplay;

    private int coolerOffset;
    private int thisOffset;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void TaskStartup()
    {
        coolerOffset = Random.Range(1, 300);
        thisOffset = Random.Range(100, 200);

        offsetDisplay.text = "C:/COOLER_OFFSET> " + coolerOffset;
        thisOffsetDisplay.text = " " + thisOffset;

        tempDisplay.text = "C:/CURRENT_TEMP> " + boilerScript.temperature;

        if (boilerScript.temperature >= 343)
        {
            status.text = "C:/CONDITION_STATUS> CRITICAL";
        }
        else
        {
            status.text = "C:/CONDITION_STATUS> STABLE";
        }
    }

    // Update is called once per frame
    void Update()
    {
        thisOffsetDisplay.text = " " + thisOffset;
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