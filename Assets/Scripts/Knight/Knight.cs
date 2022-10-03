using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Knight : Container
{
    [SerializeField] private int _needSwords;
    [SerializeField] private float _speed;
    [SerializeField] private BoxCollider _collider;
    [SerializeField] private GameObject _moneyPrefab;
    [SerializeField] private Transform _moneySpawn;
    [SerializeField] private Animator _animator;
    [SerializeField] private Sword _sword;
    [SerializeField] private float _secondForJump;
    [SerializeField] private float _rotateDuration;

    private float _currentSpeed;
    private bool _isFill = false;
    private bool _isStop;
    private float _ellapsedTime;
    private Vector3 _direction;
    private Vector3 _directionToStore = new Vector3(0f, 1f, 0f);
    private Vector3 _directionToBattle = new Vector3(0f, 181f, 0f);

    private const float ZTopBoard = 18f;
    private const float ZDownBoard = 12f;
    private const string WalkAnimation = "Walk";
    private const string JumpAnimation = "Jump";

    public int NeedSwords => _needSwords;
    public event UnityAction<int> SwordsChanged;

    private void Start()
    {
        _currentSpeed = _speed;
        _ellapsedTime = _secondForJump;
        transform.rotation = Quaternion.LookRotation(Vector3.forward);
        RunToStore();
    }

    private void Update()
    {
        _ellapsedTime += Time.deltaTime;
        transform.Translate(_direction * _currentSpeed * Time.deltaTime);
        if (transform.position.z < ZDownBoard && !_isFill)
            Stop();
        if (transform.position.z > ZTopBoard && _isFill)
            RunToStore();
        if (_isFill && _isStop && _ellapsedTime > _secondForJump )     
            RunToBattle();
        if (!_isStop && _currentSpeed < _speed)
            _currentSpeed += Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        Container container;
        if (other.TryGetComponent<Container>(out container) && Items.Count < _needSwords)
        {
            Take(container);
            SwordsChanged?.Invoke(Items.Count);
        }
        else if (Items.Count == _needSwords && !_isFill)
        {
            SwordsChanged?.Invoke(Items.Count);
            _isFill = true;
            _ellapsedTime = 0;
            _sword.gameObject.SetActive(true);
            Jump(); 
        }
    }

    private void RunToStore()
    {
        Items.Clear();
        if (_isFill)
        {
            transform.DORotate(_directionToStore, 0);
            _isFill = false;
        }
        _collider.enabled = true;
        _sword.gameObject.SetActive(false);
        _animator.SetBool(WalkAnimation, true);
        _direction = Vector3.back;
    }

    private void Jump()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward);
        _animator.SetBool(JumpAnimation, true);
    }

    private void RunToBattle()
    {
        _isStop = false;
        _animator.SetBool(JumpAnimation, false);
        Instantiate(_moneyPrefab, _moneySpawn.position, Quaternion.identity);
        _collider.enabled = false;
        _animator.SetBool(WalkAnimation, true);
        _direction = Vector3.back;
        transform.DORotate(_directionToBattle, _rotateDuration);
    }

    private void Stop()
    {
        _currentSpeed = 0;
        transform.rotation = Quaternion.LookRotation(Vector3.back);
        _direction = Vector3.zero;
        SwordsChanged?.Invoke(Items.Count);
        _animator.SetBool(WalkAnimation, false);
        _isStop = true;
    }
}
