namespace CatalogueLib
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Collections.Generic;

    using ExceptionLib;
    using Products.Enumerations;
    using Products;

    public class Catalogue : IChangeable, ISortable
    {
        private XDocument xmldoc;
        private IList<Product> catalogueList;

        public Catalogue()
        {
            this.CatalogueList = new List<Product>();
            CatalogInitializer();
        }

        public IList<Product> CatalogueList
        {
            get
            {
                return new List<Product>(this.catalogueList);
            }
            private set
            {
                this.catalogueList = value;
            }
        }


        /// <summary>
        /// Load data from xml to a List
        /// with all possible classes.
        /// The properties are parsed properly
        /// and the list stores objects of the classes which represent the bisiness logic.
        /// </summary>
        private void CatalogInitializer()
        {
            xmldoc = XDocument.Load(@"C:\Users\Yoana\Desktop\Telerik-OOP-Team-StarFruit\TeamworkStarFruit\CatalogueLib\Data\ProductsData.xml");   //add xml document  
            var airConditions = xmldoc.Descendants("AirConditioner")
                .Select(p => new AirConditioner(
                int.Parse(p.Element("id").Value),
                decimal.Parse(p.Element("price").Value),
                 (p.Element("isAvailable").Value == "true" ? true : false),
                (Brand)int.Parse(p.Element("brand").Value),
                p.Element("color").Value,
                 p.Element("origin").Value,
                 p.Element("typeOfSystem").Value,
                 (p.Element("HasWiFi").Value == "true" ? true : false)
                ));
            foreach (var item in airConditions)
            {
                AddProduct(item);
            }

            //oven
            var ovens = xmldoc.Descendants("Oven")
                .Select(p => new Oven(
                int.Parse(p.Element("id").Value),
                decimal.Parse(p.Element("price").Value),
                 (p.Element("isAvailable").Value == "true" ? true : false),
                 (Brand)int.Parse(p.Element("brand").Value),
                p.Element("color").Value,
                 p.Element("origin").Value,
                 p.Element("electricOrGas").Value
                ));
            foreach (var item in ovens)
            {
                AddProduct(item);
            }
            //refrigerator
            var refrigerators = xmldoc.Descendants("Refrigerator")
                .Select(p => new Refrigerator(
                int.Parse(p.Element("id").Value),
                decimal.Parse(p.Element("price").Value),
                 (p.Element("isAvailable").Value == "true" ? true : false),
                 (Brand)int.Parse(p.Element("brand").Value),
                p.Element("color").Value,
                 p.Element("origin").Value,
                 p.Element("typeOfTechnology").Value
                ));
            foreach (var item in refrigerators)
            {
                AddProduct(item);
            }
            //washing machine
            var washingMachines = xmldoc.Descendants("WashingMachine")
              .Select(p => new WashingMachine(
              int.Parse(p.Element("id").Value),
              decimal.Parse(p.Element("price").Value),
               (p.Element("isAvailable").Value == "true" ? true : false),
               (Brand)int.Parse(p.Element("brand").Value),
              p.Element("color").Value,
               p.Element("origin").Value,
               p.Element("laundryCapacity").Value,
               p.Element("motorType").Value
              ));
            foreach (var item in washingMachines)
            {
                AddProduct(item);
            }
            //desktops
            var desktops = xmldoc.Descendants("Desktop")
              .Select(p => new Desktop(
              int.Parse(p.Element("id").Value),
              decimal.Parse(p.Element("price").Value),
               (p.Element("isAvailable").Value == "true" ? true : false),
               (Brand)int.Parse(p.Element("brand").Value),
              p.Element("CPU").Value,
              int.Parse(p.Element("driveMemory").Value),
              p.Element("videoCardModel").Value,
              p.Element("operationSystem").Value,
              double.Parse(p.Element("screenSize").Value),
              int.Parse(p.Element("RAM").Value),
              p.Element("hasDVDRecorder").Value == "true" ? true : false
              ));
            foreach (var item in desktops)
            {
                AddProduct(item);
            }
            //laptop
            var laptops = xmldoc.Descendants("Laptop")
              .Select(p => new Laptop(
              int.Parse(p.Element("id").Value),
              decimal.Parse(p.Element("price").Value),
               (p.Element("isAvailable").Value == "true" ? true : false),
               (Brand)int.Parse(p.Element("brand").Value),
              p.Element("CPU").Value,
              int.Parse(p.Element("driveMemory").Value),
              p.Element("videoCardModel").Value,
              p.Element("operationSystem").Value,
              double.Parse(p.Element("screenSize").Value),
              int.Parse(p.Element("RAM").Value),
              int.Parse(p.Element("howManyUSBPorts").Value)
              ));
            foreach (var item in laptops)
            {
                AddProduct(item);
            }

            //ebook
            var ebooks = xmldoc.Descendants("EBook")
              .Select(p => new EBook(
              int.Parse(p.Element("id").Value),
              decimal.Parse(p.Element("price").Value),
               (p.Element("isAvailable").Value == "true" ? true : false),
               (Brand)int.Parse(p.Element("brand").Value),
               int.Parse(p.Element("memory").Value),
              p.Element("CPU").Value,
              int.Parse(p.Element("RAM").Value),
              p.Element("model").Value,
              p.Element("battery").Value,
              p.Element("connectivity").Value,
              p.Element("expandableMemory").Value == "true" ? true : false,
              double.Parse(p.Element("screenSize").Value),
              p.Element("supportedFileFormat").Value
              ));
            foreach (var item in ebooks)
            {
                AddProduct(item);
            }
            //mobile phone
            var mobilePhones = xmldoc.Descendants("MobilePhone")
              .Select(p => new MobilePhone(
              int.Parse(p.Element("id").Value),
              decimal.Parse(p.Element("price").Value),
               (p.Element("isAvailable").Value == "true" ? true : false),
               (Brand)int.Parse(p.Element("brand").Value),
               int.Parse(p.Element("memory").Value),
              p.Element("CPU").Value,
              int.Parse(p.Element("RAM").Value),
              p.Element("model").Value,
              p.Element("battery").Value,
              p.Element("connectivity").Value,
              p.Element("expandableMemory").Value == "true" ? true : false,
              double.Parse(p.Element("screenSize").Value),
              p.Element("GPU").Value,
              p.Element("OperatingSystem").Value
              ));
            foreach (var item in mobilePhones)
            {
                AddProduct(item);
            }
            //tablet
            var tablets = xmldoc.Descendants("Tablet")
              .Select(p => new Tablet(
              int.Parse(p.Element("id").Value),
              decimal.Parse(p.Element("price").Value),
               (p.Element("isAvailable").Value == "true" ? true : false),
               (Brand)int.Parse(p.Element("brand").Value),
               int.Parse(p.Element("memory").Value),
              p.Element("CPU").Value,
              int.Parse(p.Element("RAM").Value),
              p.Element("model").Value,
              p.Element("battery").Value,
              p.Element("connectivity").Value,
              p.Element("expandableMemory").Value == "true" ? true : false,
              double.Parse(p.Element("screenSize").Value),
              double.Parse(p.Element("frontCamera").Value),
              double.Parse(p.Element("backCamera").Value),
              p.Element("hasGPS").Value == "true" ? true : false
              ));
            foreach (var item in tablets)
            {
                AddProduct(item);
            }
            //smart watches
            var smartWatches = xmldoc.Descendants("SmartWatch")
              .Select(p => new SmartWatch(
              int.Parse(p.Element("id").Value),
              decimal.Parse(p.Element("price").Value),
               (p.Element("isAvailable").Value == "true" ? true : false),
               (Brand)int.Parse(p.Element("brand").Value),
               int.Parse(p.Element("memory").Value),
              p.Element("CPU").Value,
              int.Parse(p.Element("RAM").Value),
              p.Element("model").Value,
              p.Element("battery").Value,
              p.Element("connectivity").Value,
              p.Element("expandableMemory").Value == "true" ? true : false,
              double.Parse(p.Element("screenSize").Value),
              double.Parse(p.Element("size").Value),
              p.Element("waterResistance").Value == "true" ? true : false
              ));
            foreach (var item in smartWatches)
            {
                AddProduct(item);
            }
            //hair dryer
            var hairDryers = xmldoc.Descendants("HairDryer")
              .Select(p => new HairDryer(
              int.Parse(p.Element("id").Value),
              decimal.Parse(p.Element("price").Value),
               (p.Element("isAvailable").Value == "true" ? true : false),
               (Brand)int.Parse(p.Element("brand").Value),
               double.Parse(p.Element("capacity").Value),
               double.Parse(p.Element("cableLength").Value),
               int.Parse(p.Element("affixes").Value),
               int.Parse(p.Element("differentSpeeds").Value)
              ));
            foreach (var item in hairDryers)
            {
                AddProduct(item);
            }
            //mixer
            var mixers = xmldoc.Descendants("Mixer")
              .Select(p => new Mixer(
              int.Parse(p.Element("id").Value),
              decimal.Parse(p.Element("price").Value),
               (p.Element("isAvailable").Value == "true" ? true : false),
               (Brand)int.Parse(p.Element("brand").Value),
               double.Parse(p.Element("capacity").Value),
               double.Parse(p.Element("cableLength").Value),
               int.Parse(p.Element("affixes").Value),
               p.Element("hasBowl").Value == "true" ? true : false
              ));
            foreach (var item in mixers)
            {
                AddProduct(item);
            }
            //vacuum cleaner
            var vacuumCleaners = xmldoc.Descendants("VacuumCleaner")
              .Select(p => new VacuumCleaner(
              int.Parse(p.Element("id").Value),
              decimal.Parse(p.Element("price").Value),
               (p.Element("isAvailable").Value == "true" ? true : false),
               (Brand)int.Parse(p.Element("brand").Value),
               double.Parse(p.Element("capacity").Value),
               double.Parse(p.Element("cableLength").Value),
               int.Parse(p.Element("affixes").Value),
               double.Parse(p.Element("garbageBagVolume").Value)
              ));
            foreach (var item in vacuumCleaners)
            {
                AddProduct(item);
            }
        }

        public void InsertAirConditionerInXml(AirConditioner air)
        {
            XElement airCond = new XElement("AirConditioner",
                    new XElement("id", air.ID),
                    new XElement("price", air.Price),
                    new XElement("isAvailable", air.IsAvailable),
                    new XElement("brand", (int)air.Brand),
                    new XElement("color", air.Color),
                    new XElement("origin", air.CountryOfOrigin),
                    new XElement("typeOfSystem", air.TypeOfSystem),
                    new XElement("HasWiFi", air.HasWiFi));
            xmldoc.Root.Add(airCond);
            xmldoc.Save(@"C:\Users\Yoana\Desktop\Telerik-OOP-Team-StarFruit\TeamworkStarFruit\CatalogueLib\Data\ProductsData.xml");
        }

        public void AddProduct(Product product)
        {
            this.catalogueList.Add(product);
        }

        public Product GetProductByID(int id)
        {
            foreach (var product in this.catalogueList)
            {
                if (product.ID == id)
                {
                    return product;
                }
            }
            throw new ProductNotFoundException();
        }

        public void RemoveProduct(int id, Product product)
        {

            XElement emp = xmldoc.Descendants(product.GetType().Name)
                .FirstOrDefault(p => p.Element("id").Value == id.ToString());
            if (emp != null)
            {
                emp.Remove();
                xmldoc.Save(@"C:\Users\Yoana\Desktop\Telerik-OOP-Team-StarFruit\TeamworkStarFruit\CatalogueLib\Data\ProductsData.xml");
            }
        }



        /// <summary>
        /// Filter from a collection with different types specific one
        /// </summary>
        /// <param name="p">The type of the object to search in the collection</param>
        /// <returns>filtered collection</returns>
        public IEnumerable<Product> Show(Product p)
        {
            var bigAppliances = this.CatalogueList.Where(x => x.GetType().Equals(p.GetType()));
            return bigAppliances;
        }

        public void RemoveAll()
        {
            this.CatalogueList.Clear();
        }
    }
}
