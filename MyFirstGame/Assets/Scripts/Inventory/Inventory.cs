using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public GameObject inventory;
    private bool _inventoryIsOpened;

    private void Start()
    {
        _inventoryIsOpened = false;
    }

    public void ChestOpenClose()
    {
        if (!_inventoryIsOpened)
        {
            _inventoryIsOpened = true;
            inventory.SetActive(true);
        }
        else
        {
            _inventoryIsOpened = false;
            inventory.SetActive(false);
        }
    }
}
