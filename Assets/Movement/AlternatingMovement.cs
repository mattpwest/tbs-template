using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternatingMovement : AbstractMovement
{
    void Update()
    {
        if(!this.MyTurn)
        {
            return;            
        }

        if(this.HandleOrdinalMovement())
        {
            this.turnManager.AdvanceTurn();
        }
    }
}
