using UnityEngine;

public class PlaneteryObject : MonoBehaviour, IPlaneteryObject
{
    private MassClass _massClass;
    public double Mass => _massClass.Mass;
    public MassClass.MassClassType MassClassEnum => _massClass.Type;
    public double Radius => _massClass.Radius;
    public Transform Transform => transform;

    public void Init(double mass)
    {
        _massClass = new(mass);
        transform.localScale = Vector3.one * (float)_massClass.Radius;
        GetComponent<SpriteRenderer>().color = Random.ColorHSV();

        ApplyToTrail();
    }

    private void ApplyToTrail()
    {
        TrailRenderer trailRenderer = GetComponentInChildren<TrailRenderer>();

        Keyframe[] keyframes = trailRenderer.widthCurve.keys;
        for (int i = 0; i < keyframes.Length; i++)
            keyframes[i].value *= (float)_massClass.Radius;

        trailRenderer.widthCurve = new(keyframes);
    }
}
