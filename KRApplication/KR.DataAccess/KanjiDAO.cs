using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KR.DataAccess
{
    public class KanjiDAO
    {
        public static List<Kanji> GetKanjisByLevel(string level)
        {
            using (KRDatabaseEntities db = new KRDatabaseEntities())
            {
                List<Kanji> list = new List<Kanji>();
                try
                {
                    list = (from k in db.Kanji
                            orderby k.ID ascending
                            where k.Level == level
                            select k).ToList();
                }
                catch (Exception)
                {

                }
                return list;
            }
        }


        public static List<Kanji> GetKanjisByLike()
        {
            using (KRDatabaseEntities db = new KRDatabaseEntities())
            {
                List<Kanji> list = new List<Kanji>();
                try
                {
                    list = (from k in db.Kanji
                            orderby k.ID ascending
                            where k.IsLiked == true
                            select k).ToList();
                }
                catch (Exception)
                {

                }
                return list;
            }
        }
    }
}
