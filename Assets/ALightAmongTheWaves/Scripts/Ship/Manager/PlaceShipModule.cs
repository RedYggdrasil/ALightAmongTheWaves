using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceShipModule : MonoBehaviour
{
    public GridSystem moduleGridSystem;

    //[HideInInspector]
    ShipModule shipPart;

    public void SetShipPartToPlace(ShipModule shipModule)
    {
        if (shipPart != null)
            Destroy(shipPart.gameObject);

        shipPart = shipModule;
        shipPart.GetComponent<SpriteRenderer>().sortingOrder = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(shipPart != null)
        {

            Vector2 mouseInWorldSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (moduleGridSystem.IsInBoat(mouseInWorldSpace) && shipPart != null)
            {
                shipPart.transform.position = moduleGridSystem.GetPositionForCellIndex(moduleGridSystem.GetCellIndexFromPosition(mouseInWorldSpace));

                if (!moduleGridSystem.CanPLaceModule(moduleGridSystem.GetCellIndexFromPosition(mouseInWorldSpace), shipPart.GetComponent<ShipModule>().moduleSize))
                    shipPart.GetComponent<SpriteRenderer>().color = new Color(0.9f, 0.3f, 0.3f, 0.5f);
                else
                    shipPart.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);

            }

            if (Input.GetMouseButtonDown(0))
            {
                if (shipPart != null && moduleGridSystem.IsInBoat(mouseInWorldSpace) &&
                    moduleGridSystem.CanPLaceModule(moduleGridSystem.GetCellIndexFromPosition(mouseInWorldSpace), shipPart.GetComponent<ShipModule>().moduleSize))
                {
                    shipPart.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                    shipPart.GetComponent<SpriteRenderer>().sortingOrder = 0;
                    moduleGridSystem.PutGameObjectOnPosition(shipPart.gameObject, mouseInWorldSpace);
                    shipPart = null;
                }
            }
            else if (Input.GetMouseButtonDown(1))
            {
                Destroy(shipPart.gameObject);
                shipPart = null;
            }
        }

        
    }

    
}
