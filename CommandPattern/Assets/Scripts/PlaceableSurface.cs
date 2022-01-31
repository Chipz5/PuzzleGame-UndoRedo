using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//surface on which cubes can be placed
public class PlaceableSurface : MonoBehaviour
{
    Camera mainCam;
    RaycastHit hitInfo;
    public Transform platformPrefab;

    void Awake()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out hitInfo, Mathf.Infinity))
            {
                if (hitInfo.collider.gameObject.tag == "Water" || hitInfo.collider.gameObject.tag == "Fire")
                {
                    Color c = new Color(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f));
                    ICommand command = new PlaceObjectCommand(hitInfo.point, c, platformPrefab);
                    CommandInvoker.AddCommand(command);
                }

            }
        }
    }
}
