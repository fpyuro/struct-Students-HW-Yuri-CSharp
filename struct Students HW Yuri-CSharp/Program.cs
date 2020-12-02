using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region условие
//Создайте структуру с именем student, содержащую поля: фамилия и инициалы, номер группы, успеваемость (массив из пяти элементов).
//Создать массив из десяти элементов такого типа, упорядочить записи по возрастанию среднего балла. 
//Добавить возможность вывода фамилий и номеров групп студентов, имеющих оценки, равные только 4 или 5.
#endregion

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
        public string getSurnameIO() => SurnameIO;
        public int getNumberOfGroup() => numberOfGroup;
        public double getAverageAcademicPerformance()
        {
            double sumOfRatings = 0; //сумма оценок
            int numberOfRatings = 0; //количество оценок
            for (int i = 0; i < academicPerformance.Length; ++i)
            {
                sumOfRatings += academicPerformance[i];
                numberOfRatings++;
            }
            return sumOfRatings / numberOfRatings;
        }
        //проверка на отсутствие у студента двоек и троек
        public bool check45()
        {
            bool check = true;
            for(int i =0; i < academicPerformance.Length; ++i)
            {
                if (academicPerformance[i] < 4) check = false;
            }
            return check;
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
        private static Random rand = new Random(); 
        //метод заполнения всего массива студентов случайными студентами
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
            int newNumberOfGroup = rand.Next(3) + 1; //1-3
            string newSurnameIO = surname[rand.Next(surname.Length)] + " " + name[rand.Next(name.Length)][0] + "." + middlename[rand.Next(middlename.Length)][0] + ".";
            int[] newAcademicPerformance = { rand.Next(4) + 2, rand.Next(4) + 2, rand.Next(4) + 2, rand.Next(4) + 2, rand.Next(4) + 2 }; //случайные оценки от 2 до 5 
            for (int i = 0; i < stdnts.Length; ++i)
            {
                if (stdnts[i].getSurnameIO() == null)
                {
                    stdnts[i] = new student(newSurnameIO, newNumberOfGroup, newAcademicPerformance);
                    break;
                }
            }
        }
        //показывает весь массив студентов
        public void ShowAll()
        {
            for(int i = 0; i< stdnts.Length; ++i)
                Console.WriteLine(stdnts[i].getSurnameIO() + "\tСредний балл студента: " + stdnts[i].getAverageAcademicPerformance());
            Console.WriteLine();
        }
        //сортировка по средней успеваемости
        public void sortByMiddleAcademicPerformance()
        {
            double[] averagePerformance = new double[stdnts.Length];
            for(int i =0; i < stdnts.Length; ++i)
            {
                averagePerformance[i] = stdnts[i].getAverageAcademicPerformance();
            }
            Array.Sort(averagePerformance, stdnts);
        }
        //показывает студентов отличников и ударников
        public void Show45()
        {
            Console.WriteLine("Студенты имеющие четверки и пятерки:\n");
            for(int i =0; i<stdnts.Length; ++i)
            {
                if(stdnts[i].check45())
                    Console.WriteLine("Группа номер: " + stdnts[i].getNumberOfGroup() + " - " + stdnts[i].getSurnameIO());
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Students group1 = new Students(100); //по условию 10, но на 100 элементов больше шансов случайного создания ударников и отличников
            Console.WriteLine("\nОбщий не сортированный список студентов:\n");
            group1.ShowAll();
            group1.sortByMiddleAcademicPerformance();
            Console.WriteLine("Общий отсортированный список студентов:\n");
            group1.ShowAll();
            group1.Show45();
            Console.ReadLine();
        }
    }
}
