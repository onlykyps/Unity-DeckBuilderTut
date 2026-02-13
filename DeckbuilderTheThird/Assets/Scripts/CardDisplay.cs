using UnityEngine;
using TMPro;
using RedOnWhiteGames;
using UnityEngine.UI;
using System;

public class CardDisplay : MonoBehaviour
{
   public Card cardData;
   public Image cardImage;
   public TMP_Text nameText;
   public TMP_Text healthText;
   public TMP_Text damageText;
   public Image[] typeImage;

   private Color[] cardColours =
   {
      Color.red, //fire
      new Color (0.8f, 0.52f, 0.24f), //earth
      Color.blue, // water
      Color.magenta, // dark
      Color.yellow, // light
      Color.cyan // air
   };

   private Color[] typeColours =
   {
      Color.red, //fire
      new Color (0.8f, 0.52f, 0.24f), //earth
      Color.blue, // water
      new Color (0.47f, 0.0f, 0.40f), // dark
      Color.yellow, // light
      Color.cyan // air
   };

   // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
   {
      UpdateCardDisplay();
   }

   private void UpdateCardDisplay()
   {
      //update the main card image colour based on the first card type
      cardImage.color = cardColours[(int)cardData.cardType[0]];

      nameText.text = cardData.cardName.ToString();
      healthText.text = cardData.health.ToString();
      damageText.text = $"{cardData.damageMin} - {cardData.damageMax}";

      //update type images
      for (int i = 0; i < typeImage.Length; i++)
      {
         if(i < cardData.cardType.Count)
         {
            typeImage[i].gameObject.SetActive(true);
            typeImage[i].color = cardColours[(int)cardData.cardType[i]];
         }
         else
         {
            typeImage[i].gameObject.SetActive(false);
         }
      }

   }

   /*// Update is called once per frame
   void Update()
   {

   }*/
}
