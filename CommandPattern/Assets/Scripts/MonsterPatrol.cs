using UnityEngine;

//controls monster movement
public class MonsterPatrol : MonoBehaviour
{

    public float distanceToCover;
    public float speed;
    private Vector3 startingPosition;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = startingPosition;
        v.x += distanceToCover * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }
}
