using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineManager : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera _cinemachine;
    void Start()
    {
        EventManager.Instance.Escape4thWall += StopFollow;
    }

    private void OnDisable()
    {
        EventManager.Instance.Escape4thWall -= StopFollow;
    }

    void StopFollow()
    {
        _cinemachine.Follow = null;
    }
}
