using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShipPartSelectorUI : MonoBehaviour
{
    public Button menuButton;
    public RectTransform panelPartTransform;
    public Button partButtonPrefab;

    public PlaceShipModule placeShipModule;
    public ShipModule[] shipParts;

    //public List<part>

    // Start is called before the first frame update
    void Start()
    {
        foreach(ShipModule shipModule in shipParts)
        {
            GameObject button = GameObject.Instantiate(partButtonPrefab.gameObject, panelPartTransform);
            button.GetComponentInChildren<TextMeshProUGUI>().text = shipModule.name;
            button.GetComponent<Button>().onClick.AddListener(() => {
                placeShipModule.SetShipPartToPlace(GameObject.Instantiate(shipModule.gameObject).GetComponent<ShipModule>());
                panelPartTransform.gameObject.SetActive(false);
            });
        }

        menuButton.onClick.AddListener(() => panelPartTransform.gameObject.SetActive(!panelPartTransform.gameObject.activeSelf));
    }

}
