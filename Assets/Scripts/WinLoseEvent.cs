using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinLoseEvent : MonoBehaviour
{

    public GameObject loseText;
    public GameObject winText;
    public GameObject player;
    public GameObject endGameMenu;

    public GameObject timeline;
void OnEnable()
    {
    ConvoyDamage.loseConditionTrue += Lose;
    WinSingal.winCondition += Winning;
    PlayerMovement.playerExploded += Lose;
    ProjectileMovement.PlayerHitted +=Lose;
    endGameMenu.SetActive(false);
    }

    void Lose()
    {
        loseText.SetActive(true);
        player.SetActive(false);
        timeline.SetActive(false);
        endGameMenu.SetActive(true);
    }

    void Winning()
    {
        winText.SetActive(true);
        player.SetActive(false);
        timeline.SetActive(false);
        endGameMenu.SetActive(true);
    }

    void OnDisable()
    {
        ConvoyDamage.loseConditionTrue -= Lose;
        WinSingal.winCondition -= Winning;  
        PlayerMovement.playerExploded -= Lose;
        ProjectileMovement.PlayerHitted -=Lose;
    }
}
