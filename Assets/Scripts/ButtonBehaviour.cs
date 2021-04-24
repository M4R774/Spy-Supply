using UnityEngine;
using System.Collections;

public class ButtonBehaviour : MonoBehaviour {
   int resolveMission(float randNum, double odds){
      if (randNum <= odds) return 1;
      else return 0;
   }
   
   public void OnButtonPress(){

      int[] items = { 1, -3, 3 };

      int sum_items = 0;
      for(var i = 0; i<items.Length; i++){
         sum_items += items[i];
      }

      int max_modifier = 3;
      int max_items = 3;
      int difficulty = 2;
      int max_difficulty = 5;

      double odds = (1 - (double) difficulty / (2 * max_difficulty)) + sum_items * (double) difficulty / (2 * max_difficulty) / (max_modifier * max_items);
      // double odds = 0.82;
      
      int result = resolveMission(Random.Range(0f,1f), odds);
      Debug.Log("Outcome odds are " + odds + " and result was " + result);
   }

}