using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float sightCutoffDistance;
    public float fieldOfView;
    public bool CanSeePlayer;
    public Transform Player;
    public LayerMask layer;
    public float ViewRadius;
    public Transform visibleTarget;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        float Distance = Vector3.Distance(transform.position, Player.position);
        Vector3 directionToTarget = (Player.position - transform.position).normalized;
        Debug.Log(Mathf.Abs(fieldOfView));
        if (Vector3.Angle(transform.right, directionToTarget) > Mathf.Abs(fieldOfView / 2))
        {
            Debug.Log("Angle is less than 55");
            if (Distance <= ViewRadius)
            {
                Debug.Log("Player Spotted");

            }


        }



    }

    public void Die()
    {
        Destroy(this.gameObject);
    }

    private bool CanSee(GameObject target)
    {



        return false;
    }
    public Vector3 AngleToTarget(float angleInDegrees, bool AngleIsGlobal)
    {
        if (!AngleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.x;
        }
        return new Vector3(Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0);
    }
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            //Reward the player with points
            PlayerControl player = collider.gameObject.GetComponent<PlayerControl>();
            player.CurrentHealth -= 1;

        }
    }
}
