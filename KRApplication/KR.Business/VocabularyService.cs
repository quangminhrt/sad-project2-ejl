using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KR.DataAccess;

namespace KR.Business
{
    public class VocabularyService
    {
        public static List<Vocabulary> GetVocabularyByLessonID(int lessonID)
        {
            return VocabularyDAO.GetVocabularyByLessonID(lessonID);
        }
    }
}
