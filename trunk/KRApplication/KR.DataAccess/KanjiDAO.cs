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


        public static bool UpdateLikedKanji(int id, bool isLiked)
        {
            using (KRDatabaseEntities db = new KRDatabaseEntities())
            {
                bool result = false;
                try
                {
                    var group = (from k in db.Kanji
                                 where k.ID == id
                                 select k).FirstOrDefault();
                    group.IsLiked = isLiked;
                    db.SaveChanges();
                    result = true;
                }
                catch (Exception)
                {

                }
                return result;
            }
        }
    }
}
