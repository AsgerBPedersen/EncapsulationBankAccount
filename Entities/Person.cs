using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Entities
{
    public abstract class Person : Entity
    {
        protected string firstname;
        protected string lastname;
        protected string ssn;

        protected Person(string ssn, string lastname, string firstname)
        {
            Ssn = ssn;
            Lastname = lastname;
            Firstname = firstname;
        }

        protected Person(int id, string ssn, string lastname, string firstname) : base(id)
        {
            Ssn = ssn;
            Lastname = lastname;
            Firstname = firstname;
        }

    public string Ssn
        {
            get { return ssn; }
            set {
                if (!ValidateSsn(value))
                {
                    throw new ArgumentException("wrong ssn format");
                } else
                {
                    ssn = value;
                }
            }
        }

        public string Lastname
        {
            get { return lastname; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name can't be empty");
                }
                else if (!ValidateName(value))
                {
                    throw new ArgumentException("wrong format");
                }
                else
                {
                   lastname = value;
                }
            }
        }

        public string Firstname
        {
            get { return firstname; }
            set {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name can't be empty");
                } else if(!ValidateName(value))
                {
                    throw new ArgumentException("wrong format");
                } else
                {
                    firstname = value;
                }
            }
        }

        public static bool ValidateName(string name)
        {
           return Regex.Match(name, @"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$").Success;
        }

        public static bool ValidateSsn(string ssn)
        {
            return Regex.Match(ssn, @"^[0-3][0-9][0-1][1-9]\d{2}-\d{4}?[^0-9]*$").Success;
        }

    }
}
