namespace MTT.Migrations
{
    using MTT.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    internal sealed class Configuration : DbMigrationsConfiguration<MTT.DAL.OrganizationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        protected override void Seed(DAL.OrganizationContext context)
        {
            var players = new List<Player>
{
 new Player{FirstMidName="Gabriel",LastName="Rau",JoinDate=DateTime.Parse("2018-01-07")},
 new Player{FirstMidName="Paul",LastName="Boyer",JoinDate=DateTime.Parse("2016-12-01")},
 new Player{FirstMidName="Mads",LastName="Brock-Pedersen",JoinDate=DateTime.Parse("2017-02-06")},
 new Player{FirstMidName="Rasmus",LastName="Winther",JoinDate=DateTime.Parse("2016-12-01")},
 new Player{FirstMidName="Martin",LastName="Larsson",JoinDate=DateTime.Parse("2015-05-14")},
 new Player{FirstMidName="Zdravets",LastName="Iliev Galabov",JoinDate=DateTime.Parse("2017-12-14")},
 new Player{FirstMidName="Park",LastName="Kwon-hyuk",JoinDate=DateTime.Parse("2018-01-07")},
 new Player{FirstMidName="Lee",LastName="Sang-hyeok",JoinDate=DateTime.Parse("2014-11-23")}
};
            players.ForEach(s => context.Players.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var coaches = new List<Coach>
            {
                new Coach { FirstMidName = "Alvar ",     LastName = "Alenar",HireDate = DateTime.Parse("2016-03-11") },
                new Coach { FirstMidName = "Dylan ",    LastName = "Falco",HireDate = DateTime.Parse("2017-07-06") },
                new Coach { FirstMidName = "Urszula ",   LastName = "Klimczak",HireDate = DateTime.Parse("2017-07-01") },
                new Coach { FirstMidName = "Wai ", LastName = "Lau ",HireDate = DateTime.Parse("2016-01-15") },
                new Coach { FirstMidName = "Nicholas ",   LastName = "Korsgaard",HireDate = DateTime.Parse("2018-02-12") }
            };
            coaches.ForEach(s => context.Coaches.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var regions = new List<Region>
            {
                new Region { Name = "EUW",     Budget = 350000,StartDate = DateTime.Parse("2007-09-01"),
                    CoachID  = coaches.Single( i => i.LastName == "Falco").ID },
                new Region { Name = "EUW", Budget = 100000,StartDate = DateTime.Parse("2007-09-01"),
                    CoachID  = coaches.Single( i => i.LastName == "Korsgaard").ID },
                new Region { Name = "EUW", Budget = 350000,StartDate = DateTime.Parse("2007-09-01"),
                    CoachID  = coaches.Single( i => i.LastName == "Alenar").ID },
                new Region { Name = "EUW",   Budget = 100000,StartDate = DateTime.Parse("2007-09-01"),
                    CoachID  = coaches.Single( i => i.LastName == "Klimczak").ID }
            };
            regions.ForEach(s => context.Regions.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var roles = new List<Role>
{
 new Role{RoleID=1,Champion="Sion",KDA=9,RegionID = regions.Single( s => s.Name == "EUW").RegionID,
                  Coaches = new List<Coach>()
 },
 new Role{RoleID=2,Champion="Swain",KDA=4,RegionID = regions.Single( s => s.Name == "EUW").RegionID,
                  Coaches = new List<Coach>()
 },
 new Role{RoleID=3,Champion="Yasuo",KDA=3,RegionID = regions.Single( s => s.Name == "EUW").RegionID,
                  Coaches = new List<Coach>()
 },
 new Role{RoleID=4,Champion="Gangplank",KDA=4,RegionID = regions.Single( s => s.Name == "EUW").RegionID,
                  Coaches = new List<Coach>()
 },
 new Role{RoleID=5,Champion="Zoe",KDA=10,RegionID = regions.Single( s => s.Name == "EUW").RegionID,
                  Coaches = new List<Coach>()
 },
};
            roles.ForEach(s => context.Roles.AddOrUpdate(p => p.Champion, s));
            context.SaveChanges();
            var teams = new List<Team>
            {
new Team {PlayerID = players.Single(s => s.LastName == "Martin").ID,RoleID = roles.Single(c => c.Champion == "Sion" ).RoleID,Rank = Rank.D
},
new Team {PlayerID = players.Single(s => s.LastName == "Martin").ID,RoleID = roles.Single(c => c.Champion == "Swain" ).RoleID,Rank=Rank.C
},
new Team {PlayerID = players.Single(s => s.LastName == "Martin").ID,RoleID = roles.Single(c => c.Champion == "Yasuo" ).RoleID,Rank = Rank.B
},
new Team {PlayerID = players.Single(s => s.LastName == "Zdravets").ID,RoleID = roles.Single(c => c.Champion == "Yasuo" ).RoleID,Rank = Rank.B
},
new Team {PlayerID = players.Single(s => s.LastName == "Zdravets").ID,RoleID = roles.Single(c => c.Champion == "Zoe" ).RoleID,Rank = Rank.B
},
new Team {PlayerID = players.Single(s => s.LastName == "Zdravets").ID,RoleID = roles.Single(c => c.Champion == "Gangplank" ).RoleID,Rank = Rank.B
},
new Team {PlayerID = players.Single(s => s.LastName == "Park").ID,RoleID = roles.Single(c => c.Champion == "Sion" ).RoleID
},
new Team {PlayerID = players.Single(s => s.LastName == "Park").ID,RoleID = roles.Single(c => c.Champion == "Zoe").RoleID,Rank = Rank.B
},
new Team {PlayerID = players.Single(s => s.LastName == "Rasmus").ID,RoleID = roles.Single(c => c.Champion == "Sion").RoleID,Rank = Rank.B
},
new Team {PlayerID = players.Single(s => s.LastName == "Lee").ID,RoleID = roles.Single(c => c.Champion == "Gangplank").RoleID,Rank = Rank.B
},
new Team {PlayerID = players.Single(s => s.LastName == "Paul").ID,RoleID = roles.Single(c => c.Champion == "Yasuo").RoleID,Rank = Rank.B
}
};
            foreach (Team e in teams)
            {
                var teamInDataBase = context.Teams.Where(
                s =>
                s.Player.ID == e.PlayerID &&
                s.Role.RoleID == e.RoleID).SingleOrDefault();
                if (teamInDataBase == null)
                {
                    context.Teams.Add(e);
                }
            }
            context.SaveChanges();
        }

        void AddOrUpdateCoach(DAL.OrganizationContext context, string roleChampion, string coachName)
        {
            var rl = context.Roles.SingleOrDefault(c => c.Champion == roleChampion);
            var inst = rl.Coaches.SingleOrDefault(i => i.LastName == coachName);
            if (inst == null)
                rl.Coaches.Add(context.Coaches.Single(i => i.LastName == coachName));
        }
}

}