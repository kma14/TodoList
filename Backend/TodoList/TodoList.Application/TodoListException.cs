﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Application
{
    public class ItemAlreadyExistException:Exception
    {
        public ItemAlreadyExistException(string message):base(message) { 
        }
    }
}
