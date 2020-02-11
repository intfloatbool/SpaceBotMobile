
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCommandRunner : MonoBehaviour
{
    [SerializeField] private ProgrammableObjectBase _reciever;
    public ProgrammableObjectBase Reciever => _reciever;

    [SerializeField] private string[] _args;
    public string[] Args => _args;

}
