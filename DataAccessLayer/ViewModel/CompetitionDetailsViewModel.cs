﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CompetitionDetailsViewModel : LayoutViewModel
    {
        public List<Competitions> CompetitonDetails { get; set; }
        public List<CompetitionsTeams> CompetitionTeams { get; set; }
        public List<Images> ListImages { get; set; }
        public List<Competitions> CompetitonEditions { get; set; }
        public List<CompetitionsCategory> competitionsCategory { get; set; }

    }
}
