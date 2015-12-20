
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
    public class CommentDAO
    {
        private Database1Entities1 _entities = new Database1Entities1(); //создаем объект сущность-комментарий

        public IEnumerable<Comment> getAllComments() // коллекция содержит список всех комментариев
        {
            return (from c in _entities.Comments select c); // LINQ запрос на вывод списка комментариев
        }

        public Article GetCommentArticle(int? id) //метод возвращает комментарий по выбранной статье
                {
                    if (id != null)
                        return (from c in _entities.Articles where c.IdArticle == id select c).FirstOrDefault();
                    else
                        return (from c in _entities.Articles select c).FirstOrDefault();
        }

        public Comment getComment(int id) //получить комментарий по идентификатору
        {
            return (from c in _entities.Comments.Include("Article") where c.IdComment == id select c).FirstOrDefault();
        }

        public IEnumerable<Comment> getCommentByArticle(int id)  //получить список комментариев по id статьи
        {
            return (from c in _entities.Comments.Include("Article") where c.idArticle == id select c);
        }

        public bool addComment(int idArticle, Comment comment) // добавление комментария
        {
            try
            {
                comment.Article = GetCommentArticle(idArticle);  // устанавливаем для комментария статью
                _entities.Comments.Add(comment); //добавляем запись в объект сущность-комментарий
                _entities.SaveChanges(); // применяем изменение
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool editComment(int idArticle, Comment comment) // обновление комментария
        {
 
            try
            {
                _entities.Entry(comment).State = EntityState.Modified; // подтверждаем изменение
                _entities.SaveChanges(); // применяем изменение
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool deleteComment(int id) //удаление комментария
        {
            Comment comment = selectComment(id); //сохраняем удаляемый комментарий во временную переменную
            try
            {
                _entities.Comments.Remove(comment); //удаляем комментарии из сущности
                _entities.SaveChanges(); //применяем изменение
            }
            catch
            {
                return false;
            }
            return true;
        }

        public Comment selectComment(int id)
        {
            return (_entities.Comments.Find(id));
        }
    }
}