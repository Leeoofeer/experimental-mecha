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
    public Animator CharAnim;
    public bool isHuman = true;
    AnimState _animState;

    float _moveX;
    float _moveZ;

    void Update()
    {
        bool isIdle = true;

        if (isHuman)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                isIdle = false;
                _animState = AnimState.WALK;
                if (this.transform.position.z < GameController.Instance.MaxUp)
                    _moveZ = MoveOnZ;
                else
                    _moveZ = 0;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                isIdle = false;
                _animState = AnimState.WALK;
                if (this.transform.position.z > GameController.Instance.MaxDown)
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

                if (this.transform.position.x < GameController.Instance.MaxRight)
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

                if (this.transform.position.x > GameController.Instance.MaxLeft)
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

            Move(this.transform, new Vector3(_moveX, 0, _moveZ));
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                isIdle = false;
                _animState = AnimState.WALK;
                if (this.transform.position.z < GameController.Instance.MaxUp)
                    _moveZ = MoveOnZ;
                else
                    _moveZ = 0;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                isIdle = false;
                _animState = AnimState.WALK;
                if (this.transform.position.z > GameController.Instance.MaxDown)
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

                if (this.transform.position.x < GameController.Instance.MaxRight)
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

                if (this.transform.position.x > GameController.Instance.MaxLeft)
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

            Move(this.transform, new Vector3(_moveX, 0, _moveZ));
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

    void Move(Transform t, Vector3 dir)
    {
        t.position += new Vector3(dir.x * Time.deltaTime, 0, dir.z * Time.deltaTime);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pescaderia"))
        {
            smellFish.SetActive(true);
        }
    }

}
