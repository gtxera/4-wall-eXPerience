using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaHitHandler : MonoBehaviour
{
    [SerializeField] Image _image;
    void Start()
    {
        _image.alphaHitTestMinimumThreshold = 0.0001f;
    }

}
