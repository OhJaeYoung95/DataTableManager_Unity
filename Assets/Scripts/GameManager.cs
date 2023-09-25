using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int Score { get; private set; }

    public TextMeshProUGUI score;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    public void AddScore()
    {
        ++Score;
        score.text = $"SCORE : {Score}";
    }
}
