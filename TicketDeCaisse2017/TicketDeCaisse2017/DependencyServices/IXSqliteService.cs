﻿using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketDeCaisse2017.DependencyServices
{
    public interface IXSqliteService
    {
        SQLiteAsyncConnection GetAsyncConnection();
    }
}