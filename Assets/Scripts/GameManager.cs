using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player CurrentPlayer;


    private void Awake()
    {
        if (Instance != null)
            throw new System.Exception("There should not be more than 1 instance of game manager in scene");
        Instance = this;

        //DontDestroyOnLoad(gameObject);
    }


    public static GameManager Instance { get; private set; }


}
