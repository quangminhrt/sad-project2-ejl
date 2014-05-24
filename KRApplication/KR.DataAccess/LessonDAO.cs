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
    }
}
