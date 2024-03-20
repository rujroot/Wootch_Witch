using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject preFab, InventoryUI;
    public void CreateItem(Sprite sprite, string name)
    {
        GameObject clone = Instantiate(preFab, InventoryUI.transform);
        clone.GetComponent<Image>().sprite = sprite;
        clone.name = name;


    }

}
