using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTile : Tile
{
    [SerializeField] private GameObject _tilePlate;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Animator _animator;

    private GameObject _signObject = default(GameObject);

    private void SpawnSign()
    {
        _signObject = GameManager.Instance.GetSignObject(SelectedSign);
        Instantiate(_signObject, transform.position, Quaternion.identity).transform.SetParent(_tilePlate.transform);
    }

    private void CheckPlayerChanged()
    {
        switch (GameManager.Instance.Players.Current.Sign)
        {
            case Sign.Circle:
                SelectedColor = Color.red;
                break;
            case Sign.Cross:
                SelectedColor = Color.blue;
                break;
            case Sign.Triangle:
                SelectedColor = Color.green;
                break;
            case Sign.Square:
                SelectedColor = Color.yellow;
                break;
            default:
                break;
        }
    }

    private void OnMouseEnter()
    {
        if (!AdjacentTilePresent())
        {
            _renderer.material.color = Color.black;
            return;
        }

        CheckPlayerChanged();
        _renderer.material.color = SelectedColor;
    }

    private void OnMouseExit()
    {
        _renderer.material.color = Color.white;
    }

    private void OnMouseDown()
    {
        if (!AdjacentTilePresent())
            return;

        SelectedSign = GameManager.Instance.Players.Current.Sign;

        if (_signObject == null && _signObject is null)
            SpawnSign();

        GameManager.Instance.Players.MoveNext();
        _animator.SetTrigger("TriggerFlip");
    }

    private bool AdjacentTilePresent()
    {
        for (int i = 0; i < 8; i++)
        {
            Vector3 dir = new Vector3(Mathf.Cos(Mathf.Deg2Rad * i * 45), 0, Mathf.Sin(Mathf.Deg2Rad * i * 45));
            if (Physics.Raycast(transform.position, dir, out RaycastHit hit, 14.1f))
            {
                Debug.DrawRay(transform.position, dir * hit.distance, Color.yellow);
                Tile otherTile = hit.transform.GetComponent<Tile>();
                if (otherTile != null && otherTile.SelectedSign == GameManager.Instance.Players.Current.Sign && otherTile.SelectedSign != Sign.None)
                    return true;
            }
        }

        return false;
    }
}
