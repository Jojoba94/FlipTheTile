using UnityEngine;

[System.Serializable]
public struct Player
{
    public Player(string name, Sign sign)
    {
        Name = name;
        Sign = sign;
    }

    public string Name;

    public Sign Sign;
}
