using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

public class SimulatonController : MonoBehaviour
{
    private const float FIRST_STEP = 1000;

    [SerializeField] private float _deltaTime = 0.0001f;
    private IPlanetarySystem _planeterySystem;
    private IPlaneterySystemFactory _factory;

    public void CreateNewSystem(TMP_InputField field)
    {
        if (double.Parse(field.text) <= 0)
            return;

        foreach (var celestial in _planeterySystem.PlanetaryObjects)
            Destroy(celestial.Transform.gameObject);

        _planeterySystem = _factory.Create(double.Parse(field.text));
        StartSimulation();
    }

    private void Awake()
    {
        _factory = FindObjectsOfType<MonoBehaviour>().OfType<IPlaneterySystemFactory>().First();
        _planeterySystem = _factory.Create(8);
        StartSimulation();
    }

    private void StartSimulation()
    {
        StopAllCoroutines();
        StartCoroutine(UpdateSimulation());
    }

    private IEnumerator UpdateSimulation()
    {
        _planeterySystem.Update(FIRST_STEP);
        while (true)
        {
            _planeterySystem.Update(_deltaTime);
            yield return new WaitForSeconds(_deltaTime);
        }
    }
}
