using System;

namespace Methods
{
    class Student : IPerson
    {
        private DateTime birthDate;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherInfo { get; set; }

        public DateTime BirthDate
        {
            get
            {
                return this.birthDate;
            }
            private set
            {
                this.birthDate = DateTime.Parse(this.OtherInfo.Substring(this.OtherInfo.Length - 10));
            }
        }

        public bool IsOlderThan(IPerson other)
        {
            bool isOlder = this.BirthDate > other.BirthDate;
            return isOlder;
        }
    }
}
