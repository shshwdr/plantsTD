using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public AnimationCurve curve;
    public float moveSpeed = 2;
    float time;

    public float explodeRadius = 2;

    Vector3 startPosition;
    Vector3 targetPosition;

    float damage = 0;

    public void init(Vector3 target, float d)
    {
        damage = d;
        targetPosition = target;
    }

    // Start is called before the first frame update
    void Start()
    {
        var pos = transform.position;
        startPosition = pos;
        //targetPosition = pos;
        //targetPosition = new Vector3(pos.x > 0 ? 1 : -1, pos.y, pos.z);
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime * moveSpeed;
        Vector3 pos = Vector3.Lerp(startPosition, targetPosition, time);
        pos.y += curve.Evaluate(time);
        transform.position = pos;
        if (time >= 1)
        {
            //find all human around the area
            foreach(var enemy in EnemyManager.Instance.findAround(transform.position, explodeRadius))
            {
                enemy.getDamage(damage);
            }


            Destroy(gameObject);

        }
    }
}
