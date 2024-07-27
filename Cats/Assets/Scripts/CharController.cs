using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimState
{
    IDLE,
    WALK
}

public class CharController : MonoBehaviour
{
    public float MoveOnX = 0.9f;
    public float MoveOnZ = 0.7f;
    public float velocity = 1f;
    public Animator CharAnim;
    public bool isHuman = true;
    public FollowPosition cController;
    AnimState _animState;
    public CatController catController;
    public int catEncounters = 0;

    private float _moveX;
    private float _moveZ;
    private Rigidbody rb;
    public GameObject Fence;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }

        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        rb.useGravity = false;  
    }

    void Update()
    {
        bool isIdle = true;

        if (isHuman)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                isIdle = false;
                _animState = AnimState.WALK;
                if (transform.position.z < GameController.Instance.MaxUp)
                    _moveZ = MoveOnZ;
                else
                    _moveZ = 0;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                isIdle = false;
                _animState = AnimState.WALK;
                if (transform.position.z > GameController.Instance.MaxDown)
                    _moveZ = -MoveOnZ;
                else
                    _moveZ = 0;
            }
            else
            {
                _moveZ = 0f;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                isIdle = false;
                _animState = AnimState.WALK;
                FlipRight(CharAnim.transform);

                if (transform.position.x < GameController.Instance.MaxRight)
                {
                    _moveX = MoveOnX;
                }
                else
                {
                    if (GameController.Instance.Cats == 5)
                    {
                        GameEvents.ExitArea();
                    }
                    else
                    {
                        _moveX = 0;
                    }
                }
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                isIdle = false;
                _animState = AnimState.WALK;
                FlipLeft(CharAnim.transform);

                if (transform.position.x > GameController.Instance.MaxLeft)
                    _moveX = -MoveOnX;
                else
                    _moveX = 0;
            }
            else
            {
                _moveX = 0f;
            }

            if (isIdle)
            {
                _animState = AnimState.IDLE;
            }

            switch (_animState)
            {
                case AnimState.IDLE:
                    IdleAnim();
                    break;
                case AnimState.WALK:
                    WalkAnim();
                    break;
                default:
                    break;
            }

            Move(new Vector3(_moveX, 0, _moveZ));
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                isIdle = false;
                _animState = AnimState.WALK;
                if (transform.position.z < GameController.Instance.MaxUp)
                    _moveZ = MoveOnZ;
                else
                    _moveZ = 0;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                isIdle = false;
                _animState = AnimState.WALK;
                if (transform.position.z > GameController.Instance.MaxDown)
                    _moveZ = -MoveOnZ;
                else
                    _moveZ = 0;
            }
            else
            {
                _moveZ = 0f;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                isIdle = false;
                _animState = AnimState.WALK;
                FlipRight(CharAnim.transform);

                if (transform.position.x < GameController.Instance.MaxRight)
                {
                    _moveX = MoveOnX;
                }
                else
                {
                    if (GameController.Instance.Cats == 5)
                    {
                        GameEvents.ExitArea();
                    }
                    else
                    {
                        _moveX = 0;
                    }
                }
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                isIdle = false;
                _animState = AnimState.WALK;
                FlipLeft(CharAnim.transform);

                if (transform.position.x > GameController.Instance.MaxLeft)
                    _moveX = -MoveOnX;
                else
                    _moveX = 0;
            }
            else
            {
                _moveX = 0f;
            }

            if (isIdle)
            {
                _animState = AnimState.IDLE;
            }

            switch (_animState)
            {
                case AnimState.IDLE:
                    IdleAnim();
                    break;
                case AnimState.WALK:
                    WalkAnim();
                    break;
                default:
                    break;
            }

            Move(new Vector3(_moveX, 0, _moveZ));
        }
    }

    float CheckMoveOnZ(float f)
    {
        float value = 0;
        return value;
    }

    #region Animations
    void IdleAnim()
    {
        CharAnim.Play("Idle");
    }
    void WalkAnim()
    {
        CharAnim.Play("Walk");
    }
    #endregion

    #region Move

    void Move(Vector3 dir)
    {
        rb.MovePosition(transform.position + dir * velocity * Time.deltaTime);
    }

    #endregion

    #region Flip
    void FlipRight(Transform t)
    {
        t.localScale = new Vector3(Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
    }
    void FlipLeft(Transform t)
    {
        t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
    }
    #endregion

    public GameObject smellFish;
    public GameObject cat;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pescaderia"))
        {
            smellFish.SetActive(true);
        }
        if (other.gameObject.CompareTag("TransformToCat"))
        {
            cat.GetComponent<AudioListener>().enabled = true;
            cController.SetCatMode();
            catController.enabled = true;
            this.gameObject.SetActive(false);
            Fence.SetActive(true);
        }
    }

    public AudioSource catPurr;
    public void CatPurr()
    {
        StartCoroutine(PlayPurr());
    }

    IEnumerator PlayPurr()
    {
        catPurr.Play();
        yield return new WaitForSeconds(2);
        catPurr.Stop();
    }
    public GameObject ct1, ct2, ct3, ct4, ct5;
    public void DeactivateCateOne()
    {
        ct1.GetComponent<AudioSource>().enabled = false;
    }
    public void DeactivateCateTwo()
    {
        ct2.GetComponent<AudioSource>().enabled = false;
    }
    public void DeactivateCateThree()
    {
        ct3.GetComponent<AudioSource>().enabled = false;
    }
    public void DeactivateCateFour()
    {
        ct4.GetComponent<AudioSource>().enabled = false;
    }
    public void DeactivateCateFive()
    {
        ct5.GetComponent<AudioSource>().enabled = false;
    }
}


