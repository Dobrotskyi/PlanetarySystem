using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using CustomUtil;

public class MassClass
{
    public enum MassClassType
    {
        Asteroidan,
        Mercurian,
        Subterran,
        Terran,
        Superterran,
        Neptunian,
        Jovian
    }

    public MassClassType Type { get; private set; }

    public double Mass { get; private set; }
    public double Radius { get; private set; }

    private struct MassAndRadiusRanges
    {
        public Vector2 MinMaxRadius { private set; get; }
        public Vector2 MinMaxMass { private set; get; }

        public MassAndRadiusRanges(Vector2 minMaxMass, Vector2 minMaxRadius)
        {
            MinMaxRadius = minMaxRadius;
            MinMaxMass = minMaxMass;
        }
    }

    private Dictionary<MassClassType, MassAndRadiusRanges> Specifications =
                        new Dictionary<MassClassType, MassAndRadiusRanges>()
    {
        { MassClassType.Asteroidan, new MassAndRadiusRanges(new Vector2(0, 0.00001f), new Vector2(0 , 0.03f ))},
        {MassClassType.Mercurian,   new MassAndRadiusRanges(new Vector2(0.00001f, 0.1f), new Vector2(0.03f,0.07f)) },
        {MassClassType.Subterran,   new MassAndRadiusRanges(new Vector2(0.1f, 0.5f), new Vector2(0.5f, 1.2f)) },
        {MassClassType.Terran,      new MassAndRadiusRanges(new Vector2(0.5f, 2f), new Vector2(0.8f, 1.9f)) },
        {MassClassType.Superterran, new MassAndRadiusRanges(new Vector2(2, 10), new Vector2(1.3f, 3.3f)) },
        {MassClassType.Neptunian,   new MassAndRadiusRanges(new Vector2(10,50), new Vector2(2.1f,5.7f)) },
        {MassClassType.Jovian,      new MassAndRadiusRanges(new Vector2(50, 5000), new Vector2(3.5f,27)) }
    };

    public MassClass(double mass)
    {
        Mass = mass;
        Type = Specifications.FirstOrDefault(s => (mass > s.Value.MinMaxMass.x && mass <= s.Value.MinMaxMass.y)).Key;
        Radius = Utils.GetFloatInRange(Specifications[Type].MinMaxRadius);
    }
}
