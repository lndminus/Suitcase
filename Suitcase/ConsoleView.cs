using System;
using System.Collections.Generic;
using System.Text;

namespace Suitcase
{
    public class ConsoleView
    {
        public AnimalSetter AnimalSetter;
        private string AnimalName;
        private string CellName;
        public ConsoleView(AnimalSetter setter)
        {
            this.AnimalSetter = setter;
        }

        public void Continue()
        {
            Console.WriteLine("\nВозможные действия:" +
                "\n1.Изменить время" +
                "\n2.Запросить голос у всех животных" +
                "\n3.Запросить голос у одного животного" +
                "\n4.Добавить случайное животное" +
                "\n5.Добавить животное в чемодан" +
                "\n6.Вывести данные про еду животных в чемодане" +
                "\n");
            switch (Console.ReadLine())
            {
                case "1":
                    this.TimeToNight();
                    this.Continue();
                    break;
                case "2":
                    this.GetAllAnimalVoices();
                    this.Continue();
                    break;
                case "3":
                    this.GetAnimalVoice();
                    this.Continue();
                    break;
                case "4":
                  //  this.AnimalSetter.GetAllVoices();
                    this.Continue();
                    break;
                case "5":
                    this.SetAnimalIntoSuitcase();
                    this.Continue();
                    break;
                case "6":
                    this.ShowFoodPerDay();
                    this.Continue();
                    break;
                default:
                    Console.WriteLine("неизвестная команда");
                    this.Continue();
                    break;
            }
        }



        public void TimeToNight()
        {
            this.AnimalSetter.ChangeTime();
        }

        public void GetAllAnimalVoices()
        {
            this.AnimalSetter.GetAllVoices();
            foreach (string voice in this.AnimalSetter.AllVoices)
            {
                Console.WriteLine(voice);
            }
        }

        public void GetAnimalVoice()
        {
            Console.WriteLine("Укажите имя животного, чей голос хотите получить" +
            "\nСписок имён животных:");
            this.ShowAllNamesOfAnimalsInCells();
            Console.WriteLine(this.AnimalSetter.GetVoice(Console.ReadLine()));
        }

        public void SetAnimalIntoSuitcase()
        {
            Console.WriteLine("Укажите имя животного, которого хотите добавить в чемодан" +
            "\nСписок имён незаселенных животных:");
            this.ShowAllNamesOfAnimal();
            this.AnimalName = Console.ReadLine();
            if (this.AnimalSetter.FindAnimalByName(this.AnimalName))
            {
                this.AnimalSetter.IterateCells(this.AnimalSetter.Animal, this.AnimalSetter.AllCells);
            }
            
            Console.WriteLine("Укажите название места, куда хотите заселить животное" +
            "\nСписок названий подходящих мест:");
            foreach (Cell cell in this.AnimalSetter.TrueCells)
            {
                Console.WriteLine(cell.NameOfCell);
            }
            this.CellName = Console.ReadLine();
            if (this.AnimalSetter.SetAnimalIntoCellByNames(this.AnimalName, this.CellName))
            {
                Console.WriteLine("Животное "+ this.AnimalName + " успешно добавлено в "+ this.CellName);
            }
            else
            {
                Console.WriteLine("false");
            }

        }

        public void ShowFoodPerDay()
        {
            Console.WriteLine("Необходимая еда для животных в чемодане - "+ this.AnimalSetter.CalculateFoodWeight() + 
                            "\nСредний вес еды для одного животного - "+ this.AnimalSetter.CalculateMiddleFoodWeight());
        }
    
        public void ShowAllNamesOfAnimal()
        {
            foreach (string name in this.AnimalSetter.GetAnimalNames())
            {
                Console.WriteLine(name);
            }
        }

        public void ShowAllNamesOfAnimalsInCells()
        {
            foreach (string name in this.AnimalSetter.GetAnimalNamesFromCells())
            {
                Console.WriteLine(name);
            }
        }
    }
}
