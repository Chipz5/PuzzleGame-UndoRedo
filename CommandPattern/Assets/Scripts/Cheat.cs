using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour, IObserver
{
    bool isActive = true;
    public void OnNotify(int id)
    {
        if (id == 1)
            isActive = false;
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("cheat"))
        {
            GameObject.FindGameObjectWithTag("cheat").SetActive(isActive);
        }
        
        gameObject.SetActive(isActive);
    }
}
