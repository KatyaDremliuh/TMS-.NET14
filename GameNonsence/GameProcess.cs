using System;
using System.Collections.Generic;
using System.Text;

namespace GameNonsence
{
    public class GameProcess
    {
        private List<string> _story = new();
        private List<string> _questions = new();
        private readonly List<string> _usersAnswers = new();

        public void FirstPlayer()
        {
            this._story = WritePartsOfStory();
            this._questions = WriteQuestions();
            AskUser();
        }

        public void SecondPlayer()
        {
            JoinUsersAnswersWithTheStory();
        }

        private List<string> WritePartsOfStory()
        {
            _story.Add("I am a ");
            _story.Add("and I hadn't been on vacation for ");
            _story.Add("years. So, that's why this ");
            _story.Add("I bought a ticket to ");
            _story.Add(". And went there by ");
            _story.Add("Every day I ");
            _story.Add("and ate for lunch ");
            _story.Add("delicious ");
            _story.Add("tangerines. My vacation lasted ");
            _story.Add("days. All this time my best friend was looking after my darling ");
            _story.Add("and watered my ");

            return _story;
        }

        private List<string> WriteQuestions()
        {
            _questions.Add("Profession?");
            _questions.Add("How many?");
            _questions.Add("Time of the year?");
            _questions.Add("Country?");
            _questions.Add("Type of transport?");
            _questions.Add("What were U doing?");
            _questions.Add("Color");
            _questions.Add("Geometric shape?");
            _questions.Add("How many?");
            _questions.Add("Animal?");
            _questions.Add("Plants (trees/flowers)?");

            return _questions;
        }

        private void AskUser()
        {
            foreach (string question in _questions)
            {
                Console.WriteLine(question);
                string userInput = Console.ReadLine();
                _usersAnswers.Add(userInput);
                Console.Clear();
            }
        }

        private void JoinUsersAnswersWithTheStory()
        {
            StringBuilder story = new();
            for (int i = 0; i < _story.Count; i++)
            {
                story.Append(_story[i]);
                story.Append("[" + _usersAnswers[i] + "]" + " \n");
            }

            Console.WriteLine(story.ToString());
        }
    }
}
