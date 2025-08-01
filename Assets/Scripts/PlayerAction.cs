using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAction : ScriptableObject
{
    public abstract void Execute();
    public abstract void SecondaryExecute();
    public abstract bool TestExecute();
}
