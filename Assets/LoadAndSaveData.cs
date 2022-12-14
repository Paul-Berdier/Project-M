using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadAndSaveData : MonoBehaviour
{
    public Text interactUI;
    private bool isInRange;
    private int health;

    public static LoadAndSaveData instance;
    void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            Save();
            isInRange = true;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            isInRange = true;
        }
    }
    
    void Save()
    {
        int health = PlayerPrefs.GetInt("Health");
        int shield = PlayerPrefs.GetInt("Shield");

        PlayerPrefs.SetInt("saveHealth",health);
        PlayerPrefs.SetInt("saveShield",shield);
    
        GetComponent<BoxCollider2D>().enabled = false;
        interactUI.enabled = false;
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        isInRange = false;
        interactUI.enabled = false;
    }
}
