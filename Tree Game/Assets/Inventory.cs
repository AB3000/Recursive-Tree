using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory : MonoBehaviour, IHasChanged{

    [SerializeField] Transform slots;
    [SerializeField] Text inventoryText;
    public static string sequence;

    public void HasChanged()
    {
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        foreach(Transform slot in slots)
        {
            GameObject item = slot.GetComponent<Slot>().item;
            if(item)
            {
                builder.Append(item.name);
                builder.Append(" ");
            }
        }
        inventoryText.text = builder.ToString();
        sequence = builder.ToString();
    }

    // Use this for initialization
    void Start () {
        HasChanged();
	}
	
	
}

namespace UnityEngine.EventSystems
{
    public interface IHasChanged:IEventSystemHandler
    {
        void HasChanged();
    }
}
