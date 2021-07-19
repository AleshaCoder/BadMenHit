using UnityEngine;
[CreateAssetMenu]
public class WalkState : HumanState
{
    private float _speed = 10.1f;
    private float _maxAngle = 0;

    public override void Init()
    {
        base.Init();
        _maxAngle = (Random.Range(-10, 10)+1) * 20;
        if (_maxAngle > 0) Human.transform.Rotate(new Vector3(0, 1), 180);
        Human.Animator.SetInteger("State", 1);
    }

    public override void Run()
    {
        if (Finished)
            return;
        if (Mathf.Abs(_maxAngle) <= 1)
        {
            if (_maxAngle > 0) Human.transform.Rotate(new Vector3(0, 1), 180);
            Finished = true;
        }
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        Human.transform.RotateAround(Human.Planet.transform.position, new Vector3(0, 0, _maxAngle / Mathf.Abs(_maxAngle)), _speed * Time.deltaTime);
        _maxAngle -= _speed * Time.deltaTime * _maxAngle / Mathf.Abs(_maxAngle);
    }
}
