using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsMenu : MonoBehaviour
{

    public GameObject statMenu;
    public bool isOpen;
    
    // Start is called before the first frame update
    void Start()
    {
        statMenu.SetActive(false);
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) {
            if (isOpen)
            {
                CloseStatMenu();
            }
            else
            {
                OpenStatMenu();
            }


        }

    }


    public void OpenStatMenu() {
        statMenu.SetActive(true);
        isOpen = true;
    }

    public void CloseStatMenu()
    {
        statMenu.SetActive(false);
        isOpen = false;
    }
}
