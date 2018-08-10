using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(AbstractMovement), typeof(SpriteRenderer))]
public class FlashOnMyTurn : MonoBehaviour
{
	private AbstractMovement abstractMovement;
	private SpriteRenderer spriteRenderer;

	private Tweener tweener;

	[SerializeField]
	private float duration = 1.0f;
	
	void Awake()
	{
		this.abstractMovement = this.GetComponent<AbstractMovement>();
		this.spriteRenderer = this.GetComponent<SpriteRenderer>();
	}
	
	void Update () {
		if(this.abstractMovement.MyTurn && this.tweener == null)
		{
			this.FadeOut();
			this.tweener.OnComplete(this.FadeIn);
		}

		if(!this.abstractMovement.MyTurn)
		{
			if(this.tweener != null)
			{
				this.tweener.Kill();
				this.FadeIn();
			}
		}
	}

	public void FadeOut()
	{
		this.tweener = this.spriteRenderer
			.DOFade(0.5f, this.duration);
	}

	public void FadeIn()
	{
		this.tweener = this.spriteRenderer
			.DOFade(1.0f, this.duration)
			.OnComplete(this.EndAnimation);
	}

	public void EndAnimation()
	{
		this.tweener = null;
	}
}
