using UnityEngine;
using DG.Tweening;

public abstract class AbstractMovement : MonoBehaviour
{
    [SerializeField]
    private Side side;

    [SerializeField]
    protected TurnManager turnManager;

    private bool canMove = true;

    public bool MyTurn => this.side.Id == this.turnManager.CurrentSide;

    protected bool HandleOrdinalMovement()
    {
        if(!this.MyTurn)
        {
            return false;
        }

        if(!this.canMove)
        {
            return false;
        }
        
        var pos = transform.position;
        if(Input.GetKeyDown(KeyCode.A))
        {
            this.DisableMoving();
            transform.DOMoveX(transform.position.x - 1.0f, 0.5f)
                .OnComplete(this.EnableMoving);
            return true;
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            this.DisableMoving();
            transform.DOMoveX(transform.position.x + 1.0f, 0.5f)
                .OnComplete(this.EnableMoving);

            return true;
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
            this.DisableMoving();
            transform.DOMoveY(transform.position.y + 1.0f, 0.5f)
                .OnComplete(this.EnableMoving);
            return true;
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            this.DisableMoving();
            transform.DOMoveY(transform.position.y - 1.0f, 0.5f)
                .OnComplete(this.EnableMoving);
            return true;
        }

        return false;
    }

    public void DisableMoving()
    {
        this.canMove = false;
    }
    
    public void EnableMoving()
    {
        this.canMove = true;
    }
}
