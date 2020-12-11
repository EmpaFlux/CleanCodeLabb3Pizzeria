﻿using System;
using System.Collections.Generic;
using System.Text;
using CleanCodeLabb3_Pizzeria.Models.Toppings;

namespace CleanCodeLabb3_Pizzeria.Models.Pizza
{
    public abstract class Pizza
    {
        private string _name;
        private double _price;
        private List<Topping> _standardToppings = new List<Topping>() { new TomatoSauce(), new Tomato() };
        private List<Topping> _extraToppings = new List<Topping>();

        public string Name { get => _name; set => _name = value; }
        public double Price { get => _price; set => _price = value; }
        public List<Topping> StandardToppings { get => _standardToppings; }
        public List<Topping> ExtraToppings { get => _extraToppings; }
        public string PriceToString()
        {
            return Price.ToString("#.##");
        }
    }
}