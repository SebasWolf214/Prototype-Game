using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Collider2D _coll;
    private Rigidbody2D _rb;
    private Vector2 _respawn;
    private Animator Anime;

    [Header("Movimiento")]
    private float Horizontal = 0f;
    [SerializeField] private float MovementVelocity;
    [SerializeField] private float MovmentSoft;
    [SerializeField] private bool Active = true;
    private Vector3 Velocity = Vector3.zero;
    private bool WatchRight = true;

    [Header("Salto")]
    [SerializeField] private float JumpForce;
    [SerializeField] private LayerMask OnWalk;
    [SerializeField] private Transform WalkController;
    [SerializeField] private Vector3 BoxDimension;
    [SerializeField] private bool OnFloor;
    private bool Jump = false;

    [Header("DashMove")]
    [SerializeField] private float DashTime = 0.5f;
    [SerializeField] private float DashVelocity = 14f;
    private Vector2 DashDir;
    private float InicialGravity;
    private bool MakeDash;
    private bool IsDashing;

    [Header("Hair Control")]
    [SerializeField] private HairAnchor _HairAnchor;
    [SerializeField] private Vector2 IDLEOffSet;
    [SerializeField] private Vector2 RunOffSet;
    [SerializeField] private Vector2 JumpOffSet;
    [SerializeField] private Vector2 FallOffSet;
    //[Header("CoyoteTime")]
    //[SerializeField] private float CoyoteTime = 1;
    //[SerializeField] private float CoyoteTimeCounter;

    [Header("Particulas")]
    [SerializeField] private ParticleSystem DashParticles;
    //Transition Muerte
    public string transitionID;
    public float loadDelay;
    public EasyTransition.TransitionManager transitionManager;
    void Start()
    {   //Rigibody
        _rb = GetComponent<Rigidbody2D>();
        //Animaciones
        Anime = GetComponent<Animator>();
        //Collider
        _coll = GetComponent<Collider2D>();
        //Respawn
        SetRespawnPoint(transform.position);
    }
    void Update()
    {
        //Muerte Checking
        if (!Active)
        {
            return;
        }
        //Movimiento
        Horizontal = Input.GetAxisRaw("Horizontal") * MovementVelocity;
        //ANIMACIONES
        if (Horizontal > 0 || Horizontal < 0)
        {
            Anime.SetBool("Move", true);
        }
        else
        {
            Anime.SetBool("Move", false);
        }
        //Saltar
        if (Input.GetButtonDown("Jump"))
        {
            //SALTO ACTIACION
            if (OnFloor)
            {
                //OnFloor = false;
                Anime.SetBool("Jump", true);
                _rb.AddForce(new Vector2(0f, JumpForce));

            }
        }
        //Dash activacion
        if (Input.GetButtonDown("Dash") && MakeDash)
        {
            Anime.SetBool("Dash", true);
            IsDashing = true;
            MakeDash = false;
            DashDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            DashParticles.Play();
            if (DashDir == Vector2.zero)
            {
                DashDir = new Vector2(transform.localScale.x, 0);
            }
            StartCoroutine(StopDash());
        }
        if (IsDashing)
        {
            GhostEffect.me.GhostSkill();
            _rb.velocity = DashDir.normalized * DashVelocity;

            return;
        }
        if (OnFloor)
        {
            MakeDash = true;
        }
    }
    private void FixedUpdate()
    {
        OnFloor = Physics2D.OverlapBox(WalkController.position, BoxDimension, 0f, OnWalk);
        Move(Horizontal * Time.fixedDeltaTime, Jump);
        UpdateHairOffset();
        Jump = false;
    }
    private void UpdateHairOffset()
    {
        Vector2 currentOffSet = Vector2.zero;
        //IDLE
        if (_rb.velocity.x == 0 && _rb.velocity.y == 0)
        {
            currentOffSet = IDLEOffSet;
        }
        //JUMP
        else if (_rb.velocity.y > 0)
        {
            currentOffSet = JumpOffSet;
        }
        //FALL
        else if (_rb.velocity.y < 0)
        {
            currentOffSet = FallOffSet;
        }
        //RUN
        else if (_rb.velocity.x != 0)
        {
            currentOffSet = RunOffSet;
        }
        //FLIP X
        if (!WatchRight)
        {
            currentOffSet.x = currentOffSet.x * -1;
        }
        _HairAnchor.Offset = currentOffSet;
    }
    private void Move(float move, bool jump)
    {
        Vector3 GoalVelocity = new Vector2(move, _rb.velocity.y);
        _rb.velocity = Vector3.SmoothDamp(_rb.velocity, GoalVelocity, ref Velocity, MovmentSoft);
        //Girador de Sprite
        if (move > 0 && !WatchRight)
        {
            RoundSprite();
        }
        else if (move < 0 && WatchRight)
        {
            RoundSprite();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "World")
        {
            OnFloor = true;
            Anime.SetBool("Jump", false);
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        //Jump = true;
        StartCoroutine(Co_CoyoteTime());
    }
    IEnumerator Co_CoyoteTime()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        Jump = true;
        OnFloor = false;
    }
    private IEnumerator StopDash()
    {
        yield return new WaitForSeconds(DashTime);
        IsDashing = false;
        Anime.SetBool("Dash", false);
    }
    public void RoundSprite()
    {
        WatchRight = !WatchRight;
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
    public void SetRespawnPoint(Vector2 position)
    {
        _respawn = position;

    }
    public void Die()
    {
        CameraShake.Shake(0.5f, 0.25f);
        Anime.SetTrigger("Die");
        Active = false;
        _coll.enabled = false;
        _rb.bodyType = RigidbodyType2D.Static;
        //transitionManager.LoadScene(1, transitionID, loadDelay);
        StartCoroutine(Respawn());
    }
    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1.1f);
        _rb.bodyType = RigidbodyType2D.Dynamic;
        _rb.position = _respawn;
        Active = true;
        _coll.enabled = true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(WalkController.position, BoxDimension);
    }
}
