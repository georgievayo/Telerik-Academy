namespace FactoryLib
{
    using CatalogueLib.Products;
    using CatalogueLib.Products.Enumerations;

    public interface IBigAppliancesFactory
    {
        AirConditioner CreateAirConditioner(decimal price, bool isAvailable, int brand, string Color, string CountryOfBirth, string TypeOfSystem, bool HasWiFi);

        Oven CreateOven(decimal price, bool isAvailable, Brand brand, string Color, string CountryOfBirth, string ElectricOrGas);

        Refrigerator CreateRefrigerator(decimal price, bool isAvailable, Brand brand, string Color, string CountryOfBirth, string TypeOfTechnology);

        WashingMachine CreateWashingMachine(decimal price, bool isAvailable, Brand brand, string Color, string CountryOfBirth, string LaundryCapacity, string MotorType);
    }
}
