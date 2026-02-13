
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(DeckManager))]
public class DeckManagerEditor : Editor
{
   public override void OnInspectorGUI()
   {
      DrawDefaultInspector();

      DeckManager deckManager = (DeckManager)target;
      if (GUILayout.Button("Draw Next Card"))
      {
         HandManager handManager = FindObjectOfType<HandManager>();
         if (handManager != null)
         {
            deckManager.DrawCard(handManager);
         }
      }
   }

   // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {

   }
}
#endif