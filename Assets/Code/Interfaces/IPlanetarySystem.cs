using System.Collections.Generic;

public interface IPlanetarySystem
{
    public IEnumerable<IPlaneteryObject> PlanetaryObjects { get; }
    public void Update(float deltaTime);
}
