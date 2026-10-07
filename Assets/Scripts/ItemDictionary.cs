using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemDictionary : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<Item> itemPrefabs;
    private Dictionary<int, GameObject> itemDictionary;


    private void Awake()
    {
        itemDictionary = new Dictionary<int, GameObject>();

        for(int i = 0; i < itemPrefabs.Count; i++)
        {
            if(itemPrefabs[i] != null)
            {
                itemPrefabs[i].ID = i + 1;
            }
        }

        foreach(Item item in itemPrefabs)
        {
            itemDictionary[item.ID] = item.gameObject;
        }
    }

    // Update is called once per frame
    public GameObject getItemPrefab(int itemID)
    {
        itemDictionary.TryGetValue(itemID, out GameObject prefab);
        if(prefab == null)
        {
            Debug.LogWarning($"Item with ID {itemID} not found in dictionary");
        }
        return prefab;
    }
}
