using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float offset;
    public GameObject bullet;
    public Transform shotPoint;
    public Player player;



    private float timeBtwShots;
    public float startTimeBtwShots; 
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);


        if (player.weapon == 2)
        {
            if (timeBtwShots <= 0)
            {
                if (Input.GetMouseButton(0))
                {
                    Instantiate(bullet, shotPoint.position, transform.rotation);
                    timeBtwShots = startTimeBtwShots;
                }
            }

            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }

        }
    }

