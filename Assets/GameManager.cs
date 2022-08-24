using UnityEngine;

public class GameManager : MonoBehaviour
{
	#region General Setup --Don't need to mess with this--

	[SerializeField] private float _arrowDepth;
	[SerializeField] private int _numArrows;
	[SerializeField] private GameObject _arrowPrefab;

	private GameObject[] _arrows;

	private void Awake()
	{
		// Spawn the arrows - no need to mess with this unless you want to
		_arrows = new GameObject[_numArrows];
		for (int i = 0; i < _numArrows; ++i)
		{
			Vector3 randPos =
				Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * Random.Range(0f, 1f), Screen.height* Random.Range(0f, 1f),
					(-Camera.main.transform.position.z + _arrowDepth) * 1.5f));
			randPos.z = _arrowDepth + Random.Range(0f, 1f) * _arrowDepth;
			_arrows[i] = Instantiate(_arrowPrefab, randPos, Quaternion.identity);
			_arrows[i].transform.parent = transform;
		}
	}

	#endregion

}
