﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work6._6
{
    struct Worker
    {
        /// <summary>
        /// Конструктор структуры "Рабочий"
        /// </summary>
        /// <param name="ID">ID</param>
        /// <param name="EntryDate">Дата создания записи</param>
        /// <param name="FullName">ФИО</param>
        /// <param name="Age">Возраст</param>
        /// <param name="DateOfBirth">Дата рождения</param>
        /// <param name="PlaceOfBirth">Место рождения</param>
        public Worker (int ID, DateTime EntryDate, string FullName, int Age, DateTime DateOfBirth, string PlaceOfBirth)
        {
            this.id = ID;
            this.entryDate = EntryDate;
            this.fullName = FullName;
            this.age = Age;
            this.dateOfBirth = DateOfBirth;
            this.placeOfBirth = PlaceOfBirth;
        }

        public Worker(string FullName, int Age, DateTime DateOfBirth, string PlaceOfBirth) :
            this(0, DateTime.Now, FullName, Age, DateOfBirth, PlaceOfBirth)  
        {

        }

        #region Поля

        public int id;

        public DateTime entryDate;

        public string fullName;

        public int age;

        public DateTime dateOfBirth;

        public string placeOfBirth;

        #endregion

        #region Свойства

        /// <summary>
        /// ID сотрудника
        /// </summary>
        public int ID { get { return this.id; } set { this.id = value; } }
        /// <summary>
        /// Дата создания записи
        /// </summary>
        public DateTime EntryDate { get { return this.entryDate; } set { this.entryDate = value; } }
        /// <summary>
        /// ФИО
        /// </summary>
        public string FullName { get { return this.fullName; } set { this.fullName = value; } }
        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get { return this.age; } set { this.age = value; } }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime DateOfBirth { get { return this.dateOfBirth; } set { this.dateOfBirth= value; } }
        /// <summary>
        /// Место рождения
        /// </summary>
        public string PlaceOfBirth { get { return this.placeOfBirth; } set { this.placeOfBirth = value;  } }

        #endregion
    }
}











