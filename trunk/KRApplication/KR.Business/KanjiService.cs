using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KR.DataAccess;

namespace KR.Business
{
    public class KanjiService
    {
        public static List<Kanji> GetKanjisByLevel(string level)
        {
            return GetKanjisByLevel(level);
        }


        public static bool UpdateLikedKanji(int id, bool isLiked)
        {
            return UpdateLikedKanji(id, isLiked);
        }
    }
}
