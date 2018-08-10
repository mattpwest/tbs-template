using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Selectable), typeof(SpriteRenderer))]
public class FlashOnSelected : MonoBehaviour
{
	private Selectable selectable;
	private SpriteRenderer spriteRenderer;

	private Tweener tweener;

	[SerializeField]
	private float duration = 1.0f;
	
	void Awake()
	{
		this.selectable = this.GetComponent<Selectable>();
		this.spriteRenderer = this.GetComponent<SpriteRenderer>();
	}
	
	void Update () {
		if(this.selectable.Selected && this.tweener == null)
		{
			this.FadeOut();
			this.tweener.OnComplete(this.FadeIn);
		}

		if(!this.selectable.Selected)
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
