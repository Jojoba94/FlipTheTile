using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player CurrentPlayer;

    [SerializeField] private GameObject _circleSign;
    [SerializeField] private GameObject _crossSign;
    [SerializeField] private GameObject _triangleSign;
    [SerializeField] private GameObject _squareSign;


    private void Awake()
    {
        if (Instance != null)
            throw new System.Exception("There should not be more than 1 instance of game manager in scene");
        Instance = this;

        //DontDestroyOnLoad(gameObject);
    }


    public static GameManager Instance { get; private set; }

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
