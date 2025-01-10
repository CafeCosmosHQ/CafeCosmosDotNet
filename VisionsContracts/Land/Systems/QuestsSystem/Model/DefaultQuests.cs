using System;
using System.Collections.Generic;
using System.Text;

namespace VisionsContracts.Land.Systems.QuestsSystem.Model
{
    public static class DefaultQuests
    {
        public static List<Quest> GetAll()
        {
            return DefaultDailyQuests.GetAll();
        }
    }
}
