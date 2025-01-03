using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject preFab, InventoryUI;
    public List<GameObject> items;
    public void CreateItem(Sprite sprite, string name)
    {
        GameObject clone = Instantiate(preFab, InventoryUI.transform);
        clone.GetComponent<Image>().sprite = sprite;
        clone.name = name;

        items.Add(clone);
        ReImage();
    }

    private void ReImage()
    {

        for(int i = 0; i < items.Count; i++)
        {
            GameObject item = items[i];
            item.GetComponent<RectTransform>().anchoredPosition = new Vector3(100 + i * 100, 0f, 0f);
        }

        Vector2 size = InventoryUI.GetComponent<RectTransform>().sizeDelta;
        float rectSize = 100 + items.Count * 100;
         InventoryUI.SetActive(rectSize > 0);
        InventoryUI.GetComponent<RectTransform>().sizeDelta = new Vector2(rectSize, size.y);
    }

    public GameObject Find(string name)
    {
        foreach (GameObject obj in items)
        {
            if (obj.name == name) return obj;
        }
        return null;
    }

    public void Delete(GameObject obj)
    {

        items.Remove(obj);
        ReImage();
        Destroy(obj);
    }

}
