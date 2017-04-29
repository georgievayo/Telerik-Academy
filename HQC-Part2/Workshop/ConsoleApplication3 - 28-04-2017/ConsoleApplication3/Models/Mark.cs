using System;
using SchoolSystem.Models;

namespace SchoolSystem
{
    public class Mark : IMark
    {
        private float value;
        private Subject subject;

        public Mark(Subject subject, float value)
        {
            this.Subject = subject;
            this.Value = value;
        }

        public float Value
        {
            get
            {
                return this.value;
            }

            set
            {
                if (value < 2 || value > 6)
                {
                    throw new ArgumentException("Mark should be between 2 and 6!");
                }

                this.value = value;
            }
        }

        public Subject Subject
        {
            get
            {
                return this.subject;
            }

            set
            {
                if (value != Subject.Bulgarian && value != Subject.English && value != Subject.Math &&
                    value != Subject.Programming)
                {
                    throw new ArgumentException("Incorrect subject!");
                }

                this.subject = value;
            }
        }
    }
}
