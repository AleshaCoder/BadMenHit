using UnityEngine;

public class Player : MonoBehaviour //xmenbro
{
	[SerializeField] private GameObject lightningObj;
	[SerializeField] private People _people;
	[SerializeField] private GameObject _planet;

    private void Start() => _people.OnLightningStrike += Strike;

    private void Strike()
    {
		var lightning = Instantiate(lightningObj, new Vector3(_people.transform.position.x,
            _people.transform.position.y, _people.transform.position.z), Quaternion.identity);

        lightning.transform.rotation = _planet.transform.rotation;

        Destroy(lightning, 1f);
    }
}
