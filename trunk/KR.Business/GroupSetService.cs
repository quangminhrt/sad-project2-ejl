using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KR.DataAccess;

namespace KR.Business
{
    public class GroupSetService
    {
        public static List<GroupSet> GetAll()
        {
            return GroupSetDAO.GetAll();
        }


        public static bool AddGroup(GroupSet gro)
        {
            return GroupSetDAO.AddGroup(gro);
        }


        public static bool UpdateGroup(GroupSet gro)
        {
            return GroupSetDAO.UpdateGroup(gro);
        }


        public static bool RemoveGroup(GroupSet gro)
        {
            return GroupSetDAO.RemoveGroup(gro);
        }


        public static GroupSet GetGroupByID(int id)
        {
            return GroupSetDAO.GetGroupByID(id);
        }


        public static GroupSet GetGroupByName(string name)
        {
            return GroupSetDAO.GetGroupByName(name);
        }


        public static List<GroupSet> GetGroupsStartsName(string name)
        {
            return GroupSetDAO.GetGroupsStartsName(name);
        }


        public static List<GroupSet> GetGroupsContainsName(string name)
        {
            return GroupSetDAO.GetGroupsContainsName(name);
        }


        public static List<GroupSet> GetGroupsOnTop(int amount)
        {
            return GroupSetDAO.GetGroupsOnTop(amount);
        }


        public static List<GroupSet> GetGroupsSkipAmount(int skipAmount, int takeAmount)
        {
            return GetGroupsSkipAmount(skipAmount, takeAmount);
        }


        public static GroupSet GetPreviousGroup(int currentGroupID)
        {
            return GroupSetDAO.GetPreviousGroup(currentGroupID);
        }


        public static GroupSet GetNextGroup(int currentGroupID)
        {
            return GroupSetDAO.GetNextGroup(currentGroupID);
        }


        public static GroupSet GetRandomGroup()
        {
            return GroupSetDAO.GetRandomGroup();
        }
    }
}
