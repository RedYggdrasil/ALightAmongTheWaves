using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceShipModule : MonoBehaviour
{
    public GridSystem moduleGridSystem;

    public GameObject modulePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseInWorldSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                
        if (Input.GetMouseButtonDown(0))
        {
            if (moduleGridSystem.isInGrid(mouseInWorldSpace))
                moduleGridSystem.PutGameObjectOnPosition( GameObject.Instantiate(modulePrefab), mouseInWorldSpace);

        }
    }
}
