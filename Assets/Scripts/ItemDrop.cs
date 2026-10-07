using UnityEngine;

public class ItemDrop : MonoBehaviour
{   

    private ItemDictionary itemDictionary;
    void Start() => itemDictionary = FindAnyObjectByType<ItemDictionary>();
    public void dropItem(Transform position, int itemID)
    {
        GameObject prefab = itemDictionary.getItemPrefab(itemID);
        Instantiate(prefab, position);
    }
}
