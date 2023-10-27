using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneteryObject : MonoBehaviour, IPlaneteryObject
{
    private MassClass _massClass;
    //public MassClass.MassClassType MassClassEnum { get; protected set; }
    public double Mass => throw new System.NotImplementedException();

    public MassClass.MassClassType MassClassEnum { get => throw new System.NotImplementedException(); }

}
