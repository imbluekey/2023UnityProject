using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items;

    [SerializeField]
    private Transform slotParent;
    [SerializeField]
    private Slot[] slots;

//#if UNITY_EDITOR
    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
    }
//#endif
    // Start is called before the first frame update
    void Update()
    {
        Freshslot();
    }
    public void Freshslot()
    {
        int i = 0;
        for(;i<items.Count && i <slots.Length;i++)
        {
            slots[i].item = items[i];
        }
        for(;i<slots.Length;i++) 
        {
            slots[i].item = null;
        }
    }
    public void AddItem(Item _item)
    {
        if(items.Count < slots.Length)
        {
            items.Add(_item);
            Freshslot();
        }
        else
        {
            Debug.Log("½½·ÔÀÌ °¡µæ Â÷ ÀÖ½À´Ï´Ù.");
            print("½½·ÔÀÌ °¡µæ Â÷ ÀÖ½À´Ï´Ù.");
        }
    }
}
