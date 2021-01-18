using System;
using System.Collections.Generic;

namespace Suitcase
{
    public class Program
    {
        static void Main(string[] args)
        {


            LandAnimal landanimalanimal1 = new LandAnimal("name1", "voice1", 10, 100, "forest");
            LandAnimal landanimalanimal2 = new LandAnimal("name2", "voice2", 15, 100, "steppe");
            LandAnimal landanimalanimal3 = new LandAnimal("name3", "voice3", 5, 100, "steppe");
            LandAnimal Demiguise = new LandAnimal("Комуф", "voice3", 3, 100, "steppe");
            LandAnimal Occamy = new LandAnimal("Оккам", "voice3", 12, 100, "steppe");
            LandAnimal Bowtruckle = new LandAnimal("Лічур", "voice4", 1, 50, "forest");
            Waterfowl waterfowl1 = new Waterfowl("name4", "voice4", 2, 300, "salt");
            Waterfowl waterfowl2 = new Waterfowl("name5", "voice5", 2, 400, "salt");
            Waterfowl waterfowl3 = new Waterfowl("name6", "voice6", 1, 100, "fresh");

            landanimalanimal1.Successor = landanimalanimal2;
            landanimalanimal2.Successor = landanimalanimal3;
            landanimalanimal3.Successor = waterfowl1;
            waterfowl1.Successor = waterfowl2;
            waterfowl2.Successor = waterfowl3;


            Area suitcase = new Area("suitcase", "forest");
            Area area1 = new Area("area1", "steppe");
            Area area2 = new Area("area2", "forest");
            Aviary aviary1 = new Aviary("aviary1", "forest", 100);
            Aviary aviary2 = new Aviary("aviary2", "steppe", 200);
            Aviary aviary3 = new Aviary("aviary3", "steppe", 100);
            WaterZone waterzone1 = new WaterZone("waterzone1", "salt", 500);
            WaterZone waterzone2 = new WaterZone("waterzone2", "fresh", 300);
            WaterZone waterzone3 = new WaterZone("waterzone3", "fresh", 400);


            area2.Add(aviary3);
            area2.Add(waterzone3);
            area1.Add(area2);
            area1.Add(aviary2);
            area1.Add(waterzone2);
            suitcase.Add(area1);
            suitcase.Add(aviary1);
            suitcase.Add(waterzone1);


            AnimalSetter animalsetter = new AnimalSetter();
            //animalsetter.AllCells = new List<Cell>();
            animalsetter.AllCells.Add(suitcase);
            animalsetter.AllCells.Add(area1);
            animalsetter.AllCells.Add(area2);
            animalsetter.AllCells.Add(aviary1);
            animalsetter.AllCells.Add(aviary2);
            animalsetter.AllCells.Add(aviary3);
            animalsetter.AllCells.Add(waterzone1);
            animalsetter.AllCells.Add(waterzone2);
            animalsetter.AllCells.Add(waterzone3);



            animalsetter.AllAnimals = new List<AnimalHandler>();
            animalsetter.AllAnimals.Add(landanimalanimal1);
            animalsetter.AllAnimals.Add(landanimalanimal2);
            animalsetter.AllAnimals.Add(landanimalanimal3);
            animalsetter.AllAnimals.Add(waterfowl1);
            animalsetter.AllAnimals.Add(waterfowl2);
            animalsetter.AllAnimals.Add(waterfowl3);
            
            foreach(AnimalHandler an in animalsetter.AllAnimals)
            {
                animalsetter.AnimalsWithoutCells.Add(an);
            }

        //    animalsetter.ChangeTimeToNight();

           // animalsetter.GetAllVoices();

            ConsoleView view = new ConsoleView(animalsetter);
            view.Continue();
        }
    }
}
