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
    public class ArticleDAO
    {
        private Database1Entities1 _entities = new Database1Entities1(); //создаем объект сущность-статьи

        public IEnumerable<Article> getAllArticles() // коллекция содержит список всех статей
        {
            return (from c in _entities.Articles select c); // LINQ запрос на вывод списка статей
        }


        public bool addArticle(Article article) // добавление статьи
        {
            try
            {   
                _entities.Articles.Add(article); //добавляем запись в объект сущность-статьи
                _entities.SaveChanges(); // применяем изменение
            }
            catch
            {
                return false;
            }
            return true;
        }

        public Article getArticle(int id) //получить статью по идентификатору
        {
            return (from c in _entities.Articles where c.IdArticle == id select c).FirstOrDefault();
        }

        public bool editArticle(Article article) // обновление статьи
        {
            Article originalArticle = getArticle(Convert.ToInt32(article.IdArticle)); //сохраняем редактируемую статью во временную переменную
            try
            {
              
                _entities.Entry(originalArticle).State = EntityState.Modified; // подтверждаем изменение
                _entities.SaveChanges(); // применяем изменение
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool deleteArticle(Article article) //удаление статьи
        {
            Article originalArticle = getArticle(Convert.ToInt32(article.IdArticle)); //сохраняем удаляемую статью во временную переменную

            try
            {
                _entities.Articles.Remove(originalArticle); //удаляем статью из сущности
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