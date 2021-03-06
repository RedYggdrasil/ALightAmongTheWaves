﻿using System.Collections;
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
    public Button[] shipPartsButton;

    private TagContainer _tagContainer;

    // Start is called before the first frame update
    void Start()
    {
        _tagContainer = TagContainer.Instance;

        shipPartsButton = new Button[shipParts.Length];

        int i = 0;
        foreach (ShipModule shipModule in shipParts)
        {
            GameObject buttonGamebject = GameObject.Instantiate(partButtonPrefab.gameObject, panelPartTransform);
            buttonGamebject.GetComponentInChildren<TextMeshProUGUI>().text = shipModule.moduleName;

            Button button = buttonGamebject.GetComponent<Button>();

            button.transform.Find("wood price").GetComponent<TextMeshProUGUI>().text = shipModule.cost.woodCost.ToString();
            button.transform.Find("men price").GetComponent<TextMeshProUGUI>().text = shipModule.cost.freePeopleCost.ToString();

            shipPartsButton[i++] = button;

            button.onClick.AddListener(() => {
                placeShipModule.SetShipPartToPlace(GameObject.Instantiate(shipModule.gameObject).GetComponent<ShipModule>());
                panelPartTransform.gameObject.SetActive(false);
            });
        }

        menuButton.onClick.AddListener(() => {
            panelPartTransform.gameObject.SetActive(!panelPartTransform.gameObject.activeSelf);
            if (panelPartTransform.gameObject.activeSelf)
                UpdateAvailableByCost();
            }
            );

        UpdateUnlockShipPart();
        _tagContainer.onTagsUpdate += UpdateUnlockShipPart;
    }

    private void OnDestroy()
    {
        _tagContainer.onTagsUpdate += UpdateUnlockShipPart;
    }

    void UpdateAvailableByCost()
    {
        Storage storage = StorageManager.Instance.GetStorageRefence();

        int i = 0;
        foreach (ShipModule shipModule in shipParts)
        {
            Button shipPartButton = shipPartsButton[i++];

            shipPartButton.interactable = shipModule.IsPurchable(storage);

            if (!shipModule.IsPurchable(storage))
                shipPartButton.GetComponent<Image>().color = new Color(0.7f, 0.3f, 0.3f, 0.8f);
            
        }
    }

    void UpdateUnlockShipPart()
    {
        List<Consequence> consequences = _tagContainer.GetTagListRefence();

        int i = 0;
        foreach (ShipModule shipModule in shipParts)
        {
            Button shipPartButton = shipPartsButton[i++];
            shipPartButton.interactable = shipModule.IsUnlock(consequences);
        }
    }

}
