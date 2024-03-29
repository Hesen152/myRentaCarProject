﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
   public static class Messages
    {
        public static string Added = "Added";
        public static string Updated = "Uptaded";
        public static string Deleted = "Deleted!";
        public static string Listed = "Listed!";
        public static string NotFound = "NotFOund!";
        public static string InvalidDailyPrice = "The daily price of the car must be greater than 0.";
        public static string InvalidBrandName = "Car name must be min 2 characters.";
        public static string NullDate = "The car has not been delivered";
        public static string CarLimitedDenied = "Cart Images less than 5";
        public static string AuthorizationDenied="Authorization Denied";
    }
}
