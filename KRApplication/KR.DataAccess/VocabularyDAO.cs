using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KR.DataAccess
{
    public class VocabularyDAO
    {
        public static List<Vocabulary> GetVocabularyByLessonID(int lessonID)
        {
            using (KRDatabaseEntities db = new KRDatabaseEntities())
            {
                List<Vocabulary> list = new List<Vocabulary>();
                try
                {
                    list = (from v in db.Vocabulary
                            orderby v.ID ascending
                            where v.LessonID == lessonID
                            select v).ToList();
                }
                catch (Exception)
                {

                }
                return list;
            }
        }
    }
}
