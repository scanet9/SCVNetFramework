﻿using System;
namespace CosmosApiBase.DataLayer.DataTransferObjects
{
    public class UpdateUserDto
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string Name { get; set; }
        public string Surnames { get; set; }
    }
}
