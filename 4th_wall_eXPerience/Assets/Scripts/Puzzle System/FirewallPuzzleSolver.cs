using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirewallPuzzleSolver : BasePuzzleSolver
{
    [SerializeField] GameWindowController _gameWindowController;
    [SerializeField] GameObject butterflyGO;
    public override void SolvePuzzle(int _areaId, int _solveId)
    {
        if(_gameWindowController.HasMsn && CheckAreaId(_areaId, _solveId))
        {
            butterflyGO.SetActive(true);
        }
    }
}
