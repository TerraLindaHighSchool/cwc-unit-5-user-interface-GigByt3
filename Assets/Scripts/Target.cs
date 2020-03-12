using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public int pointValue;
    public ParticleSystem explosionParticle;
    private GameManager gameManager;
    private Rigidbody targetRB;
    private float minSpeed = 500; private float maxSpeed = 600;
    private float maxTorque = 20; private float xRange = 5;
    private float ySpawnPos = 11;
    // Start is called before the first frame update
    void Start()
    {   
        targetRB = GetComponent<Rigidbody>();
        targetRB.AddForce(RandomForce(), ForceMode.Impulse);
        targetRB.AddTorque(RandomTorque(),
                           RandomTorque(),
                           RandomTorque(),
                           ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    Vector3 RandomForce() { return Vector3.up; }
    float RandomTorque() { return Random.Range(-maxTorque, maxTorque); }
    Vector3 RandomSpawnPos() { return new Vector3(Random.Range(-xRange, xRange), ySpawnPos); }

    private void OnMouseDown() {
        Destroy(gameObject);
        Instantiate(explosionParticle, transform.position,
            explosionParticle.transform.rotation);
        gameManager.UpdateScore(pointValue);
    }
    private void OnTriggerEnter(Collider other) {
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.EndGame();
        }
        Destroy(this.gameObject);
        Instantiate(explosionParticle, transform.position,
            explosionParticle.transform.rotation);
    }
}
