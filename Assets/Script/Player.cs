using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    Plane glound; // �n��
    [SerializeField] Hand hand_;
    private float speed_ = 3.0f; // �ړ����x
    private float distance_ = 0; // �n�ʂƂ̃L����

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �ړ�
        Move();
        // �}�E�X�̕���������
        Direction();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(speed_, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed_, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, speed_) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0, 0, speed_) * Time.deltaTime;
        }
    }
    private void Direction()
    {
        // �J�����ƃ}�E�X�̈ʒu������Ray������
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // �v���C���[�̍�����Plane���X�V���āA�J�����̏������ɒn�ʔ��肵�ċ������擾
        glound.SetNormalAndPosition(Vector3.up, transform.localPosition);
        if (glound.Raycast(ray, out distance_))
        {
            // ���������Ɍ�_���Z�o���āA��_�̕�������
            var lookPoint = ray.GetPoint(distance_);
            transform.LookAt(lookPoint);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        // �e�ɓ���������
        if (collider.tag == "Gun")
        {
            // �e�̍��W��ݒ�A�e�q�֌W�����
            hand_.SetPerrent(this);
        }
    }
}
