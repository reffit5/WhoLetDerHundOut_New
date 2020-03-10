using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WhoLetDerHundOut.Models;

namespace WhoLetDerHundOut.DAL
{
    public class DogInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DogContext>
    {
        protected override void Seed(DogContext context)
        {
            var user = new List<Users>
           {
               new Users{Name="John",Id=1,NumberofDogs=4,DogId=2},
               new Users{Name="Joe",Id=2,NumberofDogs=1,DogId=4},
               new Users{Name="Kim",Id=3,NumberofDogs=2,DogId=7},
               new Users{Name="Kathy",Id=4,NumberofDogs=4,DogId=9},
               new Users{Name="Jill",Id=5,NumberofDogs=0,DogId=0},
               new Users{Name="Art",Id=6,NumberofDogs=10,DogId=6},
               new Users{Name="Morgz",Id=7,NumberofDogs=2,DogId=3},
               new Users{Name="Alec",Id=8,NumberofDogs=1,DogId=1}
           };

            user.ForEach(u => context.User.Add(u));
            context.SaveChanges();

            var dogs = new List<Dog>
            {
                new Dog{UserId=4,nickName="Jupiter",Breed="Siberian Husky",BreedId=2},
                new Dog{UserId=3,nickName="Bannana",Breed="GoldenLab",BreedId=1},
                new Dog{UserId=1,nickName="Fido",Breed="Bernese Mountain",BreedId=3},
                new Dog{UserId=5,nickName="Stammpy",Breed="Austrailian Shepard",BreedId=4},
                new Dog{UserId=3,nickName="Princess",Breed="Rottweiler",BreedId=5},
                new Dog{UserId=6,nickName="Buddy",Breed="Beagle",BreedId=6},
                new Dog{UserId=7,nickName="Martin",Breed="Chow Chow",BreedId=7},
                new Dog{UserId=8,nickName="Walter",Breed="Great Dane",BreedId=8}
            };
            dogs.ForEach(d => context.Dogs.Add(d));
            context.SaveChanges();

            var breeds = new List<Breed>
            {
                new Breed{BreedName="Siberian Husky", Country="Siberia",Photo="~/Content/siberianHusky.jpg"},
                new Breed{BreedName="Golden Lab", Country="United Kingdom",Photo="~/Content/gooddog.jpg"},
                new Breed{BreedName="Bernese Mountain", Country="Switzerland",Photo="~/Content/Bernese.jpg"},
                new Breed{BreedName="Austrailian Shepard", Country="Australia",Photo="~/Content/Astralia.jpg"},
                new Breed{BreedName="Rottweiler", Country="Germany",Photo="~/Content/rot.jpg"},
                new Breed{BreedName="Beagle", Country="United Kingdom",Photo="~/Content/beaglel.jpg"},
                new Breed{BreedName="Chow Chow", Country="China",Photo="~/Content/chowchow.jpg"},
                new Breed{BreedName="Great Dane", Country="Germany",Photo="~/Content/Scooby.jpg"}

            };
            breeds.ForEach(b => context.Breeds.Add(b));
            context.SaveChanges();
        }

    }
}