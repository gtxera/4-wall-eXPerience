using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSolveArea : MonoBehaviour
{
    [SerializeField] int _solveAreaId;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            EventManager.Instance.SolveAreaId = _solveAreaId;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            EventManager.Instance.SolveAreaId = 0;
        }
    }
}
