using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KR.DataAccess
{
    public class GroupSetDAO
    {

        /* GET ALL GROUPS
         */
        public static List<GroupSet> GetAll()
        {
            using (KRDatabaseEntities db = new KRDatabaseEntities())
            {
                List<GroupSet> list = new List<GroupSet>();
                try
                {
                    list = (from g in db.GroupSet
                            //orderby g.Name ascending
                            orderby g.Name descending
                            select g).ToList();
                }
                catch (Exception)
                {

                }
                return list;
            }
        }


        /* ADD A GROUP
         */
        public static bool AddGroup(GroupSet gro)
        {
            using (KRDatabaseEntities db = new KRDatabaseEntities())
            {
                bool result = false;
                try
                {
                    db.GroupSet.Add(gro);
                    db.SaveChanges();
                    result = true;
                }
                catch (Exception)
                {

                }
                return result;
            }
        }


        /* UPDATE A GROUP
         */
        public static bool UpdateGroup(GroupSet gro)
        {
            using (KRDatabaseEntities db = new KRDatabaseEntities())
            {
                bool result = false;
                try
                {
                    var group = (from g in db.GroupSet
                                 where g.ID == gro.ID
                                 select g).FirstOrDefault();
                    group.ID = gro.ID;
                    group.Name = gro.Name;
                    group.Meaning = gro.Meaning;
                    group.Description = gro.Description;
                    db.SaveChanges();
                    result = true;
                }
                catch (Exception)
                {

                }
                return result;
            }
        }


        /* REMOVE A GROUP
         */
        public static bool RemoveGroup(GroupSet gro)
        {
            using (KRDatabaseEntities db = new KRDatabaseEntities())
            {
                bool result = false;
                try
                {
                    var group = (from g in db.GroupSet
                                 where g.ID == gro.ID
                                 select g).FirstOrDefault();
                    db.GroupSet.Remove(group);
                    db.SaveChanges();
                    result = true;
                }
                catch (Exception)
                {

                }
                return result;
            }
        }


        /* GET A GROUP BY ID
         */
        public static GroupSet GetGroupByID(int id)
        {
            using (KRDatabaseEntities db = new KRDatabaseEntities())
            {
                GroupSet group = new GroupSet();
                try
                {
                    group = (from g in db.GroupSet
                             where g.ID == id
                             select g).FirstOrDefault();
                }
                catch (Exception)
                {

                }
                return group;
            }
        }


        /* GET A GROUP BY NAME
         */
        public static GroupSet GetGroupByName(string name)
        {
            using (KRDatabaseEntities db = new KRDatabaseEntities())
            {
                GroupSet group = new GroupSet();
                try
                {
                    group = (from g in db.GroupSet
                             where g.Name == name
                             select g).FirstOrDefault();
                }
                catch (Exception)
                {

                }
                return group;
            }
        }


        /* GET GROUPS WITH STARTED STRING
         * trả về danh sách những group có Name bắt đầu với chuỗi tìm kiếm
         */
        public static List<GroupSet> GetGroupsStartsName(string name)
        {
            using (KRDatabaseEntities db = new KRDatabaseEntities())
            {
                List<GroupSet> list = new List<GroupSet>();
                try
                {
                    list = (from g in db.GroupSet
                            orderby g.ID ascending
                            where g.Name.StartsWith(name)
                            select g).ToList();
                }
                catch (Exception)
                {

                }
                return list;
            }
        }


        /* GET GROUPS WITH CONTAINED STRING
         * trả về 1 danh sách những group có Name chứa chuỗi tìm kiếm
         */
        public static List<GroupSet> GetGroupsContainsName(string name)
        {
            using (KRDatabaseEntities db = new KRDatabaseEntities())
            {
                List<GroupSet> list = new List<GroupSet>();
                try
                {
                    list = (from g in db.GroupSet
                            orderby g.ID ascending
                            where g.Name.Contains(name)
                            select g).ToList();
                }
                catch (Exception)
                {

                }
                return list;
            }
        }


        /* GET N GROUPS ON TOP
         * trả về danh sách những group ở trên cùng
         */
        public static List<GroupSet> GetGroupsOnTop(int amount)
        {
            using (KRDatabaseEntities db = new KRDatabaseEntities())
            {
                List<GroupSet> list = new List<GroupSet>();
                try
                {
                    list = (from g in db.GroupSet
                            orderby g.ID ascending
                            select g).Take(amount).ToList();
                }
                catch (Exception)
                {

                }
                return list;
            }
        }


        /* GET N GROUPS SKIP M GROUPS
         * trả về danh sách những group ở 1 khoảng xác định
         */
        public static List<GroupSet> GetGroupsSkipAmount(int skipAmount, int takeAmount)
        {
            using (KRDatabaseEntities db = new KRDatabaseEntities())
            {
                List<GroupSet> list = new List<GroupSet>();
                try
                {
                    list = (from g in db.GroupSet
                            orderby g.ID ascending
                            select g).Skip(skipAmount).Take(takeAmount).ToList();
                }
                catch (Exception)
                {

                }
                return list;
            }
        }


        /* GET A PREVIOUS GROUP BASED ON CURRENT CURRENT GROUP ID
         * trả về 1 group nằm kế trước group được xác định bằng ID
         */
        public static GroupSet GetPreviousGroup(int currentGroupID)
        {
            using (KRDatabaseEntities db = new KRDatabaseEntities())
            {
                GroupSet group = new GroupSet();
                try
                {
                    group = (from g in db.GroupSet
                             where g.ID < currentGroupID
                             select g).FirstOrDefault();
                }
                catch (Exception)
                {

                }
                return group;
            }
        }


        /* GET A NEXT GROUP BASED ON CURRENT CURRENT GROUP ID
         * trả về 1 group nằm kế sau group được xác định bằng ID
         */
        public static GroupSet GetNextGroup(int currentGroupID)
        {
            using (KRDatabaseEntities db = new KRDatabaseEntities())
            {
                GroupSet group = new GroupSet();
                try
                {
                    group = (from g in db.GroupSet
                             where g.ID > currentGroupID
                             select g).FirstOrDefault();
                }
                catch (Exception)
                {

                }
                return group;
            }
        }


        /* GET A RANDOM GROUP (RANDOM ROW)
         * trả về 1 group ngẫu nhiên, không phụ thuộc vào ID
         */
        public static GroupSet GetRandomGroup()
        {
            using (KRDatabaseEntities db = new KRDatabaseEntities())
            {
                GroupSet group = new GroupSet();
                try
                {
                    group = (from g in db.GroupSet
                             orderby Guid.NewGuid()
                             select g).FirstOrDefault();
                }
                catch (Exception)
                {

                }
                return group;
            }
        }
    }
}
