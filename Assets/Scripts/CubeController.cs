using System.Collections;
using UnityEngine;



public class CubeController : MonoBehaviour
{
    [SerializeField] private float rollSpeed = 5f;
    private Vector3 _pivotPoint;
    private Vector3 _axis;
    private bool _isMoving;
    private Rigidbody _rigidbody;
    private bool _hadWallOnPreviousStep;



    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    public void Move(Vector3 direction)
    {
        if (_isMoving) return;
        var isGrounded = BlockChecker.CheckIsGrounded(transform.position);
        if (!(isGrounded || _hadWallOnPreviousStep))
        {
            return;
        }

        _hadWallOnPreviousStep = false;
        var verticalComponent = Vector3.down;
        var hasWall = BlockChecker.HasWallInDirection(transform.position, direction);
        if (hasWall)
        {
            verticalComponent = Vector3.up;
            _hadWallOnPreviousStep = true;
        }

        
        _pivotPoint = (direction / 2f) + (verticalComponent / 2f) + transform.position; //задаем точку вращения через сложение двух вескоров и
        _axis = Vector3.Cross(Vector3.up, direction);                          //прибавляем позицию куба, чтобы точка не улетела
        StartCoroutine(Roll(_pivotPoint, _axis));
        // var position = transform.position;//присвоили переменной position позицию персонажа
        // position += direction * Time.deltaTime;// сделали, чтобы при нажатии клавиши, в заданном направлении менялись координаты
        //transform.position = position;// вернули позиции персонажа измененные координаты
    }

    private IEnumerator Roll(Vector3 pivot, Vector3 axis)
    {
        _isMoving = true;
        _rigidbody.isKinematic = true;
        
        for (var i = 0; i < 90/ rollSpeed; i++)
        {
            transform.RotateAround(pivot, axis, rollSpeed);
            yield return new WaitForSeconds(0.02f);
        }
        _rigidbody.isKinematic = false;
        _isMoving = false;
        BlockChecker.SnapPositionToInteger(transform);
       
    }
    /*private void OnDrawGizmos()
    {
       
        Gizmos.color = Color.black;//цвет гизмоса
        //Gizmos.DrawSphere(_pivotPoint, 0.2f);//рисует сферу в заданной точке, определенного радиуса 
        Gizmos.DrawRay(transform.position+ _direction, Vector3.down );//рисует луч из заданной точки и оси
    }*/
}