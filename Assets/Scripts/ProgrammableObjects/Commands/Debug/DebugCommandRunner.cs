using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCommandRunner : MonoBehaviour
{
    [SerializeField] private ProgrammableObjectBase _reciever;
    public ProgrammableObjectBase Reciever => _reciever;

    [SerializeField] private int[] _args;
    public int[] Args => _args;

}
