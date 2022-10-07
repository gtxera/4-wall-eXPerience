using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PasswordPuzzleSolver : BasePuzzleSolver
{
    [SerializeField] GameObject _passwordInputGO;
    [SerializeField] TMP_InputField _passwordInput;
    [SerializeField] SpriteRenderer _passwordRenderer;
    [SerializeField] Sprite _openDoorSprite;
    [SerializeField] string _password;
    [SerializeField] BoxCollider2D _collider;
    public override void SolvePuzzle(int _areaId, int _solveId)
    {
        if (_passwordInput.text == _password && CheckAreaId(_areaId, _solveId))
        {
            _passwordRenderer.sprite = _openDoorSprite;
            Component.Destroy(_collider);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _passwordInputGO.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _passwordInputGO.SetActive(false);
        }
    }
}
