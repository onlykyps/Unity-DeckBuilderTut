using System;
using System.Collections.Generic;
using UnityEngine;
using RedOnWhiteGames;

public class HandManager : MonoBehaviour
{
   public DeckManager deckManager;

   public GameObject cardPrefab; // assign card prefab in inspector
   public Transform handTransform; // root of the hand position

   private float fanSpread = 15f;
   private float cardSpacing = -150f;
   private float verticalSpacing = 190f;

   public List<GameObject> cardsInHand = new List<GameObject>(); // hold a list of the card objects in our hand

   // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
   {
      
   }

   public void AddCardToHand(Card cardData)
   {
      // instantiate the card
      GameObject newCard = Instantiate(cardPrefab, transform.position, Quaternion.identity, handTransform);
      cardsInHand.Add(newCard);

      // set card data of the instantiated card

      newCard.GetComponent<CardDisplay>().cardData = cardData;

      UpdateHandVisuals();
   }

   private void UpdateHandVisuals()
   {
      int cardCount = cardsInHand.Count;

      if (cardCount == 1)
      {
         cardsInHand[0].transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
         cardsInHand[0].transform.localPosition = new Vector3(0f, 0f, 0f);
         return;
      }

      for (int i = 0; i < cardCount; i++)
      {
         float rotationAngle = (fanSpread * (i - (cardCount - 1) / 2f));
         cardsInHand[i].transform.localRotation = Quaternion.Euler(0f, 0f, rotationAngle);

         float horizontalOffset = (cardSpacing * (i - (cardCount - 1) / 2f)); ;

         float normilizedPosition = (2f * i / (cardCount - 1) - 1); //normalize card position between -1  and 1

         float verticalOffset = verticalSpacing * (1 - normilizedPosition * normilizedPosition);

         // set card positions
         cardsInHand[i].transform.localPosition = new Vector3(horizontalOffset, verticalOffset, 0f);
      }
   }

   // Update is called once per frame
   private void Update()
   {
      UpdateHandVisuals();
   }
}
