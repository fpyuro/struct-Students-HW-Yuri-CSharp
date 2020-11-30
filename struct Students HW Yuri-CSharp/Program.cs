using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace struct_Students_HW_Yuri_CSharp
{
    struct student
    {
        string SurnameIO; //фамилия и инициалы
        int numberOfGroup; //номер группы
        int[] academicPerformance; //успеваемость (массив из пяти элементов)
        public student(string SurnameIO, int numberOfGroup, int[] academicPerformance)
        {
            this.SurnameIO = SurnameIO;
            this.numberOfGroup = numberOfGroup;
            this.academicPerformance = academicPerformance;
        }
        public string getSurnameIO()
        {
            return SurnameIO;
        }
    }
    class Students
    {
        private student[] stdnts; //массив студентов
        public Students(int size)
        { 
            stdnts = new student[size];
            for(int i =0; i<size; ++i)
            {
                this.Add();
            }
        } 
        public void Add()
        {
            string[] name = { "Юрий", "Терентий", "Олег", "Никанор", "Матвей", "Арсений", "Никита", "Аскольд",
                "Святослав", "Александр", "Фома", "Тимур", "Трофим", "Бронислав", "Родион", "Эмиль", "Чеслав",
                "Клавдий", "Вацлав", "Бронислав" };
            string[] surname = { "Гунин", "Ибрагимов", "Горностаев", "Рутберг", "Клоков", 
                "Ручкин", "Голованов", "Бореев", "Колобков", "Мячиков", "Челомцев", "Мизенов", 
                "Яночкин", "Рудников", "Мальцов", "Никоненко", "Смышляев", "Набоков", "Петрухин", "Бармыкин" };
            string[] middlename = { "Матвеевич", "Георгиевич", "Измаилович", "Елисеевич", "Потапович", "Эрнестович",
                "Моисеевич", "Мартьянович", "Никанорович", "Данилевич", "Прохорович", "Ипатиевич", "Феликсович",
                "Дмитриевич", "Викентиевич", "Пахомович", "Семенович", "Измаилович", "Дмитриевич", "Герасимович" };
            DateTime moment = DateTime.Now;
            var rand = new Random((int)moment.Ticks);
            int newNumberOfGroup = rand.Next(3) + 1; //1-3
            string newSurnameIO = surname[rand.Next(surname.Length)] + " " + name[rand.Next(name.Length)][0] + "." + middlename[rand.Next(middlename.Length)][0] + ".";
            int[] newAcademicPerformance = { rand.Next(5) + 1, rand.Next(5) + 1, rand.Next(5) + 1, rand.Next(5) + 1, rand.Next(5) + 1 };
            for (int i = 0; i < stdnts.Length; ++i)
            {
                if (stdnts[i].getSurnameIO() == null)
                {
                    stdnts[i] = new student(newSurnameIO, newNumberOfGroup, newAcademicPerformance);
                    break;
                }
            }
        }
        public void Show()
        {
            for(int i = 0; i< stdnts.Length; ++i)
                Console.WriteLine(stdnts[i].getSurnameIO());
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Students group1 = new Students(3);

            group1.Show();
            Console.ReadLine();
        }
    }
}
