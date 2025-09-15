using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource shootSound;
    public AudioSource buySound;

    public void shoot()
    {
        //play the shoot sound
        shootSound.Play();
    }

    public void buy()
    {
        //play the buy sound
        buySound.Play();
    }
}
