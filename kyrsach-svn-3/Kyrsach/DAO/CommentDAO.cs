using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Kyrsach.Models;

namespace Kyrsach.DAO
{
    public class CommentDAO
    {
        private Database1Entities1 _entities = new Database1Entities1(); //создаем объект сущность-статьи

        public IEnumerable<Comment> getAllComents() // коллекция содержит список всех статей
        {
            return (from c in _entities.Comments select c); // LINQ запрос на вывод списка статей
        }

        public Test GetCommentTest(int? id) //метод возвращает комментарий по выбранной статье
        {
            if (id != null)
                return (from c in _entities.Tests where c.IdTest == id select c).FirstOrDefault();
            else
                return (from c in _entities.Tests select c).FirstOrDefault();
        }

        public bool addComment(int idTest, string user, Comment comment) // добавление комментария
        {
            try
            {
                comment.UserName = user;  // устанавливаем для комментария статью
                comment.Test = GetCommentTest(idTest);  // устанавливаем для комментария статью
                _entities.Comments.Add(comment); //добавляем запись в объект сущность-комментарий
                _entities.SaveChanges(); // применяем изменение
            }
            catch
            {
                return false;
            }
            return true;
        }

        public Comment getComment(int id) //получить статью по идентификатору
        {
            return (from c in _entities.Comments where c.IdComment == id select c).FirstOrDefault();
        }

        public bool deleteComment(Comment comment) //удаление статьи
        {
            Comment originalComment = getComment(Convert.ToInt32(comment.IdComment)); //сохраняем удаляемую статью во временную переменную

            try
            {
                _entities.Comments.Remove(originalComment); //удаляем статью из сущности
                _entities.SaveChanges(); //применяем изменение
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool editComment(Comment Comment) // обновление теста
        {
            Comment originalComment = getComment(Convert.ToInt32(Comment.IdComment)); //сохраняем редактируемут тест во временную переменную
            try
            {
                _entities.Entry(originalComment).State = EntityState.Modified; // подтверждаем изменение
                _entities.SaveChanges(); // применяем изменение
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}