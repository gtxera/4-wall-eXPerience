using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PasswordPuzzleSolver : BasePuzzleSolver
{
    [SerializeField] GameObject _passwordInputGO;
    [SerializeField] TMP_InputField _passwordInput;
    [SerializeField] string _password;
    public override void SolvePuzzle(int _areaId, int _solveId)
    {
        if (_passwordInput.text == _password)
        {
            _passwordInputGO.SetActive(false);
            base.SolvePuzzle(_areaId, _solveId);
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
