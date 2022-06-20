using UnityEngine;
public class ParticleManager : Singleton<ParticleManager>
{
    [SerializeField]
    private ParticleSystem _explosionParticles;

    private void Awake()
    {
        if (_explosionParticles == null)
        {
            _explosionParticles = GetComponent<ParticleSystem>();
        }
    }
    public void PlayExplosionParticle(Vector3 playPosition)
    {
        _explosionParticles.gameObject.SetActive(true);
        _explosionParticles.transform.position = playPosition;
        _explosionParticles.Play();
        Invoke("Hide", 2f);
        //ParticleSystem ps = Instantiate(_explosionParticles, playPosition, Quaternion.identity) as ParticleSystem;
    }

    private void Hide()
    {
        _explosionParticles.gameObject.SetActive(false);
    }
}