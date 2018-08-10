using UnityEngine;

[CreateAssetMenu(menuName = "TBS/Side")]
public class Side : ScriptableObject
{
	[SerializeField]
	private int id;

	public int Id => this.id;
}
