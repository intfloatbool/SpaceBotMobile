using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannableObject : MonoBehaviour
{
    [SerializeField] private string _scanTag;
    public string ScanTag => _scanTag;

}
