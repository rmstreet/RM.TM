
namespace TM.DomainTests.Utilities
{
    using Bogus;
    using System;
    using System.Collections.Generic;
    using TM.Domain.Entities;

    public class DataGenerator
    {
        public static List<Team> Teams(int quantity = 2, bool withAcronyms = true)
        {
            var teamsOf2017BrazilianChampionship = new List<Tuple<string, string>>()
                        {
                            new Tuple<string, string>("ATG", "Atlético Goianiense"),
                            new Tuple<string, string>("CAM", "Atlético Mineiro"),
                            new Tuple<string, string>("CAP", "Atlético Paranaense"),
                            new Tuple<string, string>("AVA", "Avaí"),
                            new Tuple<string, string>("BAH", "Bahia"),
                            new Tuple<string, string>("BOT", "Botafogo"),
                            new Tuple<string, string>("CHA", "Chapecoense"),
                            new Tuple<string, string>("COR", "Corinthians"),
                            new Tuple<string, string>("CFC", "Coritiba"),
                            new Tuple<string, string>("CRU", "Cruzeiro"),
                            new Tuple<string, string>("FLA", "Flamengo"),
                            new Tuple<string, string>("FLU", "Fluminense"),
                            new Tuple<string, string>("GRE", "Grêmio"),
                            new Tuple<string, string>("PAL", "Palmeiras"),
                            new Tuple<string, string>("PON", "Ponte Preta"),
                            new Tuple<string, string>("SAN", "Santos"),
                            new Tuple<string, string>("SPO", "São Paulo"),
                            new Tuple<string, string>("SPT", "Sport"),
                            new Tuple<string, string>("VAS", "Vasco da Gama"),
                            new Tuple<string, string>("VIT", "Vitória")
                        };
            int qtdTeams = teamsOf2017BrazilianChampionship.Count;

            return new Faker<Team>("pt-BR")
                .CustomInstantiator
                (
                    f => 
                    {                        
                        int indexRandom = f.Random.Number(0, qtdTeams - 1);
                        var team = teamsOf2017BrazilianChampionship[indexRandom];
                        return new Team(team.Item2)
                                    .SetAcronyms(team.Item1);
                    }
                )
                .Generate((qtdTeams - quantity)>0 ? quantity : qtdTeams);
        }
    }
}
