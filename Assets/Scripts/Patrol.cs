using UnityEngine;
using System.Collections;

public class Patrol : MonoBehaviour {

    public Transform[] patrolPoints;
    public float moveSpeed;
    private int currentPoint;
    private bool notInRange = true;

    NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        transform.position = patrolPoints[0].position;
        currentPoint = 0;
        agent = gameObject.GetComponent<NavMeshAgent>();
	}

    // Update is called once per frame
    void Update() {
        if (transform.position == patrolPoints[currentPoint].position) {
            currentPoint++;
        }

        if (currentPoint >= patrolPoints.Length) {
            currentPoint = 0;
        }

        Debug.Log(notInRange);
        if (notInRange == true)
        {
            //transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);
            //nevaikscioja
            agent.SetDestination(patrolPoints[currentPoint].position);
        }
        }

    void OnTriggerStay(Collider obj)
    {
        if (obj.gameObject.CompareTag("Player")) {
            notInRange = false;
        }
    }

    void OnTriggerExit(Collider obj)
    {
        if (obj.gameObject.CompareTag("Player"))
        {
            notInRange = true;
        }
    }
}
