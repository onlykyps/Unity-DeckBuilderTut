using RedOnWhiteGames;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
   public List<Card> allCards = new List<Card>();
   public int currentIndex = 0;
   
   
   
   public void DrawCard(HandManager handManager)
   {
      if(allCards.Count == 0)
      {
         return;
      }

      Card nextCard = allCards[currentIndex];
      handManager.AddCardToHand(nextCard);
      currentIndex = (currentIndex + 1) % allCards.Count;

   }

   // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
   {
      // load all card assets from the resources folder
      Card[] cards = Resources.LoadAll<Card>("Cards");

      // add the loaded cards to the allCards list
      allCards.AddRange(cards);
   }

   // Update is called once per frame
   void Update()
   {

   }
}
