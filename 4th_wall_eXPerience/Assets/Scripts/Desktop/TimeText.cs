using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _time;

    void Update()
    {
        _time.text = System.DateTime.Now.ToString("HH:mm");
    }
}
