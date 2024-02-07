using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksBoard.Models.Contracts;

namespace TasksBoard.Models
{
    internal class Comment : IComment
    {
        string comment;
        string author;
        public Comment(string content, string author)
        {
            Content= content;
            Author = author;
        }

        public string Content
        {
            get { return comment; }
            set {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Comment Content cannot be null");

                comment = value;
            }
        }
        public string Author
        {
            get { return author; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Comment author cannot be null");

                author = value;
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(Content);
            sb.AppendLine("From: " + Author);
            return sb.ToString();
        }
    }
}
