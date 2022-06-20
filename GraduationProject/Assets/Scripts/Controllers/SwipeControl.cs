using UnityEngine;
using UnityEngine.UI;
using InControl;
using com;

public class SwipeControl : MonoBehaviour
{
	public static bool isDynamic;
	public static float rotation;
	[SerializeField]
	private GameObject _ballista;
	[SerializeField]
	private Arrow _arrow;
	[SerializeField]
	private GameObject _arrowContainer;
	[SerializeField]
	private bool _shouldExpand;
	[SerializeField]
	private int _amountToPool;
	[SerializeField]
	private Button _fireButton;
	private int _arrowsAmount;
	private ObjectPooler<Arrow> _pooler;

	private void Awake()
	{
		_arrowsAmount = _amountToPool;
		isDynamic = true;
		rotation = 0;
	}

	private void Start()
	{
		_fireButton.onClick.AddListener(Fire);
		_pooler = new ObjectPooler<Arrow>(_arrowContainer, _arrow, _amountToPool, _shouldExpand);
	}

	private void Update()
	{
		var inputDevice = InputManager.ActiveDevice;
		if (inputDevice.LeftStick.IsPressed)
		{
			_ballista.transform.Rotate(new Vector3(0, 0, 5), 100 * Time.deltaTime * inputDevice.Direction.Y, Space.World);
			rotation = _ballista.transform.rotation.eulerAngles.z;
		}
	}

	private void Fire()
	{
		_arrow = _pooler.GetPooledObject();
		_arrowsAmount--;
		if (_arrow != null)
		{
			EventManager.DispatchEvent(EventManager.FIRED,null);
			AudioManager.SingletonInstance.PlaySound(AudioName.BallistaFire);
			_arrow.transform.position = _ballista.transform.position;
			_arrow.transform.rotation = _ballista.transform.rotation;
		}
	}
}