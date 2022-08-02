using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEngine : MonoBehaviour
{
    public ParticleSystem system;

    public int number_of_columns;
    public float speed;
    public Sprite texture;
    public Color color;
    public float lifetime;
    public float firerate;
    public float size;
    private float angle;
    public Material material;
    public float spin_speed;
    private float time;
    public float force_applied;
    public int layer;
    public bool player_shooter;
    private float aim;
    public bool reverse_mod;
    public bool reverse_mod2;
    public bool pause_mod;



    private void Awake()
    {
        Summon();
    }
    private void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        transform.rotation = Quaternion.Euler(0, 0, time * spin_speed);
    }
    void Summon()
    {
        angle = 360f / number_of_columns;

        for (int i=0; i < number_of_columns; i++)
        {
            // A simple particle material with no texture.
            Material particleMaterial = material;

            // Create a green Particle System.
            var go = new GameObject("Particle System");
            aim=player_shooter?-90: angle * i;
            go.transform.Rotate(aim, -90, 0); // Rotate so the system emits upwards.
            go.transform.parent = this.transform;
            go.transform.position = this.transform.position;
            system = go.AddComponent<ParticleSystem>();
            go.GetComponent<ParticleSystemRenderer>().material = particleMaterial;
            var mainModule = system.main;
            mainModule.startColor = Color.green;
            mainModule.startSize = 0.5f;
            mainModule.startSpeed = speed;
            mainModule.simulationSpace = ParticleSystemSimulationSpace.World;
            

            var emission = system.emission;
            emission.enabled = false;

            var forma = system.shape;
            forma.enabled = true;
            forma.shapeType = ParticleSystemShapeType.Sprite;
            forma.sprite = null;

            var text = system.textureSheetAnimation;
            text.enabled = true;
            text.mode = ParticleSystemAnimationMode.Sprites;
            text.AddSprite(texture);
            

            var force = system.forceOverLifetime;
            force.enabled = true;
            force.y = force_applied;

            var collision = system.collision;
            collision.enabled = true;
            collision.type = ParticleSystemCollisionType.World;
            collision.mode = ParticleSystemCollisionMode.Collision2D;
            collision.bounce = 0;
            collision.radiusScale = 0.333f;
            collision.lifetimeLoss = 1;
            collision.sendCollisionMessages = true;
            collision.collidesWith = layer; //64=player, 128=enemy

            var velocity = system.velocityOverLifetime;
            if (reverse_mod)
            {
                velocity.enabled = true;
                AnimationCurve curve = new AnimationCurve();
                curve.AddKey(0.0f, 2.2f);
                curve.AddKey(1f, -2.2f);


                ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(1.0f, curve);

                velocity.speedModifier = minMaxCurve;
            }
            if (reverse_mod2)
            {
                velocity.enabled = true;
                AnimationCurve curve = new AnimationCurve();
                curve.AddKey(0.0f, 0f);
                curve.AddKey(0.5f, 0f);
                curve.AddKey(0.8f, 2f);
                curve.AddKey(1f, -6f);


                ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(1.0f, curve);

                velocity.speedModifier = minMaxCurve;
            }

            if (pause_mod)
            {
                velocity.enabled = true;
                AnimationCurve curve = new AnimationCurve();
                curve.AddKey(0.0f, 2.2f);
                curve.AddKey(0.7f, -2.5f);
                curve.AddKey(0.0f, 3f);


                ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(1.0f, curve);

                velocity.speedModifier = minMaxCurve;
            }


        }
        

        // Every 2 secs we will emit.
        InvokeRepeating("DoEmit", 0f, firerate);
    }

    void DoEmit()
    {
        foreach(Transform child in transform)
        {
            system = child.GetComponent<ParticleSystem>();
            child.tag = "EnemyBullet";
            
            // Any parameters we assign in emitParams will override the current system's when we call Emit.
            // Here we will override the start color and size.
            var emitParams = new ParticleSystem.EmitParams();
            emitParams.startColor = color;
            emitParams.startSize = size;
            emitParams.startLifetime = lifetime;
            system.Emit(emitParams, 10);
            
        }
        
    }

    
}
