using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksBoard.Models.Enums;
using TasksBoard.Models.Contracts;

namespace TaskBoard.Models
{
    public class Feedback : Task, IFeedback
    {
        private const FeedbackStatus FinalStatus = FeedbackStatus.Done;
        private const FeedbackStatus InitialStatus = FeedbackStatus.New;
        private const int MinRatingValue = 1;
        private const int MaxRatingValue = 10;
        private int rating;
        public Feedback(string title, string description, int rating) : base(title, description)
        {
            Rating = rating;
            Status = FeedbackStatus.New;
        }

        public int Rating
        {
            get { return rating; } 
            private set 
            {
                if (value < 1)
                {
                    throw new InvalidOperationException("Rating cannot be 0 or negative"); //todo, this could be more specific (Tomi)
                }
                rating = value;
            } 
        }
        public FeedbackStatus Status { get; private set; }

        public void AdvanceStatus()
        {
            if (Status == FinalStatus)
                throw new InvalidOperationException($"Status is already {FinalStatus}");
            Status++;
        }
        public void RevertStatus()
        {
            if (Status == InitialStatus)
                throw new InvalidOperationException($"Status is already {InitialStatus}");
            Status--;
        }

        public void ChangeRating(int targetRating)
        {
            if (Rating == targetRating)
                throw new InvalidOperationException($"Rating is already {Rating}");
            if (targetRating < 1 || targetRating > 10)
                throw new InvalidOperationException($"Rating must be between {MinRatingValue} and {MaxRatingValue}");
            Rating = targetRating;
        }        
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("--Feedback--");
            sb.Append(base.ToString());
            sb.AppendLine($"Rating: {Rating}");
            return sb.ToString();
        }
    }
}
