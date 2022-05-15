using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterShip : MonoBehaviour
{
    [SerializeField] float speedRotation;
    [SerializeField] float speed = 5;

    [SerializeField] Bullet model_bullet;
    [SerializeField] Bullet model_bullet2;

    [SerializeField] Transform shoot1;
    [SerializeField] Transform shoot2;
    [SerializeField] Transform shoot3;

    [SerializeField] Image img_speed;

    [SerializeField] aNIMrOTATOR anim_rotator;

    public Transform brujula;

    float currentSpeed;
    float aux_last_Speed;
    int speed_multiplier;
    int nitroMultiplier = 1;
    bool begincooldown = false;
    float timer_cooldown;
    public float time_to_end_cooldown = 3;
    [SerializeField] int maxSpeedMultiplier;

    private void Start()
    {
        RefreshSpeedUI();
    }

    public void AddSpeed()
    {
        aux_last_Speed = speed_multiplier;
        speed_multiplier++;
        if (speed_multiplier > maxSpeedMultiplier)
        {
            speed_multiplier = maxSpeedMultiplier;
        }

        RefreshSpeedUI();
    }
    public void GetNitro()
    {
        nitroMultiplier = 2;
        begincooldown = true;
    }
    public void RemoveSpeed()
    {
        aux_last_Speed = speed_multiplier;
        speed_multiplier--;
        if (speed_multiplier < 0)
        {
            speed_multiplier = 0;
        }

        RefreshSpeedUI();
    }
    void RefreshSpeedUI()
    {
        float lerp = (float)speed_multiplier / (float)maxSpeedMultiplier;
        img_speed.fillAmount = lerp;
        img_speed.color = Color.Lerp(Color.red, Color.green, lerp);
    }
    void LerpSpeed(float timer)
    {
        currentSpeed = Mathf.Lerp(speed_multiplier, maxSpeedMultiplier, timer);
    }


    float timer_shooter;
    float time_to_shoot = 0.1f;
    // Update is called once per frame
    void Update()
    {

        if (begincooldown)
        {
            if (timer_cooldown < time_to_end_cooldown)
            {
                timer_cooldown += 1 * Time.deltaTime;
            }
            else
            {
                nitroMultiplier = 1;
                begincooldown = false;
                timer_cooldown = 0;
            }
        }

        Vector3 Move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Input.GetAxis("Rot"));
        Move = Vector3.Slerp(Vector3.zero, Move, Time.deltaTime * speedRotation);
        transform.Rotate(Move.y, Move.x, Move.z * -1);

        if (Input.GetButton("Fire3"))
        {
            if (timer_shooter < time_to_shoot)
            {
                timer_shooter += 1 * Time.deltaTime;
            }
            else
            {
                timer_shooter = 0;
                SpawnBullet(shoot3.position, shoot3.forward, model_bullet2);
            }

            anim_rotator.Activ(true);
        }
        else
        {
            timer_shooter = 0;
            anim_rotator.Activ(false);
        }

        if (Input.GetButtonDown("Fire2")) SpawnBullet(shoot1.position, shoot1.forward, model_bullet);
        if (Input.GetButtonDown("Fire1")) SpawnBullet(shoot2.position, shoot2.forward, model_bullet);

        transform.position += transform.forward * speed * nitroMultiplier * speed_multiplier * Time.deltaTime;

        if (Input.GetButtonDown("Run")) AddSpeed();
        if (Input.GetButtonDown("Brake")) RemoveSpeed();

        if (RingManager.instance.currentRing != null)
        {
            brujula.gameObject.SetActive(true);
            brujula.transform.forward = RingManager.instance.currentRing.transform.position - this.transform.position;
        }
        else
        {
            brujula.gameObject.SetActive(false);
        }
    }

    void SpawnBullet(Vector3 pos, Vector3 dir, Bullet _model_bullet)
    {
        Bullet bullet = GameObject.Instantiate(_model_bullet);
        bullet.Initialize(pos, dir);
    }
}
