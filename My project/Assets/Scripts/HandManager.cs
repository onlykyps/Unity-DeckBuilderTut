using System;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
   public GameObject cardPrefab; // assign card prefab in inspector
   public Transform handTransform; // root of the hand position
   public float fanSpread = 5f;
   public List<GameObject> cardsInHand = new List<GameObject>(); // hold a list of the card objects in our hand


   // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
   {
      AddCardToHand();
      AddCardToHand();
      AddCardToHand();
      AddCardToHand();
      AddCardToHand();
      AddCardToHand();
   }

   public void AddCardToHand()
   {
      // instantiate the card
      GameObject newCard = Instantiate(cardPrefab, transform.position, Quaternion.identity, handTransform);
      cardsInHand.Add(newCard);

      UpdateHandVisuals();
   }

   private void UpdateHandVisuals()
   {
      int cardCount = cardsInHand.Count;

      for (int i = 0; i < cardCount; i++)
      {
         float rotationAngle = (fanSpread * (i - (cardCount - 1) / 2f));
         cardsInHand[i].transform.localRotation = Quaternion.Euler(0f, 0f, rotationAngle);
      }
   }

   //// Update is called once per frame
   //void Update()
   //{

   //}
}
