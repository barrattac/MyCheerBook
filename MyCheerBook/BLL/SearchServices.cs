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
            UserDAO dao = new UserDAO();
            List<string> wordList = SplitWords(words.ToLower());
            List<UserVM> results = new List<UserVM>();
            List<User> users = dao.GetAllUsers();
            for (int i = 0; i < wordList.Count; i++)
            {
                for(int j = 0; j < users.Count; j++)
                {
                    if (Contains(wordList[i], users[j].FirstName) || Contains(wordList[i], users[j].LastName) || Contains(wordList[i], users[j].Email))
                    {
                        results.Add(ConvertForSearch(users[j]));
                        users.RemoveAt(j);
                        j--;
                    }
                }
            }
            return results;
        }
        //Determines if first string is in second string
        private bool Contains(string part, string word)
        {
            if (word.ToLower() == part.ToLower())
            {
                return true;
            }
            if(word.Length > part.Length && word.ToLower().Contains(part.ToLower()))
            {
                return true;
            }
            return false;
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
        //Converts Users into a UserVM(ID = ID, FirstName = first name, LastName = ProfileImageLocation)
        private UserVM ConvertForSearch(User user)
        {
            ImageDAO dao = new ImageDAO();
            UserVM vm = new UserVM();
            vm.ID = user.ID;
            vm.FirstName = user.FirstName;
            vm.LastName = dao.GetProfileImage(user.ProfileImage).Location;
            return vm;
        }
    }
}