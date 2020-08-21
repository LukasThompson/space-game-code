using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public GameController gameController;
    public int scoreValue;
    private GameObject gameControllerObject;

    void Start()
    {
        gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        if(gameController == null)
        {
            UnityEngine.Debug.Log("Cannot find game controller script!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Enemy")
        {
            return;
        }
        if(explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        
        if (other.tag == "Bolt")
        {
            gameController.AddScore(scoreValue);
        }
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}