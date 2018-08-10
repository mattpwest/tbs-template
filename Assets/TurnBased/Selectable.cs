using UnityEngine;

public class Selectable : MonoBehaviour
{
	[SerializeField]
	private Side side;

	[SerializeField]
	private SelectionManager selectionManager;

	private AbstractMovement movement;

	private bool selected;
	
	public bool Selected
	{
		get
		{
			return this.selected;
		}
		set
		{
			this.selected = value;

			if(this.movement == null)
			{
				return;
			}
			
			this.movement.enabled = value;
		}
	}

	public Side Side => this.side;
	
	void Awake()
	{
		this.movement = this.GetComponent<AbstractMovement>();
		this.selectionManager.Register(this);
	}
}
