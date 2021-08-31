using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Analytics;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory _inventory;
    public GameObject slotButton;
    public int id;

    private void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //если объект соприкоснулся с персонажем
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < _inventory.slots.Length; i++)
            {
                if (!_inventory.isFull[i])
                {
                    _inventory.isFull[i] = true;
                    //создание объекта
                    Instantiate(slotButton, _inventory.slots[i].transform);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
    
}
