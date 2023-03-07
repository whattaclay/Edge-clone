using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainCharacter : MonoBehaviour
{
    [SerializeField] private float rollSpeed = 5f;
    private Vector3 _pivotPoint;
    private Vector3 _axis;
    private bool _isMoving;
    private Rigidbody _rigidbody;
    private Vector3 _fallingDirection = Vector3.down;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (!Physics.Raycast(transform.position, _fallingDirection, 1f))
        {
            Debug.Log("falling");
        }
        if (_isMoving) return;
        if (Input.GetKey(KeyCode.A))
        {
            Move(Vector3.left);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Move(Vector3.right);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            Move(Vector3.forward);
        } 
        else if (Input.GetKey(KeyCode.S))
        {
            Move(Vector3.back);
        }
        
    }
    

   
    private void Move(Vector3 direction)
    {
        var verticalComponent = Vector3.down;
        var hasWall = HasWallInDirection(direction);
        if (hasWall)
        {
            verticalComponent = Vector3.up;
        }
        _pivotPoint = (direction / 2f) + (verticalComponent / 2f) + transform.position; //задаем точку вращения через сложение двух вескоров и
        _axis = Vector3.Cross(Vector3.up, direction);                          //прибавляем позицию куба, чтобы точка не улетела
        StartCoroutine(Roll(_pivotPoint, _axis));
        
        // var position = transform.position;//присвоили переменной position позицию персонажа
        // position += direction * Time.deltaTime;// сделали, чтобы при нажатии клавиши, в заданном направлении менялись координаты
        //transform.position = position;// вернули позиции персонажа измененные координаты
    }
    private bool HasWallInDirection(Vector3 direction)
    {
        return Physics.Raycast(transform.position, direction, 0.55f);
    }

    private IEnumerator Roll(Vector3 pivot, Vector3 axis)
    {
        _isMoving = true;
        _rigidbody.isKinematic = true;

        for (int i = 0; i < 90 / rollSpeed; i++)
        {
            transform.RotateAround(pivot, axis, rollSpeed);
            yield return new WaitForSeconds(0.02f);
        }
        
        _rigidbody.isKinematic = false;
        _isMoving = false;
    }
    private void OnDrawGizmos()
    {
       
         //Gizmos.color = Color.black;//цвет гизмоса
        //Gizmos.DrawSphere(_pivotPoint, 0.2f);//рисует сферу в заданной точке, определенного радиуса 
        //Gizmos.DrawRay(_pivotPoint, _axes );//рисует луч из заданной точки и оси
    }
   
}


