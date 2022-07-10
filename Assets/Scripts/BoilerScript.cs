using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoilerScript : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider;

    [SerializeField] private GameObject taskMenu;

    public int temperature;
    public int minTemperature;
    public int maxTemperature;

    private PlayerMovement intPlayer;
    private bool playerColliding;

    private bool taskOn;

    private int nextUpdate = 1;

    // Start is called before the first frame update
    void Start()
    {
        minTemperature = 293;
        maxTemperature = 473;
        temperature = Random.Range(294, 313);

        playerColliding = false;
        taskOn = false;

        taskMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerColliding == true && intPlayer.interacting == true)
        {
            StartTask();
        }

        if(Time.time >= nextUpdate)
        {
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            UpdateEverySecond();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            intPlayer = collision.gameObject.GetComponent<PlayerMovement>();
            playerColliding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerColliding = false;
        }
    }

    private void StartTask()
    {
        intPlayer.inTask = true;
        taskOn = true;
        taskMenu.SetActive(true);
        taskMenu.GetComponent<BoilerTask>().TaskStartup();
    }

    public void StopTask()
    {
        intPlayer.inTask = false;
        taskOn = false;
    }

    private void UpdateEverySecond()
    {
        if(taskOn == false && temperature < maxTemperature)
        {
            temperature += 1;
        }
    }
}
