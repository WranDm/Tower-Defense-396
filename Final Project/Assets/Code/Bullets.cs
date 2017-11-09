using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {

	public Vector3 _targ;
    public GameObject enemy;
    private float _velocity;
	private float _lifetime;
	private float _starttime;

	
	
	// Use this for initialization
	public void Initialize (GameObject target)
	{
        enemy = target;
		_velocity = 5f;
		_targ = target.transform.position;
		_lifetime = 1f;
		_starttime = Time.time;

	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > _lifetime + _starttime)
			Die();
        //get vector between enemy and base and normalize it 
        Vector3 bulletLeadVector = FindObjectOfType<Home_Base>().transform.position - _targ;
        bulletLeadVector /= bulletLeadVector.magnitude;

        Component averageOp = enemy.GetComponent("Opponent");
        Component fastOp = enemy.GetComponent("SpeedyOpponent");
        //Component slowOp = enemy.GetComponent("SlowOpponent");
        if (averageOp)
        {
            bulletLeadVector *= 0.5f;
        }
        else if (fastOp)
        {
            bulletLeadVector *= 10.0f;
        }
        else
        {
            bulletLeadVector *= 1.0f;
        }
        
        
        

        
        


		transform.position = Vector3.MoveTowards(transform.position,
			new Vector3(_targ.x+bulletLeadVector.x, _targ.y + 0.5f, _targ.z+bulletLeadVector.z), _velocity * Time.deltaTime);
	}
	
	private void OnCollisionEnter(Collision other)
	{
		Die();
	}
	
	void Die()
	{
		Destroy(gameObject);
	}
}
