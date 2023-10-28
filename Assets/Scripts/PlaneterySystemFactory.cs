using CustomUtil;
using System.Collections.Generic;
using UnityEngine;

public class PlaneterySystemFactory : MonoBehaviour, IPlaneterySystemFactory
{
    private const int MAX_OBJECTS = 10;
    private const double MIN_OBJECT_MASS = 0.000001;
    private const float DISTANCE_OFFSET = 1f;

    [SerializeField] private PlaneteryObject _planeteryObjectPref;

    public IPlanetarySystem Create(double mass)
    {
        List<IPlaneteryObject> objects = new();
        float lastObjectXPos = 0;
        while (mass > 0)
        {
            PlaneteryObject newObject = Instantiate(_planeteryObjectPref);
            if (objects.Count == MAX_OBJECTS - 1)
                newObject.Init(mass);
            else
                newObject.Init(Utils.GetDoubleInRange(MIN_OBJECT_MASS, mass));

            mass -= newObject.Mass;

            Vector3 position = newObject.transform.position;
            position.x += (float)(DISTANCE_OFFSET * newObject.Radius) + DISTANCE_OFFSET + lastObjectXPos;
            newObject.transform.position = position;
            lastObjectXPos = newObject.transform.position.x;

            objects.Add(newObject);
        }

        return new PlaneterySystem(objects);
    }
}
