using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGameState
{
    public abstract void EnterState(GameManager gameManager);

    public abstract void Update(GameManager gameManager);

    public abstract void LeaveState(GameManager gameManager);
}
