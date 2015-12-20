using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Kyrsach.Models;

namespace Kyrsach.DAO
{
    public class ArticleDAO
    {
        private Database1Entities1 _entities = new Database1Entities1(); //создаем объект сущность-статьи

        public IEnumerable<Article> getAllArticles() // коллекция содержит список всех статей
        {
            return (from c in _entities.Articles select c); // LINQ запрос на вывод списка статей
        }

        public Test GetArticleTest(int? id) //метод возвращает комментарий по выбранной статье
        {
            if (id != null)
                return (from c in _entities.Tests where c.IdTest == id select c).FirstOrDefault();
            else
                return (from c in _entities.Tests select c).FirstOrDefault();
        }

        public bool addArticle(int idTest, Article article) // добавление комментария
        {
            try
            {
                article.Test = GetArticleTest(idTest);  // устанавливаем для комментария статью
                _entities.Articles.Add(article); //добавляем запись в объект сущность-комментарий
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