﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MovieTickets.Setting
{
    public class CustomPasswordValidator : IIdentityValidator<string>
    {
        public int RequiredLength { get; set; } // минимальная длина
        public CustomPasswordValidator(int length)
        {
            RequiredLength = length;
        }
        public Task<IdentityResult> ValidateAsync(string item)
        {
            if (String.IsNullOrEmpty(item) || item.Length < RequiredLength)
            {
                return Task.FromResult(IdentityResult.Failed(
                                String.Format("Минимальная длина пароля равна {0}", RequiredLength)));
            }
            string pattern = "^[0-9]+$";

            if (!Regex.IsMatch(item, pattern))
            {
                return Task.FromResult(IdentityResult.Failed("Пароль должен состоять только из цифр"));
            }

            return Task.FromResult(IdentityResult.Success);
        }
    }
}