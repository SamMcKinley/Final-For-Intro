using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    //Add points when the player picks up the pickup
    public int points;

    //Audio clip to play when pickup is collected
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Reward the player with points
            PlayerControl player = collision.gameObject.GetComponent<PlayerControl>();
            player.CurrentHealth += 1;
            //Play the coin sound effect
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
            //destroy our coin
            Destroy(this.gameObject);
        }
    }
}
