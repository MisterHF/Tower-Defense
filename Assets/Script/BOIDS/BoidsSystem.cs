using System;
using UnityEngine;

public class BoidsSystem : MonoBehaviour
{
   public Transform boidPrefab;
   public int numberOF;


    Boid[] boids;


    [SerializeField]
    BoidSettings settings;
    private void Start()
    {
        boids = new Boid[numberOF];

        for (int i = 0; i < numberOF; i++)
        {
            boids[i] = new Boid { boidTransform = Instantiate(boidPrefab, transform), velocity = UnityEngine.Random.onUnitSphere };

        }

    }

    private void Update()
    {
        ComputNextVelocities();
        ApplyNextVelocities();
    }

    private void ApplyNextVelocities()
    {
        for (int i = 0; i < boids.Length; i++)
        {
            boids[i].ApplyNextVelocity(boids, settings);
        }
    }

    private void ComputNextVelocities()
    {
        for (int i = 0; i < boids.Length; i++)
        {
            boids[i].ComputeNextVelocity(boids, settings);
        }
    }

    struct Boid
    {
        public Transform boidTransform;
        public Vector3 velocity;
        public Vector3 nextVelocity;
        // Nouveau vecteur  d attraction pour donner une nouvelle direction.
        public void ApplyNextVelocity(Boid[] boids, BoidSettings settings)
        {
            velocity = Vector3.Slerp(velocity, nextVelocity, settings.turnRate);
            boidTransform.position += velocity * settings.speed * Time.deltaTime;
        }

        public void ComputeNextVelocity(Boid[] boids, BoidSettings settings)
        {
            Vector3 alignement = Vector3.zero;
            Vector3 avoidance = Vector3.zero;
            Vector3 cohesion = Vector3.zero;


            for (int i = 0; i< boids.Length; i++)
            {
                if(boids[i].boidTransform == boidTransform) 
                { 
                    continue; 
                }
                    

                //alignement
                alignement += boids[i].velocity;

                //avoidance
                Vector3 direction = boidTransform.position - boids[i].boidTransform.position;
                float distance = direction.magnitude / settings.farThreshold;

                avoidance += direction.normalized * (1 - distance);

                //cohesion
                direction *= -1;

                if(distance > settings.farThreshold)
                {
                    cohesion += Vector3.ClampMagnitude(direction.normalized * (distance - 1), 1);
                }

            }

            nextVelocity = alignement * settings.alignement + avoidance * settings.avoidance + cohesion * settings.cohesion;
            nextVelocity.Normalize();
        }
    }

    [Serializable]
    class BoidSettings
    {
        public float alignement;
        public float avoidance;
        public float cohesion;
        public float attraction;
        public float farThreshold;
        public float speed;
        public float turnRate;
    }
}
