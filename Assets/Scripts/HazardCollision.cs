using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HazardCollision : MonoBehaviour {


    public GameObject restartButton;
    public GameObject homeButton;
    public GameObject scoreText;
    [SerializeField]
    private ParticleSystem hazardDustParticles;
    private UIFunctions uiFunctions;

    void Start()
    {
        uiFunctions = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UIFunctions>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform") {
            Destroy(Instantiate(hazardDustParticles.gameObject, transform.position, Quaternion.identity), hazardDustParticles.startLifetime);
            //gameObject.SetActive(false);
            Destroy(gameObject);

        }
        if (collision.gameObject.tag == "Player")
        {
            uiFunctions.GameEnded();
        }
    }
}
