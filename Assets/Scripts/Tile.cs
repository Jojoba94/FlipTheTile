using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private GameObject _tilePlate;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Animator _animator;

    private GameObject _signObject = default(GameObject);
    public Sign _sign;

    public Color SelectedColor { get; set; }


    private void SpawnSign()
    {
        _signObject = GameManager.Instance.GetSignObject(_sign);
        Instantiate(_signObject, transform.position, Quaternion.identity).transform.SetParent(_tilePlate.transform);
    }

    private void CheckPlayerChanged()
    {
        switch (GameManager.Instance.CurrentPlayer)
        {
            case Player.One:
                _sign = Sign.Circle;
                SelectedColor = Color.red;
                break;
            case Player.Two:
                _sign = Sign.Cross;
                SelectedColor = Color.blue;
                break;
            case Player.Three:
                _sign = Sign.Triangle;
                SelectedColor = Color.green;
                break;
            case Player.Four:
                _sign = Sign.Square;
                SelectedColor = Color.yellow;
                break;
        }
    }


    private void OnMouseEnter()
    {
        CheckPlayerChanged();
        _renderer.material.color = SelectedColor;
    }

    private void OnMouseExit()
    {
        CheckPlayerChanged();
        _renderer.material.color = Color.white;
    }


    private void OnMouseDown()
    {
        CheckPlayerChanged();
        if (_signObject == null && _signObject is null)
            SpawnSign();

        _animator.SetTrigger("TriggerFlip");
    }
}
