﻿using L2dotNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2dotNET.Repositories.Contracts
{
    public interface IServerRepository
    {
        List<ServerModel> GetServerList();

        List<int> GetPlayersObjectIdList();
    }
}
