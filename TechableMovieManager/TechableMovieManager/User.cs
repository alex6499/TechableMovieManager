﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechableMovieManager
{
    public class User
    {
        private bool admin;
        private int userId;
        private string userName;
        private string firstName;
        private string lastName;

        public User(bool isAdmin, string userName, string firstName, string lastName, int userId)
        {
            this.admin = isAdmin;
            this.userId = userId;
            this.userName = userName.Trim();
            this.firstName = firstName.Trim();
            this.lastName = lastName.Trim();
        }

        public bool isAdmin()
        {
            return admin;
        }

        public string getUserName()
        {
            return userName;
        }

        public int getUserId()
        {
            return userId;
        }

        public string getFirstName()
        {
            return firstName;
        }

        public string getLastName()
        {
            return lastName;
        }
    }
}