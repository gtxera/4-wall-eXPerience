using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    //instancia que gerencia os eventos
    public static EventManager Instance;

    public Action<int, int> TrySolvePuzzle;
    public Action Escape4thWall;
    public Action OpenGame;
    public Action CloseGame;

    public int SolveAreaId;
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    //evento para as soluções de puzzle
    public void StartPuzzleEvent(int _solveId)
    {
        TrySolvePuzzle?.Invoke(SolveAreaId, _solveId);
    }

    //evento para abertura da janela do jogo
    public void OpenGameEvent()
    {
        OpenGame?.Invoke();
    }

    //evento para o fechamento da janela do jogo
    public void CloseGameEvent()
    {
        CloseGame?.Invoke();
    }

    public void Escape4thWallEvent()
    {
        Escape4thWall?.Invoke();
    }

}
