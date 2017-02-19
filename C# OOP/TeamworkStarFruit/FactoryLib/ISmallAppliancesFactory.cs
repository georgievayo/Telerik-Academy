namespace FactoryLib
{
    using CatalogueLib.Products;
    using CatalogueLib.Products.Enumerations;

    public interface ISmallAppliancesFactory
    {
        Mixer CreateMixer(decimal price, bool isAvailable, Brand brand, double Capacity, double CableLength, int Affixes, bool HasBowl);

        HairDryer CreateHairDryer(decimal price, bool isAvailable, Brand brand, double Capacity, double CableLength, int Affixes, int DifferentSpeeds);

        VacuumCleaner CreateVacuumCleaner(decimal price, bool isAvailable, Brand brand, double Capacity, double CableLength, int Affixes, double GarbageBagVolume);
    }
}
