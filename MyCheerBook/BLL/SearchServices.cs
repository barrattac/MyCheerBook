using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class SearchServices
    {
        //Searchs for users
        public List<UserVM> SearchUsers(string words)
        {
            List<string> wordList = SplitWords(words);
            if (wordList != null)
            {
                return SearchUsers(wordList);
            }
            return null;
        }
        //Searchs for team
        public List<string> SearchTeams(string words)
        {
            List<string> wordList = SplitWords(words);
            if (wordList != null)
            {
                return SearchTeams(wordList);
            }
            return null;
        }
        //Takes a string of words and returns a list of words
        private List<string> SplitWords(string words)
        {
            List<string> wordList = new List<string>();
            string word = "";
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] != Convert.ToChar(" "))
                {
                    word = word + words[i];
                }
                else
                {
                    if (word != "")
                    {
                        wordList.Add(word);
                        word = "";
                    }
                }
            }
            if (word != "")
            {
                wordList.Add(word);
            }
            return wordList;
        }
        //Search through users
        private List<UserVM> SearchUsers(List<string> wordList)
        {
            UserDAO dao = new UserDAO();
            List<List<User>> results = new List<List<User>>();
            foreach (string word in wordList)
            {
                results.Add(dao.SearchUsers("%" + word + "%"));
            }
            return ConvertData(results);
        }
        //Search through teams
        private List<string> SearchTeams(List<string> wordList)
        {
            TeamDAO dao = new TeamDAO();
            List<List<Teams>> results = new List<List<Teams>>();
            foreach (string word in wordList)
            {
                results.Add(dao.SearchTeams("%" + word + "%"));
            }
            return ConvertData(results);
        }
        //Converts Users into a UserVM(FirstName = first name and LastName = ProfileImageLocation)
        private List<UserVM> ConvertData(List<List<User>> users)
        {
            ImageDAO dao = new ImageDAO();
            List<UserVM> results = new List<UserVM>();
            for(int i = 0; i < users.Count; i++)
            {
                for(int j = 0; j < users[i].Count; j++)
                {
                    UserVM vm = new UserVM();
                    vm.ID = users[i][j].ID;
                    vm.FirstName = users[i][j].FirstName;
                    vm.LastName = dao.GetProfileImage(users[i][j].ProfileImage).Location;
                    results.Add(vm);
                }
            }
            return results;
        }
        //Converts Teams into a string list
        private List<string> ConvertData(List<List<Teams>> teams)
        {
            List<string> results = new List<string>();
            foreach (List<Teams> list in teams)
            {
                foreach (Teams team in list)
                {
                    results.Add(team.TeamName);
                }
            }
            return results;
        }
    }
}