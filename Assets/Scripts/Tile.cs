using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private GameObject _tilePlate;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Animator _animator;

    [SerializeField] private GameObject _circleSign;
    [SerializeField] private GameObject _crossSign;
    [SerializeField] private GameObject _triangleSign;
    [SerializeField] private GameObject _squareSign;

    private Sign _selectedSign;
    private Color _selectedColor;
    private GameObject _signObject = default(GameObject);

    private void SpawnSign(Sign sign)
    {
        switch (_selectedSign)
        {
            case Sign.None:
                return;
            case Sign.Circle:
                _signObject = _circleSign;
                break;
            case Sign.Cross:
                _signObject = _crossSign;
                break;
            case Sign.Triangle:
                _signObject = _triangleSign;
                break;
            case Sign.Square:
                _signObject = _squareSign;
                break;
        }


        Instantiate(_signObject, transform.position, Quaternion.identity).transform.SetParent(_tilePlate.transform);
    }

    private void CheckPlayerChanged()
    {

        switch (GameManager.Instance.CurrentPlayer)
        {
            case Player.One:
                _selectedSign = Sign.Circle;
                _selectedColor = Color.red;
                break;
            case Player.Two:
                _selectedSign = Sign.Cross;
                _selectedColor = Color.blue;

                break;
            case Player.Three:
                _selectedSign = Sign.Triangle;
                _selectedColor = Color.green;
                break;
            case Player.Four:
                _selectedSign = Sign.Square;
                _selectedColor = Color.yellow;
                break;
        }
    }


    private void OnMouseEnter()
    {
        CheckPlayerChanged();
        _renderer.material.color = _selectedColor;
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
            SpawnSign(_selectedSign);

        _animator.SetTrigger("TriggerFlip");
    }
}
