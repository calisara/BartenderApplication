using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BartenderApplication.Models;

namespace BartenderApplication.Repository
{
    public class FakeRepository
    {
        public List<DrinksModel> Drinks;
        public List<TicketsModel> Tickets;
        public List<User> Users;


        public FakeRepository()
        {
            Drinks = new List<DrinksModel>();
            Drinks.Add(new DrinksModel()
            {
                Id = Guid.NewGuid().ToString(),
                DrinkName = "Mojito",
                DrinkIngredients = "1 1/2 oz White rum1 oz Fresh lime juice, 2 teaspoons Sugar, 6 leaves of Mint, Soda Water",
                DrinkPrice = "$12.99"
            });

            Drinks.Add(new DrinksModel()
            {
                Id = Guid.NewGuid().ToString(),
                DrinkName = "Pina Colada",
                DrinkIngredients = "· 6 ounces pineapple juice · 3 ounces coconut cream coco real cream of coconut · 1 1/2 ounces light rum · 1-2 cups crushed ice",
                DrinkPrice = "$13.99"
            });


            Drinks.Add(new DrinksModel()
            {
                Id = Guid.NewGuid().ToString(),
                DrinkName = "Aperol Spritz",
                DrinkIngredients = "· Ice · 3 ounces (1 part) Aperol · 3 ounces (1 part) dry Prosecco · 1 ounce (a splash) club soda or unflavored sparkling water · Orange ",
                DrinkPrice = "$11.99"
            });


            Drinks.Add(new DrinksModel()
            {
                Id = Guid.NewGuid().ToString(),
                DrinkName = "Margarita",
                DrinkIngredients = "2 ounces blanco tequila · 1/2 ounce orange liqueur · 1 ounce lime juice, freshly squeezed · 1/2 ounce agave syrup ",
                DrinkPrice = "$14.99"
            });

            Tickets = new List<TicketsModel>();
            Tickets.Add(new TicketsModel()
            {
                Id = Guid.NewGuid().ToString(),
                Customer = "oltacali",
                Drink = "Mojito"

            });

            Tickets.Add(new TicketsModel()
            {
                Id = Guid.NewGuid().ToString(),
                Customer = "saracali",
                Drink = "Aperol Spritz"

            });

            Tickets.Add(new TicketsModel()
            {
                Id = Guid.NewGuid().ToString(),
                Customer = "manola",
                Drink = "Margarita"

            });

            Users = new List<User>();
            Users.Add(new User()
            {
                Username = "saracali",
                Password = "password",
                Roles = { "Employee" }
            });


            Users.Add(new User()
            {
                Username = "oltacali",
                Password = "password",
                Roles = { "Customer" }
            });

            Users.Add(new User()
            {
                Username = "manola",
                Password = "password",
                Roles = { "Customer" }
            });


        }
    }
}
