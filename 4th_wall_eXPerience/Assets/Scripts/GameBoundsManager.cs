using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameBoundsManager : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            EventManager.Instance.Escape4thWallEvent();
        }
    }
}
