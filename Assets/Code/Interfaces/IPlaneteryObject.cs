using UnityEngine;

public interface IPlaneteryObject
{
    public Transform Transform { get; }
    public MassClass.MassClassType MassClassEnum { get; }
    public double Mass { get; }
}
