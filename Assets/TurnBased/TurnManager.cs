using UnityEngine;

public class TurnManager : MonoBehaviour
{
	[SerializeField]
	private Side[] sides;

	[SerializeField]
	private int currentSide = 0;

	private bool mustAdvance = false;
	
	public int CurrentSide => this.currentSide;

	private void OnEnable()
	{
		this.currentSide = 0;
	}

	public void AdvanceTurn()
	{
		this.mustAdvance = true;
	}

	void Update()
	{
		if(this.mustAdvance)
		{
			this.currentSide = (this.currentSide + 1) % this.sides.Length;
			this.mustAdvance = false;
		}
	}
}
