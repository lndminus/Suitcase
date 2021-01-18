using System;
using System.Collections.Generic;
using System.Text;

namespace Suitcase
{
    public class AnimalSetter
    {
     //   private Cell Suitcase;
        public List<AnimalHandler> AllAnimals = new List<AnimalHandler>();
        public List<AnimalHandler> AnimalsWithoutCells = new List<AnimalHandler>();
        public List<Cell> AllCells = new List<Cell>();
        public List<Cell> TrueCells = new List<Cell>();
        public int FoodWeight;
        public double MidleWeightOfFood;

        private Area Area;
        private Aviary Aviary;
        private WaterZone WaterZone;
        private Cell Cell;

        private LandAnimal LandAnimal;
        private Waterfowl Waterfowl;
        public AnimalHandler Animal;

        private string Answer;
        private string AnName;
        private string CellName;
        public List<string> AllVoices;

        public AnimalSetter()
        {
        }

        public void ChangeTime()
        {
            this.AllAnimals[0].Handle();
            
        }
        /*
        public void ChangeTimeToMorning()
        {
            foreach (AnimalHandler animal in this.AllAnimals)
            {
                animal.WakeUp(animal);
            }
        }*/

        private void SetAnimalIntoCell(AnimalHandler animal, Cell cell)
        {
            cell.Animals.Add(animal);
            animal.CellStatus = true;
        }

        public bool SetAnimalIntoCellByNames(string animalname, string cellname)
        {
            if (this.FindAnimalByName(animalname))
            {
                if (this.FindCellByName(cellname))
                {
                    this.SetAnimalIntoCell(this.Animal, this.Cell);
                    this.AnimalsWithoutCells.Remove(this.Animal);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void ChooseCell(AnimalHandler animal, Cell cell)
        {
            if (animal.GetType() == typeof(Waterfowl))
                {
                this.Waterfowl = (Waterfowl)animal;
                if(cell.GetType() == typeof(WaterZone))
                    {
                    this.WaterZone = (WaterZone)cell;
                    if(this.Waterfowl.TypeOfWater == this.WaterZone.TypeOfWater && this.Waterfowl.NecessaryVolume <= this.WaterZone.Volume)
                    {
                        this.TrueCells.Add(cell);
                    }
                }
            }
            else if (animal.GetType() == typeof(LandAnimal))
            {
                this.LandAnimal = (LandAnimal)animal;
                if (cell.GetType() == typeof(Aviary))
                {
                    this.Aviary = (Aviary)cell;
                    if (this.LandAnimal.TypeOfTerritory == this.Aviary.TypeOfTerritory && this.LandAnimal.NecessaryArea <= this.Aviary.Area)
                    {
                        this.TrueCells.Add(cell);
                    }
                }
                else if (cell.GetType() == typeof(Area))
                {
                    this.Area = (Area)cell;
                    if (this.LandAnimal.TypeOfTerritory == this.Area.TypeOfTerritory)
                    {
                        this.TrueCells.Add(cell);
                    }
                }
            }
        }

        public void IterateCells(AnimalHandler animal, List<Cell> cells)
        {
            this.TrueCells = new List<Cell>();
            foreach(Cell cell in cells)
            {
                this.ChooseCell(animal, cell);
            }
        }

        public string GetVoice(string name)
        {
            this.Answer = "error";
            foreach (Cell cell in this.AllCells)
            {
                foreach (AnimalHandler animal in cell.Animals)
                {
                    if (animal.AnimalName == name)
                    {
                        this.Answer = animal.Voice;
                    }
                }
            }
            return this.Answer;
        }

        public List<string> GetAllVoices()
        {
            this.AllVoices = new List<string>();
            foreach (Cell cell in this.AllCells)
            {
                foreach (AnimalHandler animal in cell.Animals)
                {
                    this.AllVoices.Add(animal.GiveAnswer());
                }
            }
            return this.AllVoices;


            this.AllVoices = new List<string>();

            foreach (AnimalHandler animal in this.AllAnimals)
            {
                this.AllVoices.Add(animal.GiveAnswer());
            }

            return this.AllVoices;
        }

        public List<string> GetAnimalNamesFromCells()
        {
            this.AllVoices = new List<string>();
            foreach (Cell cell in this.AllCells)
            {
                foreach (AnimalHandler animal in cell.Animals)
                {
                    this.AllVoices.Add(animal.AnimalName);
                }
            }
            return this.AllVoices;
        }

        public List<string> GetAnimalNames()
        {
            this.AllVoices = new List<string>();

            foreach (AnimalHandler animal in this.AnimalsWithoutCells)
            {
                this.AllVoices.Add(animal.AnimalName);
            }

            return this.AllVoices;
        }

        public int CalculateFoodWeight()
        {
            this.FoodWeight = 0;
            foreach (Cell cell in this.AllCells)
            {
                foreach(AnimalHandler animal in cell.Animals)
                {
                    this.FoodWeight = this.FoodWeight + animal.MassOfFoodPerDay;
                }
            }
            return this.FoodWeight;
        }

        public double CalculateMiddleFoodWeight()
        {
            this.MidleWeightOfFood = 0;
            double num = 0;
            foreach (Cell cell in this.AllCells)
            {
                num = num + cell.Animals.Count;
            }
            if (num == 0)
            {
                return 0;
            }
            else
            {
                this.MidleWeightOfFood = this.CalculateFoodWeight() / num;
                return this.MidleWeightOfFood;
            }

        }
     
        public bool FindAnimalByName(string name)
        {
            foreach (AnimalHandler animal in this.AnimalsWithoutCells)
            {
                if (animal.AnimalName == name)
                {
                    this.Animal = animal;

                    return true;
                }
            }
            return false;
        }

        private bool FindCellByName(string name)
        {
            foreach (Cell cell in this.AllCells)
            {
                if (cell.NameOfCell == name)
                {
                    this.Cell = cell;
                    return true;
                }
            }
            return false;
        }
    }
}
