using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePuzzleSolver : MonoBehaviour
{
    [SerializeField] int _puzzleId;

    private void Start()
    {
        EventManager.Instance.TrySolvePuzzle += SolvePuzzle;
    }

    private void OnDisable()
    {
        EventManager.Instance.TrySolvePuzzle -= SolvePuzzle;
    }

    public virtual void SolvePuzzle(int _areaId, int _solveId) 
    {
        if (_areaId == _puzzleId && _puzzleId == _solveId)
        {
            gameObject.SetActive(false);
        }
    }

}
