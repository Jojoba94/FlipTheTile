using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Player> _players;

    [SerializeField] private GameObject _circleSign;
    [SerializeField] private GameObject _crossSign;
    [SerializeField] private GameObject _triangleSign;
    [SerializeField] private GameObject _squareSign;

    public NavigationList<Player> Players { get; set; }

    private void Awake()
    {
        if (Instance != null)
            throw new System.Exception("There should not be more than 1 instance of game manager in scene");
        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    //private void Start()
    //{
    //    Players = new NavigationList<Player>(_players);
    //}

    public static GameManager Instance { get; private set; }

    public void SelectPlayerMode(int numPlayers)
    {
        if (numPlayers <= 1 || numPlayers > 4)
            throw new System.Exception("Player Options must range from 2 to 4");

        _players = new List<Player>();
        _players.Add(new Player($"Player 1", (Sign)1));

        for (int i = 2; i <= numPlayers; i++)
        {
            _players.Add(new Player($"Player {i}", (Sign)i));
        }

        Players = new NavigationList<Player>(_players);
    }

    public GameObject GetSignObject(Sign sign)
    {
        switch (sign)
        {
            case Sign.Circle:
                return _circleSign;
            case Sign.Cross:
                return _crossSign;
            case Sign.Triangle:
                return _triangleSign;
            case Sign.Square:
                return _squareSign;
            default:
                return default(GameObject);
        }
    }
}
