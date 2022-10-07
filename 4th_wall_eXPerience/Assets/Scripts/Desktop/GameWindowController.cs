using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWindowController : MonoBehaviour
{
    private bool _fullscreen;
    [SerializeField] RectTransform _gameWindowRectTransform;
    private Vector2 _lastPosition;

    private void Start()
    {
        _lastPosition = _gameWindowRectTransform.localPosition;

        SetFullscreen();
        EventManager.Instance.OpenGame += SetFullscreen;
        EventManager.Instance.CloseGame += SetInvisible;
    }

    private void OnDisable()
    {
        EventManager.Instance.OpenGame -= SetFullscreen;
        EventManager.Instance.CloseGame -= SetInvisible;
    }

    public void SetFullscreen() 
    {
        if (!_fullscreen)
        {
            _lastPosition = _gameWindowRectTransform.localPosition;

            _fullscreen = true;
            Vector2 _screenSize = new Vector2(Screen.width, Screen.height);
            var _newScale = _screenSize / _gameWindowRectTransform.sizeDelta;
            _gameWindowRectTransform.localScale = _newScale;

           _gameWindowRectTransform.localPosition = Vector2.zero;
           _gameWindowRectTransform.SetAsLastSibling();
        }
    }

    public void SetWindowed()
    {
        if (_fullscreen)
        {
            _gameWindowRectTransform.localPosition = _lastPosition;

            _fullscreen = false;
            _gameWindowRectTransform.localScale = Vector2.one;
        }
    }

    public void SetInvisible()
    {
        _fullscreen = false;
        _gameWindowRectTransform.localScale = Vector2.zero;
    }
}
