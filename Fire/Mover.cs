using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour 
{
	public float speed = 1.0f;

	public Vector2 direction;
	

	void Start()
	{
		if (direction == Vector2.zero) 
		{
			direction = new Vector2(0,1);
		}


        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.localRotation = q;
   

        GetComponent<Rigidbody2D> ().velocity = direction.normalized * speed;//* LevelShmupController.CurrentPlayerShotTimer;

	}


}
