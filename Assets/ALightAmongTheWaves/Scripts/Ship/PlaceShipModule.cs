using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceShipModule : MonoBehaviour
{
    public GridSystem moduleGridSystem;

    public GameObject modulePrefab;

    public GameObject modulePhantom;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseInWorldSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (moduleGridSystem.IsInBoat(mouseInWorldSpace))
        {
            if(modulePhantom == null)
            {
                modulePhantom = GameObject.Instantiate(modulePrefab, transform);
                //modulePhantom.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            }

            modulePhantom.transform.position = moduleGridSystem.GetPositionForCellIndex(moduleGridSystem.GetCellIndexFromPosition(mouseInWorldSpace));

            if( moduleGridSystem.GetGameObjectFormCellIndex(moduleGridSystem.GetCellIndexFromPosition(mouseInWorldSpace)) != null)
                modulePhantom.GetComponent<SpriteRenderer>().color = new Color(0.9f, 0.3f, 0.3f, 0.5f);
            else
                modulePhantom.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);

        }
        
                
        if (Input.GetMouseButtonDown(0))
        {
            if (moduleGridSystem.IsInBoat(mouseInWorldSpace) && 
                moduleGridSystem.GetGameObjectFormCellIndex(moduleGridSystem.GetCellIndexFromPosition(mouseInWorldSpace)) == null )
            {
                modulePhantom.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                moduleGridSystem.PutGameObjectOnPosition(modulePhantom, mouseInWorldSpace);
                modulePhantom = null;
            }
                

        }
    }
}
