using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public void ActivateInventory()
    {
        this.transform.parent.transform.gameObject.SetActive(!GetInventoryState());
    }

    public bool GetInventoryState()
    {
        return this.transform.parent.transform.gameObject.activeInHierarchy;
    }

}
