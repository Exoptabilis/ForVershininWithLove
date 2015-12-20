using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Kyrsach.Models;

namespace Kyrsach.DAO
{
    public class TestDAO
    {
        private Database1Entities1 _entities = new Database1Entities1(); //создаем объект сущность-тест
        private UsersContext _user = new UsersContext();

        public IEnumerable<Test> getAllTests() // коллекция содержит список всех статей
        {
            return (from c in _entities.Tests select c); // LINQ запрос на вывод списка
        }

        public bool addTest(Test test) // добавление теста
        {
            try
            {
                _entities.Tests.Add(test); //добавляем запись в объект сущность-тест
                _entities.SaveChanges(); // применяем изменение
            }
            catch
            {
                return false;
            }
            return true;
        }

        public Test getTest(int id) //получить тест по идентификатору
        {
            return (from c in _entities.Tests where c.IdTest == id select c).First();
        }

        public bool editTest(Test test) // обновление теста
        {
            Test originalTest = getTest(Convert.ToInt32(test.IdTest)); //сохраняем редактируемут тест во временную переменную
            try
            {
                _entities.Entry(originalTest).State = EntityState.Modified; // подтверждаем изменение
                _entities.SaveChanges(); // применяем изменение
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool deleteTest(Test test) //удаление теста
        {
            Test originalTest = getTest(Convert.ToInt32(test.IdTest)); //сохраняем удаляемый тест во временную переменную

            try
            {
                _entities.Tests.Remove(originalTest); //удаляем тест из сущности
                _entities.SaveChanges(); //применяем изменение
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}