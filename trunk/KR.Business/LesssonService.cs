using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KR.DataAccess;

namespace KR.Business
{
    public class LesssonService
    {
        public static List<string> GetAllLessonName()
        {
            return LessonDAO.GetAllLessonName();
        }
    }
}
