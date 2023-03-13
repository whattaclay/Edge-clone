using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using Update = Unity.VisualScripting.Update;

public class MainCharacter : MonoBehaviour
{
    [SerializeField] private float rollSpeed = 5f;
    private Vector3 _pivotPoint;
    private Vector3 _axis;
    private bool _isMoving;
    private Rigidbody _rigidbody;
    private bool _isFalling;
    private Vector3 _verticalComponent = Vector3.down;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private bool FallingController()
    {
        return !Physics.Raycast(transform.position, Vector3.down, 0.55f);
        /*if (!Physics.Raycast(transform.position, Vector3.down, 0.5f))
        {
            _rigidbody.freezeRotation = true;
            _isMoving = true;
        }*/
    }
    void Update()
    {   
        if (_isMoving)return;
        _isFalling = FallingController();
        _rigidbody.freezeRotation = _isFalling;
        if (_isFalling) return;
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
        
        var hasWall = HasWallInDirection(direction);
        if (hasWall)
        {
            _verticalComponent = Vector3.up;
        }
        _pivotPoint = (direction / 2f) + (_verticalComponent / 2f) + transform.position; //задаем точку вращения через сложение двух вескоров и
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
        int deg = 90;
        if (_verticalComponent != Vector3.down)
        {
            deg = 180;
        }
        for (var i = 0; i < deg / rollSpeed; i++)
        {
            transform.RotateAround(pivot, axis, rollSpeed);
            yield return new WaitForSeconds(0.02f);
        }
        /*if (_isFalling)
        {
            _rigidbody.isKinematic = false;
            _rigidbody.freezeRotation= true;
            _isFalling = false;
        }*/
        _rigidbody.isKinematic = false;
        _isMoving = false;
        _verticalComponent = Vector3.down;
    }
    /*private void OnDrawGizmos()
    {
       
        //Gizmos.color = Color.black;//цвет гизмоса
        //Gizmos.DrawSphere(_pivotPoint, 0.2f);//рисует сферу в заданной точке, определенного радиуса 
        //Gizmos.DrawRay(_pivotPoint, _fallingDirection );//рисует луч из заданной точки и оси
    }*/
   
}


