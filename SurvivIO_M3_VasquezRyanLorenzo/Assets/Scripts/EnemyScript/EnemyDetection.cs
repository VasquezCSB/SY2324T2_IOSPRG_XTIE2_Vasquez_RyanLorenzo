using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		OnEnemyDetected(collision.gameObject);
	}
	private void OnTriggerStay2D(Collider2D collision)
	{
		OnEnemyDetected(collision.gameObject);
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		OnEnemyGotAway(collision.gameObject);
	}

	void OnEnemyDetected(GameObject otherObj)
	{
		//check if other object is present in your dectection beside the parent object
		if (otherObj == this.transform.parent.gameObject)
			return;

		if (otherObj.GetComponent<Unit>())
		{
			this.GetComponentInParent<Enemy>().Target = otherObj.transform;
		}
	}

	void OnEnemyGotAway(GameObject otherObj)
	{
		if (otherObj == this.transform.parent.gameObject)
			return;

		if (otherObj.GetComponent<Unit>())
		{
			if (this.GetComponentInParent<Enemy>().Target == otherObj.transform)
				this.GetComponentInParent<Enemy>().Target = null;
		}
	}
}
