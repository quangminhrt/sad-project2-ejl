using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KR.DataAccess
{
    public class LessonDAO
    {
        public static List<string> GetAllLessonName()
        {
            using (KRDatabaseEntities db = new KRDatabaseEntities())
            {
                List<string> list = new List<string>();
                try
                {
                    list = (from l in db.Lesson
                            orderby l.Name ascending
                            select l.Name).ToList();
                }
                catch (Exception)
                {

                }
                return list;
            }
        }
        public static List<Lesson> GetAll()
        {
            using (KRDatabaseEntities db = new KRDatabaseEntities())
            {
                List<Lesson> list = new List<Lesson>();
                try
                {
                    list = (from l in db.Lesson
                            orderby l.Name ascending
                            select l).ToList();
                }
                catch (Exception)
                {

                }
                return list;
            }
        }

        public static Lesson GetLessonByName(string name)
        {
            using (KRDatabaseEntities db = new KRDatabaseEntities())
            {
                Lesson lesson = new Lesson();
                try
                {
                    lesson = (from l in db.Lesson
                              where l.Name == name
                              select l).FirstOrDefault();
                }
                catch (Exception)
                {

                }
                return lesson;
            }
        }


        public static Lesson GetLessonByID(int id)
        {
            using (KRDatabaseEntities db = new KRDatabaseEntities())
            {
                Lesson lesson = new Lesson();
                try
                {
                    lesson = (from l in db.Lesson
                              where l.ID == id
                              select l).FirstOrDefault();
                }
                catch (Exception)
                {

                }
                return lesson;
            }
        }
    }
}
