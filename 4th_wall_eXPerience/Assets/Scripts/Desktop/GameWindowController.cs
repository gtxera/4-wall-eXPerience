using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWindowController : MonoBehaviour
{
    private bool _fullscreen;
    [SerializeField] RectTransform _gameWindowRectTransform;
    private void Start()
    {
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
            _fullscreen = true;
            Vector2 _screenSize = new Vector2(Screen.width, Screen.height);
            var _newScale = _screenSize / _gameWindowRectTransform.sizeDelta;
            _gameWindowRectTransform.localScale = _newScale;
        }
    }

    public void SetWindowed()
    {
        if (_fullscreen)
        {
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
