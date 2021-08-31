using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
   //кол-во отданных элементов npc
   public int questElementsNum;
   //массив id предметов
   public int[] items;
   //предмет, полученный в итоге квеста
   public GameObject price;

   public void OnTriggerEnter2D(Collider2D other)
   {
      //если предмет не является игроком и его id совпадает с id необходимого предмета
      if (items.Length > questElementsNum  && 
          !other.CompareTag("Player") 
          && other.gameObject.GetComponent<Pickup>().id == items[questElementsNum])
      {
         //продвинутся дальше по списку id
         questElementsNum++;
         //уничтожить объект
         Destroy(other.gameObject);
         QuestCheck();
      }
   }
   
   //функция проверки квеста
   public void QuestCheck()
   {
      if (questElementsNum == 2)
      {
            price.SetActive(true);
      }
   }
}
