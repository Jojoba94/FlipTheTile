using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPole : Tile
{
    [SerializeField] private GameObject _signSocket;
    [SerializeField] private Renderer _flag1Renderer;
    [SerializeField] private Renderer _flag2Renderer;
    [SerializeField] private Renderer _tileRenderer;

    private void Start()
    {
        GameObject signObject = GameManager.Instance.GetSignObject(SelectedSign);
        Instantiate(signObject, _signSocket.transform.position, _signSocket.transform.rotation).transform.SetParent(_signSocket.transform);
        _flag1Renderer.material.color = signObject.GetComponentInChildren<Renderer>().sharedMaterial.color;
        _flag2Renderer.material.color = signObject.GetComponentInChildren<Renderer>().sharedMaterial.color;
        _tileRenderer.material.color = signObject.GetComponentInChildren<Renderer>().sharedMaterial.color;
    }
}
