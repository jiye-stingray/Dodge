using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;
   void Start()
   {
        //게임오브젝트에서 Rigidbody 컴포넌트를 찾아 BulletRigidbody에 할당
        bulletRigidbody = GetComponent<Rigidbody>();
        //리지드바디의 속도 = 앞쪽 방향 * 이동 속력
        bulletRigidbody.velocity = transform.forward * speed;

        //3초 뒤에 자신의 게임 오브젝트 파괴
        Destroy(gameObject, 3f);
   }

    private void OnTriggerEnter(Collider other)
    {
        //충돌한 상대방 게임 오브젝트가 Player태그를 가진 경우
        if (other.tag == "Player")
        {
            //상대방 게임 오브젝트에서 playerController 컴포넌트 가져오기 
            PlayerController playerController = other.GetComponent<PlayerController>();
            //상대방으로부터 PlayerController 컴포넌트를 가져오는 데 성공했다면
            if (playerController != null)
            {
                //상대방 PlayerController 컴포넌트의 Die()메서드 실행
                playerController.Die();
            }
        }
        
    }

}
