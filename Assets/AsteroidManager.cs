using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidManager : MonoBehaviour
{
    public Asteroid model;

    public int asteroidQuantity = 50;

    public Transform position1;
    public Transform position2;

    public Vector3 max;
    public Vector3 min;

    public int MinScale;
    public int maxScale;

    private void Start()
    {
        for (int i = 0; i < asteroidQuantity; i++)
        {
            Asteroid asteroid = Instantiate(model);
            asteroid.transform.position = new Vector3(
                Random.Range(position1.position.x, position2.position.x),
                Random.Range(position1.position.y, position2.position.y),
                Random.Range(position1.position.z, position2.position.z)
                );

            float scale = Random.Range(MinScale, maxScale);

            asteroid.transform.localScale = new Vector3(scale, scale, scale);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
}
