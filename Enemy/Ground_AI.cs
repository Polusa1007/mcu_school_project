using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//YEE_DINO
public class Ground_AI : MonoBehaviour
{
    public float moveSpeed = 3f;  // �ĤH���ʳt��
    public float detectionRange = 3f; // �˴����a���d��
    public Transform player; // ���a��Transform�ե�
    public Animator animator;
    SpriteRenderer sprite;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        // �ˬd���a�O�_�b�˴��dQ��
        if (PlayerInRange())
        {
            animator.SetBool("Run", true);
            // �p�G���a�b�˴��d�򤺡A�h���ʼĤH�¦V���a
            MoveTowardsPlayer();
        }
        else
        {
            animator.SetBool("Run", false);
        }
        sprite.flipX = player.position.x > transform.position.x ? true : false;

    }

    bool PlayerInRange()
    {
        // �p��ĤH�P���a������X�b�Z��
        float distanceToPlayerX = Mathf.Abs(player.position.x - transform.position.x);

        // �p�GX�b�Z���p���˴��d��A��^true�A�_�h��^false
        return distanceToPlayerX < detectionRange;
    }

    void MoveTowardsPlayer()
    {
        // �p��X�b�W�����ʦV�q
        float moveDirectionX = (player.position.x - transform.position.x > 0) ? 1f : -1f;

        // ���ʼĤH
        transform.Translate(new Vector2(moveDirectionX, 0f) * moveSpeed * Time.deltaTime);
    }
}
