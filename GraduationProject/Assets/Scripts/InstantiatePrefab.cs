using UnityEngine;
using UnityEngine.UI;

public class InstantiatePrefab : MonoBehaviour
{
    public static bool isDynamic;
    public static int cannonRotation;
    [SerializeField]
    private GameObject _arrowContainer;
    [SerializeField]
    private Transform _parent;
    [SerializeField]
    private Button _upButton;
    [SerializeField]
    private Button _downButton;
    [SerializeField]
    private Button _fireButton;
    [SerializeField]
    private bool _shouldExpand;
    [SerializeField]
    private int _amountToPool;
    [SerializeField]
    private CannonballScript _arrow;
    private ObjectPooler<CannonballScript> _pooler;

    private void Awake()
    {
        isDynamic = true;
        cannonRotation = 0;
    }

    void Start()
    { 
        _upButton.onClick.AddListener(Up);
        _downButton.onClick.AddListener(Down);
        _fireButton.onClick.AddListener(Fire);
        _pooler = new ObjectPooler<CannonballScript>(_arrowContainer, _arrow, _amountToPool, _shouldExpand);
    }

   private void Up()
    {
        if (cannonRotation < Constants.MAX_ROTATION)
        {
            _parent.transform.Rotate(new Vector3(0, 0, Constants.DIFF));
            cannonRotation += Constants.DIFF;
        }
    }

    private void Down()
    {
        if (cannonRotation > Constants.MIN_ROTATION)
        {
            _parent.transform.Rotate(new Vector3(0, 0, -Constants.DIFF));
            cannonRotation -= Constants.DIFF;
        }
    }

    private void Fire()
    {
        _arrow = _pooler.GetPooledObject();
        if (_arrow != null)
        {
            AudioManager.SingletonInstance.PlaySound(AudioName.BallistaFire);
            _arrow.transform.position = _parent.transform.position;
            _arrow.transform.rotation = _parent.transform.rotation;
        }
    }
}