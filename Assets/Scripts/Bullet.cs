using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform tf;

    public float bulletspeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //always move forward
        tf.position += tf.right * bulletspeed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D OtherObject)
    {
        Debug.Log(OtherObject.gameObject.name);
        if (OtherObject.gameObject != GameManager.instance.Player && OtherObject.gameObject.tag != "bullet")
        {
            if (OtherObject.gameObject.GetComponent<Enemy>())
            {
                OtherObject.gameObject.GetComponent<Enemy>().Die();
            }
            
        }
        this.Die();
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
