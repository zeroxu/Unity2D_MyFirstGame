using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
  public static GameManager instance;
  public int gameScore;
  public GameObject WinUI;
  public Text targetText;

  private void Awake() {
      if(instance == null){
          instance = this;
      }
  }

  
  public void GetScore(int value){
      gameScore += value;
      targetText.text = gameScore.ToString();
      if(gameScore <= 0){
          WinUI.SetActive(true);
      }
  }
}
