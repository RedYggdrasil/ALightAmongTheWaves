using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceShipModule : MonoBehaviour
{
    public GridSystem moduleGridSystem;

    public GameObject[] modulePrefab = new GameObject[4];

    GameObject modulePhantom;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseInWorldSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (modulePhantom != null)
            {
                Destroy(modulePhantom);
                modulePhantom = null;
            }
            modulePhantom = GameObject.Instantiate(modulePrefab[0], transform);
            modulePhantom.GetComponent<SpriteRenderer>().sortingOrder = 1;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (modulePhantom != null)
            {
                Destroy(modulePhantom);
                modulePhantom = null;
            }
            modulePhantom = GameObject.Instantiate(modulePrefab[1], transform);
            modulePhantom.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (modulePhantom != null)
            {
                Destroy(modulePhantom);
                modulePhantom = null;
            }
            modulePhantom = GameObject.Instantiate(modulePrefab[2], transform);
            modulePhantom.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (modulePhantom != null)
            {
                Destroy(modulePhantom);
                modulePhantom = null;
            }
            modulePhantom = GameObject.Instantiate(modulePrefab[3], transform);
            modulePhantom.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }


        if (moduleGridSystem.IsInBoat(mouseInWorldSpace) && modulePhantom != null)
        {
            modulePhantom.transform.position = moduleGridSystem.GetPositionForCellIndex(moduleGridSystem.GetCellIndexFromPosition(mouseInWorldSpace));
            
            if (!moduleGridSystem.CanPLaceModule(moduleGridSystem.GetCellIndexFromPosition(mouseInWorldSpace), modulePhantom.GetComponent<ShipModule>().moduleSize))
                modulePhantom.GetComponent<SpriteRenderer>().color = new Color(0.9f, 0.3f, 0.3f, 0.5f);
            else
                modulePhantom.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);

        }

        if (Input.GetMouseButtonDown(0))
        {
            if (modulePhantom != null && moduleGridSystem.IsInBoat(mouseInWorldSpace) &&
                moduleGridSystem.CanPLaceModule(moduleGridSystem.GetCellIndexFromPosition(mouseInWorldSpace), modulePhantom.GetComponent<ShipModule>().moduleSize))
            {
                modulePhantom.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                modulePhantom.GetComponent<SpriteRenderer>().sortingOrder = 0;
                moduleGridSystem.PutGameObjectOnPosition(modulePhantom, mouseInWorldSpace);
                modulePhantom = null;
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Destroy(modulePhantom);
            modulePhantom = null;
        }
    }

    
}
