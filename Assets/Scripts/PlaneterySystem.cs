using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlaneterySystem : IPlanetarySystem
{
    private const float G = 100f;
    private readonly double _systemTotalMass;

    private List<IPlaneteryObject> _planeteryObjects = new();

    public IEnumerable<IPlaneteryObject> PlanetaryObjects => _planeteryObjects;

    public void Update(float deltaTime)
    {
        foreach (var celestial in _planeteryObjects)
        {
            float speed = Mathf.Sqrt((float)(G * _systemTotalMass) / celestial.Transform.position.magnitude);
            celestial.Transform.RotateAround(Vector3.zero, Vector3.forward, speed * deltaTime);
        }
    }

    public PlaneterySystem(List<IPlaneteryObject> planeteries)
    {
        _planeteryObjects = planeteries;
        _systemTotalMass = _planeteryObjects.Sum(o => o.Mass);
    }
}
