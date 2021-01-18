using System;
using System.Collections.Generic;
using System.Text;

namespace Suitcase
{

    public abstract class AnimalHandler
    {
        public AnimalHandler Successor { get; set; }
        public string AnimalName;
        public string Voice;
        public int MassOfFoodPerDay;
        public IAnimalState State;
        public bool CellStatus = false;
        //    public bool Predation;
        //    public bool Aggressiveness;
        //    public string NecessaryClimate;

        public AnimalHandler(string name, string voice, int food)
        {
            this.AnimalName = name;
            this.Voice = voice;
            this.MassOfFoodPerDay = food;
        }

        public abstract void Handle();

        public void WakeUp(AnimalHandler animal)
        {
            this.State.WakeUp(animal);
        }

        public void FallAsleep()
        {
            this.State.FallAsleep(this);
        }

        public  string GiveAnswer()
        {
            return this.State.GiveAnsver(this);
        }
    }


    public class LandAnimal : AnimalHandler
    {
        public int NecessaryArea;
        public string TypeOfTerritory;

        public LandAnimal(string name, string voice, int food, int area, string territory)
            : base(name, voice, food)
        {
            this.NecessaryArea = area;
            this.TypeOfTerritory = territory;
            this.State = new SleepState();
        }
        public override void Handle()
        {
            if (this.State.GetType() == typeof(SleepState))
            {
                this.State.WakeUp(this);
            }
            else
            {
                this.State.FallAsleep(this);
            }
            if (Successor != null)
            {
                Successor.Handle();
            }
        }

    }

    public class Waterfowl : AnimalHandler
    {
        public int NecessaryVolume;
        public string TypeOfWater;
        public Waterfowl(string name, string voice, int food, int volume, string water)
    : base(name, voice, food)
        {
            this.NecessaryVolume = volume;
            this.TypeOfWater = water;
            this.State = new SleepState();
        }
        public override void Handle()
        {
            if (this.State.GetType() == typeof(SleepState))
            {
                this.State.WakeUp(this);
            }
            else
            {
                this.State.FallAsleep(this);
            }
            if (Successor != null)
            {
                Successor.Handle();
            }
        }

    }

    public interface IAnimalState
    {
        void WakeUp(AnimalHandler animal);
        void FallAsleep(AnimalHandler animal);

        string GiveAnsver(AnimalHandler animal);
    }

    public class SleepState : IAnimalState
    {
        public void WakeUp(AnimalHandler animal)
        {
            animal.State = new AwekeState();
        }

        public void FallAsleep(AnimalHandler animal)
        {

        }

        public string GiveAnsver(AnimalHandler animal)
        {
            return animal.AnimalName + " is sleeping";
        }
    }

    public class AwekeState : IAnimalState
    {
        public void WakeUp(AnimalHandler animal)
        {

        }

        public void FallAsleep(AnimalHandler animal)
        {
            animal.State = new SleepState();
        }

        public string GiveAnsver(AnimalHandler animal)
        {
            return animal.Voice;
        }
    }
}
