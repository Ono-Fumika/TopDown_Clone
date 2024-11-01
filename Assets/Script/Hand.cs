using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] Gun gun_;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPerrent(Player player)
    {
        // �e�̍��W��ݒ肷��
        Vector3 offset = new Vector3(0.1f, 0.1f, 0.5f); // �e�̈ʒu�̃I�t�Z�b�g
        Vector3 pos = player.transform.position + player.transform.TransformDirection(offset);
        gun_.transform.position = pos;

        // �e���v���C���[�̎q�ɂ���
        gun_.transform.parent = player.transform;
    }
}
