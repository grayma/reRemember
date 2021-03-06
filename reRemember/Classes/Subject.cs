﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace reRemember.Classes
{
    [Serializable]
    public class Subject
    {
        //constructors
        public Subject()
        {
            Title = "";
            ChildSubjects = new List<Subject>();
            PastStudySessions = new List<StudySession>();
            Cards = new List<Card>();
        }
        public Subject(string title)
        {
            this.Title = title;
            ChildSubjects = new List<Subject>();
            PastStudySessions = new List<StudySession>();
            Cards = new List<Card>();
        }
        public Subject(string title, List<Subject> childSubjects, List<Card> cards)
        {
            this.Title = title;
            this.ChildSubjects = childSubjects;
            this.Cards = cards;
        }

        //properties (fields done separately in case modifcations/checks need to be made)
        public string Title { get; set; }
        public List<Subject> ChildSubjects { get; set; }
        public List<StudySession> PastStudySessions { get; set; }
        public List<Card> Cards { get; set; }
        public bool HasChildSubjects
        {
            get
            {
                return this.ChildSubjects.Count > 0;
            }
        }
    }

    [Serializable]
    public class RootSubject : Subject
    {
        //constructors
        public RootSubject() : base() { } //needed for serialization
        public RootSubject(string title) : base(title) { }
        public RootSubject(string title, List<Subject> childSubjects, List<Card> cards)
            : base(title, childSubjects, cards)
        {

        }

        /// <summary>
        /// Function to save an instantiated root subject.
        /// </summary>
        /// <param name="filePath">The file path to save to.</param>
        /// <returns>Boolean value showing whether or not saving was a success.</returns>
        public bool Save(string filePath)
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(RootSubject));
                StreamWriter writer = new StreamWriter(stream);
                serializer.Serialize(writer, this);
                writer.Close();
            }
            return true;
        }

        /// <summary>
        /// Static function to open a root subject and return said RootSubject.
        /// </summary>
        /// <param name="filePath">The file path to open from.</param>
        /// <returns>Root subject that was opened.</returns>
        public static RootSubject Open(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(RootSubject));
            using (StreamReader reader = new StreamReader(filePath))
            {
                RootSubject returnSubject = (RootSubject)serializer.Deserialize(reader);
                return returnSubject;
            }
        }
    }
}
