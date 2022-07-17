
using Assets.Scripts;
using Assets.Scripts.Components;
using System;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float _speed;
    protected Rigidbody Rigidbody;
    protected Animator Animator;
    protected Vector3 Direction;
    [SerializeField] private CheckSphereOverlap _onKick;
    [SerializeField] private int _currentHealth;

    private HealthComponent _health;
    public event Action OnMenu;


    private static readonly int KickKey = Animator.StringToHash("Kick");
    private static readonly int Speed = Animator.StringToHash("Speed");


    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Animator = GetComponent<Animator>();
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    private void Start()
    {
        _health = GetComponent<HealthComponent>();
        _health.SetHealth(_currentHealth);
    }

    public void OnHealthChanged(int currentHealth)
    {
        _currentHealth = currentHealth;
    }
    private void FixedUpdate()
    {
        var xVelocity = Direction.x * _speed;
        var zVelocity = Direction.y * _speed;
        Rigidbody.velocity = new Vector3(xVelocity, 0, zVelocity);

        Animator.SetFloat(Speed, Rigidbody.velocity.magnitude);
    }

    public void Kick()
    {
        Animator.SetTrigger(KickKey);
    }

    public void Check()
    {
        _onKick.Check();
    }


    public void LoadMenu()
    {
        OnMenu?.Invoke();
    }
}
