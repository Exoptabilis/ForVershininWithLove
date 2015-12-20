using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Data.EntityModel;
using System.Data;
using System.Data.Objects;
using System.Data.SqlClient;
using Kyrsach.Models;
using Kyrsach.DAO;

namespace Kyrsach.DAO
{
    public class ComplainDAO
    {
        private Database1Entities1 _entities = new Database1Entities1(); //создаем объект сущность-жалобы

        public IEnumerable<Complain> getAllComplains() // коллекция содержит список всех жалоб
        {
            return (from c in _entities.Complains select c); // LINQ запрос на вывод списка жалоб
        }

        public Article GetComplainArticle(int? id) //метод возвращает жалобу по выбранной статье
                {
                    if (id != null)
                        return (from c in _entities.Articles where c.IdArticle == id select c).FirstOrDefault();
                    else
                        return (from c in _entities.Articles select c).FirstOrDefault();
        }

        public Complain getComplain (int id) //получить жалобу по идентификатору
        {
            return (from c in _entities.Complains.Include("Article") where c.IdComplain == id select c).FirstOrDefault();
        }

        public IEnumerable<Complain> getComplainByArticle(int id)  //получить список жалоб по id статьи
        {
            return (from c in _entities.Complains.Include("Article") where c.idArticle == id select c);
        }

        public bool addComplain(int idArticle, Complain complain) // добавление жалобы
        {
            try
            {
                 complain.Article = GetComplainArticle(idArticle);  // устанавливаем для жалобы статью
                _entities.Complains.Add(complain); //добавляем запись в объект сущность-жалобы
                _entities.SaveChanges(); // применяем изменение
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool editComplain(int idArticle, Complain complain) // обновление жалобы
        {
            try
            {
               _entities.Entry(complain).State = EntityState.Modified; // подтверждаем изменение
               _entities.SaveChanges(); // применяем изменение
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool deleteComplain(int id) //удаление жалобы
        {
            Complain complain = selectComplain(id); //сохраняем удаляемую жалобу во временную переменную

            try
            {
                _entities.Complains.Remove(complain); //удаляем жалобы из сущности
                _entities.SaveChanges(); //применяем изменение
            }
            catch
            {
                return false;
            }
            return true;
        }
        public Complain selectComplain(int id)
        {
            return (_entities.Complains.Find(id));
        }
    }
}