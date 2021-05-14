using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public GameObject bulletPrefab; // ������ ź���� ���� ������
    public float spawnRateMin = 0.5f; //�ּ� ���� �ֱ�
    public float spawnRateMax = 3f; // �ִ� ���� �ֱ�

    private Transform target; //�߻��� ���
    private float spawnRate; //�����ֱ�
    private float timeAfterSpawn; //�ֱ� ���� �������� ���� �ð�
    
    void Start()
    {
        //�ֱ� ���� ������ ���� �ð��� 0���� �ʱ�ȭ 
        timeAfterSpawn = 0f;
        //ź�� ���� ������ spawnRateMin�� spawnRateMax ���̿��� ���� ����
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        //PlayerController ������Ʈ�� ���� ���� ������Ʈ�� ã�� ���ش������ ����
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        //timeAfterSpawn ����
        timeAfterSpawn += Time.deltaTime;
        //�ֱ� ���� ������������ ������ �ð��� �����ֱ� ���� ũ�ų� ���ٸ�
        if (timeAfterSpawn >= spawnRate)
        {
            //������ �ð��� ����
            timeAfterSpawn = 0f;

            //bulletPrefab�� �������� 
            //transform.position ��ġ�� transform.rotation ȸ������ ����
            GameObject bullet
                = Instantiate(bulletPrefab, transform.position, transform.rotation);
            //������ bullet ���� ������Ʈ�� ���� ������ target�� ���ϵ��� ȸ��
            bullet.transform.LookAt(target);
            //������ ���� ������ spanwnRateMin, spawnRateMax ���̿��� ��������
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            
        }

    }
}
