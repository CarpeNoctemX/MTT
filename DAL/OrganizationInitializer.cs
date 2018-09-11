using System;
using System.Collections.Generic;
using MTT.Models;
namespace MTT.DAL
{
    public class OrganizationInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<OrganizationContext>
    {
        protected override void Seed(OrganizationContext context)
        {
            var players = new List<Player>
 {
 new Player{FirstMidName="Gabriël",LastName="Rau",JoinDate=DateTime.Parse("2018-01-07")},
 new Player{FirstMidName="Paul",LastName="Boyer",JoinDate=DateTime.Parse("2016-12-01")},
 new Player{FirstMidName="Mads",LastName="Brock-Pedersen",JoinDate=DateTime.Parse("2017-02-06")},
 new Player{FirstMidName="Rasmus",LastName="Winther",JoinDate=DateTime.Parse("2016-12-01")},
 new Player{FirstMidName="Martin",LastName="Larsson",JoinDate=DateTime.Parse("2015-05-14")},
 new Player{FirstMidName="Zdravets",LastName="Iliev Galabov",JoinDate=DateTime.Parse("2017-12-14")},
 new Player{FirstMidName="Park",LastName="Kwon-hyuk",JoinDate=DateTime.Parse("2018-01-07")},
 new Player{FirstMidName="Lee",LastName="Sang-hyeok",JoinDate=DateTime.Parse("2014-11-23")}
            };
            players.ForEach(s => context.Players.Add(s));
            context.SaveChanges();
            var roles = new List<Role>
 {
 new Role{RoleID=1,Champion="Sion",KDA=9,},
 new Role{RoleID=2,Champion="Swain",KDA=4,},
 new Role{RoleID=3,Champion="Yasuo",KDA=3,},
 new Role{RoleID=4,Champion="Gangplank",KDA=4,},
 new Role{RoleID=5,Champion="Zoe",KDA=10,},
 };
            roles.ForEach(s => context.Roles.Add(s));
            context.SaveChanges();
            var teams = new List<Team>
 {
 new Team{PlayerID=1,RoleID=1,Rank=Rank.C},
 new Team{PlayerID=1,RoleID=2,Rank=Rank.C},
 new Team{PlayerID=1,RoleID=3,Rank=Rank.P},
 new Team{PlayerID=2,RoleID=1,Rank=Rank.C},
 new Team{PlayerID=2,RoleID=2,Rank=Rank.D},
 new Team{PlayerID=2,RoleID=3,Rank=Rank.D},
 new Team{PlayerID=3,RoleID=1},
 new Team{PlayerID=4,RoleID=2,},
 new Team{PlayerID=4,RoleID=1,Rank=Rank.C},
 new Team{PlayerID=5,RoleID=1,Rank=Rank.P},
 new Team{PlayerID=6,RoleID=1},
 new Team{PlayerID=7,RoleID=2,Rank=Rank.C},
 };
            teams.ForEach(s => context.Teams.Add(s));
            context.SaveChanges();
        }
    }
}