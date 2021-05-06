using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;
   void Start()
   {
        //���ӿ�����Ʈ���� Rigidbody ������Ʈ�� ã�� BulletRigidbody�� �Ҵ�
        bulletRigidbody = GetComponent<Rigidbody>();
        //������ٵ��� �ӵ� = ���� ���� * �̵� �ӷ�
        bulletRigidbody.velocity = transform.forward * speed;

        //3�� �ڿ� �ڽ��� ���� ������Ʈ �ı�
        Destroy(gameObject, 3f);
   }

    private void OnTriggerEnter(Collider other)
    {
        //�浹�� ���� ���� ������Ʈ�� Player�±׸� ���� ���
        if (other.tag == "Player")
        {
            //���� ���� ������Ʈ���� playerController ������Ʈ �������� 
            PlayerController playerController = other.GetComponent<PlayerController>();
            //�������κ��� PlayerController ������Ʈ�� �������� �� �����ߴٸ�
            if (playerController != null)
            {
                //���� PlayerController ������Ʈ�� Die()�޼��� ����
                playerController.Die();
            }
        }
        
    }

}
