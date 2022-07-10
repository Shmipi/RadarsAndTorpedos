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

    // Start is called before the first frame update
    void Start()
    {
        minTemperature = 293;
        maxTemperature = 373;
        temperature = Random.Range(294, 313);

        playerColliding = false;

        taskMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerColliding == true && intPlayer.interacting == true)
        {
            StartTask();
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
            intPlayer = null;
            playerColliding = false;
        }
    }

    private void StartTask()
    {
        intPlayer.inTask = true;
        taskMenu.SetActive(true);
    }

    public void StopTask()
    {
        intPlayer.inTask = false;
    }
}
